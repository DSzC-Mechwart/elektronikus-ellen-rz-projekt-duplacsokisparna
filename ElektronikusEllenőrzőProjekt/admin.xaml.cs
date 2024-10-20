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

        static void writeCsv(List<c_Read_Bevit> list, string filePath)
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

            public void Beolvas()
        {
            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                adatok = JsonSerializer.Deserialize<List<c_Read_Bevit>>(json);
            }
        }


        public admin()
        {
            InitializeComponent();
            Beolvas();
            Megjelenit();
        }

        public void Megjelenit()
        {

            var grouped = adatok.GroupBy(x => x.osztaly);

            foreach (var group in grouped)
            {

                var sortedGroup = group
                    .Where(x => x.beirIdo.Month < 9)
                    .OrderBy(x => x.nev)
                    .Concat(group.Where(x => x.beirIdo.Month >= 9).OrderBy(x => x.beirIdo));


                int serialNumber = 1;
                foreach (var item in sortedGroup)
                {
                    item.naploszam = serialNumber;
                    serialNumber++;
                }


                string jsonString = JsonSerializer.Serialize(adatok);
                File.WriteAllText("test.json", jsonString);
                writeCsv(adatok, "test.csv");
            }


            for (int i = 0; i < adatok.Count; i++)
            {
                string honap = adatok[i].beirIdo.Month.ToString();
                adatok[i].torzsszam = $"{honap}/{adatok[i].naploszam}";
            }

            

            this.datas.ItemsSource = adatok;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (c_Read_Bevit)datas.SelectedItem;

            if (selectedItem != null)
            {
                adatok.Remove(selectedItem);
                string jsonString = JsonSerializer.Serialize(adatok);
                File.WriteAllText("test.json", jsonString);
                
                Beolvas();
                writeCsv(adatok, "test.csv");

            }
            this.datas.ItemsSource = adatok;
        }
    }
}
