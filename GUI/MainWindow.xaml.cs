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

namespace GUI
{
    public partial class MainWindow : Window, ISubscriber
    {
        private BlackJack jack;
        private int currentPlayer = 1;
        public MainWindow()
        {
            InitializeComponent();
        }


        //Buttons
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
            jack.RegisterSubscriber(this);

            NewGameStart();
        }
        private void Btn_HitMe_Click(object sender, RoutedEventArgs e)
        {
            if (!PlayerLose(currentPlayer))
            {
                jack.HitMe(currentPlayer);
            }
            else
            {
                btn_HitMe.IsEnabled = false;
            }
        }
        private void Btn_Hold_Click(object sender, RoutedEventArgs e)
        {
            if (currentPlayer.Equals(1))
            {
                lbl_SPlayerName.IsEnabled = true;
                lbl_SPlayerPoints.IsEnabled = true;
                lb_SPlayerCards.IsEnabled = true;
                lbl_FPlayerName.IsEnabled = false;
                lbl_FPlayerPoints.IsEnabled = false;
                lb_FPlayerCards.IsEnabled = false;
                currentPlayer++;
            }
            else
            {
                lbl_DealerName.IsEnabled = true;
                lbl_DealerPoints.IsEnabled = true;
                lb_DealerCards.IsEnabled = true;
                lbl_SPlayerName.IsEnabled = false;
                lbl_SPlayerPoints.IsEnabled = false;
                lb_SPlayerCards.IsEnabled = false;
                currentPlayer++;
                btn_NextRound.IsEnabled = true;
                btn_Hold.IsEnabled = false;
            }
        }
        private void Btn_NextRound_Click(object sender, RoutedEventArgs e)
        {
            lbl_FPlayerName.IsEnabled = true;
            lbl_FPlayerPoints.IsEnabled = true;
            lb_FPlayerCards.IsEnabled = true;
            lbl_DealerName.IsEnabled = false;
            lbl_DealerPoints.IsEnabled = false;
            lb_DealerCards.IsEnabled = false;
            currentPlayer = 1;
            btn_NextRound.IsEnabled = false;
            btn_Hold.IsEnabled = true;
            jack.NextRound();
        }
        //Buttons


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
            lbl_FPlayerPoints.Content = jack.GetPlayerPoints(1);
            lbl_SPlayerPoints.Content = jack.GetPlayerPoints(2);
            lbl_DealerPoints.Content = jack.GetPlayerPoints(3);
            PrintCards(1);
            PrintCards(2);
            PrintCards(3);
        }
        private bool PlayerLose(int playerNumber)
        {
            bool q = false;
            if (playerNumber.Equals(1))
            {
                if (jack.GetPlayerPoints(1) > 21)
                {
                    q = true;
                    return q;
                }
            }
            else if (playerNumber.Equals(2))
            {
                if (jack.GetPlayerPoints(2) > 21)
                {
                    q = true;
                    return q;
                }
            }
            else
            {
                if (jack.GetPlayerPoints(3) > 21)
                {
                    q = true;
                    return q;
                }
            }
            return q;
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
