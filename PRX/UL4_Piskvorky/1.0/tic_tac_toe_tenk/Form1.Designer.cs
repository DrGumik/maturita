namespace tic_tac_toe_tenk
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.p_head = new System.Windows.Forms.Panel();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lbl_minimalizeApp = new System.Windows.Forms.Label();
            this.lbl_closeApp = new System.Windows.Forms.Label();
            this.lbl_head = new System.Windows.Forms.Label();
            this.p_gameSettings = new System.Windows.Forms.Panel();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.tb_boardSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_gameType = new System.Windows.Forms.Label();
            this.cb_gameType = new System.Windows.Forms.ComboBox();
            this.lbl_toWin = new System.Windows.Forms.Label();
            this.cb_toWin = new System.Windows.Forms.ComboBox();
            this.btn_gameStart = new System.Windows.Forms.Button();
            this.p_gameStats = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_gameTime = new System.Windows.Forms.Label();
            this.lbl_nextPlayer = new System.Windows.Forms.Label();
            this.t_gameTime = new System.Windows.Forms.Timer(this.components);
            this.gameBoard = new tic_tac_toe_tenk.GameBoard();
            this.p_head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.p_gameSettings.SuspendLayout();
            this.p_gameStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_head
            // 
            this.p_head.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p_head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(100)))), ((int)(((byte)(111)))));
            this.p_head.Controls.Add(this.pb_logo);
            this.p_head.Controls.Add(this.lbl_minimalizeApp);
            this.p_head.Controls.Add(this.lbl_closeApp);
            this.p_head.Controls.Add(this.lbl_head);
            this.p_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_head.Location = new System.Drawing.Point(0, 0);
            this.p_head.Name = "p_head";
            this.p_head.Size = new System.Drawing.Size(809, 60);
            this.p_head.TabIndex = 1;
            this.p_head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mouse_down);
            // 
            // pb_logo
            // 
            this.pb_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_logo.InitialImage")));
            this.pb_logo.Location = new System.Drawing.Point(3, 3);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(55, 55);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 3;
            this.pb_logo.TabStop = false;
            this.pb_logo.WaitOnLoad = true;
            // 
            // lbl_minimalizeApp
            // 
            this.lbl_minimalizeApp.AutoSize = true;
            this.lbl_minimalizeApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_minimalizeApp.ForeColor = System.Drawing.Color.White;
            this.lbl_minimalizeApp.Location = new System.Drawing.Point(753, -3);
            this.lbl_minimalizeApp.Name = "lbl_minimalizeApp";
            this.lbl_minimalizeApp.Size = new System.Drawing.Size(25, 25);
            this.lbl_minimalizeApp.TabIndex = 2;
            this.lbl_minimalizeApp.Text = "_";
            this.lbl_minimalizeApp.Click += new System.EventHandler(this.lbl_minimalizeApp_Click);
            // 
            // lbl_closeApp
            // 
            this.lbl_closeApp.AutoSize = true;
            this.lbl_closeApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_closeApp.ForeColor = System.Drawing.Color.White;
            this.lbl_closeApp.Location = new System.Drawing.Point(783, 0);
            this.lbl_closeApp.Name = "lbl_closeApp";
            this.lbl_closeApp.Size = new System.Drawing.Size(27, 25);
            this.lbl_closeApp.TabIndex = 1;
            this.lbl_closeApp.Text = "X";
            this.lbl_closeApp.Click += new System.EventHandler(this.lbl_closeApp_Click);
            // 
            // lbl_head
            // 
            this.lbl_head.AutoSize = true;
            this.lbl_head.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_head.ForeColor = System.Drawing.Color.White;
            this.lbl_head.Location = new System.Drawing.Point(64, 9);
            this.lbl_head.Name = "lbl_head";
            this.lbl_head.Size = new System.Drawing.Size(386, 44);
            this.lbl_head.TabIndex = 0;
            this.lbl_head.Text = "Gravitační piškvorky";
            this.lbl_head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mouse_down);
            // 
            // p_gameSettings
            // 
            this.p_gameSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.p_gameSettings.Controls.Add(this.lbl_author);
            this.p_gameSettings.Controls.Add(this.lbl_info);
            this.p_gameSettings.Controls.Add(this.tb_boardSize);
            this.p_gameSettings.Controls.Add(this.label1);
            this.p_gameSettings.Controls.Add(this.lbl_gameType);
            this.p_gameSettings.Controls.Add(this.cb_gameType);
            this.p_gameSettings.Controls.Add(this.lbl_toWin);
            this.p_gameSettings.Controls.Add(this.cb_toWin);
            this.p_gameSettings.Controls.Add(this.btn_gameStart);
            this.p_gameSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_gameSettings.Location = new System.Drawing.Point(0, 60);
            this.p_gameSettings.Name = "p_gameSettings";
            this.p_gameSettings.Size = new System.Drawing.Size(166, 429);
            this.p_gameSettings.TabIndex = 2;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_author.ForeColor = System.Drawing.Color.White;
            this.lbl_author.Location = new System.Drawing.Point(21, 410);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(121, 16);
            this.lbl_author.TabIndex = 8;
            this.lbl_author.Text = "Vytvořil Jakub Tenk";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_info.ForeColor = System.Drawing.Color.White;
            this.lbl_info.Location = new System.Drawing.Point(3, 273);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(147, 48);
            this.lbl_info.TabIndex = 7;
            this.lbl_info.Text = "Vysvětlivky:\r\n PvP - hráč proti hráčovi\r\n PvA - hráč proti PC";
            // 
            // tb_boardSize
            // 
            this.tb_boardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.tb_boardSize.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.tb_boardSize.ForeColor = System.Drawing.Color.White;
            this.tb_boardSize.Location = new System.Drawing.Point(6, 152);
            this.tb_boardSize.MaxLength = 2;
            this.tb_boardSize.Name = "tb_boardSize";
            this.tb_boardSize.Size = new System.Drawing.Size(151, 22);
            this.tb_boardSize.TabIndex = 6;
            this.tb_boardSize.TextChanged += new System.EventHandler(this.tb_boardSize_TextChanged);
            this.tb_boardSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_boardSize_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Velikost hrací plochy:";
            // 
            // lbl_gameType
            // 
            this.lbl_gameType.AutoSize = true;
            this.lbl_gameType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_gameType.ForeColor = System.Drawing.Color.White;
            this.lbl_gameType.Location = new System.Drawing.Point(2, 80);
            this.lbl_gameType.Name = "lbl_gameType";
            this.lbl_gameType.Size = new System.Drawing.Size(53, 16);
            this.lbl_gameType.TabIndex = 4;
            this.lbl_gameType.Text = "Typ hry:";
            // 
            // cb_gameType
            // 
            this.cb_gameType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cb_gameType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_gameType.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.cb_gameType.ForeColor = System.Drawing.Color.White;
            this.cb_gameType.FormattingEnabled = true;
            this.cb_gameType.Items.AddRange(new object[] {
            "PvP",
            "PvA"});
            this.cb_gameType.Location = new System.Drawing.Point(6, 98);
            this.cb_gameType.Name = "cb_gameType";
            this.cb_gameType.Size = new System.Drawing.Size(151, 24);
            this.cb_gameType.TabIndex = 3;
            this.cb_gameType.Text = "PvP";
            // 
            // lbl_toWin
            // 
            this.lbl_toWin.AutoSize = true;
            this.lbl_toWin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_toWin.ForeColor = System.Drawing.Color.White;
            this.lbl_toWin.Location = new System.Drawing.Point(2, 26);
            this.lbl_toWin.Name = "lbl_toWin";
            this.lbl_toWin.Size = new System.Drawing.Size(154, 16);
            this.lbl_toWin.TabIndex = 2;
            this.lbl_toWin.Text = "Počet výherních políček:";
            // 
            // cb_toWin
            // 
            this.cb_toWin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cb_toWin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_toWin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.cb_toWin.ForeColor = System.Drawing.Color.White;
            this.cb_toWin.FormattingEnabled = true;
            this.cb_toWin.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cb_toWin.Location = new System.Drawing.Point(6, 44);
            this.cb_toWin.Name = "cb_toWin";
            this.cb_toWin.Size = new System.Drawing.Size(151, 24);
            this.cb_toWin.TabIndex = 1;
            this.cb_toWin.Text = "4";
            // 
            // btn_gameStart
            // 
            this.btn_gameStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btn_gameStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btn_gameStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btn_gameStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btn_gameStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gameStart.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.btn_gameStart.ForeColor = System.Drawing.Color.White;
            this.btn_gameStart.Image = ((System.Drawing.Image)(resources.GetObject("btn_gameStart.Image")));
            this.btn_gameStart.Location = new System.Drawing.Point(6, 197);
            this.btn_gameStart.Name = "btn_gameStart";
            this.btn_gameStart.Size = new System.Drawing.Size(151, 59);
            this.btn_gameStart.TabIndex = 0;
            this.btn_gameStart.UseVisualStyleBackColor = false;
            this.btn_gameStart.Click += new System.EventHandler(this.btn_gameStart_Click);
            // 
            // p_gameStats
            // 
            this.p_gameStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.p_gameStats.Controls.Add(this.label2);
            this.p_gameStats.Controls.Add(this.lbl_gameTime);
            this.p_gameStats.Controls.Add(this.lbl_nextPlayer);
            this.p_gameStats.Location = new System.Drawing.Point(0, 60);
            this.p_gameStats.Name = "p_gameStats";
            this.p_gameStats.Size = new System.Drawing.Size(166, 429);
            this.p_gameStats.TabIndex = 7;
            this.p_gameStats.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 80);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pro položení hracího kamenu klikni na 1. řádek daného sloupce, kam chcete hrát.";
            // 
            // lbl_gameTime
            // 
            this.lbl_gameTime.AutoSize = true;
            this.lbl_gameTime.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_gameTime.ForeColor = System.Drawing.Color.White;
            this.lbl_gameTime.Location = new System.Drawing.Point(3, 80);
            this.lbl_gameTime.Name = "lbl_gameTime";
            this.lbl_gameTime.Size = new System.Drawing.Size(126, 16);
            this.lbl_gameTime.TabIndex = 4;
            this.lbl_gameTime.Text = "Čas od začátku hry: ";
            // 
            // lbl_nextPlayer
            // 
            this.lbl_nextPlayer.AutoSize = true;
            this.lbl_nextPlayer.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_nextPlayer.ForeColor = System.Drawing.Color.White;
            this.lbl_nextPlayer.Location = new System.Drawing.Point(3, 38);
            this.lbl_nextPlayer.Name = "lbl_nextPlayer";
            this.lbl_nextPlayer.Size = new System.Drawing.Size(144, 16);
            this.lbl_nextPlayer.TabIndex = 2;
            this.lbl_nextPlayer.Text = "Aktuální tah má hráč: O";
            // 
            // t_gameTime
            // 
            this.t_gameTime.Interval = 1000;
            this.t_gameTime.Tick += new System.EventHandler(this.t_gameTime_Tick);
            // 
            // gameBoard
            // 
            this.gameBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.gameBoard.BoardSize = 30;
            this.gameBoard.GameType = 0;
            this.gameBoard.Location = new System.Drawing.Point(172, 64);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.NmbToWin = 4;
            this.gameBoard.Size = new System.Drawing.Size(637, 421);
            this.gameBoard.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(809, 489);
            this.Controls.Add(this.p_gameStats);
            this.Controls.Add(this.p_gameSettings);
            this.Controls.Add(this.p_head);
            this.Controls.Add(this.gameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.p_head.ResumeLayout(false);
            this.p_head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.p_gameSettings.ResumeLayout(false);
            this.p_gameSettings.PerformLayout();
            this.p_gameStats.ResumeLayout(false);
            this.p_gameStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel p_head;
        private System.Windows.Forms.Label lbl_head;
        private GameBoard gameBoard;
        public System.Windows.Forms.Panel p_gameSettings;
        public System.Windows.Forms.Panel p_gameStats;
        public System.Windows.Forms.Label lbl_nextPlayer;
        public System.Windows.Forms.Label lbl_gameTime;
        public System.Windows.Forms.Button btn_gameStart;
        public System.Windows.Forms.TextBox tb_boardSize;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cb_gameType;
        public System.Windows.Forms.Label lbl_gameType;
        public System.Windows.Forms.ComboBox cb_toWin;
        public System.Windows.Forms.Label lbl_toWin;
        private System.Windows.Forms.Timer t_gameTime;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label lbl_minimalizeApp;
        private System.Windows.Forms.Label lbl_closeApp;
        private System.Windows.Forms.PictureBox pb_logo;
        public System.Windows.Forms.Label label2;
    }
}

