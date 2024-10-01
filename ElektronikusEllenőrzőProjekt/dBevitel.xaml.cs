using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for dBevitel.xaml
    /// </summary>
    public partial class dBevitel : Window
    {
        List<c_Read_Bevit> adatok;

        public void Beolvas(string filepath)
        {
            adatok = new List<c_Read_Bevit>();

            foreach (var i in File.ReadAllLines(filepath))
            {
                var resz = i.Split(";");
                string nev = resz[0];
                string szulhely = resz[1];
                int szulido = Convert.ToInt32(resz[2]);
                string anyanev = resz[3];
                string lakcim = resz[4];
                int naploszam = Convert.ToInt32(resz[5]);
                DateTime beiratkozas = Convert.ToDateTime(resz[6]);
                string szak = resz[7];
                string oszatly = resz[8];
                bool kollegista = Convert.ToBoolean(resz[9]);
                string kollegium = resz[10];
                int torszszam = Convert.ToInt32(resz[11]);

                c_Read_Bevit x = new(nev, szulhely, szulido, anyanev, lakcim, naploszam, beiratkozas, szak, oszatly, kollegista, kollegium, torszszam);
                adatok.Add(x);
            }
        }
        public dBevitel()
        {
            Beolvas("test.txt");
            InitializeComponent();
            Ckollegium.IsEnabled = false;
        }

        private void cBevitVissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kollegista_Checked(object sender, RoutedEventArgs e)
        {
            Ckollegium.IsEnabled = true;
        }

        private void kollegista_Unchecked(object sender, RoutedEventArgs e)
        {
            Ckollegium.IsEnabled = false;
            Ckollegium.Text = string.Empty;
        }


        public void AdatFeltoltes()
        {
            foreach (var i in adatok)
            {
                i.Nev = Ctnev.Text;
                i.Szulhely = Cszulhely.Text;
                i.Szulido = Convert.ToInt32(Cszulido.Text);
                i.Anyanev = Canya.Text;
                i.Lakcim = Clakcim.Text;
                i.Naploszam = Convert.ToInt32(naploszam.Text);
                i.Beiratkozas = Convert.ToDateTime(Cbeirido);
                i.Szak = Cszak.Text;
                i.Osztaly = Cosztaly.Text;
                if(Ckollegista.IsChecked == false) { i.Kollegista = false; }
                else if(Ckollegista.IsChecked == true) { i.Kollegista = true;}
                if (Ckollegista.IsChecked == false) { i.Kollegium = ""; }
                else if (Ckollegista.IsChecked == true) { i.Kollegium = Ckollegium.Text; }
                i.Torszszam = Convert.ToInt32(Ctorzsszam.Text);
            }
        }

        public void WriteListToFile(string filepath)
        {
            AdatFeltoltes();
            List<string> lines = new List<string>();

            foreach (var item in adatok)
            {
                string line = $"{item.Nev};{item.Szulhely};{item.Szulido};{item.Anyanev};{item.Lakcim};" +
                              $"{item.Naploszam};{item.Beiratkozas};{item.Szak};{item.Osztaly};" +
                              $"{item.Kollegista};{item.Kollegium};{item.Torszszam}";
                lines.Add(line);
            }
        }

            private void cBevitMentes_Click(object sender, RoutedEventArgs e)
        {
            WriteListToFile("test.txt");
            this.Close();
        }

    }
}
