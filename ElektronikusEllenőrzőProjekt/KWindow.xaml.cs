﻿using System;
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
    /// Interaction logic for KWindow.xaml
    /// </summary>
    public partial class KWindow : Window
    {
        private List<Tantargyak> tantargyak;
        public KWindow()
        {
            InitializeComponent();
            tantargyak = new List<Tantargyak>();
        }

    }
}
