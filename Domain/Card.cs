using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Card
    {
        private string displayName;
        private Suit suit;
        private int value;
        public string DisplayName { get { return displayName; } set { displayName = value; } }
        public Suit Suit { get { return suit; } set { suit = value; } }
        public int Value { get { return value; } set { this.value = value; } }

        public static string ShortName(int value, Suit suit)
        {
            string shortName = "";

            if (value >= 2 && value <= 10)
            {
                shortName = value.ToString();
            }
            else if (value == 11)
            {
                shortName = "JACK";
            }
            else if (value == 12)
            {
                shortName = "QUEEN";
            }
            else if (value == 13)
            {
                shortName = "KING";
            }
            else
            {
                shortName = "ACE";
            }
            return shortName + " of " + Enum.GetName(typeof(Suit), suit);
        }
    }
}
