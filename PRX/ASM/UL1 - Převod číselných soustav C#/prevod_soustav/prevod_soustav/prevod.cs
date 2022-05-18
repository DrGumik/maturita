using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prevod_soustav
{
    class prevod
    {
        public static string z_10_2(long hodnota)
        {
            string vysledek = "";
            while (hodnota != 0)
            {
                vysledek = (hodnota % 2).ToString() + vysledek.ToString();
                hodnota = hodnota / 2;
            }
            return vysledek;
        }
        public static string z_10_8(long hodnota)
        {
            string vysledek = "";
            while (hodnota != 0)
            {
                vysledek = (hodnota % 8).ToString() + vysledek.ToString();
                hodnota = hodnota / 8;
            }
            char[] arr = vysledek.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static string z_10_16(long hodnota)
        {
            string vysledek = "";
            while (hodnota != 0)
            {
                long deleno = hodnota % 16;

                if (deleno > 9)
                {
                    if (deleno == 10) vysledek = "A" + vysledek.ToString();
                    if (deleno == 11) vysledek = "B" + vysledek.ToString();
                    if (deleno == 12) vysledek = "C" + vysledek.ToString();
                    if (deleno == 13) vysledek = "D" + vysledek.ToString();
                    if (deleno == 14) vysledek = "E" + vysledek.ToString();
                    if (deleno == 15) vysledek = "F" + vysledek.ToString();
                }
                else vysledek = deleno.ToString() + vysledek.ToString();
                hodnota = hodnota / 16;
            }
            return vysledek;
        }
        public static long z_2_10(long hodnota)
        {
            char[] dva = hodnota.ToString().ToCharArra­y();
            long vysledek = 0;
            int multiplier = 1;

            for (int i = dva.Length - 1; i >= 0; i--)
            {
                vysledek += (dva[i] == '1' ? 1 : 0) * multiplier;
                multiplier *= 2;
            }

            return vysledek;
        }
        public static int z_8_10(string hodnota)
        {
            int vysledek = 0;

            for (int i = 0; i < hodnota.Length; ++i)
            {
                int x = int.Parse(hodnota[i].ToString());

                vysledek += x * (int)Math.Pow(8, i);
            }

            return vysledek;
        }
        public static int z_16_10(string hodnota)
        {
            int vysledek = 0, multiplier = 0;

            for (int i = 0; i < hodnota.Length; ++i)
            {
                char x = hodnota[i];

                switch (x)
                {
                    case 'A':
                        multiplier = 10;
                        break;
                    case 'B':
                        multiplier = 11;
                        break;
                    case 'C':
                        multiplier = 12;
                        break;
                    case 'D':
                        multiplier = 13;
                        break;
                    case 'E':
                        multiplier = 14;
                        break;
                    case 'F':
                        multiplier = 15;
                        break;
                    case 'a':
                        multiplier = 10;
                        break;
                    case 'b':
                        multiplier = 11;
                        break;
                    case 'c':
                        multiplier = 12;
                        break;
                    case 'd':
                        multiplier = 13;
                        break;
                    case 'e':
                        multiplier = 14;
                        break;
                    case 'f':
                        multiplier = 15;
                        break;
                    default:
                        multiplier = int.Parse(x.ToString());
                        break;
                }

                vysledek += multiplier * (int)Math.Pow(16, (hodnota.Length - 1) - i);
            }

            return vysledek;
        }


    }
}
