using System.Drawing;
using System.Windows.Forms;
using System;
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

            gameFieldsBoard = new GameField[boardSize, boardSizeY+1];
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSizeY; y++)
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
            if (numberOfFieldRows >= nmbToWin)
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
                    break;
                }
            }

            // Kontrola svisle dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0)
                    break;

                if (gameFieldsBoard[posX, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }

            // Vyhodnoceni zda hrac dosahl poctu kamenu co je potreba k vyhre
            if (CheckWinner(fieldsInRow))
                return;

            fieldsInRow = 1;

            // Kontrola diagonalne do prava nahoru
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY + i > boardSizeY || posX + i >= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY + i] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }

            // Kontrola diagonalne do leva dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0 || posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }
            
            if (CheckWinner(fieldsInRow))
                return;

            fieldsInRow = 1;

            // Kontrola diagonalne do leva nahoru
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY + i > boardSizeY || posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY + i] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }

            // Kontrola diagonalne do prava dolu
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posY - i < 0 || posX + i >= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY - i] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }

            if (CheckWinner(fieldsInRow))
                return;

            fieldsInRow = 1;

            // Kontrola do prava
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posX + i >= boardSize)
                    break;

                if (gameFieldsBoard[posX + i, posY] == player)
                    fieldsInRow++;
                else
                {
                    break;
                }
            }

            // Kontrola do leva
            for (int i = 1; i < nmbToWin; i++)
            {
                if (posX - i < 0)
                    break;

                if (gameFieldsBoard[posX - i, posY] == player)
                    fieldsInRow++;
                else
                {
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
                            if (gameState != GameState.Played)
                            {
                                currentPlayer = currentPlayer == GameField.X ? GameField.O : GameField.X;
                                break;
                            }

                            Play_by_AI(posX, posY);
                            break;
                        }
                            
                    }
                }
            }
        }

        private void Play_by_AI(int posX, int posY)
        {
            // AI algoritmus pro hrani PvA
            // Pozn. je to jen pokus o udelani AI pro hrani
            int AIposY = 0;
            int AIposX = 0;

            FindBestMove(posX, posY, ref AIposX, ref AIposY);

            gameFieldsBoard[AIposX, AIposY] = currentPlayer;
            DrawIntoBoardFields(AIposX, AIposY);

            EvulationMove(currentPlayer, AIposX, AIposY);

            currentPlayer = currentPlayer == GameField.X ? GameField.O : GameField.X;

            (this.Parent as Form1).GameUpdateStats();
        }

        private void FindBestMove(int posX, int posY, ref int AIposX, ref int AIposY) 
        {
            int nmbTry = 0;
            bool tryAgain = true;

            while (tryAgain) {
                int score = 0;

                for (AIposX = 0; AIposX < boardSize; AIposX++)
                {
                    for (int y = boardSizeY; y >= 0; y--)
                    {
                        if (gameFieldsBoard[AIposX, y] == GameField.NotOccupied)
                        {
                            // Reworked
                            for (int i = 1; i < nmbToWin; i++)
                            {
                                // Kontrola zda je misto nejlepsi po svisle ose
                                if (y + i <= boardSizeY && y - i >= 0)
                                {
                                    if (gameFieldsBoard[AIposX, y + i] == GameField.X || gameFieldsBoard[AIposX, y - i] == GameField.X)
                                    {
                                        score += 1;
                                    }

                                    if (gameFieldsBoard[AIposX, y + i] == GameField.O || gameFieldsBoard[AIposX, y - i] == GameField.O)
                                    {
                                        score += 10;
                                    }
                                }

                                // Kontrola zda je misto nejlepsi po vodorovne ose
                                if (AIposX + i < boardSize && AIposX - i >= 0)
                                {
                                    if (gameFieldsBoard[AIposX + i, y] == GameField.X || gameFieldsBoard[AIposX - i, y] == GameField.X)
                                    {
                                        score += 1;
                                    }

                                    if (gameFieldsBoard[AIposX + i, y] == GameField.O || gameFieldsBoard[AIposX - i, y] == GameField.O)
                                    {
                                        score += 10;
                                    }
                                }

                                // Kontrola zda je misto nejlepsi po diagonalnch osach do leva dolu i nahoru
                                if (AIposX - i >= 0 && y + i <= boardSizeY && y - i >= 0)
                                {
                                    if (gameFieldsBoard[AIposX - i, y + i] == GameField.X || gameFieldsBoard[AIposX - i, y - i] == GameField.X)
                                    {
                                        score += 1;
                                    }

                                    if (gameFieldsBoard[AIposX - i, y + i] == GameField.O || gameFieldsBoard[AIposX - i, y - i] == GameField.O)
                                    {
                                        score += 10;
                                    }
                                }

                                // Kontrola zda je misto nejlepsi po diagonalni ose do prava dolu i nahoru
                                if (AIposX + i < boardSize && y + i <= boardSizeY && y - i >= 0)
                                {
                                    if (gameFieldsBoard[AIposX + i, y + i] == GameField.X || gameFieldsBoard[AIposX + i, y - i] == GameField.X)
                                    {
                                        score += 1;
                                    }

                                    if (gameFieldsBoard[AIposX + i, y + i] == GameField.O || gameFieldsBoard[AIposX + i, y - i] == GameField.O)
                                    {
                                        score += 10;
                                    }
                                }
                            }

                            AIposY = y;
                            nmbTry++;
                            break;
                        
                        }
                    }


                    if (score >= (nmbToWin * 10 - 10))
                    {
                        tryAgain = false;
                        break;
                    }
                    else if (score >= 3 && score < (nmbToWin))
                    {
                        if (nmbTry > 1)
                        {
                            tryAgain = false;
                            break;
                        }
                    }
                    else if (score >= 2 && score < 3)
                    {
                        if (nmbTry > 5)
                        {
                            tryAgain = false;
                            break;
                        }
                    }
                    else if (score >= 1 && score < 2)
                    {
                        if (nmbTry > 20)
                        {
                            tryAgain = false;
                            break;
                        }
                    }
                    else if (score >= 0 && score < 2)
                    {
                        if (nmbTry > 30)
                        {
                            tryAgain = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
