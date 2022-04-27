namespace library_tenk
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_minimalize = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.listBox_clients = new System.Windows.Forms.ListBox();
            this.listBox_aviable_books = new System.Windows.Forms.ListBox();
            this.listBox_borrowed_books = new System.Windows.Forms.ListBox();
            this.listBox_transactions_history = new System.Windows.Forms.ListBox();
            this.lbl_clients = new System.Windows.Forms.Label();
            this.lbl_aviable_books = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_readed_client = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_readed_book = new System.Windows.Forms.TextBox();
            this.btn_add_client = new System.Windows.Forms.Button();
            this.btn_remove_client = new System.Windows.Forms.Button();
            this.btn_add_book = new System.Windows.Forms.Button();
            this.btn_remove_book = new System.Windows.Forms.Button();
            this.btn_borrow = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.btn_minimalize);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 42);
            this.panel1.TabIndex = 0;
            // 
            // btn_minimalize
            // 
            this.btn_minimalize.AutoSize = true;
            this.btn_minimalize.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_minimalize.ForeColor = System.Drawing.Color.Orange;
            this.btn_minimalize.Location = new System.Drawing.Point(855, -4);
            this.btn_minimalize.Name = "btn_minimalize";
            this.btn_minimalize.Size = new System.Drawing.Size(21, 22);
            this.btn_minimalize.TabIndex = 2;
            this.btn_minimalize.Text = "_";
            this.btn_minimalize.Click += new System.EventHandler(this.Btn_minimalize_Click);
            // 
            // btn_close
            // 
            this.btn_close.AutoSize = true;
            this.btn_close.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_close.ForeColor = System.Drawing.Color.Orange;
            this.btn_close.Location = new System.Drawing.Point(882, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(23, 22);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "X";
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_title.ForeColor = System.Drawing.Color.Orange;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(294, 22);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Knihovna - databázový systém";
            // 
            // listBox_clients
            // 
            this.listBox_clients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.listBox_clients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_clients.ForeColor = System.Drawing.Color.Orange;
            this.listBox_clients.FormattingEnabled = true;
            this.listBox_clients.Location = new System.Drawing.Point(12, 72);
            this.listBox_clients.Name = "listBox_clients";
            this.listBox_clients.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_clients.Size = new System.Drawing.Size(203, 314);
            this.listBox_clients.TabIndex = 1;
            // 
            // listBox_aviable_books
            // 
            this.listBox_aviable_books.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.listBox_aviable_books.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_aviable_books.ForeColor = System.Drawing.Color.Orange;
            this.listBox_aviable_books.FormattingEnabled = true;
            this.listBox_aviable_books.Location = new System.Drawing.Point(238, 72);
            this.listBox_aviable_books.Name = "listBox_aviable_books";
            this.listBox_aviable_books.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_aviable_books.Size = new System.Drawing.Size(203, 314);
            this.listBox_aviable_books.TabIndex = 2;
            // 
            // listBox_borrowed_books
            // 
            this.listBox_borrowed_books.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.listBox_borrowed_books.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_borrowed_books.ForeColor = System.Drawing.Color.Orange;
            this.listBox_borrowed_books.FormattingEnabled = true;
            this.listBox_borrowed_books.Location = new System.Drawing.Point(464, 72);
            this.listBox_borrowed_books.Name = "listBox_borrowed_books";
            this.listBox_borrowed_books.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_borrowed_books.Size = new System.Drawing.Size(203, 314);
            this.listBox_borrowed_books.TabIndex = 3;
            // 
            // listBox_transactions_history
            // 
            this.listBox_transactions_history.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.listBox_transactions_history.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_transactions_history.ForeColor = System.Drawing.Color.Orange;
            this.listBox_transactions_history.FormattingEnabled = true;
            this.listBox_transactions_history.HorizontalScrollbar = true;
            this.listBox_transactions_history.Location = new System.Drawing.Point(690, 72);
            this.listBox_transactions_history.Name = "listBox_transactions_history";
            this.listBox_transactions_history.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_transactions_history.Size = new System.Drawing.Size(203, 314);
            this.listBox_transactions_history.TabIndex = 4;
            // 
            // lbl_clients
            // 
            this.lbl_clients.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_clients.ForeColor = System.Drawing.Color.Orange;
            this.lbl_clients.Location = new System.Drawing.Point(12, 50);
            this.lbl_clients.Name = "lbl_clients";
            this.lbl_clients.Size = new System.Drawing.Size(203, 22);
            this.lbl_clients.TabIndex = 3;
            this.lbl_clients.Text = "ZÁKAZNÍCÍ";
            this.lbl_clients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_aviable_books
            // 
            this.lbl_aviable_books.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_aviable_books.ForeColor = System.Drawing.Color.Orange;
            this.lbl_aviable_books.Location = new System.Drawing.Point(238, 53);
            this.lbl_aviable_books.Name = "lbl_aviable_books";
            this.lbl_aviable_books.Size = new System.Drawing.Size(203, 19);
            this.lbl_aviable_books.TabIndex = 5;
            this.lbl_aviable_books.Text = "DOSTUPNÉ KNIHY";
            this.lbl_aviable_books.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(464, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "VYPŮJČENÉ KNIHY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(686, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "HISTORIE TRANSAKCÍ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_readed_client
            // 
            this.tb_readed_client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.tb_readed_client.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_readed_client.ForeColor = System.Drawing.Color.Orange;
            this.tb_readed_client.Location = new System.Drawing.Point(12, 422);
            this.tb_readed_client.Name = "tb_readed_client";
            this.tb_readed_client.Size = new System.Drawing.Size(203, 20);
            this.tb_readed_client.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Načtený ID klienta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(238, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Načtený ID knihy:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_readed_book
            // 
            this.tb_readed_book.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.tb_readed_book.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_readed_book.ForeColor = System.Drawing.Color.Orange;
            this.tb_readed_book.Location = new System.Drawing.Point(238, 422);
            this.tb_readed_book.Name = "tb_readed_book";
            this.tb_readed_book.Size = new System.Drawing.Size(203, 20);
            this.tb_readed_book.TabIndex = 11;
            // 
            // btn_add_client
            // 
            this.btn_add_client.Location = new System.Drawing.Point(12, 448);
            this.btn_add_client.Name = "btn_add_client";
            this.btn_add_client.Size = new System.Drawing.Size(99, 33);
            this.btn_add_client.TabIndex = 12;
            this.btn_add_client.Text = "Přidat klienta";
            this.btn_add_client.UseVisualStyleBackColor = true;
            this.btn_add_client.Click += new System.EventHandler(this.Btn_add_client_Click);
            // 
            // btn_remove_client
            // 
            this.btn_remove_client.Location = new System.Drawing.Point(117, 448);
            this.btn_remove_client.Name = "btn_remove_client";
            this.btn_remove_client.Size = new System.Drawing.Size(99, 33);
            this.btn_remove_client.TabIndex = 13;
            this.btn_remove_client.Text = "Odebrat klienta";
            this.btn_remove_client.UseVisualStyleBackColor = true;
            this.btn_remove_client.Click += new System.EventHandler(this.Btn_remove_client_Click);
            // 
            // btn_add_book
            // 
            this.btn_add_book.Location = new System.Drawing.Point(238, 448);
            this.btn_add_book.Name = "btn_add_book";
            this.btn_add_book.Size = new System.Drawing.Size(99, 33);
            this.btn_add_book.TabIndex = 14;
            this.btn_add_book.Text = "Přidat knihu";
            this.btn_add_book.UseVisualStyleBackColor = true;
            this.btn_add_book.Click += new System.EventHandler(this.Btn_add_book_Click);
            // 
            // btn_remove_book
            // 
            this.btn_remove_book.Location = new System.Drawing.Point(343, 448);
            this.btn_remove_book.Name = "btn_remove_book";
            this.btn_remove_book.Size = new System.Drawing.Size(99, 33);
            this.btn_remove_book.TabIndex = 15;
            this.btn_remove_book.Text = "Odebrat knihu";
            this.btn_remove_book.UseVisualStyleBackColor = true;
            this.btn_remove_book.Click += new System.EventHandler(this.Btn_remove_book_Click);
            // 
            // btn_borrow
            // 
            this.btn_borrow.Location = new System.Drawing.Point(238, 487);
            this.btn_borrow.Name = "btn_borrow";
            this.btn_borrow.Size = new System.Drawing.Size(99, 33);
            this.btn_borrow.TabIndex = 16;
            this.btn_borrow.Text = "Vypůjčit knihu";
            this.btn_borrow.UseVisualStyleBackColor = true;
            this.btn_borrow.Click += new System.EventHandler(this.Btn_borrow_Click);
            // 
            // btn_return
            // 
            this.btn_return.Location = new System.Drawing.Point(343, 487);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(99, 33);
            this.btn_return.TabIndex = 17;
            this.btn_return.Text = "Vrátit knihu";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.Btn_return_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(464, 397);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(316, 123);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(905, 533);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_borrow);
            this.Controls.Add(this.btn_remove_book);
            this.Controls.Add(this.btn_add_book);
            this.Controls.Add(this.btn_remove_client);
            this.Controls.Add(this.btn_add_client);
            this.Controls.Add(this.tb_readed_book);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_readed_client);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_aviable_books);
            this.Controls.Add(this.lbl_clients);
            this.Controls.Add(this.listBox_transactions_history);
            this.Controls.Add(this.listBox_borrowed_books);
            this.Controls.Add(this.listBox_aviable_books);
            this.Controls.Add(this.listBox_clients);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_minimalize;
        private System.Windows.Forms.Label btn_close;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ListBox listBox_clients;
        private System.Windows.Forms.ListBox listBox_aviable_books;
        private System.Windows.Forms.ListBox listBox_borrowed_books;
        private System.Windows.Forms.ListBox listBox_transactions_history;
        private System.Windows.Forms.Label lbl_clients;
        private System.Windows.Forms.Label lbl_aviable_books;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_readed_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_readed_book;
        private System.Windows.Forms.Button btn_add_client;
        private System.Windows.Forms.Button btn_remove_client;
        private System.Windows.Forms.Button btn_add_book;
        private System.Windows.Forms.Button btn_remove_book;
        private System.Windows.Forms.Button btn_borrow;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

