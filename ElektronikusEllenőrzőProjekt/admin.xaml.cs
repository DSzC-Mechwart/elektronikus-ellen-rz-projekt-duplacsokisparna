using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xaml;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        List<c_Read_Bevit> adatok;

        dBevitel fgv = new dBevitel();

        public void Beolvas()
        {
            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                adatok = JsonSerializer.Deserialize<List<c_Read_Bevit>>(json);
            }
        }
        int bejaros;
        int kollegista;
        int infos;
        int gepesz;

        public admin()
        {
            InitializeComponent();
            bejaros = 0;
            kollegista = 0;
            infos = 0;
            gepesz = 0;
            Beolvas();
            Megjelenit(); 
        }

        public void Megjelenit()
        {
            bejaros = 0;
            kollegista = 0;
            infos = 0;
            gepesz = 0;
            var osztaly = adatok.GroupBy(x => x.osztaly);

            foreach (var item in osztaly)
            {

                var osztalyok  = item
                    .Where(x => x.beirIdo.Month < 9)
                    .OrderBy(x => x.nev)
                    .Concat(item.Where(x => x.beirIdo.Month >= 9).OrderBy(x => x.beirIdo));


                int naplo = 1;
                foreach (var i in osztalyok)
                {
                    i.naploszam = naplo;
                    naplo++;
                }


                string jsonString = JsonSerializer.Serialize(adatok);
                File.WriteAllText("test.json", jsonString);
                fgv.writeCsv(adatok, "test.csv");
            }
             

            for (int i = 0; i < adatok.Count; i++)
            {
                string honap = adatok[i].beirIdo.Month.ToString();
                adatok[i].torzsszam = $"{honap}/{adatok[i].naploszam}";
            }

            foreach (var item in adatok)
            {
                if (item.kolise.ToLower() == "igen") { kollegista++; } else { bejaros++; }
                if (item.szak.ToLower() == "informatika") { infos++; } else { gepesz++; }
            }

            kolista.Text = $"Kollégista: {kollegista}";
            bejar.Text = $"Bejárós: {bejaros}";
            infost.Text = $"Informatikus: {infos}";
            gepssz.Text = $"Gépész: {gepesz}";

            this.datas.ItemsSource = adatok;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (c_Read_Bevit)datas.SelectedItem;

            if (selectedItem != null)
            {

                MessageBoxResult valasz = MessageBox.Show("Adat törlése", "Biztos benne?", MessageBoxButton.YesNo);
                if (valasz == MessageBoxResult.Yes)
                {
                    adatok.Remove(selectedItem);

                    bejaros = 0;
                    kollegista = 0;
                    infos = 0;
                    gepesz = 0;

                    foreach (var item in adatok)
                    {
                        if (item.kolise.ToLower() == "igen") { kollegista++; } else { bejaros++; }
                        if (item.szak.ToLower() == "informatika") { infos++; } else { gepesz++; }
                    }

                    kolista.Text = $"Kollégista: {kollegista}";
                    bejar.Text = $"Bejárós: {bejaros}";
                    infost.Text = $"Informatikus: {infos}";
                    gepssz.Text = $"Gépész: {gepesz}";


                    string jsonString = JsonSerializer.Serialize(adatok);
                    File.WriteAllText("test.json", jsonString);

                    Beolvas();
                    fgv.writeCsv(adatok, "test.csv");
                }
            }
            this.datas.ItemsSource = adatok;
        }

        private void vissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
