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
        }

        public void assignCard(Card card) {
            this.Hand += card;
        }

        public void Bet(float amount) {
            if(this.Bourse < amount) {
                throw new CannotBetException("Player '"+this.ToString() +"' cannot bet " + amount + " because his bursary is only of " + this.Bourse);
            }
            this.Bourse -= amount;
            this.BetAmount += amount;
        }

        public string toString() {
            return "<Player " + this.Name + ">";
        }
    }
}
