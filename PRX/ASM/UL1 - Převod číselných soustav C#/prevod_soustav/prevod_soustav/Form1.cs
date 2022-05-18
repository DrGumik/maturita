using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Vytvořil Jakub Tenk z A3

namespace prevod_soustav
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            tb2.Text = "";

            if (rb1.Checked) //2
            {
                if (rb5.Checked) //2
                {
                    tb2.Text = tb1.Text;
                }
                if (rb6.Checked)
                {
                    tb2.Text = prevod.z_10_8(prevod.z_2_10(long.Parse(tb1.Text)));
                }
                if (rb7.Checked)
                {
                    tb2.Text = prevod.z_2_10(long.Parse(tb1.Text)).ToString();
                }
                if (rb8.Checked)
                {
                    tb2.Text = prevod.z_10_16(prevod.z_2_10(long.Parse(tb1.Text)));
                }
            }
            if (rb2.Checked) //8
            {
                if (rb5.Checked)
                {
                    tb2.Text = prevod.z_10_2(prevod.z_8_10(tb1.Text));
                }
                if (rb6.Checked) //8
                {
                    tb2.Text = tb1.Text;
                }
                if (rb7.Checked)
                {
                    tb2.Text = prevod.z_8_10(tb1.Text).ToString();
                }
                if (rb8.Checked)
                {
                    tb2.Text = prevod.z_10_16(prevod.z_8_10(tb1.Text));
                }
            }
            if (rb3.Checked) //10
            {
                if (rb5.Checked)
                {
                    tb2.Text = prevod.z_10_2(long.Parse(tb1.Text));
                }
                if (rb6.Checked)
                {
                    tb2.Text = prevod.z_10_8(long.Parse(tb1.Text));
                }
                if (rb7.Checked) //10
                {
                    tb2.Text = tb1.Text;
                }
                if (rb8.Checked)
                {
                    tb2.Text = prevod.z_10_16(long.Parse(tb1.Text));
                }
            }
            if (rb4.Checked) //16
            {
                if (rb5.Checked)
                {
                    tb2.Text = prevod.z_10_2(prevod.z_16_10(tb1.Text));
                }
                if (rb6.Checked)
                {
                    tb2.Text = prevod.z_10_8(prevod.z_16_10(tb1.Text));
                }
                if (rb7.Checked)
                {
                    tb2.Text = prevod.z_16_10(tb1.Text).ToString();
                }
                if (rb8.Checked) //16
                {
                    tb2.Text = tb1.Text;
                }
            }
        }
    }
}
