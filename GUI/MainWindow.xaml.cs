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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Interfaces;
using App;

namespace GUI
{
    public partial class MainWindow : Window, ISubscriber
    {
        private BlackJack jack;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_FirstPlayerName.Text) && string.IsNullOrWhiteSpace(txt_SecondPlayerName.Text) && string.IsNullOrWhiteSpace(txt_DealerName.Text))
            {
                jack = new BlackJack("First player", "Second player", "Dealer");
            }
        }


        //Observer Pattern//
        public void Update(IPublisher publisher)
        {
            //Update noget her!
        }
        //Observer Pattern//
    }
}
