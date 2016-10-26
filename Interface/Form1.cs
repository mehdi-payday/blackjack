using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

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
            
            //InitializeComponent();
            CreateHandle();


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
            client.RefreshUI = new Action( ()=> {
                this.Invoke( (MethodInvoker)delegate {
                    this.RefreshView();
                } );
            } );
            client.ShowWinner = new Action(() => {
                this.Invoke((MethodInvoker)delegate {
                    this.showWinner();
                });
            });
            client.StartPlaying = StartPlaying;
            client.StopPlaying = StopPlaying;
            client.Start();
            

        }

        public void init() {
            InitializeComponent();
            Text = client.playerID + "";
        }
        public void showWinner() {
            CardUtils.Player actualPlayer = this.client.Game.FindPlayer(this.client.playerID);
            if (actualPlayer == this.client.Game.Winner) {
                MessageBox.Show("You won!");
            }
        }

        public void BtnHitMe_Click(object sender, EventArgs e) {
            // Button Hit Me Click
            CardUtils.Player actualPlayer = this.client.Game.FindPlayer(this.client.playerID);
            if (actualPlayer.Points > 21)
            {
                StopPlaying();
                MessageBox.Show("GAME OVER! You busted, you have more than 21 pts.");
                this.client.Stand();
            }
            else {
                client.HitMe();
            }
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
            
            if (other_players.Count > 0) {
                player2 = other_players[0];
                if (other_players.Count > 1) {
                    player3 = other_players[1];
                }
            }
            
            this.DisplayPlayers(player1, player2, player3);
            this.DisplayGameState();
        }

        public void BtnStand_Click(object sender, EventArgs e) {
            client.Stand();
            Console.WriteLine( "IM PASSING: " + client.playerID );
            StopPlaying();
        }


        private void btnBet_Click(object sender, EventArgs e)
        {
            float bet = float.Parse(textBox_Bet.Text);
            this.textBox_Bet.Text = "";
            CardUtils.Player actualPlayer = this.client.Game.FindPlayer(this.client.playerID);
            if (actualPlayer.Bourse >= bet) {
                client.Bet(bet);
                this.btnBet.Enabled = false;
            }
            else{
                System.Windows.Forms.MessageBox.Show("You're bet exceeds your balance!");
            }
        }

        private void StopPlaying() {
            this.Invoke( new Action( () => {
                this.btnHitMe.Enabled = false;
                this.btnStand.Enabled = false;
                this.turnPictureBox.Image = null;
            } ) );
        }
        private void StartPlaying() {
            this.Invoke( new Action( () => {
                this.btnHitMe.Enabled = true;
                this.btnStand.Enabled = true;
                this.turnPictureBox.Image = (System.Drawing.Image)global::Interface.Properties.Resources._yourTurn;
            } ) );            
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void label_balance_Click(object sender, EventArgs e) {

        }

        private void Player2Panel_Paint(object sender, PaintEventArgs e) {

        }

        private void labelBet_Click(object sender, EventArgs e) {

        }
    }
    

}
