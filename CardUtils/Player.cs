using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardUtils {
    public class PlayerException : Exception {
        public PlayerException(string m) : base(m) {
        }
        public PlayerException(string m, Exception cause) : base(m,cause) {

        }
    }
    public class CannotBetException : Exception {
        public CannotBetException(string m ) : base(m){

        }
        public CannotBetException(string m, Exception cause) : base(m, cause) {

        }

    }
    
    [Serializable]
    public class Player {
        public uint ID {
            get;
            private set;
        }

        public Deck Hand {
            get; private set;
        }

        public String  Name {
            get;private set;
        }
        public float BetAmount {
            get; private set;
        }
        public float Bourse {
            get; private set;
        }

        public Player(String name, uint ID) {
            this.ID = ID;
            this.Hand = new Deck();
        }
        public void displayCards() {
            Console.WriteLine("Player '" + this.ToString() + "' cards :");
            foreach (Card c in this.Hand) {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Points : " + this.Points);
            Console.WriteLine();
        }

        public int Points {
            get {
                int points = 0;
                int number_of_aces = 0;
                foreach (Card card in this.Hand) {
                    int pt = card.Number;
                    if(card.Number > 10) { // Bigger than 10
                        pt = 10;
                    }
                    if(card.Number == 1) { // Ace
                        number_of_aces++;
                        pt = 11;
                    }
                    points += pt;
                }
                
                
                while(points > 21 && number_of_aces > 0) {
                    number_of_aces--;
                    points -= 10;
                    Console.WriteLine("Nb points : " + points);
                    Console.WriteLine("Nb Aces : " + number_of_aces);
                }
                
                //points -= ((points - 21) / (number_of_aces * 11)) * 10;
                
                return points;
            }
        }
        
        public void assignCard(Card card) {
            this.Hand += card;
        }

        public void Bet(float amount) {
            if(this.Bourse < amount) {
                throw new CannotBetException("Player '" + this.ToString() + "' cannot bet " + amount + " because his bursary is only of " + this.Bourse);
            }
            this.Bourse -= amount;
            this.BetAmount += amount;
        }

        public override string ToString() {
            return "<Player " + this.Name + ">";
        }
    }
}
