using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dealer : Player
    {
        private List<Card> cardDeck;

        public List<Card> CardDeck { get { return cardDeck; } set { cardDeck = value; } }

        public Card DealCard()
        {
            Card card = CardDeck[0];
            CardDeck.RemoveAt(0);
            return card;
        }
        public List<Card> DealStartUpCards()
        {
            List<Card> cards = new List<Card>();
            cards.Add(DealCard());
            cards.Add(DealCard());
            return cards;
        }
    }
}
