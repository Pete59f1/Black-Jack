using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Domain;

namespace App
{
    public class BlackJack
    {
        public BlackJack(string player1, string player2, string dealer)
        {
            List<Card> deck = Deck.GenerateCardDeck();
            Dealer deal = new Dealer { Name = dealer, CardDeck = deck};
            deal.Cards = deal.DealTwoCards();
            Player play1 = new Player { Name = player1, Cards = deal.DealTwoCards() };
            Player play2 = new Player { Name = player2, Cards = deal.DealTwoCards() };
        }
    }
}
