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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.head_panel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.btn_minimalize = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Label();
            this.lb_title = new System.Windows.Forms.Label();
            this.panel_left_menu = new System.Windows.Forms.Panel();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_log = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer_day = new System.Windows.Forms.Timer(this.components);
            this.timer_night = new System.Windows.Forms.Timer(this.components);
            this.timer_btn_states = new System.Windows.Forms.Timer(this.components);
            this.trafficLightsPedestrainMinorRight2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorMain1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorRight2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorMain2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorMain1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorLeft2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorMain2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMinorRight1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsMajorLeft1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMinorLeft1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMinorLeft2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMinorRight1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMajorTop1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMajorTop2 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMajorBottom1 = new crossroad_tenk.TrafficLights();
            this.trafficLightsPedestrainMajorBottom2 = new crossroad_tenk.TrafficLights();
            this.lbl_info = new System.Windows.Forms.Label();
            this.head_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.panel_left_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // head_panel
            // 
            this.head_panel.BackColor = System.Drawing.Color.Firebrick;
            this.head_panel.Controls.Add(this.logo);
            this.head_panel.Controls.Add(this.btn_minimalize);
            this.head_panel.Controls.Add(this.btn_exit);
            this.head_panel.Controls.Add(this.lb_title);
            this.head_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.head_panel.Location = new System.Drawing.Point(0, 0);
            this.head_panel.Name = "head_panel";
            this.head_panel.Size = new System.Drawing.Size(862, 45);
            this.head_panel.TabIndex = 0;
            this.head_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_mouse_down);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(1, 2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(48, 42);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 3;
            this.logo.TabStop = false;
            this.logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_mouse_down);
            // 
            // btn_minimalize
            // 
            this.btn_minimalize.AutoSize = true;
            this.btn_minimalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btn_minimalize.ForeColor = System.Drawing.Color.White;
            this.btn_minimalize.Location = new System.Drawing.Point(806, 0);
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
            this.btn_exit.Location = new System.Drawing.Point(836, 0);
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
            this.lb_title.ForeColor = System.Drawing.Color.White;
            this.lb_title.Location = new System.Drawing.Point(55, 10);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(310, 24);
            this.lb_title.TabIndex = 2;
            this.lb_title.Text = "Křižovatka - systém pro řízení";
            this.lb_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_mouse_down);
            // 
            // panel_left_menu
            // 
            this.panel_left_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel_left_menu.Controls.Add(this.lbl_info);
            this.panel_left_menu.Controls.Add(this.lbl_author);
            this.panel_left_menu.Controls.Add(this.lbl_log);
            this.panel_left_menu.Controls.Add(this.btn_stop);
            this.panel_left_menu.Controls.Add(this.btn_connect);
            this.panel_left_menu.Controls.Add(this.btn_start);
            this.panel_left_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left_menu.Location = new System.Drawing.Point(0, 45);
            this.panel_left_menu.Name = "panel_left_menu";
            this.panel_left_menu.Size = new System.Drawing.Size(141, 620);
            this.panel_left_menu.TabIndex = 1;
            // 
            // lbl_author
            // 
            this.lbl_author.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_author.ForeColor = System.Drawing.Color.White;
            this.lbl_author.Location = new System.Drawing.Point(0, 597);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(141, 23);
            this.lbl_author.TabIndex = 6;
            this.lbl_author.Text = "Vytvořil Jakub Tenk";
            this.lbl_author.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_log
            // 
            this.lbl_log.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_log.ForeColor = System.Drawing.Color.White;
            this.lbl_log.Location = new System.Drawing.Point(3, 158);
            this.lbl_log.Name = "lbl_log";
            this.lbl_log.Size = new System.Drawing.Size(135, 60);
            this.lbl_log.TabIndex = 5;
            this.lbl_log.Text = "LOG:";
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.Firebrick;
            this.btn_stop.FlatAppearance.BorderSize = 0;
            this.btn_stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btn_stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_stop.ForeColor = System.Drawing.Color.White;
            this.btn_stop.Location = new System.Drawing.Point(3, 40);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(135, 47);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop křižovatky";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.Firebrick;
            this.btn_connect.FlatAppearance.BorderSize = 0;
            this.btn_connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btn_connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connect.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_connect.ForeColor = System.Drawing.Color.White;
            this.btn_connect.Location = new System.Drawing.Point(3, 40);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(135, 47);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Připojit zařízení";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Firebrick;
            this.btn_start.FlatAppearance.BorderSize = 0;
            this.btn_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btn_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(3, 93);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(135, 47);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start křižovatky";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // timer_day
            // 
            this.timer_day.Interval = 3000;
            this.timer_day.Tick += new System.EventHandler(this.Timer_Day_Tick);
            // 
            // timer_night
            // 
            this.timer_night.Interval = 1000;
            this.timer_night.Tick += new System.EventHandler(this.Timer_Night_Tick);
            // 
            // timer_btn_states
            // 
            this.timer_btn_states.Interval = 5;
            this.timer_btn_states.Tick += new System.EventHandler(this.Timer_btn_states_Tick);
            // 
            // trafficLightsPedestrainMinorRight2
            // 
            this.trafficLightsPedestrainMinorRight2.Angle = 0F;
            this.trafficLightsPedestrainMinorRight2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMinorRight2.Location = new System.Drawing.Point(632, 404);
            this.trafficLightsPedestrainMinorRight2.Name = "trafficLightsPedestrainMinorRight2";
            this.trafficLightsPedestrainMinorRight2.Size = new System.Drawing.Size(109, 120);
            this.trafficLightsPedestrainMinorRight2.TabIndex = 10;
            this.trafficLightsPedestrainMinorRight2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsMinorMain1
            // 
            this.trafficLightsMinorMain1.Angle = 90F;
            this.trafficLightsMinorMain1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMinorMain1.Location = new System.Drawing.Point(303, 323);
            this.trafficLightsMinorMain1.Name = "trafficLightsMinorMain1";
            this.trafficLightsMinorMain1.Size = new System.Drawing.Size(103, 107);
            this.trafficLightsMinorMain1.TabIndex = 2;
            this.trafficLightsMinorMain1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMinorRight2
            // 
            this.trafficLightsMinorRight2.Angle = 270F;
            this.trafficLightsMinorRight2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMinorRight2.Location = new System.Drawing.Point(598, 248);
            this.trafficLightsMinorRight2.Name = "trafficLightsMinorRight2";
            this.trafficLightsMinorRight2.Size = new System.Drawing.Size(107, 73);
            this.trafficLightsMinorRight2.TabIndex = 9;
            this.trafficLightsMinorRight2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Single;
            // 
            // trafficLightsMinorMain2
            // 
            this.trafficLightsMinorMain2.Angle = 270F;
            this.trafficLightsMinorMain2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMinorMain2.Location = new System.Drawing.Point(562, 286);
            this.trafficLightsMinorMain2.Name = "trafficLightsMinorMain2";
            this.trafficLightsMinorMain2.Size = new System.Drawing.Size(144, 74);
            this.trafficLightsMinorMain2.TabIndex = 8;
            this.trafficLightsMinorMain2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorMain1
            // 
            this.trafficLightsMajorMain1.Angle = 180F;
            this.trafficLightsMajorMain1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMajorMain1.Location = new System.Drawing.Point(354, 204);
            this.trafficLightsMajorMain1.Name = "trafficLightsMajorMain1";
            this.trafficLightsMajorMain1.Size = new System.Drawing.Size(70, 74);
            this.trafficLightsMajorMain1.TabIndex = 6;
            this.trafficLightsMajorMain1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorLeft2
            // 
            this.trafficLightsMajorLeft2.Angle = 0F;
            this.trafficLightsMajorLeft2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMajorLeft2.Location = new System.Drawing.Point(428, 407);
            this.trafficLightsMajorLeft2.Name = "trafficLightsMajorLeft2";
            this.trafficLightsMajorLeft2.Size = new System.Drawing.Size(106, 142);
            this.trafficLightsMajorLeft2.TabIndex = 3;
            this.trafficLightsMajorLeft2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMajorMain2
            // 
            this.trafficLightsMajorMain2.Angle = 0F;
            this.trafficLightsMajorMain2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMajorMain2.Location = new System.Drawing.Point(511, 407);
            this.trafficLightsMajorMain2.Name = "trafficLightsMajorMain2";
            this.trafficLightsMajorMain2.Size = new System.Drawing.Size(106, 142);
            this.trafficLightsMajorMain2.TabIndex = 5;
            this.trafficLightsMajorMain2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsMinorRight1
            // 
            this.trafficLightsMinorRight1.Angle = 90F;
            this.trafficLightsMinorRight1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMinorRight1.Location = new System.Drawing.Point(268, 361);
            this.trafficLightsMinorRight1.Name = "trafficLightsMinorRight1";
            this.trafficLightsMinorRight1.Size = new System.Drawing.Size(82, 108);
            this.trafficLightsMinorRight1.TabIndex = 4;
            this.trafficLightsMinorRight1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Single;
            // 
            // trafficLightsMajorLeft1
            // 
            this.trafficLightsMajorLeft1.Angle = 180F;
            this.trafficLightsMajorLeft1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsMajorLeft1.Location = new System.Drawing.Point(440, 204);
            this.trafficLightsMajorLeft1.Name = "trafficLightsMajorLeft1";
            this.trafficLightsMajorLeft1.Size = new System.Drawing.Size(74, 74);
            this.trafficLightsMajorLeft1.TabIndex = 7;
            this.trafficLightsMajorLeft1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Normal;
            // 
            // trafficLightsPedestrainMinorLeft1
            // 
            this.trafficLightsPedestrainMinorLeft1.Angle = 180F;
            this.trafficLightsPedestrainMinorLeft1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMinorLeft1.Location = new System.Drawing.Point(235, 203);
            this.trafficLightsPedestrainMinorLeft1.Name = "trafficLightsPedestrainMinorLeft1";
            this.trafficLightsPedestrainMinorLeft1.Size = new System.Drawing.Size(74, 73);
            this.trafficLightsPedestrainMinorLeft1.TabIndex = 11;
            this.trafficLightsPedestrainMinorLeft1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMinorLeft2
            // 
            this.trafficLightsPedestrainMinorLeft2.Angle = 0F;
            this.trafficLightsPedestrainMinorLeft2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMinorLeft2.Location = new System.Drawing.Point(203, 407);
            this.trafficLightsPedestrainMinorLeft2.Name = "trafficLightsPedestrainMinorLeft2";
            this.trafficLightsPedestrainMinorLeft2.Size = new System.Drawing.Size(105, 117);
            this.trafficLightsPedestrainMinorLeft2.TabIndex = 12;
            this.trafficLightsPedestrainMinorLeft2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMinorRight1
            // 
            this.trafficLightsPedestrainMinorRight1.Angle = 180F;
            this.trafficLightsPedestrainMinorRight1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMinorRight1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trafficLightsPedestrainMinorRight1.Location = new System.Drawing.Point(667, 205);
            this.trafficLightsPedestrainMinorRight1.Name = "trafficLightsPedestrainMinorRight1";
            this.trafficLightsPedestrainMinorRight1.Size = new System.Drawing.Size(74, 73);
            this.trafficLightsPedestrainMinorRight1.TabIndex = 13;
            this.trafficLightsPedestrainMinorRight1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMajorTop1
            // 
            this.trafficLightsPedestrainMajorTop1.Angle = 90F;
            this.trafficLightsPedestrainMajorTop1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMajorTop1.Location = new System.Drawing.Point(289, 98);
            this.trafficLightsPedestrainMajorTop1.Name = "trafficLightsPedestrainMajorTop1";
            this.trafficLightsPedestrainMajorTop1.Size = new System.Drawing.Size(73, 108);
            this.trafficLightsPedestrainMajorTop1.TabIndex = 14;
            this.trafficLightsPedestrainMajorTop1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMajorTop2
            // 
            this.trafficLightsPedestrainMajorTop2.Angle = 270F;
            this.trafficLightsPedestrainMajorTop2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMajorTop2.Location = new System.Drawing.Point(573, 134);
            this.trafficLightsPedestrainMajorTop2.Name = "trafficLightsPedestrainMajorTop2";
            this.trafficLightsPedestrainMajorTop2.Size = new System.Drawing.Size(121, 72);
            this.trafficLightsPedestrainMajorTop2.TabIndex = 15;
            this.trafficLightsPedestrainMajorTop2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMajorBottom1
            // 
            this.trafficLightsPedestrainMajorBottom1.Angle = 90F;
            this.trafficLightsPedestrainMajorBottom1.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMajorBottom1.Location = new System.Drawing.Point(292, 475);
            this.trafficLightsPedestrainMajorBottom1.Name = "trafficLightsPedestrainMajorBottom1";
            this.trafficLightsPedestrainMajorBottom1.Size = new System.Drawing.Size(73, 108);
            this.trafficLightsPedestrainMajorBottom1.TabIndex = 16;
            this.trafficLightsPedestrainMajorBottom1.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // trafficLightsPedestrainMajorBottom2
            // 
            this.trafficLightsPedestrainMajorBottom2.Angle = 270F;
            this.trafficLightsPedestrainMajorBottom2.BackColor = System.Drawing.Color.Transparent;
            this.trafficLightsPedestrainMajorBottom2.Location = new System.Drawing.Point(572, 510);
            this.trafficLightsPedestrainMajorBottom2.Name = "trafficLightsPedestrainMajorBottom2";
            this.trafficLightsPedestrainMajorBottom2.Size = new System.Drawing.Size(121, 73);
            this.trafficLightsPedestrainMajorBottom2.TabIndex = 17;
            this.trafficLightsPedestrainMajorBottom2.TrafficLightType = crossroad_tenk.Enums.TrafficLightType.Pedestrian;
            // 
            // lbl_info
            // 
            this.lbl_info.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_info.ForeColor = System.Drawing.Color.White;
            this.lbl_info.Location = new System.Drawing.Point(-2, 14);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(143, 23);
            this.lbl_info.TabIndex = 7;
            this.lbl_info.Text = "Ovládání";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(862, 665);
            this.Controls.Add(this.trafficLightsPedestrainMinorRight2);
            this.Controls.Add(this.trafficLightsPedestrainMajorTop2);
            this.Controls.Add(this.trafficLightsPedestrainMinorRight1);
            this.Controls.Add(this.trafficLightsPedestrainMinorLeft1);
            this.Controls.Add(this.trafficLightsMinorMain1);
            this.Controls.Add(this.trafficLightsMinorRight2);
            this.Controls.Add(this.trafficLightsMinorMain2);
            this.Controls.Add(this.trafficLightsMinorRight1);
            this.Controls.Add(this.panel_left_menu);
            this.Controls.Add(this.head_panel);
            this.Controls.Add(this.trafficLightsPedestrainMinorLeft2);
            this.Controls.Add(this.trafficLightsPedestrainMajorTop1);
            this.Controls.Add(this.trafficLightsMajorMain1);
            this.Controls.Add(this.trafficLightsMajorLeft1);
            this.Controls.Add(this.trafficLightsPedestrainMajorBottom1);
            this.Controls.Add(this.trafficLightsMajorLeft2);
            this.Controls.Add(this.trafficLightsMajorMain2);
            this.Controls.Add(this.trafficLightsPedestrainMajorBottom2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Crossroad - created by Jakub Tenk";
            this.head_panel.ResumeLayout(false);
            this.head_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
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
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Timer timer_btn_states;
        private System.Windows.Forms.Label lbl_log;
        private System.Windows.Forms.Label lbl_author;
        private TrafficLights trafficLightsPedestrainMinorRight2;
        private TrafficLights trafficLightsPedestrainMinorLeft1;
        private TrafficLights trafficLightsPedestrainMinorLeft2;
        private TrafficLights trafficLightsPedestrainMajorTop1;
        private TrafficLights trafficLightsPedestrainMajorTop2;
        private TrafficLights trafficLightsPedestrainMajorBottom1;
        private TrafficLights trafficLightsPedestrainMajorBottom2;
        private TrafficLights trafficLightsPedestrainMinorRight1;
        private System.Windows.Forms.Label lbl_info;
    }
}

