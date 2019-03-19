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
            string firstName = "First Player";
            string secondName = "Second Player";
            string dealerName = "Dealer";

            if (!IsNull(txt_FirstPlayerName.Text))
            {
                firstName = txt_FirstPlayerName.Text;
            }
            if (!IsNull(txt_SecondPlayerName.Text))
            {
                secondName = txt_SecondPlayerName.Text;
            }
            if (!IsNull(txt_DealerName.Text))
            {
                dealerName = txt_DealerName.Text;
            }
            jack = new BlackJack(firstName, secondName, dealerName);
        }
        private bool IsNull(string name)
        {
            bool q = false;
            if (string.IsNullOrWhiteSpace(name))
            {
                q = true;
                return q;
            }
            return q;
        }


        //Observer Pattern//
        public void Update(IPublisher publisher)
        {
            //Update noget her!
        }
        //Observer Pattern//
    }
}
