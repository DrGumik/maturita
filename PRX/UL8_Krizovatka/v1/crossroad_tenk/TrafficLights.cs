using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using crossroad_tenk.Enums;

namespace crossroad_tenk
{
    public partial class TrafficLights : UserControl
    {
        private float angle = 0.0F;
        private int lightX = 7;
        private int width = 20;
        private int hight = 20;
        private int dispersion = 2;

        private TrafficLightType trafficLightType = TrafficLightType.Normal;
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush yellowBrush = new SolidBrush(Color.Yellow);
        private Brush greenBrush = new SolidBrush(Color.LimeGreen);
        private Brush blackBrush = new SolidBrush(Color.Black);
        private Brush grayBrush = new SolidBrush(Color.Gray);
        

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public TrafficLightType TrafficLightType 
        { 
            get { return trafficLightType; }
            set { trafficLightType = value; }
        }


        public TrafficLights()
        {
            InitializeComponent();
        }

        private void SetDefaultRotate(Graphics graphics)
        {
            graphics.TranslateTransform(70.0F, 0.0F);
            graphics.RotateTransform(angle);
        }

        private Brush GetBrush(TrafficLight color = TrafficLight.Default) 
        { 
            switch(color)
            {
                case TrafficLight.Green:
                    return greenBrush;
                case TrafficLight.Red:
                    return redBrush;
                case TrafficLight.Yellow:
                    return yellowBrush;
                case TrafficLight.Default:
                    return grayBrush;
            }

            return grayBrush;
        }

        private int GetLightY(TrafficLight color = TrafficLight.Red)
        {
            if (trafficLightType == TrafficLightType.Single) return 7;

            int y = 0;
            switch (color)
            {
                case TrafficLight.Red:
                    y = 0;
                    break;
                case TrafficLight.Yellow:
                    y = 22;
                    break;
                case TrafficLight.Green:
                    y = 44;
                    break;
            }

            return y + dispersion;
        }

        private void DrawLight(Graphics graphics, int lightY, TrafficLight color = TrafficLight.Default)
        {
            graphics.FillEllipse(this.GetBrush(color), lightX, lightY, width, hight);
        }

        private void DrawDefaultLight(Graphics graphics)
        {
            this.DrawLight(graphics, this.GetLightY(TrafficLight.Red));
            
            if (trafficLightType == TrafficLightType.Normal)
            {
                this.DrawLight(graphics, this.GetLightY(TrafficLight.Yellow));
                this.DrawLight(graphics, this.GetLightY(TrafficLight.Green));
            }
        }


        private void GenerateTrafficLight(Graphics graphics)
        {
            int radius = 12;
            int diameter = radius * 2;

            Rectangle coords = new Rectangle();
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(coords.Location, size);

            GraphicsPath path = new GraphicsPath();
            this.SetDefaultRotate(graphics);

            switch (trafficLightType) 
            {
                case TrafficLightType.Normal:
                    coords = new Rectangle(0, 0, 34, 70);
                    arc = new Rectangle(coords.Location, size);
                    
                    // top left arc  
                    path.AddArc(arc, 180, 90);

                    // top right arc  
                    arc.X = coords.Right - diameter;
                    path.AddArc(arc, 270, 90);

                    // bottom right arc  
                    arc.Y = coords.Bottom - diameter;
                    path.AddArc(arc, 0, 90);

                    // bottom left arc 
                    arc.X = coords.Left;
                    path.AddArc(arc, 90, 90);

                    graphics.FillPath(blackBrush, path);
                                                          
                    break;

                case TrafficLightType.Single:
                    coords = new Rectangle(0, 0, 34, 34);
                    arc = new Rectangle(coords.Location, size);
                    
                    // top left arc  
                    path.AddArc(arc, 180, 90);

                    // top right arc  
                    arc.X = coords.Right - diameter;
                    path.AddArc(arc, 270, 90);

                    // bottom right arc  
                    arc.Y = coords.Bottom - diameter;
                    path.AddArc(arc, 0, 90);

                    // bottom left arc 
                    arc.X = coords.Left;
                    path.AddArc(arc, 90, 90);

                    graphics.FillPath(blackBrush, path);
                                        
                    break;
            }

            this.DrawDefaultLight(graphics);
            
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            // Zavolani funkce k vygenerovani semaforu
            GenerateTrafficLight(e.Graphics);
        }

        public void TurnLight(TrafficLight color, TrafficLightRegime regime)
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                this.SetDefaultRotate(graphics);
                this.DrawDefaultLight(graphics);

                if (color == TrafficLight.Yellow && regime == TrafficLightRegime.Day)
                    this.DrawLight(graphics, this.GetLightY(TrafficLight.Red), TrafficLight.Red);
                
                this.DrawLight(graphics, this.GetLightY(color), color);
            }
        }

    }
}
