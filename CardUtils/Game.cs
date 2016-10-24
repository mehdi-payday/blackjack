using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardUtils {
    public class GameException : Exception {
        public GameException(String m) : base(m) {
            
        }
        public GameException(String m, Exception cause) : base(m, cause) {
            
        }
    }
    
    [Serializable]
    public class Game {
        private Deck deck = new Deck();

        public Stack<Player> WaitingTurn = new Stack<Player>();
        public List<Player> Players = new List<Player>();

        /*
        * @var Locked : Si la partie est "fermée", on ne peut plus ajouter de joueurs
        */
        public bool Locked { get; private set; }

        private uint PlayingPlayerIndex;
        public Player PlayingPlayer {
            get {
                return this.Players.Find((Player p) => p.ID == this.PlayingPlayerIndex);
            }
            set {
                if (this.Players.Exists((Player p) => p.ID == value.ID)) {
                    this.PlayingPlayerIndex = value.ID;
                } else {
                    throw new GameException("You can't affect the playing player to this player because he is not in the list of players.");
                }
            }
        }
        
        private float Pot = 0;
        public Game(List<Player> players) {
            this.Players = players;

            // Générer les cartes en fonction du nombre de joueurs
            int countPlayers = players.Count();
            for(int i = 0; i < countPlayers; i++) {
                this.deck += Deck.generateDeck();
            }

            // "Fermer" la partie
            this.Lock();
        }

        public Game() {
        }

        public void Lock() {
            this.Locked = true;
        }
        public void AddPlayer(Player p) {
            if(!this.Locked) {
                this.Players.Add(p);
            } else {
                throw new GameException("Cannot add players to the game when it is locked.");
            }
            
        }

        public void TurnChange(Player p) {
            if (!this.Exists(p))
                throw new GameException("Cannot change turn to player " + p.ToString() + " because he is not part of the game.");
            this.PlayingPlayer = p;
        }

        public void TurnChange(uint playerId) {
            Player player = this.Players.Find((Player p) => p.ID == playerId);
            if (player != null) {
                this.TurnChange(player);
            } else {
                throw new GameException("Cannot change turn to player which id is '"+ playerId + "' because he doesn't belong to the list of players");
            }
        }
        private Player FindPlayer(uint playerId) {
            Player p = this.Players.Find((Player candidate) => candidate.ID == playerId);
            if(p == null) {
                throw new GameException("Player whose id is '"+playerId+"' is not part of the game.");
            }
            return p;
        }

        private bool Exists(uint playerId) {
            try {
                return this.FindPlayer(playerId) != null;
            } catch (GameException playerNotFound) {
                return false;
            }
        }

        private bool Exists(Player p) {
            this.Exists(p.ID);
        }
		
		public Player createPlayer() {
            Player new_player = new Player("unamed", this.generatePlayerId());

            return new_player;
		}
		public uint generatePlayerId() {
			List<uint> ids = new List<uint>();
			foreach(Player player in this.Players) {
                ids.Add(player.ID);
            }
            uint generatedId;
            Random rnd = new Random();
            do {
                int number = rnd.Next(1, 1000);
                generatedId = (uint)(number + (uint)Int32.MaxValue);
            } while (ids.Exists(id => id == generatedId) );

            return generatedId;
        }

        public void Bet(uint playerId, float amount) {
            Player p = this.FindPlayer(playerId);
            if(p != null) {
                try {
                    p.Bet(amount);
                    this.Pot += amount;
                } catch(CannotBetException betException) {
                    throw new GameException("Error when trying to register the bet of the player " + p.toString(), betException);
                }
            } else {
                throw new GameException("Error when trying to register the bet of the player which index is "+playerId+" because he doesn't belong to the list of registered players");
            }
        }

        public void Bet(Player player, float amount) {
            this.Bet(player.ID, amount);
        }

        /**
        * Faire passer le tour du joueur à l'id playerId
        */
        public void Pass(uint playerId) {
            if(this.PlayingPlayerIndex != playerId) {
                throw new GameException("Cannot pass player whose id is " + playerId + ", because he's not the actual playing player.");
            }
            this.PlayingPlayer = this.WaitingTurn.Pop();
            
        }

        public void Pass(Player player) {
            this.Pass(player.ID);
        }

        public void Disconnect(uint playerId) {
            this.Players.Remove(this.FindPlayer(playerId));
        }

        public void Disconnect(Player player) {
            this.Disconnect(player.ID);
        }

        public Card PickCard(uint playerId) {
            Card picked = this.deck.Pick();

            this.FindPlayer(playerId).assignCard(picked);

            return picked;
        }

        public Card PickCard(Player player) {
            this.PickCard(player.ID);
        }
    }
}
