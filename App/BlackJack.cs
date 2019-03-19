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
        public BlackJack(string player1, string player2, string dealer)
        {
            List<Card> deck = Deck.GenerateCardDeck();
            Dealer deal = new Dealer { Name = dealer, CardDeck = deck};
            deal.Cards = deal.DealStartUpCards();
            Player play1 = new Player { Name = player1, Cards = deal.DealStartUpCards() };
            Player play2 = new Player { Name = player2, Cards = deal.DealStartUpCards() };
        }


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
