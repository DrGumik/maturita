using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace K8055Demo
{
    public partial class Form1 : Form
    {
        int Data1, Data2;
        int n = 0;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("k8055d.dll")]
        public static extern int OpenDevice(int CardAddress);

        [DllImport("k8055d.dll")]
        public static extern void CloseDevice();

        [DllImport("k8055d.dll")]
        public static extern int ReadAnalogChannel(int Channel);

        [DllImport("k8055d.dll")]
        public static extern void ReadAllAnalog(ref int Data1, ref int Data2);

        [DllImport("k8055d.dll")]
        public static extern void OutputAnalogChannel(int Channel, int Data);

        [DllImport("k8055d.dll")]
        public static extern void OutputAllAnalog(int Data1, int Data2);

        [DllImport("k8055d.dll")]
        public static extern void ClearAnalogChannel(int Channel);

        [DllImport("k8055d.dll")]
        public static extern void SetAllAnalog();

        [DllImport("k8055d.dll")]
        public static extern void ClearAllAnalog();

        [DllImport("k8055d.dll")]
        public static extern void SetAnalogChannel(int Channel);

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
        public static extern int ReadCounter(int CounterNr);

        [DllImport("k8055d.dll")]
        public static extern void ResetCounter(int CounterNr);

        [DllImport("k8055d.dll")]
        public static extern void SetCounterDebounceTime(int CounterNr, int DebounceTime);

        [DllImport("k8055d.dll")]
        public static extern int Version();

        [DllImport("k8055d.dll")]
        public static extern int SearchDevices();

        [DllImport("k8055d.dll")]
        public static extern int SetCurrentDevice(int lngCardAddress);

        private void Button1_Click(object sender, EventArgs e)
        {
            int CardAddr = 3 - (Convert.ToInt32(CheckBox1.Checked) + Convert.ToInt32(CheckBox2.Checked) * 2);
            int h = OpenDevice(CardAddr);
            switch (h) 
            {
            case  0:
            case  1:
            case  2:
            case  3: 
                Label1.Text = "Card " + h.ToString() + " connected";
                Timer1.Enabled = true;
                break;
            case  -1 :
              Label1.Text = "Card " + CardAddr.ToString() + " not found";
                break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseDevice();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            ReadAllAnalog(ref Data1, ref Data2);
            VScrollBar3.Value = 255 - Data1;
            VScrollBar4.Value = 255 - Data2;
            Label6.Text = Data1.ToString();
            Label7.Text = Data2.ToString();
            TextBox1.Text = ReadCounter(1).ToString();
            TextBox2.Text = ReadCounter(2).ToString();
            int i = ReadAllDigital();
            CheckBox4.Checked = (i & 1) > 0;
            CheckBox5.Checked = (i & 2) > 0;
            CheckBox6.Checked = (i & 4) > 0;
            CheckBox7.Checked = (i & 8) > 0;
            CheckBox8.Checked = (i & 16) > 0;
            Timer1.Enabled = true;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            ClearDigitalChannel(n);
            n++;
            if (n == 9)
                n = 1;
            SetDigitalChannel(n);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SetAllDigital();
            CheckBox9.Checked = true;
            CheckBox10.Checked = true;
            CheckBox11.Checked = true;
            CheckBox12.Checked = true;
            CheckBox13.Checked = true;
            CheckBox14.Checked = true;
            CheckBox15.Checked = true;
            CheckBox16.Checked = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ClearAllDigital();
            CheckBox9.Checked = false;
            CheckBox10.Checked = false;
            CheckBox11.Checked = false;
            CheckBox12.Checked = false;
            CheckBox13.Checked = false;
            CheckBox14.Checked = false;
            CheckBox15.Checked = false;
            CheckBox16.Checked = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            SetAllAnalog();
            VScrollBar1.Value = 0;
            VScrollBar2.Value = 0;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ClearAllAnalog();
            VScrollBar1.Value = 255;
            VScrollBar2.Value = 255;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked)
            {
                Timer2.Enabled = true;
            }
            else
            {
                Timer2.Enabled = false;
                ClearAllDigital();
                CheckBox9.Checked = false;
                CheckBox10.Checked = false;
                CheckBox11.Checked = false;
                CheckBox12.Checked = false;
                CheckBox13.Checked = false;
                CheckBox14.Checked = false;
                CheckBox15.Checked = false;
                CheckBox16.Checked = false;
            }
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            OutputAnalogChannel(1, 255 - VScrollBar1.Value);
            Label4.Text = (255 - VScrollBar1.Value).ToString();
        }

        private void VScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            OutputAnalogChannel(2, 255 - VScrollBar2.Value);
            Label5.Text = (255 - VScrollBar2.Value).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ResetCounter(1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ResetCounter(2);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(1, 0);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(1, 2);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(1, 10);
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(1, 1000);
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(2, 0);
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(2, 2);
        }

        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(2, 10);
        }

        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            SetCounterDebounceTime(2, 1000);
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox9.Checked) SetDigitalChannel(1); 
                else ClearDigitalChannel(1);
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox10.Checked) SetDigitalChannel(2); 
                else ClearDigitalChannel(2);
        }

        private void CheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox11.Checked) SetDigitalChannel(3); 
                else ClearDigitalChannel(3);
        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox12.Checked) SetDigitalChannel(4); 
                else ClearDigitalChannel(4);
        }

        private void CheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox13.Checked) SetDigitalChannel(5); 
                else ClearDigitalChannel(5);
        }

        private void CheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox14.Checked) SetDigitalChannel(6); 
                else ClearDigitalChannel(6);
        }

        private void CheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox15.Checked) SetDigitalChannel(7); 
                else ClearDigitalChannel(7);
        }

        private void CheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox16.Checked) SetDigitalChannel(8); 
                else ClearDigitalChannel(8);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int k;
            bool CardFound ;
            CardFound = false;
            Timer1.Enabled = false; 
            RadioButton9.Enabled = false;
            RadioButton9.Checked = false;
            RadioButton10.Enabled = false;
            RadioButton10.Checked = false;
            RadioButton11.Enabled = false;
            RadioButton11.Checked = false;
            RadioButton12.Enabled = false;
            RadioButton12.Checked = false;
            k = SearchDevices();
            if (k > 0) Timer1.Enabled = true;
            if ((k & 1) > 0)
            {
                CardFound = true;
                RadioButton9.Enabled = true;
                RadioButton9.Checked = true;
                SetCurrentDevice(0);
            }
            if ((k & 2) > 0)
            {
                RadioButton10.Enabled = true;
                if (!CardFound)
                {
                    CardFound = true;
                    RadioButton10.Checked = true;
                    SetCurrentDevice(1);
                }
            }
            if ((k & 4) > 0)
            {
                RadioButton11.Enabled = true;
                if (!CardFound)
                {
                    CardFound = true;
                    RadioButton11.Checked = true;
                    SetCurrentDevice(2);
                }
            }
            if ((k & 8) > 0)
            {
                RadioButton12.Enabled = true;
                if (!CardFound)
                {
                    CardFound = true;
                    RadioButton12.Checked = true;
                    SetCurrentDevice(3);
                }
            }
        }

        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentDevice(0);
        }

        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentDevice(1);
        }

        private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentDevice(2);
        }

        private void RadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentDevice(3);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            int ver = Version();
            Label9.Text = (ver >> 24).ToString() + "." + ((ver >> 16) & 0xFF).ToString() + "."
            + ((ver >> 8) & 0xFF).ToString() + "." + (ver & 0xFF).ToString();
        }
    }
}
