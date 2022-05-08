using System;
using System.Drawing;
using System.Windows.Forms;

namespace tenis_siriste
{
    public partial class pong : Form
    {
        int posun_miceX; //deklarace rychlosti posunu míče
        int posun_miceY;
        int posun_hrace1;//Deklarace rychlosti posunu hráče
        int posun_hrace2;
        int rychlost_palky_1;
        int rychlost_palky_2; //rychlosti pálek
        bool stop = true; //Stop hry (při spuštění aktivní)
        int stav_stisknuteho_tlacitka_1 = 0; //hodnota 1 pro šipku nahoru, 2pro šipku dolů
        int stav_stisknuteho_tlacitka_2 = 0; //hodnota 1 pro šipku nahoru, 2pro šipku dolů
        int mod; //volba modu (1=hra pro jednoho), 2=hra pro dva
        int skore_hrac1;
        int skore_hrac2;//Proměnné pro skóre hráčů
        int posun_pc;//Posun pálky při hře pro jednoho
        int bodovani_hrace1 = 0;
        int bodovani_hrace2 = 0; //Pomocné proměnné pro bodování
        Random nahoda = new Random();//definice náhody

        bool povoleni_barvy;
        bool hrac1_horni_koncak;
        bool hrac1_dolni_koncak;
        bool hrac2_horni_koncak;
        bool hrac2_dolni_koncak;//Pomocné proměnné pro posun pálek


        public pong()
        {
            InitializeComponent();
        }

        private void pong_Load(object sender, EventArgs e)
        {
            this.Size = new Size(800, 600); //Nastavení velikosti okna
            hriste.Size = new Size(600, 400); //Nastavení velikosti hrací plochy
            hriste.Location = new Point(100, 100); //Lokalizace hrací plochy ve formu
            mic.Size = new Size(12, 12);//Nastavenírozměru míče
            restart.Enabled = false; //Zakáže se reset tlačítko
            jeden_hrac.Checked = true; //výchozí nastavení
            casovac.Enabled = true; //Povolení časovače
            vysvetleni.Location = new Point(0,0);//Umístění textboxu v panelu
            vysvetleni.Size = new Size(600, 400);//Rozměr textboxu
            vysvetleni.Text += "Hráč 1 = levá strana hřiště" + Environment.NewLine + "W = pohyb nahoru" + Environment.NewLine + "S = pohyb dolů" + Environment.NewLine;
            vysvetleni.Text += Environment.NewLine+"Hráč 2 = pravá strana hřiště" + Environment.NewLine + "Šipka nahoru = pohyb nahoru" + Environment.NewLine + "Šipka dolů = pohyb dolů" + Environment.NewLine;
            vysvetleni.Text += Environment.NewLine + "Pravidla hry jsou jednoduchá, cílem Vaší hry je odrážet míč a získat více bodů, jak Váš soupeř. ";
            vysvetleni.Text += "Ten, kdo jako dříve dosáhne 12ti bodů, vítězí. Je možnost volby mezi jednotlivými módy a obtížnostmi. ";
            vysvetleni.Text +="Při volbě hry pro jednoho je hráč na pravé straně nahrazen počítačem. Obtížnost nelze v tomto módu volit, ta se mění v průběhu hry dle Vašeho skóre." + Environment.NewLine;
            vysvetleni.Text += Environment.NewLine + "Hru je možno kdykoliv pozastavit stisknutím Escape, pozastavená hra lze restartovat a uživatel může změnit herní mód nebo obtížnost, pokud ale chcete pokračovat ve své rozehrané hře, stiskněte Enter pro pokračování" + Environment.NewLine;
            vysvetleni.Text += Environment.NewLine + "Po zvolení módu a obtížnosti, hrajete-li hru pro dva, potvrdíte svou volbou stiskem Start tlačítka a pomocí Enteru spustíte hru." + Environment.NewLine; 
            vysvetleni.Text += Environment.NewLine + "Stiskněte na tlačítko Rozumím pro spuštění hry.";
            vysvetleni.TabStop = false;//pouze pro estetiku, text není označený                                 
            label_hrac1.Visible = false;
            label_hrac2.Visible = false;
            skupina_mod.Visible = false;
            start.Visible = false;
            restart.Visible = false;//Skrytí všeho na začátek

        }

        private void rozumim_Click(object sender, EventArgs e)
        {
            vysvetleni.Visible = false;//Zmizí vysvětlivka
            rozumim.Enabled = false;
            rozumim.Visible = false;//Zakáže kompletně tlačítko rozumím
            label_hrac1.Visible = true;
            label_hrac2.Visible = true;
            skupina_mod.Visible = true;
            start.Visible = true;
            restart.Visible = true;//odkrytí všeho
        }

        private void jeden_hrac_CheckedChanged(object sender, EventArgs e)
        {
            bodovani_hrace1 = 0;
            bodovani_hrace2 = 0;//Nulování pomocné proměnné
            skupina_obtiznost.Visible = false; //Hra pro jednoho je bez volby obtížnosti
            mod = 1;//Indikace hry pro jednoho
            hrac1.Size = new Size(10, 80); //Vaše pálka má největší velikost
            hrac2.Size = new Size(10, 40);//Protihráčovo nejmenší
            posun_miceX = 4;
            posun_miceY = 2; //Rychlost míčku při spuštení
            rychlost_palky_1 = 5;//Rychlost pálky hráče 1
            posun_pc = 2; //Na začátku je pálka pomalá
            casovac.Interval = 15; //změna času tiknutí časovače
            posun_miceX = -1 * posun_miceX;//začne hráč 1
            start.Enabled = true;//Povolení tlačítka start
        }

        private void dva_hraci_CheckedChanged(object sender, EventArgs e)
        {
            skupina_obtiznost.Visible = true; //Povolení volby obtížnosti
            mod = 2;//Indikace hry pro dva
            lehka.Checked = false;
            stredni.Checked = false;
            tezka.Checked = false;//Nic není zaškrtnuto
            start.Enabled = false;//Dokud se nezvolí obtížnost, nelze spustit
        }

        private void barva_CheckStateChanged(object sender, EventArgs e)
        {
            if (barva.Checked == true)
            {
                povoleni_barvy = true;//Povolení
            }
            else povoleni_barvy = false;
        }

        private void lehka_CheckedChanged(object sender, EventArgs e)
        {
            if (dva_hraci.Checked == true) //pokud je navolena hra pro dva
            {
                hrac1.Size = new Size(10, 80);
                hrac2.Size = new Size(10, 80);//Obě pálky jsou velké
                rychlost_palky_1 = 5;
                rychlost_palky_2 = 5; //Posun obou hráčů je stejný
                posun_miceX = 3;
                posun_miceY = 1;// rychlost posunu míče
                casovac.Interval = 15;//změna času tiknutí časovače
                start.Enabled = true;//Povolení tlačítka start
            }
        }

        private void stredni_CheckedChanged(object sender, EventArgs e)
        {
            if (dva_hraci.Checked == true) //pokud je navolena hra pro dva
            {
                hrac1.Size = new Size(10, 60);
                hrac2.Size = new Size(10, 60);//Stejná velikost pálek pro oba
                rychlost_palky_1 = 5;
                rychlost_palky_2 = 5; //Posun hráčů je vyrovnaný
                posun_miceX = 4;
                posun_miceY = 2;// rychlost posunu míče
                casovac.Interval = 15;//změna času tiknutí časovače 
                start.Enabled = true;//Povolení tlačítka start
            }
        }

        private void tezka_CheckedChanged(object sender, EventArgs e)
        {
            if (dva_hraci.Checked == true) //pokud je navolena hra pro dva
            {
                hrac1.Size = new Size(10, 40);
                hrac2.Size = new Size(10, 40);//Stejná velikost pálek pro oba
                rychlost_palky_1 = 5;
                rychlost_palky_2 = 5; //Posun hráčů je vyrovnaný
                posun_miceX = 6;
                posun_miceY = 2;// rychlost posunu míče
                casovac.Interval = 15;//změna času tiknutí časovače
                start.Enabled = true;//Povolení tlačítka start
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            hrac1.Location = new Point(10, hriste.Height / 2 - hrac1.Height / 2);
            hrac2.Location = new Point(580, hriste.Height / 2 - hrac2.Height / 2); //Vyrovnání pálek
            mic.Location = new Point(294, 194);//Vyrovnání míče
            start.Enabled = false; //Znepřístupní tlačítko po jeho stisku
            skupina_obtiznost.Enabled = false;
            skupina_mod.Enabled = false; //deaktivuje volbu   
            oznameni.Text = "Stiskni enter pro začátek hry"; //oznámení
            oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
        }

        private void restart_Click(object sender, EventArgs e)
        {
            skore_hrac1 = 0; //nulování skóre
            skore_hrac2 = 0;
            skupina_mod.Enabled = true;//Povolení všech nastavení pro změnu módu
            skupina_obtiznost.Enabled = true;
            start.Enabled = true; //povolení tlačítka start
            restart.Enabled = false;//zakázání tlačítka restart
            mic.Location = new Point(hriste.Width / 2 - mic.Width / 2, hriste.Height / 2 - mic.Height / 2);//Vyrovnání míče
            hrac1.Location = new Point(10, hriste.Height / 2 - hrac1.Height / 2);
            hrac2.Location = new Point(580, hriste.Height / 2 - hrac2.Height / 2); //Vyrovnání pálek
            oznameni.Text = "Hra resetována, zvolte mód a obtížnost"; //oznámení
            oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
        }

        private void pong_KeyDown(object sender, KeyEventArgs e) //stisknutí klávesy
        {
            if (e.KeyCode == Keys.Escape) //Pokud byl stisknut esc
            {
                stop = true;//Pozastavení hry
                restart.Enabled = true;//Povolí se restart
                oznameni.Text = "Hra pozastavena, Enter = pokračovat, Restart = změna módu"; //oznámení
                oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
            }
            if (e.KeyCode == Keys.Enter) //Postisknutí enteru se vše znovu spustí
            {
                oznameni.Text = ""; //vymazání oznámení
                stop = false;//Deaktivuje stop stav
                start.Enabled = false;//zakáže start tlačítko
                Focus();//Pouze pro odstranění zvuku během hry
            }
            //Ovládání hráče číslo 1:
            if (e.KeyCode == Keys.S)  //S pro pohyb dolů
            {
                stav_stisknuteho_tlacitka_1 = 2;//Pomocná proměnná pro kontrolu stisku v časovači
                posun_hrace1 = rychlost_palky_1; //Směr posunu je dolů
            }

            if (e.KeyCode == Keys.W)//W pro pohyb nahoru
            {
                stav_stisknuteho_tlacitka_1 = 1;//Pomocná proměnná pro kontrolu stisku v časovači
                posun_hrace1 = -rychlost_palky_1;//Směr posunu je nahoru
            }

            // Ovládání hráče číslo 2:
            if (e.KeyCode == Keys.Up) //stisknutí šipky nahoru
            {
                stav_stisknuteho_tlacitka_2 = 1;//Pomocná proměnná pro kontrolu stisku v časovači
                posun_hrace2 = -rychlost_palky_2; //Pokud bylo stisknuta šipka nahoru, tak při každém tiknutí časovače se posune pálka hráče 1 nahoru
            }
            if (e.KeyCode == Keys.Down)//Stisknutí šipky dolu
            {
                stav_stisknuteho_tlacitka_2 = 2; //Pomocná proměnná pro kontrolu stisku v časovači
                posun_hrace2 = rychlost_palky_2;  //Pokud bylo stisknuta šipka dolu, tak při každém tiknutí časovače se posune pálka hráče 1 dolu
            }
        }

        private void pong_KeyUp(object sender, KeyEventArgs e) //puštění klávesy
        {
            //Ovládání hráče číslo 1:
            if (e.KeyCode == Keys.S)  //S
            {
                posun_hrace1 = 0; //pokud není stisknuto tlačítko S, pálka se nehýbe dolů
            }
            if (e.KeyCode == Keys.W)//W
            {
                posun_hrace1 = 0;
            }
            // Ovládání hráče číslo 2:
            if (e.KeyCode == Keys.Up) //šipka nahoru
            {
                posun_hrace2 = 0;
            }
            if (e.KeyCode == Keys.Down)//šipka dolu
            {
                posun_hrace2 = 0;
            }
        }

        private void casovac_Tick(object sender, EventArgs e)
        {
            Color nahodna_barva = Color.FromArgb(nahoda.Next(30, 250), nahoda.Next(30, 250), nahoda.Next(60, 250));//vybrání náhodné barvy z palety
            label_hrac1.Text = skore_hrac1.ToString(); //Zobrazení skóre hráče 1
            label_hrac2.Text = skore_hrac2.ToString(); //Zobrazení skóre hráče 2
            if (stop != true)
            {           
                if (mic.Left <= 0)//Pokud neodrazil hráč 1 míč
                {
                    skore_hrac2++;//inkrementace skore hráče 2
                    mic.Location = new Point(294, 194);//míč se navrátí na původní pozici
                    posun_miceX = -1 * posun_miceX; //Po bodování mění míč směr
                    bodovani_hrace2++; //pro indikaci toho,že hráč 2 boduje
                }              
                if (mic.Right >= hriste.Width) //Pokud hráč 2neodrazil míč
                {
                    bodovani_hrace1++; //pro indikaci toho,že hráč 1 boduje
                    skore_hrac1++; //inkrementace skore hráče 1
                    mic.Location = new Point(294,194);//míč se navrátí na původní pozici
                   // mic.Location = new Point(hriste.Width / 2 - mic.Width / 2, hriste.Height / 2 - mic.Height / 2);//míč se navrátí na původní pozici
                    posun_miceX = -1 * posun_miceX;//Po bodování mění míč směr
                }    
                if ((mic.Location.X+mic.Width>=hrac2.Location.X)&&(mic.Location.X+mic.Width<=hrac2.Location.X+2)&&(mic.Location.Y+mic.Height>=hrac2.Location.Y)&&(mic.Location.Y<=hrac2.Location.Y+hrac2.Height))
                {
                    if (povoleni_barvy == true) hriste.BackColor = nahodna_barva;//Změna barvy při odrazu

                    posun_miceX = -1 * posun_miceX; //otočí se směr jeho trajektorie se zachováním úhel dopadu= úhel odrazu
                }          
                else if ((mic.Location.X<=hrac1.Location.X+hrac1.Width)&&(mic.Location.X>=hrac1.Location.X+hrac1.Width-2)&&(mic.Location.Y+mic.Height>=hrac1.Location.Y)&&(mic.Location.Y<=hrac1.Location.Y+hrac1.Height))
                {
                    if (povoleni_barvy == true) hriste.BackColor = nahodna_barva;//změna barvy při odrazu
                    posun_miceX = -1 * posun_miceX; //otočí se směr jeho trajektorie se zachováním úhel dopadu= úhel odrazu
                }
                else if (mic.Location.Y + mic.Height >= hriste.Height) //pokud míček narazí na vrchní hranu
                {
                   posun_miceY = -1 * posun_miceY; //odrazí se
                }
                else if (mic.Location.Y <= 0) //pokud míček narazí na spodní hranu
                {
                    posun_miceY = -1 * posun_miceY;//odrazí se
                }
                mic.Location = new Point(mic.Location.X + posun_miceX, mic.Location.Y + posun_miceY); //Pohyb míčku 

                //*************Ovládání pálky hráče 1:
                if (hrac1.Top <= 0) hrac1_horni_koncak = true;//Pokud pálka 1 dosáhla 0 souřadnice, aktivuje se horní koncák
                else if (hrac1.Bottom >= hriste.Height) hrac1_dolni_koncak = true; //pokud spodní bod pálky dosáhl spodku, aktivuje se dolní koncák
                else
                {
                    hrac1_dolni_koncak = false; //Pokud nedošlo k překročení mezí,oba koncáky jsou neaktivní
                    hrac1_horni_koncak = false;
                }

                if ((hrac1_horni_koncak == true) && (stav_stisknuteho_tlacitka_1 == 2))
                {
                    hrac1.Location = new Point(hrac1.Location.X, hrac1.Location.Y + posun_hrace1); //Posun hráče 1 (lze pouze dolů při aktivním horním koncáku) 
                }
                else if ((hrac1_dolni_koncak == true) && (stav_stisknuteho_tlacitka_1 == 1))
                {
                    hrac1.Location = new Point(hrac1.Location.X, hrac1.Location.Y + posun_hrace1); //(lze pouze nahoru při aktivním dolním koncáku) 
                }
                else if ((hrac1_horni_koncak == false) && (hrac1_dolni_koncak == false))
                {
                    hrac1.Location = new Point(hrac1.Location.X, hrac1.Location.Y + posun_hrace1); //(lze nahoru i dolu, nejsou aktivní koncáky)
                }

                // Ovládání pálkyhráče 2:

                switch (mod) //dle volby módu
                {
                    case 1:
                        //skóre:
                        if (bodovani_hrace1==1)//Pokud boduje hráč 1:
                        {
                            oznameni.Text = "";//Smazání upozornění
                            switch (skore_hrac1)
                            {
                                case 3:
                                posun_miceX = -5;//Změna rychlosti míče (záporné, aby šlo směrem k hráči 1 po bodování)
                                oznameni.Text = "Obtížnost hry se navýšila"; //oznámení
                                oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                                break;
                                case 6:
                                posun_miceX =-5;//Změna rychlosti míče
                                hrac2.Size = new Size(10,60);//Zvětšení protihráčovi pálky
                                hrac1.Size = new Size(10,60);//Zmenšení Vaší pálky
                                oznameni.Text = "Obtížnost hry se navýšila"; //oznámení
                                oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                                break;
                                case 9:
                                hrac2.Size = new Size(10, 80);//Zvětšení protihráčovi pálky
                                hrac1.Size = new Size(10,40);//Zmenšení Vaší pálky
                                oznameni.Text = "Obtížnost hry se navýšila"; //oznámení
                                oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                                break;
                                case 12:
                                oznameni.Text = "Zvítězil jste! Enter = zopakování hry, Reset = změna módu."; //oznámení
                                oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                                skore_hrac1 = 0;
                                skore_hrac2 = 0; //Reset skóre
                                hrac1.Size = new Size(10, 80); //Vaše pálka má největší velikost
                                hrac2.Size = new Size(10, 40);//Protihráčovo nejmenší
                                mic.Location = new Point(294,194);//míč se navrátí na původní pozici
                                posun_miceX = 4;
                                posun_miceY = 2; //Rychlost míčku při spuštení
                                posun_pc = 1; //Na začátku je pálka pomalá
                                stop = true; //Hra se zastaví
                                restart.Enabled = true;//Aktivace resetu
                                bodovani_hrace2 = 0;
                                bodovani_hrace1 = 0;//nulování pomocné proměnné
                                posun_pc = 2;
                                break;
                            }
                            bodovani_hrace1 = 0;//Nulování pomocné proměnné, aby se tento kód vykonál právě jednou
                        }
                        else if (bodovani_hrace2==1)//Jinak pokud boduje hráč 2:
                        {
                            switch (skore_hrac2)
                            {
                                case 12:
                                    oznameni.Text = "Prohrál jste. Enter = zopakování hry, Reset = změna módu."; //oznámení
                                    oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                                    skore_hrac1 = 0;
                                    skore_hrac2 = 0; //Reset skóre
                                    hrac1.Size = new Size(10, 80); //Vaše pálka má největší velikost
                                    hrac2.Size = new Size(10, 40);//Protihráčovo nejmenší
                                    posun_miceX = 4;
                                    posun_miceY = 2; //Rychlost míčku při spuštení
                                    posun_pc = 2;
                                    stop = true;
                                    restart.Enabled = true;//Aktivace resetu
                                    bodovani_hrace2 = 0;
                                    bodovani_hrace1 = 0;//nulování pomocné proměnné
                                    mic.Location = new Point(294,194);//míč se navrátí na původní pozici
                                    break;
                            }
                            bodovani_hrace2 = 0;//Nulování pomocné proměnné, aby se tento kód vykonál právě jednou
                        }
                        //Pálka hráče 2 a její ovládání
                        if (mic.Location.X >= hriste.Width / 2) //Pálka sleduje míček pouze tehdy, když je za půlkou hřiště
                        {
                            if (hrac2.Top <= 0) hrac2_horni_koncak = true; //Pokud pálka 2 dosáhla 0 souřadnice, aktivuje se horní koncák
                            else if (hrac2.Bottom >= hriste.Height) hrac2_dolni_koncak = true; //pokud spodní bod pálky dosáhl spodku, aktivuje se dolní koncák
                            else//Pokud není ani jedna podmínka pravda
                            {
                                hrac2_dolni_koncak = false;//Koncáky jsou neaktivní
                                hrac2_horni_koncak = false;
                            }
                            if ((hrac2.Location.Y + hrac2.Height / 2 > mic.Location.Y) && (hrac2_horni_koncak != true)) //Pokud je míč nad pálkou
                            {
                                hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y - posun_pc); //pálka se sune nahoru
                            }
                            else if (hrac2_dolni_koncak != true) //Pokud je pod a je nekativní dolní koncák
                            {
                                hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y + posun_pc);//sune se dolu
                            }
                        }
                        else if (hrac2.Location.Y + hrac2.Height / 2 < hriste.Height / 2) //Pokud je nad středem
                        {
                            hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y + posun_pc); //Vrátí se ndo původní polohy
                        }
                        else if (hrac2.Location.Y + hrac2.Height / 2 > hriste.Height / 2) //Pokud je pod středem
                        {
                            hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y - posun_pc);//vrátí se do původní polohy
                        }
                        break;
                    case 2: //mód pro dva hráče
                        if ((skore_hrac1 == 12) || (skore_hrac2 == 12))
                        {
                            if (skore_hrac1 == 12) //Pokud dosáhl 12ti bodů hráč 1 
                            {
                                oznameni.Text = "Zvítězil hráč 1! Enter = zopakování hry, Reset = změna módu."; //vyhlášení
                            }
                            else if (skore_hrac2==12) //Jinak pokud měl hráč 2 12 bodů
                            {
                                oznameni.Text = "Zvítězil hráč 1! Enter = zopakování hry, Reset = změna módu."; //vyhlášení
                            }
                            oznameni.Location = new Point(this.Width / 2 - oznameni.Width / 2, 510); //Vycentrování textu
                            skore_hrac1 = 0;
                            skore_hrac2 = 0; //Reset skóre
                            stop = true;//Pozastavení hry
                            restart.Enabled = true;//Aktivace resetu
                        }
                        if (hrac2.Top <= 0) hrac2_horni_koncak = true;//Pokud pálka 2 dosáhla 0 souřadnice, aktivuje se horní koncák
                        else if (hrac2.Bottom >= hriste.Height) hrac2_dolni_koncak = true;//pokud spodní bod pálky dosáhl spodku, aktivuje se dolní koncák
                        else//Pokud není ani jedna podmínka pravda
                        {
                            hrac2_dolni_koncak = false;//Koncáky jsou neaktivní
                            hrac2_horni_koncak = false;
                        }
                        //Pokud je hroní koncák aktivní, posune se pálka jen, pokud se hráč chce posunout dolů a obráceně
                        if ((hrac2_horni_koncak == true) && (stav_stisknuteho_tlacitka_2 == 2)) hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y + posun_hrace2); 
                        else if ((hrac2_dolni_koncak == true) && (stav_stisknuteho_tlacitka_2 == 1)) hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y + posun_hrace2);
                        //Pokud jsou oba koncáky neaktivní, pálka se posouvá
                        else if ((hrac2_horni_koncak == false) && (hrac2_dolni_koncak == false)) hrac2.Location = new Point(hrac2.Location.X, hrac2.Location.Y + posun_hrace2); 
                        break;
                }
            }
        }

     

    


    }
}
