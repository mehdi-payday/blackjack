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
        public bool Finished
        {
            get;
            set;
        } = false;
        //public Stack<Player> WaitingTurn = new Stack<Player>();
        public List<Player> Players = new List<Player>();

        /*
        * @var Locked : Si la partie est "fermée", on ne peut plus ajouter de joueurs
        */
        public bool Locked { get; private set; }

        public Player Winner { get; private set; } = null;

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
        
        public float Pot {
            get;
            private set;
        } = 0;
        public Game(List<Player> players) {
            this.Players = players;
            this.init();
        }
        public void init() {

            // Générer les cartes en fonction du nombre de joueurs
            //int countPlayers =  this.Players.Count();
            int countPlayers = 3;
            for (int i = 0; i < countPlayers; i++) {
                this.deck += Deck.generateDeck();
            }

            // "Fermer" la partie
            //this.Lock();
        }

        public Game() {
            this.init();
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

        public bool isPlaying(Player p) {
            return p.ID == this.PlayingPlayerIndex;
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
        public Player FindPlayer(uint playerId) {
            Player p = this.Players.Find((Player candidate) => candidate.ID == playerId);
            Console.WriteLine("-----"+ p?.ID);
            if(p == null) {
                //throw new GameException("Player whose id is '"+playerId+"' is not part of the game.");
            }
            return p;
        }

        public bool Exists(uint playerId) {
            try {
                return this.FindPlayer(playerId) != null;
            } catch (GameException playerNotFound) {
                Console.WriteLine( playerNotFound.Message );
                return false;
            }
        }

        private bool Exists(Player p) {
            return this.Exists(p.ID);
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
                    throw new GameException("Error when trying to register the bet of the player " + p.ToString(), betException);
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
            
            int index = this.Players.FindIndex((p) => p.ID == this.PlayingPlayerIndex);
            Console.WriteLine("Current index : " + index);

            if (index == this.Players.Count - 1) {
                // Last Player. Game finished.

                this.FinishGame();

                Console.WriteLine("Winner cards :");
                this.Winner.displayCards();

                //throw new GameException("End Of The Game. Winner is " + this.Winner.ToString() + " with " + this.Winner.Points + " points.");
                
            } else {
                // Give turn to the next player
                index++;
                this.PlayingPlayer = this.Players[index];
            }

            //this.PlayingPlayer = this.WaitingTurn.Pop();
        }

        public void FinishGame() {
            this.Finished = true;

            List<Player> players_arr = new List<Player>();
            players_arr.AddRange(this.Players);

            players_arr.Sort(delegate (Player p1, Player p2) {
                if (p1.Points != p2.Points) {
                    int p1_points = p1.Points > 21 ? p1.Points : -1;
                    int p2_points = p2.Points > 21 ? p2.Points : -1;
                    
                    return p2_points - p1_points;
                }
                else
                    return p1.Hand.getCards().Count.CompareTo(p2.Hand.getCards().Count);
                
            });

            Console.WriteLine("Players number : " + players_arr.Count);

            this.Winner = players_arr[0];
        } 
        public void Pass(Player player) {
            if(!this.isPlaying(player)) {
                throw new GameException("Cannot make player " + player.ToString() + " pass because it is not his turn to play");
            }
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

        public Card PickCard(uint playerId, Card card) {
            this.FindPlayer(playerId).assignCard(card);
            return card;
        }

        public Card PickCard(Player player) {
            return this.PickCard(player.ID);
        }
    }
}
