using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
namespace Interface
{
    public partial class Form1 : Form
    {
        //private CardUtils.Game game;
        /* private CardUtils.Player player1;
         private CardUtils.Player player2;
         private CardUtils.Player player3;*/
        ServerClient.Client.Client client;

        public Form1()
        {
            InitializeComponent();
            //this.game = new CardUtils.Game();
            /*
            this.player1 = new CardUtils.Player("Jeremy", this.game.generatePlayerId());
            this.player2 = new CardUtils.Player("Mehdi", this.game.generatePlayerId());
            this.player3 = new CardUtils.Player("Adam", this.game.generatePlayerId());
            /*
            this.game.AddPlayer(this.player1);
            this.game.AddPlayer(this.player2);
            this.game.AddPlayer(this.player3);*/
            client = new ServerClient.Client.Client(this);
            client.Start();
            

        }

        public void BtnHitMe_Click(object sender, EventArgs e) {
            // Button Hit Me Click

            client.HitMe();

            CardUtils.Deck hand  = new CardUtils.Deck();
            CardUtils.Card card1 = new CardUtils.Card(2, CardUtils.Card.Suits.SPADES);
            CardUtils.Card card2 = new CardUtils.Card(2, CardUtils.Card.Suits.HEARTS);

            hand.Add(card1);
            hand.Add(card2);

            //this.refreshHands(hand);
            //CardUtils.Player player1 = new CardUtils.Player("mehdi", 1);
            //player1.assignCard(card1);
            //player1.assignCard(card2);

        }

        public void RefreshView() {
            //try {
                //List<CardUtils.Player> other_players = this.client.Game.Players;
                List<CardUtils.Player> other_players = new List<CardUtils.Player>();

                foreach (CardUtils.Player p in this.client.Game.Players) {
                    other_players.Add(p);
                }

                CardUtils.Player actualPlayer = this.client.Game.FindPlayer( this.client.playerID );
                other_players.Remove( actualPlayer );

            CardUtils.Player player1 = actualPlayer;
            CardUtils.Player player2 = null, player3 = null;
            
            if (other_players.Count > 1) {
                player2 = other_players[1];
                if (other_players.Count > 2) {
                    player3 = other_players[2];
                }
            }
            
            this.DisplayPlayers(player1, player2, player3);
            this.DisplayGameState();
        }

        public void BtnStand_Click(object sender, EventArgs e) {
            this.btnHitMe.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
