using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.IO.Enumeration;
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

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for KWindow.xaml
    /// </summary>
    public partial class KWindow : Window
    {
        private List<Tantargyak> tantargyak = new List<Tantargyak>();
        public KWindow()
        {
            InitializeComponent();
            ReadIn();
            FillUpDataGrid();
        }

        public void ReadIn()
        {
            using (StreamReader r = new StreamReader("tantargyakK.json"))
            {
                string json = r.ReadToEnd();
                tantargyak = JsonSerializer.Deserialize<List<Tantargyak>>(json);
            }
        }

        public void FillUpDataGrid()
        {
            Kdatatable.ItemsSource = null;
            Kdatatable.ItemsSource = tantargyak;
        }

        private void KozismTan_Checked(object sender, RoutedEventArgs e)
        {
            SzakmaiTan.IsEnabled = false;
            Hetioraszam.IsEnabled = true;
        }
        private void KozismTan_Unchecked(object sender, RoutedEventArgs e)
        {
            SzakmaiTan.IsEnabled = true;
            Hetioraszam.IsEnabled = false;
        }

        private void SzakmaiTan_Checked(object sender, RoutedEventArgs e)
        {
            KozismTan.IsEnabled = false;
            Hetioraszam.IsEnabled = true;
        }
        private void SzakmaiTan_Unchecked(object sender, RoutedEventArgs e)
        {
            KozismTan.IsEnabled = true;
            Hetioraszam.IsEnabled = false;
        }

        private void Tantargy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tantargy.Text != null) { Evfolyam.IsEnabled = true; }
        }

        private void Evfolyam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Evfolyam.Text != null) { KozismTan.IsEnabled = true; SzakmaiTan.IsEnabled = true; }
        }

        private void Hetioraszam_TextChanged(object sender, TextChangedEventArgs e)
        {
            Feltolt.IsEnabled = false;
            if (Hetioraszam.Text != null && CheckStrOrInt(Hetioraszam.Text) == "int") { Feltolt.IsEnabled = true; }
        }

        private string CheckStrOrInt(string str)
        {
            try
            {
                Convert.ToInt32(str);
            } catch (Exception e)
            {
                return "str";
            }
            return "int";
        }
    }
}
