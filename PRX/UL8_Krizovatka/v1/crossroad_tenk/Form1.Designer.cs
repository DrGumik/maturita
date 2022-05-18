namespace crossroad_tenk
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
            this.components = new System.ComponentModel.Container();
            this.head_panel = new System.Windows.Forms.Panel();
            this.btn_minimalize = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.panel_left_menu = new System.Windows.Forms.Panel();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.timer_day = new System.Windows.Forms.Timer(this.components);
            this.timer_night = new System.Windows.Forms.Timer(this.components);
            this.trafficLightsMajorLeft2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorMain2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorRight1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorMain1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorMain1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorLeft1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorMain2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorRight2 = new crossroad_tenk.TrafficLights();
            this.head_panel.SuspendLayout();
            this.panel_left_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // head_panel
            // 
            this.head_panel.BackColor = System.Drawing.Color.SandyBrown;
            this.head_panel.Controls.Add(this.btn_minimalize);
            this.head_panel.Controls.Add(this.btn_exit);
            this.head_panel.Controls.Add(this.lb_title);
            this.head_panel.Location = new System.Drawing.Point(0, 0);
            this.head_panel.Name = "head_panel";
            this.head_panel.Size = new System.Drawing.Size(867, 38);
            this.head_panel.TabIndex = 0;
            // 
            // btn_minimalize
            // 
            this.btn_minimalize.AutoSize = true;
            this.btn_minimalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btn_minimalize.ForeColor = System.Drawing.Color.White;
            this.btn_minimalize.Location = new System.Drawing.Point(808, -4);
            this.btn_minimalize.Name = "btn_minimalize";
            this.btn_minimalize.Size = new System.Drawing.Size(24, 25);
            this.btn_minimalize.TabIndex = 2;
            this.btn_minimalize.Text = "_";
            this.btn_minimalize.Click += new System.EventHandler(this.Btn_minimalize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btn_exit.ForeColor = System.Drawing.Color.White;
            this.btn_exit.Location = new System.Drawing.Point(838, -1);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(26, 25);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "X";
            this.btn_exit.Click += new System.EventHandler(this.Btn_exit_Click);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_title.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_title.ForeColor = System.Drawing.Color.Black;
            this.lb_title.Location = new System.Drawing.Point(3, 6);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(310, 24);
            this.lb_title.TabIndex = 2;
            this.lb_title.Text = "Křižovatka - systém pro řízení";
            // 
            // panel_left_menu
            // 
            this.panel_left_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel_left_menu.Controls.Add(this.btn_stop);
            this.panel_left_menu.Controls.Add(this.btn_connect);
            this.panel_left_menu.Controls.Add(this.btn_start);
            this.panel_left_menu.Location = new System.Drawing.Point(0, 38);
            this.panel_left_menu.Name = "panel_left_menu";
            this.panel_left_menu.Size = new System.Drawing.Size(117, 504);
            this.panel_left_menu.TabIndex = 1;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(3, 7);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(111, 47);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Připojit zařízení";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(3, 60);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(111, 47);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start křižovatky";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(3, 113);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(111, 47);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop křižovatky";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // timer_day
            // 
            this.timer_day.Interval = 1500;
            this.timer_day.Tick += new System.EventHandler(this.Timer_Day_Tick);
            // 
            // timer_night
            // 
            this.timer_night.Interval = 1000;
            this.timer_night.Tick += new System.EventHandler(this.Timer_Night_Tick);
            // 
            // trafficLightsMajorLeft2
            // 
            this.trafficLightsMajorLeft2.Angle = 0F;
            this.trafficLightsMajorLeft2.Location = new System.Drawing.Point(334, 360);
            this.trafficLightsMajorLeft2.Name = "trafficLightsMajorLeft2";
            this.trafficLightsMajorLeft2.Size = new System.Drawing.Size(106, 72);
            this.trafficLightsMajorLeft2.TabIndex = 3;
            this.trafficLightsMajorLeft2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorMain2
            // 
            this.trafficLightsMajorMain2.Angle = 0F;
            this.trafficLightsMajorMain2.Location = new System.Drawing.Point(370, 360);
            this.trafficLightsMajorMain2.Name = "trafficLightsMajorMain2";
            this.trafficLightsMajorMain2.Size = new System.Drawing.Size(106, 76);
            this.trafficLightsMajorMain2.TabIndex = 5;
            this.trafficLightsMajorMain2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMinorRight1
            // 
            this.trafficLightsMinorRight1.Angle = 90F;
            this.trafficLightsMinorRight1.Location = new System.Drawing.Point(219, 282);
            this.trafficLightsMinorRight1.Name = "trafficLightsMinorRight1";
            this.trafficLightsMinorRight1.Size = new System.Drawing.Size(71, 38);
            this.trafficLightsMinorRight1.TabIndex = 4;
            this.trafficLightsMinorRight1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Single;
            // 
            // trafficLightsMinorMain1
            // 
            this.trafficLightsMinorMain1.Angle = 90F;
            this.trafficLightsMinorMain1.Location = new System.Drawing.Point(219, 245);
            this.trafficLightsMinorMain1.Name = "trafficLightsMinorMain1";
            this.trafficLightsMinorMain1.Size = new System.Drawing.Size(71, 38);
            this.trafficLightsMinorMain1.TabIndex = 2;
            this.trafficLightsMinorMain1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorMain1
            // 
            this.trafficLightsMajorMain1.Angle = 0F;
            this.trafficLightsMajorMain1.Location = new System.Drawing.Point(334, 69);
            this.trafficLightsMajorMain1.Name = "trafficLightsMajorMain1";
            this.trafficLightsMajorMain1.Size = new System.Drawing.Size(106, 72);
            this.trafficLightsMajorMain1.TabIndex = 6;
            this.trafficLightsMajorMain1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorLeft1
            // 
            this.trafficLightsMajorLeft1.Angle = 0F;
            this.trafficLightsMajorLeft1.Location = new System.Drawing.Point(370, 69);
            this.trafficLightsMajorLeft1.Name = "trafficLightsMajorLeft1";
            this.trafficLightsMajorLeft1.Size = new System.Drawing.Size(106, 76);
            this.trafficLightsMajorLeft1.TabIndex = 7;
            this.trafficLightsMajorLeft1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMinorMain2
            // 
            this.trafficLightsMinorMain2.Angle = 90F;
            this.trafficLightsMinorMain2.Location = new System.Drawing.Point(539, 209);
            this.trafficLightsMinorMain2.Name = "trafficLightsMinorMain2";
            this.trafficLightsMinorMain2.Size = new System.Drawing.Size(71, 38);
            this.trafficLightsMinorMain2.TabIndex = 8;
            this.trafficLightsMinorMain2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMinorRight2
            // 
            this.trafficLightsMinorRight2.Angle = 90F;
            this.trafficLightsMinorRight2.Location = new System.Drawing.Point(503, 171);
            this.trafficLightsMinorRight2.Name = "trafficLightsMinorRight2";
            this.trafficLightsMinorRight2.Size = new System.Drawing.Size(71, 38);
            this.trafficLightsMinorRight2.TabIndex = 9;
            this.trafficLightsMinorRight2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Single;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(860, 531);
            this.Controls.Add(this.trafficLightsMinorMain2);
            this.Controls.Add(this.trafficLightsMinorRight2);
            this.Controls.Add(this.trafficLightsMajorMain1);
            this.Controls.Add(this.trafficLightsMajorLeft1);
            this.Controls.Add(this.trafficLightsMajorLeft2);
            this.Controls.Add(this.trafficLightsMajorMain2);
            this.Controls.Add(this.trafficLightsMinorRight1);
            this.Controls.Add(this.trafficLightsMinorMain1);
            this.Controls.Add(this.panel_left_menu);
            this.Controls.Add(this.head_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Crossroad - created by Jakub Tenk";
            this.head_panel.ResumeLayout(false);
            this.head_panel.PerformLayout();
            this.panel_left_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel head_panel;
        private System.Windows.Forms.Panel panel_left_menu;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label btn_minimalize;
        private System.Windows.Forms.Label btn_exit;
        private System.Windows.Forms.Timer timer_day;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Timer timer_night;
        private TrafficLights trafficLightsMinorMain1;
        private System.Windows.Forms.Button btn_connect;
        private TrafficLights trafficLightsMajorLeft2;
        private TrafficLights trafficLightsMinorRight1;
        private TrafficLights trafficLightsMajorMain2;
        private TrafficLights trafficLightsMajorMain1;
        private TrafficLights trafficLightsMajorLeft1;
        private TrafficLights trafficLightsMinorMain2;
        private TrafficLights trafficLightsMinorRight2;
    }
}

