using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJeuCartes {
    public class Card {
        public enum Suits{
            SPADE,
            HEARTH,
            DIAMOND,
            CLUBS

        }

        public int Number {
            get;
            private set;
        }
        public Suits Suit {
            get;
            private set;
        }

        public Card(int number, Suits suit ) {
            Suit = suit;
            Number = number;
        }

        public override string ToString() {
            return formatCardText(Number + " " + Suit);
        }

        private string formatCardText( String text ) {
            return text.Replace( ' ', '\t' ).Replace( "11", "J" ).Replace( "12", "Q" ).Replace( "13", "K" ).Replace( "1\t", "A\t" );
        }
    }
}
