using System;
using System.Windows.Forms;

namespace tic_tac_toe_tenk
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        // Protekce proti zadávání char. do tb_boardSize
        private void tb_boardSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // Pokud se změní text v tb_boardSize, tak se v reálném čase změní velikost hracího pole, pokud je splněna podmínka
        private void tb_boardSize_TextChanged(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(tb_boardSize.Text, out result))
            {
                if (result >= 4 && result <= 30)
                {
                    gameBoard.BoardSize = result;
                }                
            }
            else tb_boardSize.Clear();
        }

        private int gameTime;

        // Funkce, která spustí hru po stisknutí tlačítka "Start"
        private void btn_gameStart_Click(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(tb_boardSize.Text, out result))
            {
                if (result >= 4 && result <= 30)
                {
                    gameBoard.BoardSize = result;
                }
                else
                {
                    MessageBox.Show("Maximální povolená velikost hracího pole je od 4 do 30!");
                    return;
                }
            }            

            // Nastavení hry - počet k vyhrání a typ hry
            gameBoard.NmbToWin = int.Parse(cb_toWin.Items[cb_toWin.SelectedIndex].ToString());
            gameBoard.GameType = cb_gameType.SelectedIndex;

            // Přepne panel a spustí timer
            p_gameSettings.Visible = false;
            p_gameStats.Visible = true;

            t_gameTime.Enabled = true;
            t_gameTime.Start();

            gameBoard.PrepareGameFieldBoard();

        }

        // Funkce, která ukončí aktuální hru a přepne do základního menu, voláme ji z komponenty gameBoard
        public void GameCompleted()
        {
            p_gameStats.Visible = false;
            p_gameSettings.Visible = true;

            t_gameTime.Enabled = false;
            t_gameTime.Stop();
            gameTime = 0;
        }

        // Funkce, kterou měníme statistiky hry, voláme ji z komponenty gameBoard
        public void GameUpdateStats()
        {
            lbl_nextPlayer.Text = "Aktuální tah má hráč: " + gameBoard.CurrentPlayer;
        }

        // Timer, který slouží k počítání herního času. Tiká každou 1s
        private void t_gameTime_Tick(object sender, EventArgs e)
        {
            gameTime++;
            TimeSpan time = TimeSpan.FromSeconds(gameTime);
            string sTime = time.ToString(@"hh\:mm\:ss");
            lbl_gameTime.Text = "Čas od začátku hry: \n" + sTime;
        }

        // Ukončí aplikaci
        private void lbl_closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Minimalizuje okno aplikace
        private void lbl_minimalizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /* 
           Přesunutí okna myší (jelikož styl ohraničení aplikace je nastaveno na none, protože mám vlastí, 
           tak zde musí být tato funkce, která nám umožní hýbat s oknem aplikace)
           Zdroj: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void form_mouse_down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
