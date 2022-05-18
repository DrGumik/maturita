namespace SerialLine_Tenk
{
    partial class SerialLink_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialLink_MainForm));
            this.ports_list = new System.Windows.Forms.CheckedListBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_reloadPorts = new System.Windows.Forms.Button();
            this.tb_console = new System.Windows.Forms.TextBox();
            this.KeyboardCheck = new System.ComponentModel.BackgroundWorker();
            this.left_side_panel = new System.Windows.Forms.Panel();
            this.konzole_lbl = new System.Windows.Forms.Label();
            this.ports_lbl = new System.Windows.Forms.Label();
            this.top_panel = new System.Windows.Forms.Panel();
            this.btn_minimalize = new System.Windows.Forms.Label();
            this.main_icon = new System.Windows.Forms.PictureBox();
            this.btn_exit = new System.Windows.Forms.Label();
            this.main_text = new System.Windows.Forms.Label();
            this.author_lbl = new System.Windows.Forms.Label();
            this.left_side_panel.SuspendLayout();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // ports_list
            // 
            this.ports_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ports_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ports_list.CheckOnClick = true;
            this.ports_list.ForeColor = System.Drawing.Color.White;
            this.ports_list.FormattingEnabled = true;
            this.ports_list.HorizontalScrollbar = true;
            this.ports_list.Location = new System.Drawing.Point(157, 247);
            this.ports_list.Name = "ports_list";
            this.ports_list.Size = new System.Drawing.Size(350, 132);
            this.ports_list.Sorted = true;
            this.ports_list.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btn_connect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_connect.FlatAppearance.BorderSize = 2;
            this.btn_connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connect.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_connect.ForeColor = System.Drawing.Color.White;
            this.btn_connect.Image = ((System.Drawing.Image)(resources.GetObject("btn_connect.Image")));
            this.btn_connect.Location = new System.Drawing.Point(-8, 69);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(144, 61);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Připojit";
            this.btn_connect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_disconnect.FlatAppearance.BorderSize = 2;
            this.btn_disconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_disconnect.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_disconnect.ForeColor = System.Drawing.Color.White;
            this.btn_disconnect.Image = ((System.Drawing.Image)(resources.GetObject("btn_disconnect.Image")));
            this.btn_disconnect.Location = new System.Drawing.Point(-8, 203);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(144, 61);
            this.btn_disconnect.TabIndex = 2;
            this.btn_disconnect.Text = "Odpojit";
            this.btn_disconnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_disconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_reloadPorts
            // 
            this.btn_reloadPorts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_reloadPorts.FlatAppearance.BorderSize = 2;
            this.btn_reloadPorts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btn_reloadPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reloadPorts.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_reloadPorts.ForeColor = System.Drawing.Color.White;
            this.btn_reloadPorts.Image = ((System.Drawing.Image)(resources.GetObject("btn_reloadPorts.Image")));
            this.btn_reloadPorts.Location = new System.Drawing.Point(-8, 136);
            this.btn_reloadPorts.Name = "btn_reloadPorts";
            this.btn_reloadPorts.Size = new System.Drawing.Size(144, 61);
            this.btn_reloadPorts.TabIndex = 3;
            this.btn_reloadPorts.Text = "Načíst porty";
            this.btn_reloadPorts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reloadPorts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_reloadPorts.UseVisualStyleBackColor = true;
            this.btn_reloadPorts.Click += new System.EventHandler(this.btn_reloadPorts_Click);
            // 
            // tb_console
            // 
            this.tb_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tb_console.ForeColor = System.Drawing.Color.White;
            this.tb_console.Location = new System.Drawing.Point(157, 97);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.Size = new System.Drawing.Size(350, 116);
            this.tb_console.TabIndex = 4;
            this.tb_console.Text = "Vyberte si port v seznamu dostupných portů, který chcete použít pro komunikaci se" +
    " zařízením a poté klikněte na tlačítko připojit.";
            // 
            // KeyboardCheck
            // 
            this.KeyboardCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.KeyboardCheck_DoWork);
            // 
            // left_side_panel
            // 
            this.left_side_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.left_side_panel.Controls.Add(this.btn_reloadPorts);
            this.left_side_panel.Controls.Add(this.btn_disconnect);
            this.left_side_panel.Controls.Add(this.btn_connect);
            this.left_side_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_side_panel.Location = new System.Drawing.Point(0, 0);
            this.left_side_panel.Name = "left_side_panel";
            this.left_side_panel.Size = new System.Drawing.Size(133, 396);
            this.left_side_panel.TabIndex = 0;
            // 
            // konzole_lbl
            // 
            this.konzole_lbl.AutoSize = true;
            this.konzole_lbl.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.konzole_lbl.ForeColor = System.Drawing.Color.White;
            this.konzole_lbl.Location = new System.Drawing.Point(153, 75);
            this.konzole_lbl.Name = "konzole_lbl";
            this.konzole_lbl.Size = new System.Drawing.Size(74, 19);
            this.konzole_lbl.TabIndex = 6;
            this.konzole_lbl.Text = "Konzole:";
            // 
            // ports_lbl
            // 
            this.ports_lbl.AutoSize = true;
            this.ports_lbl.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ports_lbl.ForeColor = System.Drawing.Color.White;
            this.ports_lbl.Location = new System.Drawing.Point(153, 225);
            this.ports_lbl.Name = "ports_lbl";
            this.ports_lbl.Size = new System.Drawing.Size(213, 19);
            this.ports_lbl.TabIndex = 7;
            this.ports_lbl.Text = "Seznam dostupných protů:";
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.top_panel.Controls.Add(this.btn_minimalize);
            this.top_panel.Controls.Add(this.main_icon);
            this.top_panel.Controls.Add(this.btn_exit);
            this.top_panel.Controls.Add(this.main_text);
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(532, 63);
            this.top_panel.TabIndex = 8;
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mouse_down);
            // 
            // btn_minimalize
            // 
            this.btn_minimalize.AutoSize = true;
            this.btn_minimalize.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_minimalize.ForeColor = System.Drawing.Color.White;
            this.btn_minimalize.Location = new System.Drawing.Point(486, -11);
            this.btn_minimalize.Name = "btn_minimalize";
            this.btn_minimalize.Size = new System.Drawing.Size(21, 28);
            this.btn_minimalize.TabIndex = 10;
            this.btn_minimalize.Text = "_";
            this.btn_minimalize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_minimalize.Click += new System.EventHandler(this.btn_minimalize_Click);
            // 
            // main_icon
            // 
            this.main_icon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.main_icon.Image = ((System.Drawing.Image)(resources.GetObject("main_icon.Image")));
            this.main_icon.Location = new System.Drawing.Point(4, 0);
            this.main_icon.Name = "main_icon";
            this.main_icon.Size = new System.Drawing.Size(74, 60);
            this.main_icon.TabIndex = 0;
            this.main_icon.TabStop = false;
            this.main_icon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mouse_down);
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(511, 0);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(21, 22);
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "X";
            this.btn_exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // main_text
            // 
            this.main_text.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.main_text.ForeColor = System.Drawing.Color.White;
            this.main_text.Location = new System.Drawing.Point(74, 0);
            this.main_text.Name = "main_text";
            this.main_text.Size = new System.Drawing.Size(323, 63);
            this.main_text.TabIndex = 0;
            this.main_text.Text = "Ovládání sériové komunikace";
            this.main_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.main_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mouse_down);
            // 
            // author_lbl
            // 
            this.author_lbl.AutoSize = true;
            this.author_lbl.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.author_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.author_lbl.Location = new System.Drawing.Point(423, 380);
            this.author_lbl.Name = "author_lbl";
            this.author_lbl.Size = new System.Drawing.Size(109, 16);
            this.author_lbl.TabIndex = 9;
            this.author_lbl.Text = "Vytvořil Jakub Tenk";
            // 
            // SerialLink_MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(532, 396);
            this.Controls.Add(this.author_lbl);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.ports_lbl);
            this.Controls.Add(this.konzole_lbl);
            this.Controls.Add(this.left_side_panel);
            this.Controls.Add(this.tb_console);
            this.Controls.Add(this.ports_list);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialLink_MainForm";
            this.Text = "Ovládání sériové komunikace";
            this.Load += new System.EventHandler(this.SerialLink_MainForm_Load);
            this.left_side_panel.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ports_list;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_reloadPorts;
        private System.Windows.Forms.TextBox tb_console;
        private System.ComponentModel.BackgroundWorker KeyboardCheck;
        private System.Windows.Forms.Panel left_side_panel;
        private System.Windows.Forms.Label konzole_lbl;
        private System.Windows.Forms.Label ports_lbl;
        private System.Windows.Forms.PictureBox main_icon;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Label main_text;
        private System.Windows.Forms.Label btn_exit;
        private System.Windows.Forms.Label author_lbl;
        private System.Windows.Forms.Label btn_minimalize;
    }
}

