/// <summary>
/// Model křižovatky:
/// Zpracujte program v programovacím jazyce C# ovládající model křižovatky tak, aby obsahoval
/// nejméně tyto funkce:
///     1) funkce řízení světel křižovatky respektuje pravidla silničního provozu
///     2) pomocí tlačítek modelu přepínejte režim denní/noční(volitelně plná/zjednodušená křižovatka)
///     3) na monitoru počítače zobrazujte aktuální stav světel křižovatky, případně režimu činnosti 
///     křižovatky
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
                timer_day.Start();
            }            
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            timer_day.Enabled = false;
            timer_night.Enabled = false;
            timer_day.Stop();
            timer_night.Stop();
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
            if (march == 0)
            {
                trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);

                trafficLightsMinorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorMain2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorLeft2.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);

                march++;
            }
            else
            {
                trafficLightsMinorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);

                trafficLightsMinorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorMain2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorLeft2.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);

                march = 0;
            }
        }
        private void Timer_Night_Tick(object sender, EventArgs e)
        {
            if (march == 0)
            {
                trafficLightsMinorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMinorRight1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Yellow, TrafficLightRegime.Night);

                march++;
            }
            else
            {
                trafficLightsMinorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMinorRight1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorMain1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);
                trafficLightsMajorLeft1.TurnLight(TrafficLight.Default, TrafficLightRegime.Night);

                march = 0;
            }
        }
    }
}
