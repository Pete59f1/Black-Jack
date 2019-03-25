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
            PrintCards(1);
            PrintCards(2);
            PrintCards(3);

            NewGameStart();
        }
        private void Btn_HitMe_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Hold_Click(object sender, RoutedEventArgs e)
        {
            
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
            List<string> cards = jack.GetPlayerCards(playerNumber);
            if (playerNumber.Equals(1))
            {
                lb_FPlayerCards.Items.Clear();
                for (int i = 0; i < cards.Count; i++)
                {
                    lb_FPlayerCards.Items.Add(cards.ElementAt(i));
                }
            }
            else if (playerNumber.Equals(2))
            {
                lb_SPlayerCards.Items.Clear();
                for (int i = 0; i < cards.Count; i++)
                {
                    lb_SPlayerCards.Items.Add(cards.ElementAt(i));
                }
            }
            else
            {
                lb_DealerCards.Items.Clear();
                for (int i = 0; i < cards.Count; i++)
                {
                    lb_DealerCards.Items.Add(cards.ElementAt(i));
                }
            }
        }
        private void NewGameStart()
        {
            txt_FirstPlayerName.IsEnabled = false;
            txt_SecondPlayerName.IsEnabled = false;
            txt_DealerName.IsEnabled = false;
            btn_NewGame.IsEnabled = false;
            lbl_SPlayerName.IsEnabled = false;
            lbl_SPlayerPoints.IsEnabled = false;
            lb_SPlayerCards.IsEnabled = false;
            lbl_DealerName.IsEnabled = false;
            lbl_DealerPoints.IsEnabled = false;
            lb_DealerCards.IsEnabled = false;
            btn_HitMe.IsEnabled = true;
            btn_Hold.IsEnabled = true;
        }


        //Observer Pattern//
        public void Update(IPublisher publisher)
        {
            lbl_FPlayerPoints.Content = jack.GetPlayerPoints(1);
            lbl_SPlayerPoints.Content = jack.GetPlayerPoints(2);
            lbl_DealerPoints.Content = jack.GetPlayerPoints(3);
            PrintCards(1);
            PrintCards(2);
            PrintCards(3);
        }
        //Observer Pattern//
    }
}
