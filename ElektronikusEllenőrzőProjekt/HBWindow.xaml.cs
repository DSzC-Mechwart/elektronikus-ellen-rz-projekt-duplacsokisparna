using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ElektronikusEllenőrzőProjekt
{
    /// <summary>
    /// Interaction logic for HBWindow.xaml
    /// </summary>
    public partial class HBWindow : Window
    {
        
        public HBWindow(string HFNev)
        {
            InitializeComponent();
            HNameDisplay.Content = HFNev;
            HFNEV = HFNev;
            Beolvasas();
        }

        public string HFNEV;
        public float matekAtlag;
        public float töriAtlag;
        public float nyelvtanAtlag;
        public float irodalomAtlag;
        public float idegenAtlag;
        public float szakmaAtlag;
        public float tesiAtlag;
        public float fizikaAtlag;
        public float osszAtlag;

        List<HConsturctor> adatok = new List<HConsturctor>();
        private void Beolvasas()
        {
            foreach (var item in File.ReadAllLines("HAdatok.txt", Encoding.UTF8))
            {
                string[] resz = item.Split(';');

                string nev = resz[0];
                int om = Convert.ToInt32(resz[1]);
                string matek = resz[2];
                string töri = resz[3];
                string nyelvtan = resz[4];
                string irodalom = resz[5];
                string idegen = resz[6];
                string szakma = resz[7];
                string tesi = resz[8];
                string fizika = resz[9];

                HConsturctor ujTanulo = new HConsturctor(nev, om, matek, töri, nyelvtan, irodalom, idegen, szakma, tesi, fizika);
                adatok.Add(ujTanulo);
            }
        }
        private void HAtlagok(int index)
        {
            string[] currentAtlag;
            int HHossz;
            int HHolder = 0;

            currentAtlag = adatok[index].Matek.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz+3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            matekAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Töri.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                //MessageBox.Show(currentAtlag[i]);
                HHolder += Convert.ToInt32(currentAtlag[i]);
            töriAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Nyelvtan.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            nyelvtanAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Irodalom.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            irodalomAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Idegen.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            idegenAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Szakma.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            szakmaAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Tesi.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            tesiAtlag = HHolder / HHossz;

            HHolder = 0;
            currentAtlag = adatok[index].Fizika.Split(' ');
            HHossz = currentAtlag.Length / 3;
            for (int i = 0; i <= HHossz + 3; i += 3)
                HHolder += Convert.ToInt32(currentAtlag[i]);
            fizikaAtlag = HHolder / HHossz;
        }
        private void HFeltoltes()
        {
            HJegyekList.Items.Clear();
            int index = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Nev == HFNEV)
                    index = i;
            }
            HAtlagok(index);
            string[] HSelectedJegyek = adatok[index].Matek.Split(',');
            switch (HTargySelection.SelectedIndex)
            {
                case 0:
                    HSelectedJegyek = adatok[index].Matek.Split(',');
                    HAtlag.Content = $"Átlag : {matekAtlag}";
                    break;
                case 1:
                    HSelectedJegyek = adatok[index].Töri.Split(',');
                    HAtlag.Content = $"Átlag : {töriAtlag}";
                    break;
                case 2:
                    HSelectedJegyek = adatok[index].Nyelvtan.Split(',');
                    HAtlag.Content = $"Átlag : {nyelvtanAtlag}";
                    break;
                case 3:
                    HSelectedJegyek = adatok[index].Irodalom.Split(',');
                    HAtlag.Content = $"Átlag : {irodalomAtlag}";
                    break;
                case 4:
                    HSelectedJegyek = adatok[index].Idegen.Split(',');
                    HAtlag.Content = $"Átlag : {idegenAtlag}";
                    break;
                case 5:
                    HSelectedJegyek = adatok[index].Szakma.Split(',');
                    HAtlag.Content = $"Átlag : {szakmaAtlag}";
                    break;
                case 6:
                    HSelectedJegyek = adatok[index].Tesi.Split(',');
                    HAtlag.Content = $"Átlag : {tesiAtlag}";
                    break;
                case 7:
                    HSelectedJegyek = adatok[index].Fizika.Split(',');
                    HAtlag.Content = $"Átlag : {fizikaAtlag}";
                    break;
            }
            Hooszatlag.Content = $"Össz átlag : {(matekAtlag + nyelvtanAtlag + irodalomAtlag + idegenAtlag + szakmaAtlag + tesiAtlag + fizikaAtlag) / 7}";
            for (int i = 0; i < HSelectedJegyek.Length; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = HSelectedJegyek[i];
                HJegyekList.Items.Add(itm);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int HSJegy = 0;
            if (H1.IsChecked == true)
                HSJegy = 1;
            else if (H2.IsChecked == true)
                HSJegy = 2;
            else if (H3.IsChecked == true)
                HSJegy = 3;
            else if (H4.IsChecked == true)
                HSJegy = 4;
            else if (H5.IsChecked == true)
                HSJegy = 5;

            ListBoxItem itm = new ListBoxItem();
            itm.Content = $"{HSJegy} {HSelectedTipus.Text} {HMegjegyzes.Text}";
            HJegyekList.Items.Add(itm);


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HFeltoltes();
        }
    }
}
