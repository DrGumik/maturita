using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using crossroad_tenk.Enums;

namespace crossroad_tenk
{
  public partial class TrafficLights : UserControl
  {
    private float angle = 0.0F; // Zakladni uhel
    private int lightX = 7; // X souradnice svetel
    private int width = 20; // Sirka svetel
    private int hight = 20; // Vyska svetel
    private int dispersion = 2; // Rozptyl mezi svetly
    private int radius = 12; // Radius zaobleni semaforu

    // Enum - typ semaforu
    private TrafficLightType trafficLightType = TrafficLightType.Normal;
    // Nadefinovani stetcu danych barev
    private Brush redBrush = new SolidBrush(Color.Red);
    private Brush yellowBrush = new SolidBrush(Color.Yellow);
    private Brush greenBrush = new SolidBrush(Color.LimeGreen);
    private Brush blackBrush = new SolidBrush(Color.Black);
    private Brush grayBrush = new SolidBrush(Color.Gray);
        
    // Vlastnost objektu, pod jakym uhlem vykresli semafor
    public float Angle
    {
      get { return angle; }
      set { angle = value; }
    }

    // Vlastnost objektu, o jaky typ semaforu se jedna (Normal, Single, Pedestrian)
    public TrafficLightType TrafficLightType 
    { 
      get { return trafficLightType; }
      set { trafficLightType = value; }
    }

    public TrafficLights()
    {
      InitializeComponent();
    }

    // Metoda pro nastaveni zakladni rotace
    private void SetDefaultRotate(Graphics graphics)
    {
      graphics.TranslateTransform(70.0F, 70.0F);
      graphics.RotateTransform(angle);
    }

    // Metoda pro ziskani stetce s pozadovanou barvou
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

    // Metoda pro ziskani Y souradnice dane ho svetla na danym typu semaforu
    private int GetLightY(TrafficLight color = TrafficLight.Red)
    {
      if (trafficLightType == TrafficLightType.Single) return 7;
      if (trafficLightType == TrafficLightType.Pedestrian && color == TrafficLight.Green) return 22;

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

    // Metoda pro vykresleni svetla na semaforu
    private void DrawLight(Graphics graphics, int lightY, TrafficLight color = TrafficLight.Default)
    {
      graphics.FillEllipse(this.GetBrush(color), lightX, lightY, width, hight);
    }

    // Metoda pro vykresleni svetel na semaforu na zacatku programu
    private void DrawDefaultLight(Graphics graphics)
    {
      this.DrawLight(graphics, this.GetLightY(TrafficLight.Red));
            
      if (trafficLightType == TrafficLightType.Normal)
      {
        this.DrawLight(graphics, this.GetLightY(TrafficLight.Yellow));
        this.DrawLight(graphics, this.GetLightY(TrafficLight.Green));
      } else if (trafficLightType == TrafficLightType.Pedestrian)
      {
        this.DrawLight(graphics, this.GetLightY(TrafficLight.Green));
      }
    }

    // Metoda pro vykresleni celeho semaforu (vola se jen na zacatku programu)
    // Hrany semaforu jsou zaoblene (velikost - promenna radius)
    private void GenerateTrafficLight(Graphics graphics)
    {
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
                                                          
          break;
        case TrafficLightType.Single:
          coords = new Rectangle(0, 0, 34, 34);
          arc = new Rectangle(coords.Location, size);
                                        
          break;
        case TrafficLightType.Pedestrian:
          coords = new Rectangle(0, 0, 34, 46);
          arc = new Rectangle(coords.Location, size);

          break;
      }

      // horni levy oblouk
      path.AddArc(arc, 180, 90);

      // horni pravy oblouk 
      arc.X = coords.Right - diameter;
      path.AddArc(arc, 270, 90);

      // dolni pravy oblouk 
      arc.Y = coords.Bottom - diameter;
      path.AddArc(arc, 0, 90);

      // dolni levy oblouk
      arc.X = coords.Left;
      path.AddArc(arc, 90, 90);

      graphics.FillPath(blackBrush, path);

      this.DrawDefaultLight(graphics);
    }

    private void GameBoard_Paint(object sender, PaintEventArgs e)
    {
      // Zavolani metody k vygenerovani semaforu
      GenerateTrafficLight(e.Graphics);
    }

    // Metoda pro rozsviceni svetla na semaforu
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
