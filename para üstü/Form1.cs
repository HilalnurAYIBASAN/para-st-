using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace para_üstü
{
    public partial class Form1 : Form
    {
        Image[] resimler =
        {
            Properties.Resources.Kagit_200TL,
            Properties.Resources.Kagit_100TL,
            Properties.Resources.Kagit_50TL,
            Properties.Resources.Kagit_20TL,
            Properties.Resources.Kagit_10TL,
            Properties.Resources.Kagit_5TL,
            Properties.Resources.Madeni_1TL,
            Properties.Resources.Madeni_50Kr,
            Properties.Resources.Madeni_25Kr,
            Properties.Resources.Madeni_10Kr,
            Properties.Resources.Madeni_5Kr,
            Properties.Resources.Madeni_1Kr
        };
        int[] paradegerleri = { 20000, 10000, 5000, 2000, 1000, 500, 100, 50, 25, 10, 5, 1 };
        int tutar, odenen, para_üstü;
        //virgüllerin karışmaması için para birirmlerinin hepsini kuruş cinsinden yazdım.


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox para = (PictureBox)sender;

            int deger = Convert.ToInt32(para.Tag);
            odenen += deger;
            label2.Text = (odenen / 100.0).ToString("0.00");

            PictureBox yenipara = new PictureBox();
            yenipara.Image = para.Image;
            yenipara.Tag = para.Tag;
            yenipara.SizeMode = PictureBoxSizeMode.AutoSize;
            yenipara.Click +=  Yenipara_Click;

            flowLayoutPanel_Tezgah.Controls.Add(yenipara);
        }

        private void Yenipara_Click(object sender, EventArgs e)
        {
            PictureBox para = (PictureBox)sender;

            int deger = Convert.ToInt32(para.Tag);
            odenen = odenen - deger;
            label2.Text = (odenen / 100.0).ToString("0.00");

            flowLayoutPanel_Tezgah.Controls.Remove(para);    
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Tezgah.Controls.Clear();

            para_üstü = odenen - tutar;
            label3.Text = (para_üstü / 100.0).ToString("0.00");

            System.Threading.Thread.Sleep(500);
            Refresh();

            int i = 0;
            while (para_üstü > 0)
            {
                if (para_üstü >= paradegerleri[i])
                {

                    System.Threading.Thread.Sleep(500);
                    Refresh();
                    para_üstü -= paradegerleri[i];


                    PictureBox yenipara = new PictureBox();
                    yenipara.Image = resimler[i];
                    yenipara.SizeMode = PictureBoxSizeMode.AutoSize;
                    flowLayoutPanel_Tezgah.Controls.Add(yenipara);

                }
                else
                {
                    i++;
                }
            }
        }

    

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tutar = rnd.Next(50000);
            label1.Text = (tutar / 100.0).ToString("0.00");
            odenen = 0;
            label2.Text = "0,00";
            para_üstü = 0;
            label3.Text = "0,00";

            flowLayoutPanel_Tezgah.Controls.Clear();
            
        }
    }
}
