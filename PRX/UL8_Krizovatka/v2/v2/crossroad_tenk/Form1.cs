/// <summary>
/// Model křižovatky:
/// Zpracujte program v programovacím jazyce C# ovládající model křižovatky tak, aby obsahoval
/// nejméně tyto funkce:
///     1) funkce řízení světel křižovatky respektuje pravidla silničního provozu
///     2) pomocí tlačítek modelu přepínejte režim denní/noční(volitelně plná/zjednodušená křižovatka)
///     3) na monitoru počítače zobrazujte aktuální stav světel křižovatky, případně režimu činnosti 
///     křižovatky
///     
/// Karta 1:
///     Channel OUT:
///     ch0 = vedlejší červená
///     ch1 = vedlejší žlutá
///     ch2 = vedlejší zelená
///     ch3 = vedlejší zelená šipka
///     ch4 = hlavni doleva červená
///     ch5 = hlavní doleva žlutá
///     ch6 = hlavní doleva zelená
///     ch7 = hlavní červená
/// 
/// Karta 2:
///     Channel OUT:
///     ch0 = hlavní žlutá
///     ch1 = hlavní zelená
///     ch2 = chodci vedlejší
///     ch3 = chodci hlavní
///     
///     Channel IN:
///     ch0 = BTN 1
///     ch1 = BTN 2
/// 
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
        [DllImport("k8055d.dll")]
        public static extern int OpenDevice(int CardAddress);
        [DllImport("k8055d.dll")]
        public static extern void CloseDevice();
        [DllImport("k8055d.dll")]
        public static extern void WriteAllDigital(int Data);
        [DllImport("k8055d.dll")]
        public static extern void ClearDigitalChannel(int Channel);
        [DllImport("k8055d.dll")]
        public static extern void ClearAllDigital();
        [DllImport("k8055d.dll")]
        public static extern void SetDigitalChannel(int Channel);
        [DllImport("k8055d.dll")]
        public static extern void SetAllDigital();
        [DllImport("k8055d.dll")]
        public static extern bool ReadDigitalChannel(int Channel);
        [DllImport("k8055d.dll")]
        public static extern int ReadAllDigital();
        [DllImport("k8055d.dll")]
        public static extern int Version();
        [DllImport("k8055d.dll")]
        public static extern int SetCurrentDevice(int lngCardAddress);

        bool devicesConnectionStatus = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            OpenDevice(0);
            OpenDevice(1);
            SetCurrentDevice(0);

            if (Version() != 0)
            {
                devicesConnectionStatus = true;
                MessageBox.Show("Zařízení je připojené");
            }
            else
                MessageBox.Show("Zařízení není připojené");
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            if (devicesConnectionStatus)
            {
                timer_day.Enabled = true;
                timer_btn_states.Enabled = true;

                timer_day.Start();
                timer_btn_states.Start();
            }            
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            timer_day.Enabled = false;
            timer_night.Enabled = false;

            timer_day.Stop();
            timer_night.Stop();
            timer_btn_states.Stop();
        }

        private void Btn_minimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int march = 0;

        private void Timer_Day_Tick(object sender, EventArgs e)
        {
            march++;

            switch (march)
            {
                case 1:
                    // SetDigitalChannel(int Channel); 
                    // ClearAllDigital();

                    SetCurrentDevice(1);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    SetDigitalChannel(1);

                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(4);


                    trafficLightsMinorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(0);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

                    break;

                case 6:
                    SetCurrentDevice(1);
                    ClearAllDigital();

                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(7);

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    SetDigitalChannel(5);
                    SetDigitalChannel(4);

                    trafficLightsMinorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(0);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

                    break;

                case 7:
                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(7);

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    SetDigitalChannel(6);

                    trafficLightsMinorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(0);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    SetDigitalChannel(3);

                    break;

                case 12:
                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(7);

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(4);

                    trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    SetDigitalChannel(1);
                    SetDigitalChannel(0);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

                    break;

                case 13:
                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(7);

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(4);

                    trafficLightsMinorMain1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    SetDigitalChannel(2);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Green, TrafficLightRegime.Day);
                    SetDigitalChannel(3);

                    break;

                case 18:
                    SetCurrentDevice(1);
                    ClearAllDigital();

                    trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    trafficLightsMajorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Day);
                    SetDigitalChannel(0);

                    SetCurrentDevice(0);
                    ClearAllDigital();

                    trafficLightsMajorLeft1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMajorLeft2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(4);

                    trafficLightsMinorMain1.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    trafficLightsMinorMain2.TurnLight(TrafficLight.Red, TrafficLightRegime.Day);
                    SetDigitalChannel(0);

                    trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);
                    trafficLightsMinorRight2.TurnLight(TrafficLight.Default, TrafficLightRegime.Day);

                    march = 0;
                    break;
            }
        }
        private void Timer_Night_Tick(object sender, EventArgs e)
        {
            if (march == 1)
            {
                SetCurrentDevice(0);
                ClearAllDigital();

                trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMinorRight1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);

                SetDigitalChannel(1);
                SetDigitalChannel(5);

                SetCurrentDevice(1);
                ClearAllDigital();

                SetDigitalChannel(0);

                march = 0;
            }
            else
            {
                SetCurrentDevice(1);
                ClearAllDigital();

                SetCurrentDevice(0);
                ClearAllDigital();

                trafficLightsMinorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);

                march++;
            }
        }

        private void Timer_btn_states_Tick(object sender, EventArgs e)
        {
            int btn = 0;

            SetCurrentDevice(1);
            btn = ReadAllDigital();

            if (btn == 1)
            {
                timer_day.Enabled = false;
                timer_night.Enabled = true;

                timer_day.Stop();
                timer_night.Start();
            }
            else if (btn == 2)
            {
                timer_day.Enabled = true;
                timer_night.Enabled = false;

                timer_day.Start();
                timer_night.Stop();
            }

        }
    }
}
