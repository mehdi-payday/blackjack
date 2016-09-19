using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJeuCartes
{
    public class Deck
    {
        private List<Card> cards;
        private Random r;

        public Deck() {
            r = new Random();
            loadCards();
        }

        private void loadCards() {
            cards = new List<Card>();
            for (int i = 0; i < 13; i++) {
                cards.Add( new Card( (i + 1), Card.Suits.SPADE) );
                cards.Add( new Card( (i + 1), Card.Suits.CLUBS ) );
                cards.Add( new Card( (i + 1), Card.Suits.HEARTH ) );
                cards.Add( new Card( (i + 1), Card.Suits.DIAMOND ) );
            }
        }

        public void Add(Card c) {
            cards.Add( c );
        }

        public Card Pick() {
            return cards[r.Next( 0, cards.Count() )];
        }

        public String Show() {
            string o = "";
            foreach (Card c in cards){
                o += c.ToString() + "\n";
            }

            return o;

        }

        public void Shuffle() {
            cards = cards.OrderBy(carte => r.Next()).ToList<Card>();

        }

        public void Exchange(int c1, int c2 ) {
            Card buffer = cards[c1];
            cards[c1] = cards[c2];
            cards[c2] = buffer;
            

        }
        
        

    }
}
