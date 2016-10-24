using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardUtils
{
    [Serializable]
    public class Deck : IEnumerable<Card> {
        private List<Card> cards = new List<Card>();
        private Random r;

        public Deck() {
            r = new Random();
            //this.generateCards();
        }

        public static Deck generateDeck() {
            Deck deck = new Deck();
            deck.generateCards();
            return deck;
        }

        private void generateCards() {
            cards = new List<Card>();
            this.cards.Clear();

            for (int i = 0; i < 13; i++) {
                cards.Add( new Card( (i + 1), Card.Suits.SPADES) );
                cards.Add( new Card( (i + 1), Card.Suits.CLUBS ) );
                cards.Add( new Card( (i + 1), Card.Suits.HEARTS ) );
                cards.Add( new Card( (i + 1), Card.Suits.DIAMONDS ) );
            }
        }

        public void Add(Card c) {
            cards.Add( c );
        }

        public Card Pick() {
            if (cards.Count() == 0)
                throw new Exception("Cannot pick a card from an empty Deck. (Cards count : " + this.cards.Count() + ")");
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
            cards = cards.OrderBy(Card => r.Next()).ToList<Card>();

        }

        public void Exchange(int c1, int c2 ) {
            Card buffer = cards[c1];
            cards[c1] = cards[c2];
            cards[c2] = buffer;
            
             
        }
        public void Ajouter(Card Card) {
            this.cards.Add(Card);
        }
        public static Deck operator +(Deck deckA, Deck deckB) {
            deckA.Ajouter(deckB);
            return deckA;
        }
        public static Deck operator +(Deck deckA, Card card) {
            deckA.Ajouter(card);
            return deckA;
        }
        public void Ajouter(Deck deck) {
            List<Card> Cards = new List<Card>(deck.cards);
            foreach (Card c in Cards) {
                this.cards.Add(c);
            }
        }
        public List<Card> getCards() {
            return this.cards;
        }
        public IEnumerator<Card> GetEnumerator() {
            for (int i = 0; i < this.cards.Count; i++) {
                yield return this.cards[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
            
        }
    }
}
