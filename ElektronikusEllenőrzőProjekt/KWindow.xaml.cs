using System;
using System.Collections.Generic;
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

    }
}
