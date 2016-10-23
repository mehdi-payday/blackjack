using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardUtils {
    public class Card : IComparable<Card> {
        public enum Suits{
            SPADES,
            HEARTS,
            DIAMONDS,
            CLUBS

        }
        private int validateNumero(int avalider) {
            if (avalider >= 1 && avalider <= 13) {
                return avalider;
            } else {
                throw new Exception("Numero de carte invalide.");
            }
        }
        private int number;
        public int Number {
            get {
                return number;
            }
            private set {
                number = validateNumero(value);
            }
        }
        public Suits Suit {
            get;
            private set;
        }

        public Card(int number, Suits suit ) {
            Suit = suit;
            Number = number;
        }

        /*public override string ToString() {
            return formatCardText(Number + " " + Suit);
        }*/

        private string formatCardText( String text ) {
            return text.Replace( ' ', '\t' ).Replace( "11", "J" ).Replace( "12", "Q" ).Replace( "13", "K" ).Replace( "1\t", "A\t" );
        }

        public override string ToString() {
            string numCard = "";
            if (this.Number > 10 || this.Number == 1) {
                switch (this.Number) {
                    case 1:
                        numCard = "As";
                        break;
                    case 11:
                        numCard = "Valet";
                        break;
                    case 12:
                        numCard = "Dame";
                        break;
                    case 13:
                        numCard = "Roi";
                        break;
                }
            }
            numCard = this.Number.ToString();
            numCard = numCard + ", " + this.Suit.ToString();
            return numCard;
        }
        public string ImagePath()
        {
            string numCard = "_";
            if (this.Number > 10 || this.Number == 1)
            {
                switch (this.Number)
                {
                    case 1:
                        numCard = "ace";
                        break;
                    case 11:
                        numCard = "jack";
                        break;
                    case 12:
                        numCard = "queen";
                        break;
                    case 13:
                        numCard = "king";
                        break;
                }
            }
            else {
                numCard = this.Number +"";
            }
            numCard = "_" + numCard + "_of_" + this.Suit.ToString().ToLower();
            return numCard;
        }
        public string ShortName {
            get {
                return this.ToString();
            }
        }

        int IComparable<Card>.CompareTo(Card other) {
            return this.Number.CompareTo(((Card)other).Number);
        }
    }
}
