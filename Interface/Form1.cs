using System;
using System.Windows.Forms;
using System.Collections;
namespace Interface
{
    public partial class Form1 : Form
    {
        private CardUtils.Game game;
       /* private CardUtils.Player player1;
        private CardUtils.Player player2;
        private CardUtils.Player player3;*/

        public Form1()
        {
            InitializeComponent();
            this.game = new CardUtils.Game();

            this.player1 = new CardUtils.Player("Jeremy", this.game.generatePlayerId());
            this.player2 = new CardUtils.Player("Mehdi", this.game.generatePlayerId());
            this.player3 = new CardUtils.Player("Adam", this.game.generatePlayerId());
            /*
            this.game.AddPlayer(this.player1);
            this.game.AddPlayer(this.player2);
            this.game.AddPlayer(this.player3);*/
            client = new ServerClient.Client.Client();
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
        /*
        public void refreshHands(Hand hand) {
            this.ShowPlayer1Cards(hand);
            this.ShowPlayer2Cards(hand, true);
            this.ShowPlayer3Cards(hand);
        }*/

        public void BtnStand_Click(object sender, EventArgs e) {
            this.btnHitMe.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
