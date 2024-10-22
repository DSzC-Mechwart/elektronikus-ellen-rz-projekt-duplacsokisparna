using System;
using System.Collections.Generic;
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
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for HWindow.xaml
    /// </summary>
    public partial class HWindow : Window
    {
        public HWindow()
        {
            InitializeComponent();
            Beolvasas();
        }
        List<HConsturctor> adatok = new List<HConsturctor>();
        private void Beolvasas()
        {
            foreach (var item in File.ReadAllLines("HAdatok.txt", Encoding.UTF8))
            {
                string[] resz   = item.Split(';');

                string nev      = resz[0];
                int om          = Convert.ToInt32(resz[1]);
                string matek    = resz[2];
                string töri     = resz[3];
                string nyelvtan = resz[4];
                string irodalom = resz[5];
                string idegen   = resz[6];
                string szakma   = resz[7];
                string tesi     = resz[8];
                string fizika   = resz[9];

                HConsturctor ujTanulo = new HConsturctor(nev, om, matek, töri, nyelvtan, irodalom, idegen, szakma, tesi, fizika);
                adatok.Add(ujTanulo);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ( !(String.IsNullOrEmpty(HFN.Text)) && !(String.IsNullOrEmpty(HPass.Password)))
            {
                int index = 0;
                for (int i = 0; i < adatok.Count; i++)
                {
                    if (adatok[i].Nev == HFN.Text)
                        index = i;
                }
                if (adatok[index].OM == Convert.ToInt32(HPass.Password))
                {
                    HBWindow hb = new HBWindow(HFN.Text);
                    hb.Show();
                    Close();
                }
            }
        }
    }
}
