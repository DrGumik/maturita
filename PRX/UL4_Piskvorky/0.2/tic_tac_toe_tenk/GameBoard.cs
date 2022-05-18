using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tic_tac_toe_tenk.Enums;

namespace tic_tac_toe_tenk
{
    public partial class GameBoard : UserControl
    {
        #region Private Variables
        private int boardSize = 30; // Velikost hrací plochy po ose X (30 čtverečků)
        private int fieldSize = 21; // Velikost jednoho políčka (21x21)
        private int nmbToWin = 4; // Počet shodných znaků pro výhru
        private int boardSizeY = 19; // Velikost hrací plochy po ose Y (20 čtverečků)

        private Color colorX = Color.FromArgb(255, 255, 77, 77); // Nastavení per
        private Pen penX;

        private Color colorO = Color.FromArgb(255, 71, 209, 71);
        private Pen penO;

        private GameField[,] gameFieldsBoard; // Definování herního pole
        private GameState gameState = GameState.NotPlayed; // Definování statusu hry (hraje se / nehraje se)

        private GameField currentPlayer = GameField.O; // Urcuje kdo prave hraje

        private int gameType = 0; // Typ hry - PvP / PvA

        #endregion

        #region Public Varibles
        public Pen PenX
        {
            get
            {
                if (penX == null)
                    penX = new Pen(colorX, 4);
                return penX;
            }
        }

        public Pen PenO
        {
            get
            {
                if (penO == null)
                    penO = new Pen(colorO, 4);
                return penO;
            }
        }

        public int BoardSize 
        { 
            get { return boardSize; } 
            set 
            { 
                boardSize = value;
                Refresh();
            } 
        }

        public int NmbToWin
        {
            get { return nmbToWin; }
            set
            {
                nmbToWin = value;
                Refresh();
            }
        }

        public GameField CurrentPlayer
        {
            get { return currentPlayer;  }
        }

        public int GameType
        {
            get { return gameType; }
            set
            {
                gameType = value;
            }
        }

        #endregion

        public GameBoard()
        {
            InitializeComponent();
        }

        public void PrepareGameFieldBoard()
        {

            gameFieldsBoard = new GameField[boardSize, boardSize];
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    gameFieldsBoard[x, y] = GameField.NotOccupied;
                }
            }

            gameState = GameState.Played;
        }

        private void GenerateBoard(Graphics graphics)
        {
            // Vygenerovani herni plochy
            Pen pen = new Pen(Color.White);

            for (int i=0; i <= boardSize; i++)
            {
                graphics.DrawLine(pen, 0, i * fieldSize, boardSize * fieldSize, i * fieldSize);
                graphics.DrawLine(pen, i * fieldSize, 0, i * fieldSize, boardSize * fieldSize);
            }
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            // Zavolani funkce k vygenerovani henri plochy
            GenerateBoard(e.Graphics);
        }

        private void DrawIntoBoardFields(int x, int y)
        {
            // Vykreslovani hernich kamenu X nebo O
            using(Graphics graphics = this.CreateGraphics()) { 
                if (gameFieldsBoard[x, y] == GameField.X)
                {
                    graphics.DrawLine(PenX, x * fieldSize + 2, y * fieldSize + 2, x * fieldSize + fieldSize - 2, y * fieldSize + fieldSize - 2);
                    graphics.DrawLine(PenX, x * fieldSize + 2, y * fieldSize + fieldSize - 2, x * fieldSize + fieldSize - 2, y * fieldSize + 2);
                }
                else if (gameFieldsBoard[x, y] == GameField.O)
                {
                    graphics.DrawEllipse(PenO, x * fieldSize + 2, y * fieldSize + 2, fieldSize - 4, fieldSize - 4);
                }
            }
        }

        private bool CheckWinner(int numberOfFieldRows)
        {
            // Zjisteni zda ma hrac co prave hral vyhral
            if (numberOfFieldRows == nmbToWin)
            {
                MessageBox.Show("Winner is: " + currentPlayer);

                gameState = GameState.NotPlayed;
                Refresh();

                // Ukonceni hry a nacteni zakladniho menu
                (this.Parent as Form1).GameCompleted();
                
                return true;
            }

            return false;
        }

        private void EvulationMove(GameField player, int posX, int posY)
        {
            int fieldsInRow = 1;

            // Kontrola svisle nahoru
            for ( int i = 1; i < nmbToWin; i++)
            {
                if (posY + i > boardSizeY)
                    break;

                if (gameFieldsBoard[posX, posY + i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola diagonalne do prava
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY + i > boardSizeY || posX + i >= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY + i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola diagonalne do leva
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY + i > boardSizeY || posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY + i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola do prava
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posX + i <= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }
            
            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola diagonalne do prava dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0 || posX + i >= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola svisle dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0)
                    break;

                if (gameFieldsBoard[posX, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola diagonalne do leva dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0 || posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            // Kontrola do leva
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY] == player)
                    fieldsInRow++;
                else
                {
                    fieldsInRow = 1;
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            // Pokud se kliklo do herniho pole do prvniho radku, kdyz je hra zapla, 
            // tak provede tah za hrace
            if (gameState != GameState.Played)
                return;

            int posX = e.X / fieldSize;
            int posY = e.Y / fieldSize;

            if (posY == 0 && posX <= boardSize) 
            {
                for (int y = boardSizeY; y >= 0; y--)
                {
                    if (gameFieldsBoard[posX, y] == GameField.NotOccupied)
                    {
                        gameFieldsBoard[posX, y] = currentPlayer;
                        DrawIntoBoardFields(posX, y);
                        EvulationMove(currentPlayer, posX, y);

                        currentPlayer = currentPlayer == GameField.X ? GameField.O : GameField.X;

                        (this.Parent as Form1).GameUpdateStats();

                        // Pokud je gameType == 1 -> PvA, tak po vykonani tahu hrace hraje AI
                        if (gameType != 1)
                            break;
                        else
                        {
                            if (gameState == GameState.NotPlayed)
                            { 
                                Play_by_AI(posX, posY, y);
                                break;
                            }
                        }
                            
                    }
                }
            }
        }

        private void Play_by_AI(int posX, int posY, int y)
        {
            // AI algoritmus na zpusob algoritmu Minimax (toto je jenom pokus)

            gameFieldsBoard[posX+2, y] = currentPlayer;
            DrawIntoBoardFields(posX+2, y);
            EvulationMove(currentPlayer, posX+2, y);

            currentPlayer = currentPlayer == GameField.X ? GameField.O : GameField.X;

            (this.Parent as Form1).GameUpdateStats();
        }

        private void GameBoard_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (gameState != GameState.Played)
                return;

            int posX = e.X / fieldSize;
            int posY = e.Y / fieldSize;

            if (posY == 0 && posX <= boardSize)
            {
                for (int y = boardSizeY; y >= 0; y--)
                {
                    if (gameFieldsBoard[posX, y] == GameField.NotOccupied)
                    {
                        using (Graphics graphics = this.CreateGraphics())
                        {
                            Rectangle rectangle = new Rectangle(posX * fieldSize + 1, y * fieldSize + 1, fieldSize - 1, fieldSize - 1);
                            RectangleF rectangleF = new RectangleF(posX * fieldSize + 1, y * fieldSize + 1, fieldSize - 1, fieldSize - 1);
                            graphics.DrawRectangle(PenO, rectangle);
                            graphics.FillRectangle(new SolidBrush(Color.LightGray), rectangleF);
                        }
                    }
                }
            }*/
        }

    }
}
