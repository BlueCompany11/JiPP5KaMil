using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiPP5KaMil
{
    public partial class Form1 : Form
    {

        enum ButtonStatus
        {
            Clicked,
            InProgress,
            UnClicked
        }
        //status buttona zaczynajacego gre
        ButtonStatus buttonStatus = ButtonStatus.UnClicked;
        Model1 model1;
        public Form1()
        {
            InitializeComponent();
            model1 = new Model1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 21; i++)
            {
                comboBoxSeconds.Items.Add(i);
            }

            var gracze = model1.Players.Select(x => x.nick).ToList();
            foreach (var gracz in gracze)
            {
                comboBoxPlayers.Items.Add(gracz);
            }
        }

        private async Task WaitForClick()
        {
            //funkcja konczy sie gdy buttonStatus == clicked
            while (buttonStatus != ButtonStatus.Clicked)
            {
                await Task.Delay(10);
            }
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            //jesli nic nie jest wybrane w comboboxie to nic nie rob
            if (comboBoxSeconds.SelectedItem == null)
            {
                return;
            }
            //jesli przycisk jest juz wcisniety to zmien status na clicked
            //wtedy w metodzie WaitForClick zakonczy sie petla
            if (buttonStatus == ButtonStatus.InProgress)
            {
                buttonStatus = ButtonStatus.Clicked;
                return;
            }
            buttonStatus = ButtonStatus.InProgress;
            int amountOfSeconds = Int32.Parse(comboBoxSeconds.SelectedItem.ToString());
            buttonStart.Text = "Wcisnij jak najpozniej, ale przed " + amountOfSeconds.ToString() + " sekundami";
            //uruchamiam w osobynm watku metode do sprawdzania w petli jaki jest status przycisku
            var task = WaitForClick();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //czekam az ktorys task sie zakonczy
            //pierwszy polega na zmianie statusu przycisku - trzeba go ponownie by sie zmienil
            //drugi task polega na czekaniu pewnej ilosci sekund
            //metoda whenany zwraca ten task ktory sie zakonczy jako pierwszy
            //jesli tym taskiem bedzie zmienna task to znaczy, ze to przycisk zostal wcisniety zanim minal czas
            if (await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(amountOfSeconds))) == task)
            {
                sw.Stop();
                //ma byc podkreslone na zielono
                //nie uzywam timera tylko asynchronicznosci
                //resultAnimation to task ktory od razu sie uruchamia przy wywolaniu i kod leci dalej, a animacja sie znajduje w innym watku
                ResultAnimation(true);
                //zapisz rezultat i otworz tabele z wynikami
                Console.WriteLine(comboBoxPlayers.SelectedItem.ToString());
                Console.WriteLine(comboBoxSeconds.SelectedItem.ToString());
                DodajWynik(TimeSpan.FromSeconds(amountOfSeconds).TotalMilliseconds - (int)sw.ElapsedMilliseconds,
                    comboBoxPlayers.SelectedItem.ToString(), amountOfSeconds);
            }
            else
            {
                sw.Stop();
                ResultAnimation(false);
            }
            buttonStart.Text = "Start";
            buttonStatus = ButtonStatus.UnClicked;
        }
        private async Task ResultAnimation(bool result)
        {
            //dx ile przesunac pixeli w prawo
            int dx = 10;
            //4 - ilosc skokow napisu
            for (int i = 0; i < 4; i++)
            {
                string strResult = "Brawo!";
                if (result == false)
                    strResult = "Przegrales";
                Bitmap bmp1 = new Bitmap(tableLayoutPanelAnimation.Width, tableLayoutPanelAnimation.Height);
                Graphics graphics = Graphics.FromImage(bmp1);
                graphics.TranslateTransform(dx, 0);
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                graphics.DrawString(strResult, drawFont, drawBrush, 110, 110, drawFormat);
                tableLayoutPanelAnimation.BackgroundImage = bmp1;
                dx += 100;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private void DodajWynik(double czasGracza, string aktualnyNick, int limitCzasowyGry)
        {
            //string aktualnyNick = comboBoxPlayers.SelectedValue.ToString();
            //int limitCzasowyGry = Convert.ToInt32(comboBoxSeconds.SelectedValue.ToString());
            Console.WriteLine("asd");
            var listaPlayerow = model1.Players.Where(x => x.nick == aktualnyNick).ToList();
            Player gracz = listaPlayerow[0];
            Scoreboard scoreboard = new Scoreboard { idGracza = gracz.id, limitCzasowy = limitCzasowyGry, czasGracza = czasGracza, dataRozgrywki = DateTime.Now };
            model1.Scoreboards.Add(scoreboard);
            model1.SaveChanges();
            //var TablicaWynikow = new ScoreboadForm();
            //TablicaWynikow.Show();
            //POPRAWIC NA AUTOINCEMENT KEY W SCOREBOARD I JESZCZE RAZ EF POSTAWIC
        }

    }
}
