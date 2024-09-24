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
            InitializeComponent();
        }

        private void cBevitVissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
