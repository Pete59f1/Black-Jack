using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        private string name;
        private List<Card> cards;
        private int points;

        public string Name { get { return name; } set { name = value; } }
        public List<Card> Cards { get { return cards; } set { cards = value; } }
        public int Points { get { return points; } set { points = value; } }
    }
}
