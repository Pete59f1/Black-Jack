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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interfaces;
using App;

namespace BlackJack
{
    public partial class MainWindow : Window, ISubscriber
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Update(IPublisher publisher)
        {
            //Update noget her!
        }

        private void Btn_NewGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
