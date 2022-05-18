namespace tenis_siriste
{
    partial class pong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hriste = new System.Windows.Forms.Panel();
            this.vysvetleni = new System.Windows.Forms.TextBox();
            this.mic = new System.Windows.Forms.PictureBox();
            this.hrac2 = new System.Windows.Forms.PictureBox();
            this.hrac1 = new System.Windows.Forms.PictureBox();
            this.skupina_mod = new System.Windows.Forms.GroupBox();
            this.dva_hraci = new System.Windows.Forms.RadioButton();
            this.jeden_hrac = new System.Windows.Forms.RadioButton();
            this.skupina_obtiznost = new System.Windows.Forms.GroupBox();
            this.tezka = new System.Windows.Forms.RadioButton();
            this.stredni = new System.Windows.Forms.RadioButton();
            this.lehka = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.label_hrac1 = new System.Windows.Forms.Label();
            this.label_hrac2 = new System.Windows.Forms.Label();
            this.oznameni = new System.Windows.Forms.Label();
            this.casovac = new System.Windows.Forms.Timer(this.components);
            this.rozumim = new System.Windows.Forms.Button();
            this.barva = new System.Windows.Forms.CheckBox();
            this.hriste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrac2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrac1)).BeginInit();
            this.skupina_mod.SuspendLayout();
            this.skupina_obtiznost.SuspendLayout();
            this.SuspendLayout();
            // 
            // hriste
            // 
            this.hriste.BackColor = System.Drawing.Color.Lime;
            this.hriste.Controls.Add(this.vysvetleni);
            this.hriste.Controls.Add(this.mic);
            this.hriste.Controls.Add(this.hrac2);
            this.hriste.Controls.Add(this.hrac1);
            this.hriste.Location = new System.Drawing.Point(100, 100);
            this.hriste.Name = "hriste";
            this.hriste.Size = new System.Drawing.Size(600, 400);
            this.hriste.TabIndex = 0;
            // 
            // vysvetleni
            // 
            this.vysvetleni.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vysvetleni.Location = new System.Drawing.Point(0, 289);
            this.vysvetleni.Multiline = true;
            this.vysvetleni.Name = "vysvetleni";
            this.vysvetleni.ReadOnly = true;
            this.vysvetleni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.vysvetleni.Size = new System.Drawing.Size(157, 111);
            this.vysvetleni.TabIndex = 3;
            this.vysvetleni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mic
            // 
            this.mic.BackColor = System.Drawing.Color.Black;
            this.mic.Location = new System.Drawing.Point(288, 170);
            this.mic.Name = "mic";
            this.mic.Size = new System.Drawing.Size(15, 15);
            this.mic.TabIndex = 2;
            this.mic.TabStop = false;
            // 
            // hrac2
            // 
            this.hrac2.BackColor = System.Drawing.Color.White;
            this.hrac2.Location = new System.Drawing.Point(560, 143);
            this.hrac2.Name = "hrac2";
            this.hrac2.Size = new System.Drawing.Size(10, 80);
            this.hrac2.TabIndex = 1;
            this.hrac2.TabStop = false;
            // 
            // hrac1
            // 
            this.hrac1.BackColor = System.Drawing.Color.White;
            this.hrac1.Location = new System.Drawing.Point(22, 143);
            this.hrac1.Name = "hrac1";
            this.hrac1.Size = new System.Drawing.Size(10, 80);
            this.hrac1.TabIndex = 0;
            this.hrac1.TabStop = false;
            // 
            // skupina_mod
            // 
            this.skupina_mod.Controls.Add(this.barva);
            this.skupina_mod.Controls.Add(this.dva_hraci);
            this.skupina_mod.Controls.Add(this.jeden_hrac);
            this.skupina_mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skupina_mod.Location = new System.Drawing.Point(98, 12);
            this.skupina_mod.Name = "skupina_mod";
            this.skupina_mod.Size = new System.Drawing.Size(260, 83);
            this.skupina_mod.TabIndex = 1;
            this.skupina_mod.TabStop = false;
            this.skupina_mod.Text = "Volba módu";
            // 
            // dva_hraci
            // 
            this.dva_hraci.AutoSize = true;
            this.dva_hraci.Location = new System.Drawing.Point(147, 25);
            this.dva_hraci.Name = "dva_hraci";
            this.dva_hraci.Size = new System.Drawing.Size(109, 24);
            this.dva_hraci.TabIndex = 1;
            this.dva_hraci.TabStop = true;
            this.dva_hraci.Text = "Hra pro dva";
            this.dva_hraci.UseVisualStyleBackColor = true;
            this.dva_hraci.CheckedChanged += new System.EventHandler(this.dva_hraci_CheckedChanged);
            // 
            // jeden_hrac
            // 
            this.jeden_hrac.AutoSize = true;
            this.jeden_hrac.Location = new System.Drawing.Point(0, 25);
            this.jeden_hrac.Name = "jeden_hrac";
            this.jeden_hrac.Size = new System.Drawing.Size(141, 24);
            this.jeden_hrac.TabIndex = 0;
            this.jeden_hrac.TabStop = true;
            this.jeden_hrac.Text = "Hra pro jednoho";
            this.jeden_hrac.UseVisualStyleBackColor = true;
            this.jeden_hrac.CheckedChanged += new System.EventHandler(this.jeden_hrac_CheckedChanged);
            // 
            // skupina_obtiznost
            // 
            this.skupina_obtiznost.Controls.Add(this.tezka);
            this.skupina_obtiznost.Controls.Add(this.stredni);
            this.skupina_obtiznost.Controls.Add(this.lehka);
            this.skupina_obtiznost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skupina_obtiznost.Location = new System.Drawing.Point(364, 12);
            this.skupina_obtiznost.Name = "skupina_obtiznost";
            this.skupina_obtiznost.Size = new System.Drawing.Size(237, 82);
            this.skupina_obtiznost.TabIndex = 2;
            this.skupina_obtiznost.TabStop = false;
            this.skupina_obtiznost.Text = "Volba obtížnosti";
            // 
            // tezka
            // 
            this.tezka.AutoSize = true;
            this.tezka.Location = new System.Drawing.Point(167, 25);
            this.tezka.Name = "tezka";
            this.tezka.Size = new System.Drawing.Size(70, 24);
            this.tezka.TabIndex = 4;
            this.tezka.TabStop = true;
            this.tezka.Text = "Těžká";
            this.tezka.UseVisualStyleBackColor = true;
            this.tezka.CheckedChanged += new System.EventHandler(this.tezka_CheckedChanged);
            // 
            // stredni
            // 
            this.stredni.AutoSize = true;
            this.stredni.Location = new System.Drawing.Point(83, 25);
            this.stredni.Name = "stredni";
            this.stredni.Size = new System.Drawing.Size(78, 24);
            this.stredni.TabIndex = 3;
            this.stredni.TabStop = true;
            this.stredni.Text = "Střední";
            this.stredni.UseVisualStyleBackColor = true;
            this.stredni.CheckedChanged += new System.EventHandler(this.stredni_CheckedChanged);
            // 
            // lehka
            // 
            this.lehka.AutoSize = true;
            this.lehka.Location = new System.Drawing.Point(6, 25);
            this.lehka.Name = "lehka";
            this.lehka.Size = new System.Drawing.Size(71, 24);
            this.lehka.TabIndex = 2;
            this.lehka.TabStop = true;
            this.lehka.Text = "Lehká";
            this.lehka.UseVisualStyleBackColor = true;
            this.lehka.CheckedChanged += new System.EventHandler(this.lehka_CheckedChanged);
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start.Location = new System.Drawing.Point(607, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(89, 38);
            this.start.TabIndex = 3;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // restart
            // 
            this.restart.AutoSize = true;
            this.restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restart.Location = new System.Drawing.Point(607, 56);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(89, 37);
            this.restart.TabIndex = 4;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // label_hrac1
            // 
            this.label_hrac1.AutoSize = true;
            this.label_hrac1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_hrac1.Location = new System.Drawing.Point(93, 503);
            this.label_hrac1.Name = "label_hrac1";
            this.label_hrac1.Size = new System.Drawing.Size(36, 39);
            this.label_hrac1.TabIndex = 5;
            this.label_hrac1.Text = "0";
            // 
            // label_hrac2
            // 
            this.label_hrac2.AutoSize = true;
            this.label_hrac2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_hrac2.Location = new System.Drawing.Point(664, 503);
            this.label_hrac2.Name = "label_hrac2";
            this.label_hrac2.Size = new System.Drawing.Size(36, 39);
            this.label_hrac2.TabIndex = 6;
            this.label_hrac2.Text = "0";
            // 
            // oznameni
            // 
            this.oznameni.AutoSize = true;
            this.oznameni.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oznameni.Location = new System.Drawing.Point(300, 508);
            this.oznameni.Name = "oznameni";
            this.oznameni.Size = new System.Drawing.Size(137, 31);
            this.oznameni.TabIndex = 7;
            this.oznameni.Text = "Oznámení";
            // 
            // casovac
            // 
            this.casovac.Interval = 15;
            this.casovac.Tick += new System.EventHandler(this.casovac_Tick);
            // 
            // rozumim
            // 
            this.rozumim.AutoSize = true;
            this.rozumim.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rozumim.Location = new System.Drawing.Point(306, 506);
            this.rozumim.Name = "rozumim";
            this.rozumim.Size = new System.Drawing.Size(143, 44);
            this.rozumim.TabIndex = 8;
            this.rozumim.Text = "Rozumím";
            this.rozumim.UseVisualStyleBackColor = true;
            this.rozumim.Click += new System.EventHandler(this.rozumim_Click);
            // 
            // barva
            // 
            this.barva.AutoSize = true;
            this.barva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.barva.Location = new System.Drawing.Point(6, 53);
            this.barva.Name = "barva";
            this.barva.Size = new System.Drawing.Size(193, 24);
            this.barva.TabIndex = 9;
            this.barva.Text = "Změna barvy při odrazu";
            this.barva.UseVisualStyleBackColor = true;
            this.barva.CheckStateChanged += new System.EventHandler(this.barva_CheckStateChanged);
            // 
            // pong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.rozumim);
            this.Controls.Add(this.oznameni);
            this.Controls.Add(this.label_hrac2);
            this.Controls.Add(this.label_hrac1);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.start);
            this.Controls.Add(this.skupina_obtiznost);
            this.Controls.Add(this.skupina_mod);
            this.Controls.Add(this.hriste);
            this.Name = "pong";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.pong_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pong_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pong_KeyUp);
            this.hriste.ResumeLayout(false);
            this.hriste.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrac2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrac1)).EndInit();
            this.skupina_mod.ResumeLayout(false);
            this.skupina_mod.PerformLayout();
            this.skupina_obtiznost.ResumeLayout(false);
            this.skupina_obtiznost.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel hriste;
        private System.Windows.Forms.PictureBox mic;
        private System.Windows.Forms.PictureBox hrac2;
        private System.Windows.Forms.PictureBox hrac1;
        private System.Windows.Forms.GroupBox skupina_mod;
        private System.Windows.Forms.RadioButton dva_hraci;
        private System.Windows.Forms.RadioButton jeden_hrac;
        private System.Windows.Forms.GroupBox skupina_obtiznost;
        private System.Windows.Forms.RadioButton tezka;
        private System.Windows.Forms.RadioButton stredni;
        private System.Windows.Forms.RadioButton lehka;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Label label_hrac1;
        private System.Windows.Forms.Label label_hrac2;
        private System.Windows.Forms.Label oznameni;
        private System.Windows.Forms.Timer casovac;
        private System.Windows.Forms.TextBox vysvetleni;
        private System.Windows.Forms.Button rozumim;
        private System.Windows.Forms.CheckBox barva;
    }
}

