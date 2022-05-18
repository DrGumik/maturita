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

        static extern short GetAsyncKeyState(Keys vKey);

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
            // Zapnutí KeyBoardCheck background workera
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

        private void KeyboardCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true) 
            { 
                // Pokud je zařízení připojeno k sériové lince, tak se začnou kontrolovat tlačítka, zda se některé stisklo.
                if (isSerialReady)
                {
                    // Písmena
                    if (GetAsyncKeyState(Keys.A) < 0) // Klávesa A
                    {
                        serialPort.Write(new byte[] { 0b01110111 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.B) < 0) // Klávesa B
                    {
                        serialPort.Write(new byte[] { 0b01111100 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.C) < 0) // Klávesa C
                    {
                        serialPort.Write(new byte[] { 0b00111001 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D) < 0) // Klávesa D
                    {
                        serialPort.Write(new byte[] { 0b01011110 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.E) < 0) // Klávesa E
                    {
                        serialPort.Write(new byte[] { 0b01111001 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.F) < 0) // Klávesa F
                    {
                        serialPort.Write(new byte[] { 0b01110001 }, 0, 1);
                        Thread.Sleep(100);
                    }

                    // Čísla
                    if (GetAsyncKeyState(Keys.D0) < 0 || GetAsyncKeyState(Keys.NumPad0) < 0) // Klávesa 0
                    {
                        serialPort.Write(new byte[] { 0b00111111 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D1) < 0 || GetAsyncKeyState(Keys.NumPad1) < 0) // Klávesa 1
                    {
                        serialPort.Write(new byte[] { 0b00000110 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D2) < 0 || GetAsyncKeyState(Keys.NumPad2) < 0) // Klávesa 2
                    {
                        serialPort.Write(new byte[] { 0b01011011 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D3) < 0 || GetAsyncKeyState(Keys.NumPad3) < 0) // Klávesa 3
                    {
                        serialPort.Write(new byte[] { 0b01001111 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D4) < 0 || GetAsyncKeyState(Keys.NumPad4) < 0) // Klávesa 4
                    {
                        serialPort.Write(new byte[] { 0b01100110 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D5) < 0 || GetAsyncKeyState(Keys.NumPad5) < 0) // Klávesa 5
                    {
                        serialPort.Write(new byte[] { 0b01101101 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D6) < 0 || GetAsyncKeyState(Keys.NumPad6) < 0) // Klávesa 6
                    {
                        serialPort.Write(new byte[] { 0b01111101 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D7) < 0 || GetAsyncKeyState(Keys.NumPad7) < 0) // Klávesa 7
                    {
                        serialPort.Write(new byte[] { 0b00000111 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D8) < 0 || GetAsyncKeyState(Keys.NumPad8) < 0) // Klávesa 8
                    {
                        serialPort.Write(new byte[] { 0b01111111 }, 0, 1);
                        Thread.Sleep(100);
                    }
                    if (GetAsyncKeyState(Keys.D9) < 0 || GetAsyncKeyState(Keys.NumPad9) < 0) // Klávesa 8
                    {
                        serialPort.Write(new byte[] { 0b01001111 }, 0, 1);
                        Thread.Sleep(100);
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
