using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace SerialLine_Tenk
{
    public partial class SerialLink_MainForm : Form
    {
        [DllImport("user32.dll")]

        static extern short GetAsyncKeyState(int vKey);

        SerialPort serialPort;
        bool isSerialReady = false;

        public SerialLink_MainForm()
        {
            InitializeComponent();
        }

        private void SerialLink_MainForm_Load(object sender, EventArgs e)
        {
            // Načtení dostupných portů
            LoadPorts();
            // Zapnutí asynchronně KeyboardCheck background workera
            KeyboardCheck.RunWorkerAsync();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            // Podmínka jestli není zařízení připojeno k nějaké sériové lince
            if (isSerialReady == false)
            {
                // Podmínka jestli je vybraný port
                if (ports_list.CheckedIndices.Count == 1)
                {
                    ConnectDevice();
                }
                else
                {
                    if (ports_list.CheckedIndices.Count == 0)
                    {
                        tb_console.Text = "Musíte vybrat port, který chcete použít pro komunikaci se zařízením!";
                    }
                    else
                    {
                        tb_console.Text = "Můžete vybrat maximálně jeden port!";
                    }
                }
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            // Odpojení sériové linky
            if (isSerialReady)
            {
                serialPort.Close();
                isSerialReady = false;
                tb_console.Text = "Zařízení odpojeno.";
                LoadPorts();
            }
        }

        private void btn_reloadPorts_Click(object sender, EventArgs e)
        {
            // Znovu načtení dostupných portů
            LoadPorts();
        }

        private void LoadPorts()
        {
            // Vymaže data z pole checkboxu ports_list a znovu nahraje nové data
            ports_list.Items.Clear();

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                ports_list.Items.Add(port);
            }
        }

        private void ConnectDevice() 
        {
            // Připojení k zařízení a nadefinování sériové linky
            serialPort = new SerialPort(ports_list.CheckedItems[0].ToString(), 9600, Parity.None, 8, StopBits.One);
            serialPort.Open();

            // Podmínka pokud se sériová linka připojila úspěšně
            if (serialPort.IsOpen)
            {
                isSerialReady = true;
                tb_console.Text = "Zařízení úspěšně připojeno k portu " + ports_list.CheckedItems[0];
            } 
            else
            {
                isSerialReady = false;
                tb_console.Text = "Zařízení se nepodařilo připojit k portu " + ports_list.CheckedItems[0];
            }
        }

        // Pole s klávesami
        readonly int[] keys = { 
           /*A*/ 65, /*B*/ 66, /*C*/ 67, /*D*/ 68, /*E*/ 69, /*F*/ 70,
           /*0 or NP0*/ 48, 96, /*1 or NP1*/ 49, 97, /*2 or NP2*/ 50, 98, /*3 or NP3*/ 51, 99, /*4 or NP4*/ 52, 100, 
           /*5 or NP5*/ 53, 101, /*6 or NP6*/ 54, 102, /*7 or NP7*/ 55, 103, /*8 or NP8*/ 56, 104, /*9 or NP9*/ 57, 105
        };
        // Pole se vzory, které se odesílají
        readonly byte[] pattern = { 
           /*A*/ 0b11101110, /*B*/ 0b00111110, /*C*/ 0b00011010, /*D*/ 0b01111010, /*E*/ 0b00111110, /*F*/ 0b10001110, 
           /*0*/ 0b11111100, 0b11111100, /*1*/ 0b01100000, 0b01100000, /*2*/ 0b11011010, 0b11011010, /*3*/ 0b11110010, 0b11110010, 
           /*4*/ 0b00100110, 0b00100110, /*5*/ 0b10110110, 0b10110110, /*6*/ 0b10111110, 0b10111110, /*7*/ 0b11100000, 0b11100000, 
           /*8*/ 0b11111110, 0b11111110, /*9*/ 0b11100110, 0b11100110
        };
        int a;

        private void KeyboardCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true) 
            { 
                // Pokud je zařízení připojeno k sériové lince, tak se začnou kontrolovat klávesy, zda se některé stisklo.
                if (isSerialReady)
                {
                    a = 0;
                    foreach(int key in keys)
                    {
                        if (GetAsyncKeyState(key) < 0)
                        {
                            MessageBox.Show("key="+key.ToString()+" a="+a.ToString()+" pattern="+ Convert.ToInt32(pattern[a]).ToString());
                            serialPort.Write(pattern, a, 1);
                            Thread.Sleep(250);
                        }
                        a++;
                    }
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }
        }

        // Ukončí aplikaci
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Minimalizuje aplikaci
        private void btn_minimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /* 
           Přesunutí okna myší (jelikož styl ohraničení aplikace je nastaveno na none, protože mám vlastí, 
           tak zde musí být tato funkce, která nám umožní hýbat s oknem aplikace)
           Zdroj: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        */
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void form_mouse_down(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
