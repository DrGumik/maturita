/// <summary>
/// Model křižovatky, created by Jakub Tenk
/// 
/// Dokumentace zapojeni:
///  Karta 1:
///    Digital channel OUT:
///     ch1 = vedlejsi cervena
///     ch2 = vedlejsi zluta
///     ch3 = vedlejsi zelena
///     ch4 = vedlejsi zelena šipka
///     ch5 = hlavni doleva cervena
///     ch6 = hlavni doleva zluta
///     ch7 = hlavni doleva zelena
///     ch8 = hlavni cervena
/// 
///  Karta 2:
///    Digital channel OUT:
///     ch1 = hlavni zluta
///     ch2 = hlavni zelena
///     ch3 = chodci vedlejsi cervena
///     ch4 = chodci vedlejsi zelena
///     ch5 = chodci hlavni cervena
///     ch6 = chodci hlavni zelena
///     
///    Digital channel IN:
///     ch1 = Tlacitko A - nocni rezim
///     ch2 = Tlacitko B - denni rezim
/// 
/// </summary>

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using crossroad_tenk.Enums;

namespace crossroad_tenk
{
  public partial class Form1 : Form
  {
    // Importovani knihovny s pozadovanymi funkcemi
    [DllImport("k8055d.dll")]
    public static extern int OpenDevice(int CardAddress);

    [DllImport("k8055d.dll")]
    public static extern void CloseDevice();

    [DllImport("k8055d.dll")]
    public static extern void ClearAllDigital();

    [DllImport("k8055d.dll")]
    public static extern void SetDigitalChannel(int Channel);

    [DllImport("k8055d.dll")]
    public static extern int ReadAllDigital();

    [DllImport("k8055d.dll")]
    public static extern int Version();

    [DllImport("k8055d.dll")]
    public static extern int SetCurrentDevice(int lngCardAddress);


    bool devicesConnectionStatus = false; // Status zda karty jsou pripojeny
    int numOfTicks = 0; // Pocet tiku timeru day/night

    public Form1()
    {
      InitializeComponent();
      btn_stop.Visible = false;
    }

    private void btn_connect_Click(object sender, EventArgs e)
    {
      // Pripojeni karet
      OpenDevice(0);
      OpenDevice(1);

      int statusDeviceOne = SetCurrentDevice(0);
      int statusDeviceTwo = SetCurrentDevice(1);

      // Kontrola stavu karet zda jsou pripojeny
      if (statusDeviceOne != -1 && statusDeviceTwo != -1)
      {
        devicesConnectionStatus = true;
        lbl_log.Text = "LOG: Zařízení bylo připojeno! \nVerze knihovny: " + Version();
      }
      else
        lbl_log.Text = "LOG: Zařízení se nepodařilo připojit! \nVerze knihovny: " + Version();
    }

    private void Btn_start_Click(object sender, EventArgs e)
    {
      // Pokud jsou karty pripojeny, tak se spusti krizovatka
      if (devicesConnectionStatus)
      {
        // Prepnuti do stavu chodu krizovatky
        btn_start.Visible = false;
        btn_connect.Visible = false;
        btn_stop.Visible = true;
        timer_day.Enabled = true;
        timer_btn_states.Enabled = true;
        lbl_log.Text = "LOG: Křižovatka zapnuta!";

        // Zapnuti timeru
        timer_day.Start();
        timer_btn_states.Start();
      }            
    }

    private void Btn_stop_Click(object sender, EventArgs e)
    {
      numOfTicks = 0;

      // Prepnuti do stavu cekani na pripojeni a na start
      btn_start.Visible = true;
      btn_connect.Visible = true;
      btn_stop.Visible = false;
      timer_day.Enabled = false;
      timer_night.Enabled = false;
      timer_btn_states.Enabled = false;
      devicesConnectionStatus = false;
      lbl_log.Text = "LOG: Křižovatka vypnuta! Pro zapnutí znovu připojte zařízení...";

      // Vypnuti vsech timeru
      timer_day.Stop();
      timer_night.Stop();
      timer_btn_states.Stop();

      // Vynulovani vsech vstupu na kartach (vypnuti semaforu)
      SetCurrentDevice(0);
      ClearAllDigital();
      CloseDevice();

      SetCurrentDevice(1);
      ClearAllDigital();
      CloseDevice();

      // Vypne semafory v UI
      trafficLightsMajorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsMajorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

      trafficLightsMajorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsMajorLeft2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

      trafficLightsMinorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsMinorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

      trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

      trafficLightsPedestrainMajorTop1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMajorTop2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMajorBottom1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMajorBottom2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

      trafficLightsPedestrainMinorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMinorLeft2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
      trafficLightsPedestrainMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
    }

    private void Btn_minimalize_Click(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Minimized;
    }

    private void Btn_exit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    /// <summary>
    /// Vysvetleni promennych:
    ///  trafficLightsMajorMain == semafor hlavni silnice rovne
    ///  trafficLightsMajorLeft == semafor hlavni silnice doleva
    ///  trafficLightsPedestrainMajor == semafor chodcu pres hlavni silnici
    ///  trafficLightsPedestrainMinorRight == semafor chodcu pres vedlejsi silnici
    ///  trafficLightsMinorMain == semafor vedlejsi silnice rovne
    ///  trafficLightsMinorRight == semafor vedlejsi silnice doprava
    /// </summary>
    private void Timer_Day_Tick(object sender, EventArgs e)
    {
      // Obsluha denniho sviceni krizovatky, numOfTicks == promenna, kolikrat timer tiknul
      numOfTicks++;

      switch (numOfTicks)
      {
        case 1:
          // Prepnuti na 2. kartu
          SetCurrentDevice(1);
          ClearAllDigital();

          trafficLightsMajorMain1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(2);

          trafficLightsPedestrainMajorTop1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorTop2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(5);

          trafficLightsPedestrainMinorLeft1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorLeft2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorRight1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorRight2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(4);

          // Prepnuti na 1. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(5);


          trafficLightsMinorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(1);

          trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
          trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

          break;
        case 6:
          // Prepnuti na 2. kartu
          SetCurrentDevice(1);
          ClearAllDigital();

          // trafficLightsPedestrainMajor - RED
          SetDigitalChannel(5);

          trafficLightsPedestrainMinorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorRight1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMinorRight2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(3);

          trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          SetDigitalChannel(1);

          // Prepnuti na 1. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          SetDigitalChannel(6);
          SetDigitalChannel(5);
                    
          // trafficLightsMinorMain - RED
          SetDigitalChannel(1);

          break;
        case 7:
          // Prepnuti na 2. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(8);

          trafficLightsMajorLeft1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(7);

          // trafficLightsMinorMain - RED
          SetDigitalChannel(1);

          trafficLightsMinorRight1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsMinorRight2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(4);

          break;
        case 12:
          // Prepnuti na 2. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(8);

          trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          SetDigitalChannel(6);

          trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          SetDigitalChannel(2);
          SetDigitalChannel(1);

          trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
          trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

          break;
        case 13:
          // Prepnuti na 2. kartu
          SetCurrentDevice(1);
          ClearAllDigital();

          trafficLightsPedestrainMajorTop1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorTop2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(6);

          // trafficLightsPedestrainMinor - RED
          SetDigitalChannel(3);

          // Prepnuti na 1. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          // trafficLightsMajorMain - RED
          SetDigitalChannel(8);

          trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(5);

          trafficLightsMinorMain1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(3);

          trafficLightsMinorRight1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          trafficLightsMinorRight2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
          SetDigitalChannel(4);

          break;
        case 18:
          // Prepnuti na 2. kartu
          SetCurrentDevice(1);
          ClearAllDigital();

          trafficLightsPedestrainMajorTop1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorTop2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          trafficLightsPedestrainMajorBottom2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
          SetDigitalChannel(5);

          // trafficLightsPedestrainMinor - RED
          SetDigitalChannel(3);

          trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
          SetDigitalChannel(1);

          // Prepnuti na 1. kartu
          SetCurrentDevice(0);
          ClearAllDigital();

          // trafficLightsMajorMain - RED
          SetDigitalChannel(8);

          // trafficLightsMajorLeft - RED
          SetDigitalChannel(5);

          trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          SetDigitalChannel(2);

          trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
          trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
          numOfTicks = 0;

          break;
        default:
          break;
      }
    }
    private void Timer_Night_Tick(object sender, EventArgs e)
    {
      // Obsluha nocniho sviceni krizovatky, numOfTicks == promenna, kolikrat timer tiknul
      switch (numOfTicks)
      {
        case 0:
          SetCurrentDevice(1);
          ClearAllDigital();

          SetCurrentDevice(0);
          ClearAllDigital();

          trafficLightsMinorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
          trafficLightsMajorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
          trafficLightsMajorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);

          numOfTicks = 1;

          break;
        case 1:
          SetCurrentDevice(1);
          ClearAllDigital();

          SetDigitalChannel(1);

          trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMinorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
          trafficLightsMajorLeft2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);

          SetCurrentDevice(0);
          ClearAllDigital();

          SetDigitalChannel(2);
          SetDigitalChannel(6);

          numOfTicks = 0;

          break;
      }
    }

    private void Timer_btn_states_Tick(object sender, EventArgs e)
    {
        // Prepnuti na 2. kartu 
        SetCurrentDevice(1);

        // Precte digitalni vstupy karty a podle toho vyhodnoti
        switch(ReadAllDigital())
        {
          case 1:
            timer_day.Enabled = false;
            timer_night.Enabled = true;
            numOfTicks = 0;

            timer_day.Stop();
            timer_night.Start();

            break;
          case 2:
            timer_day.Enabled = true;
            timer_night.Enabled = false;
            numOfTicks = 0;

            timer_day.Start();
            timer_night.Stop();

            break;
          default:
            break;
        }

    }

    /// <summary> 
    /// Přesunutí okna myší (jelikož styl ohraničení aplikace je nastaveno na none, protože mám vlastí, 
    /// tak zde musí být tato funkce, která nám umožní hýbat s oknem aplikace)
    /// Zdroj: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
    /// </summary>
        
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    private void Form_mouse_down(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }
  }
}
