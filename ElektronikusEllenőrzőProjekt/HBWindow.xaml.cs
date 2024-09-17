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
            WindowState = WindowState.Maximized;
            HNameDisplay.Content = HFNev;
        }
    }
}
