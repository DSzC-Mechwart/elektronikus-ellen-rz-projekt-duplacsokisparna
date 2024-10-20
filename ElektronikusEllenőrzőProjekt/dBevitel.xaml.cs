using System;
using System.Text.Json;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices.ComTypes;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for dBevitel.xaml
    /// </summary>
    public partial class dBevitel : Window
    {
        List<c_Read_Bevit> adatok;

        public void Beolvas()
        {
            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                adatok = JsonSerializer.Deserialize<List<c_Read_Bevit>>(json);
            }
        }


        static void writeCsv (List<c_Read_Bevit> list, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {

                sw.WriteLine("Nev,SzulHely,SzulIdo,Anyjanev,Lakcim,BeirIdo,Szak,Osztaly,Kolise,Koli,Naploszam,Torzsszam");


                foreach (var item in list)
                {
                    sw.WriteLine($"{item.nev},{item.szulHely},{item.szulIdo.ToShortDateString()},{item.anyjanev},{item.lakcim},{item.beirIdo.ToShortDateString()},{item.szak},{item.osztaly},{item.kolise},{item.koli},{item.naploszam},{item.torzsszam}");
                }
            }

        }

            public dBevitel()
        { 
            InitializeComponent();
            Beolvas();
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




        private void cBevitMentes_Click(object sender, RoutedEventArgs e)
        {
          

            int koli = Ckollegista.IsChecked == false ? 0 : 1;

            string line = $"{Ctnev.Text};{Cszulhely.Text};{Cszulido.Text};{Canya.Text};{Clakcim.Text};1;{Cbeirido.Text};{Cszak.Text};{Cosztaly.Text};{koli};{Ckollegium.Text}; vmi";

            var resz = line.Split(";");

            try
            {

                string cnev = resz[0];
                string cszulhely = resz[1];
                DateTime cszulido = string.IsNullOrEmpty(resz[2]) ? DateTime.MinValue : Convert.ToDateTime(resz[2]);  
                string anya = resz[3];
                string lakcim = resz[4];
                int naploszam = string.IsNullOrEmpty(resz[5]) ? 0 : Convert.ToInt32(resz[5]);  
                DateTime beirido = string.IsNullOrEmpty(resz[6]) ? DateTime.MinValue : Convert.ToDateTime(resz[6]);
                string szak = resz[7];
                string osztaly = resz[8];
                int kolis = Convert.ToInt32(resz[9]);
                string kollegium = resz[10];
                string torzsszam =resz[11]; 

                
                adatok.Add(new c_Read_Bevit(cnev, cszulhely, cszulido, anya, lakcim,  beirido, szak, osztaly, kolis, kollegium,naploszam, torzsszam));

                
                
                string jsonString = JsonSerializer.Serialize(adatok);
                File.WriteAllText("test.json", jsonString);

                writeCsv(adatok, "test.csv");

                MessageBox.Show("Adatok sikeresen el vannak mentve!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }


            this.Close();
        }

    }
}
