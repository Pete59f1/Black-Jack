using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain;

namespace App
{
    public class BlackJack : IPublisher
    {
        private List<Card> deck;
        private Player play1;
        private Player play2;
        private Dealer deal;

        public BlackJack(string player1, string player2, string dealer)
        {
            deck = Deck.GenerateCardDeck();
            deal = new Dealer { Name = dealer, CardDeck = deck};
            play1 = new Player { Name = player1 };
            play2 = new Player { Name = player2 };
            StartOfGame();
        }

        private void StartOfGame()
        {
            deal.Cards = deal.DealStartUpCards();
            play1.Cards = deal.DealStartUpCards();
            play2.Cards = deal.DealStartUpCards();

            play1.Points = CalcPoints(play1.Cards);
            play2.Points = CalcPoints(play2.Cards);
            deal.Points = CalcPoints(deal.Cards);
        }
        private int CalcPoints(List<Card> cards)
        {
            int points = 0;
            foreach (Card card in cards)
            {
                if (card.Value >= 2 && card.Value <= 9)
                {
                    points += card.Value;
                }
                else if (card.Value > 9 && card.Value < 14)
                {
                    points += 10;
                }
                else
                {
                    if (points >= 11)
                    {
                        points += 1;
                    }
                    else
                    {
                        points += 11;
                    }
                }
            }
            if (cards.Count.Equals(5) && points <= 21)
            {
                points = 21;
            }
            return points;
        }

        public void HitMe(int playerNumber)
        {
            if (playerNumber.Equals(1))
            {
                play1.Cards.Add(deal.DealCard());
                NotifySubscribers();
            }
            else if (playerNumber.Equals(2))
            {
                play2.Cards.Add(deal.DealCard());
                NotifySubscribers();
            }
            else
            {
                deal.Cards.Add(deal.DealCard());
                NotifySubscribers();
            }
        }
        public void NextRound()
        {
            play1.Cards.Clear();
            play2.Cards.Clear();
            deal.Cards.Clear();
            deal.CardDeck.Clear();
            deal.CardDeck.AddRange(Deck.GenerateCardDeck());
            StartOfGame();
            NotifySubscribers();
        }


        //Find data metoder
        public int GetPlayerPoints(int playerNumber)
        {
            if (playerNumber.Equals(1))
            {
                return CalcPoints(play1.Cards);
            }
            else if (playerNumber.Equals(2))
            {
                return CalcPoints(play2.Cards);
            }
            else
            {
                return CalcPoints(deal.Cards);
            }
        }
        public List<string> GetPlayerCards(int playerNumber)
        {
            List<string> cards = new List<string>();
            if (playerNumber.Equals(1))
            {
                foreach (Card c in play1.Cards)
                {
                    cards.Add(c.DisplayName);
                }
            }
            else if (playerNumber.Equals(2))
            {
                foreach (Card c in play2.Cards)
                {
                    cards.Add(c.DisplayName);
                }
            }
            else
            {
                foreach (Card c in deal.Cards)
                {
                    cards.Add(c.DisplayName);
                }
            }
            return cards;
        }
        //Find data metoder


        //Observer Pattern//
        private List<ISubscriber> subs = new List<ISubscriber>();
        public void NotifySubscribers()
        {
            foreach (ISubscriber sub in subs)
            {
                sub.Update(this);
            }
        }
        public void RegisterSubscriber(ISubscriber observer)
        {
            subs.Add(observer);
        }
        public void RemoveSubscriber(ISubscriber observer)
        {
            subs.Remove(observer);
        }
        //Observer Pattern//
    }
}