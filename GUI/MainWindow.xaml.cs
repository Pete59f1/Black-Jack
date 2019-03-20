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
            lbl_FPlayerName.Content = firstName;
            lbl_SPlayerName.Content = secondName;
            lbl_DealerName.Content = dealerName;
            lbl_FPlayerPoints.Content = jack.GetPlayerPoints(1);
            lbl_SPlayerPoints.Content = jack.GetPlayerPoints(2);
            lbl_DealerPoints.Content = jack.GetPlayerPoints(3);
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
        private void PrintCards(int playerNumber)
        {
            if (playerNumber.Equals(1))
            {
                //Skriv kort ud!
                jack.GetPlayerCards(1);
            }
            else if (playerNumber.Equals(2))
            {
                //Skriv
            }
            else
            {
                //Skriv
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
