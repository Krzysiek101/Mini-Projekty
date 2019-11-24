using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wisielec
{
    public partial class Form1 : Form
    {
        string slowo;
        int ile_pudel = 0;
        public Form1()
        {
            InitializeComponent();
            LosujSlowo();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //przycisk sprawdź
        private void Button1_Click(object sender, EventArgs e)
        {
            if (ile_pudel < 5)
            {
                string litera = textBox1.Text;
                bool czy_trafiony = false;
                int gdzie_trafiony = 10;// jeżeli jest ustawione na 0 to pętla się psuje i zmienia pierwszą literę.

                for (int i = 0; i < 7; i++)
                {
                    if (Convert.ToString(slowo[i]) == litera)
                    {
                        czy_trafiony = true;
                        gdzie_trafiony = i;
                    }
                    if (gdzie_trafiony == 0) { Litera1.Text = litera; }
                    if (gdzie_trafiony == 1) { Litera2.Text = litera; }
                    if (gdzie_trafiony == 2) { Litera3.Text = litera; }
                    if (gdzie_trafiony == 3) { Litera4.Text = litera; }
                    if (gdzie_trafiony == 4) { Litera5.Text = litera; }
                    if (gdzie_trafiony == 5) { Litera6.Text = litera; }
                    if (gdzie_trafiony == 6) { Litera7.Text = litera; }
                }

                if (czy_trafiony == false)
                {
                    ile_pudel = ile_pudel + 1;
                    if (ile_pudel == 1) { pictureBox1.Image = wisielec.Properties.Resources._1; }
                    if (ile_pudel == 2) { pictureBox1.Image = wisielec.Properties.Resources._2; }
                    if (ile_pudel == 3) { pictureBox1.Image = wisielec.Properties.Resources._3; }
                    if (ile_pudel == 4) { pictureBox1.Image = wisielec.Properties.Resources._4; }
                    if (ile_pudel == 5) {
                        pictureBox1.Image = wisielec.Properties.Resources.przegrana;
                        button2.Visible = true;
                    }
                }
                wygrana();
            }
            else
            {
                pictureBox1.Image = wisielec.Properties.Resources.przegrana;
            }
        }
        
        private void LosujSlowo()
        {
            //tablica z słowami zagadki
            string[] slowa = { "krokusy", "liliput", "marchew", "selerek", "krakers", "klakier", "ciastka","pstrągi" };
            int ile_slow = slowa.Length;

            // generetor do losowania słowa zagadki z tablicy
            Random gen = new Random();
            int indeks_slowa = gen.Next(0, ile_slow);
            slowo = slowa[indeks_slowa];

            //generator losowych liczb do wyznaczania losowego miejsca odkrytych liter
                //litera_1
            Random gen1 = new Random();
            int litera_1 = gen1.Next(0, 2);
                //litera_2
            Random gen2 = new Random();
            int litera_2 = gen2.Next(3, 6);

            //ustalenie która litera ma się pokazać w podpowidzi
                //litera_1
            if (litera_1 == 0) {Litera1.Text = Convert.ToString(slowo[0]);}
            if (litera_1 == 1) {Litera2.Text = Convert.ToString(slowo[1]);}
            if (litera_1 == 2) {Litera3.Text = Convert.ToString(slowo[2]);}
                //litera_2
            if (litera_2 == 3) {Litera4.Text = Convert.ToString(slowo[3]);}
            if (litera_2 == 4) {Litera5.Text = Convert.ToString(slowo[4]);}
            if (litera_2 == 5) {Litera6.Text = Convert.ToString(slowo[5]);}
            if (litera_2 == 6) {Litera7.Text = Convert.ToString(slowo[6]);}

            //Litera1.Text = Convert.ToString(slowo[0]);
            //Litera7.Text = Convert.ToString(slowo[6]);

        }
        private void wygrana()
        {
            if(Litera1.Text != "_")
            { 
                if(Litera2.Text != "_")
                {
                    if (Litera3.Text != "_")
                    {
                        if (Litera4.Text != "_")
                        {
                            if (Litera5.Text != "_")
                            {
                                if (Litera6.Text != "_")
                                {
                                    if (Litera7.Text != "_")
                                    {
                                        pictureBox1.Image = wisielec.Properties.Resources.wygrana;
                                        button2.Visible = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //restart button
        private void Button2_Click(object sender, EventArgs e)
        {
            //ustawienie domyślengo znaku 
            Litera1.Text = "_";
            Litera2.Text = "_";
            Litera3.Text = "_";
            Litera4.Text = "_";
            Litera5.Text = "_";
            Litera6.Text = "_";
            Litera7.Text = "_";
            //wylosowanie słowa zagadki
            LosujSlowo();
            //reset ilości pudeł oraz ukrycie przycisku "reset" oraz wyczyszczenie picturebox1
            ile_pudel = 0;
            button2.Visible = false;
            pictureBox1.Image = null;
        }
    }
}
