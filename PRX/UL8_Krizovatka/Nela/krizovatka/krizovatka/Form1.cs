using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace krizovatka
{
    public partial class Form1 : Form
    {
        [DllImport("k8055d.dll")]
        public static extern int OpenDevice(int CardAddress);

        [DllImport("k8055d.dll")]
        public static extern void CloseDevice();

        [DllImport("k8055d.dll")]
        public static extern void ClearAllDigital();

        [DllImport("k8055d.dll")]
        public static extern void SetDigitalChannel(int Channel);

        int pochod = 0;      //pochod algoritmu
        int rezim;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //inicializace
            this.Size = new Size(1000, 700);
            this.BackColor = Color.ForestGreen;
            stop.Enabled = false;
            odpojeni.Enabled = false;
        }
        private void start_Click(object sender, EventArgs e)
        {
            //zapnutí křižovatky v daném režimu
            pripojeni.Enabled = false;
            rezimy.Enabled = true;
            stop.Enabled = true;
            rezimy.Enabled = false;
            start.Enabled = false;
            if (rezim_den.Checked)
            {
                pochod = 0;
                restart();
                cas.Enabled = true;
                rezim = 1;
                this.BackColor = Color.ForestGreen;
            }
            else if (rezim_noc.Checked)
            {
                pochod = 0;
                restart_chodci();
                restart();
                cas.Enabled = true;
                rezim = 0;
                this.BackColor = Color.LightGray;
            }
        }
        private void stop_Click(object sender, EventArgs e)
        {
            //vypnutí křižovatky
            pripojeni.Enabled = true;
            rezimy.Enabled = true;
            restart_chodci();
            restart();
            cas.Enabled = false;
            start.Enabled = true;
            stop.Enabled = false;
        }


        private void pripojeni_Click(object sender, EventArgs e)
        {
            int deviceRY = OpenDevice(1);   //slouží pro připojení červených a žlutých světel
            switch (deviceRY)               //kontrola, zda je karta připojená
            {
                case 1:
                    label_log.Text = "LOG: Karta c. " + deviceRY.ToString() + " pripojena";
                    ClearAllDigital();
                    break;
                default:
                    label_log.Text = "LOG: Karta c. " + deviceRY.ToString() + " se nepodarila pripojit";
                    break;
            }

            int deviceG = OpenDevice(2);    //slouží pro připojení zelených světel
            switch (deviceG)
            {
                case 2:
                    label_log.Text = "Karta c. " + deviceG.ToString() + " pripojena";
                    ClearAllDigital();
                    break;
                default:
                    label_log.Text = "Karta c. " + deviceG.ToString() + " se nepodarila pripojit";
                    break;
            }
        }

        private void odpojeni_Click(object sender, EventArgs e)
        {
            CloseDevice();
        }

        private void restart_chodci()
        {
            for (int z = 0; z < this.Controls.Count; z++)       //reset signalizace na hlavní
            {
                this.Controls[z].BackColor = Color.White;
            }
            silnice1.BackColor = Color.Gray;
            silnice2.BackColor = Color.Gray;
        }

        private void restart()  //reset barev + kroku
        {
          
            for (int i = 0; i < silnice1.Controls.Count;i++ )   //reset signalizace na hlavní
            {
                silnice1.Controls[i].BackColor = Color.White;
            }
            for (int j = 0; j < silnice2.Controls.Count; j++)   //reset signalizace na hlavní
            {
                silnice2.Controls[j].BackColor = Color.White;
            }
          
        }

        private void cas_Tick(object sender, EventArgs e)
        {
            pochod++;
            switch(rezim)
            {
                case 0:     //noční režim
                    int deviceRY = OpenDevice(1);       //navázání komunikace s 1. kartou
                    if (deviceRY != -1)                 //pokud karta komunikuje, tak vše nastaví na log.0
                    {
                        ClearAllDigital();
                    }
                    if (pochod==1)       //pokud je p rovno 1, tak semafory svítí žlutě
                    {
                        hlavni_z1.BackColor = Color.Yellow;
                        hlavni_z2.BackColor = Color.Yellow;
                        SetDigitalChannel(5);

                        hl_zat_z1.BackColor = Color.Yellow;
                        hl_zat_z2.BackColor = Color.Yellow;
                        SetDigitalChannel(3);

                        vedlejsi_z1.BackColor = Color.Yellow;
                        vedlejsi_z2.BackColor = Color.Yellow;
                        SetDigitalChannel(1);
                    }
                    else            //jinak restart křižovatky
                    {
                        pochod = 0;
                        restart();
                    }
                    break;
                case 1:     //denní režim
                    switch(pochod)
                    {
                        case 1:
                            restart_chodci();
                            restart();

                            int deviceG1 = OpenDevice(2);       //navázání komunikace s 2. kartou
                            if (deviceG1 != -1)                 //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů zeleně
                            hlavni_zel1.BackColor = Color.Lime;
                            hlavni_zel2.BackColor = Color.Lime;
                            SetDigitalChannel(3);

                            hl_zat_zel1.BackColor=Color.Lime;
                            hl_zat_zel2.BackColor = Color.Lime;
                            SetDigitalChannel(2);

                            odbocka_1.BackColor = Color.Lime;
                            odbocka_2.BackColor = Color.Lime;
                            SetDigitalChannel(1);

                            chodci_vedl_zel1.BackColor = Color.Lime;
                            chodci_vedl_zel2.BackColor = Color.Lime;
                            chodci_vedl_zel3.BackColor = Color.Lime;
                            chodci_vedl_zel4.BackColor = Color.Lime;
                            SetDigitalChannel(4);

                            int deviceRY2 = OpenDevice(1);      //navázání komunikace s 1. kartou
                            if (deviceRY2 != -1)                //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů červeně
                            vedlejsi_c1.BackColor = Color.Red;
                            vedlejsi_c2.BackColor = Color.Red;
                            SetDigitalChannel(0);

                            chodci_hl_c1.BackColor = Color.Red;
                            chodci_hl_c2.BackColor = Color.Red;
                            chodci_hl_c3.BackColor = Color.Red;
                            chodci_hl_c4.BackColor = Color.Red;
                            SetDigitalChannel(7);

                            break;
                        case 5:
                            restart_chodci();

                            int deviceRY3 = OpenDevice(1);      //navázání komunikace s 1. kartouč
                            if (deviceRY3 != -1)                //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů žlutě
                            hlavni_z1.BackColor = Color.Yellow;
                            hlavni_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(5);

                            hl_zat_z1.BackColor = Color.Yellow;
                            hl_zat_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(3);

                            vedlejsi_z1.BackColor = Color.Yellow;
                            vedlejsi_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(1);

                            break;
                        case 7:
                            restart();

                            int deviceRY4 = OpenDevice(1);          //navázání komunikace s 1. kartou
                            if (deviceRY4 != -1)                    //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů červeně
                            hlavni_c1.BackColor = Color.Red;
                            hlavni_c2.BackColor = Color.Red;
                            SetDigitalChannel(4);

                            hl_zat_c1.BackColor = Color.Red;
                            hl_zat_c2.BackColor = Color.Red;
                            SetDigitalChannel(2);

                            chodci_vedl_c1.BackColor = Color.Red;
                            chodci_vedl_c2.BackColor = Color.Red;
                            chodci_vedl_c3.BackColor = Color.Red;
                            chodci_vedl_c4.BackColor = Color.Red;
                            SetDigitalChannel(6);

                            int deviceG2 = OpenDevice(2);           //navázání komunikace s 2. kartou
                            if (deviceG2 != -1)                     //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů zeleně
                            vedlejsi_zel1.BackColor = Color.Lime;
                            vedlejsi_zel2.BackColor = Color.Lime;
                            SetDigitalChannel(0);

                            chodci_hl_zel1.BackColor = Color.Lime;
                            chodci_hl_zel2.BackColor = Color.Lime;
                            chodci_hl_zel3.BackColor = Color.Lime;
                            chodci_hl_zel4.BackColor = Color.Lime;
                            SetDigitalChannel(5);

                            break;
                        case 12:
                            restart_chodci();

                            int deviceRY5 = OpenDevice(1);          //navázání komunikace s 2. kartou
                            if (deviceRY5 != -1)                    //pokud karta komunikuje, tak vše nastaví na log.0
                            {
                                ClearAllDigital();
                            }

                            //rozsvícení daných semaforů žlutě
                            hlavni_z1.BackColor = Color.Yellow;
                            hlavni_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(5);

                            hl_zat_z1.BackColor = Color.Yellow;
                            hl_zat_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(3);

                            vedlejsi_z1.BackColor = Color.Yellow;
                            vedlejsi_z2.BackColor = Color.Yellow;
                            SetDigitalChannel(1);

                            break;
                        case 13:
                            //pokud je pochod roven 13, algoritmus začíná od začátku
                            pochod = 0;

                            int deviceRY6 = OpenDevice(1);
                            if (deviceRY6 != -1)
                            {
                                ClearAllDigital();
                            }
                            int deviceG3 = OpenDevice(2);
                            if (deviceG3 != -1)
                            {
                                ClearAllDigital();
                            }
                            break;
                    }
                    break;

            }
        }
    }
}
