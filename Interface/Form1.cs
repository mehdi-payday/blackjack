using System;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Interface
{
    public partial class Form1 : Form
    {
        private ServerClient.Client.Client client;
        private Thread clientThread;

        public Form1()
        {
            InitializeComponent();
            client = new ServerClient.Client.Client();
            clientThread = new Thread( client.Start );
            Thread.Sleep( 100 );
            clientThread.Start();
            
        }

        public void BtnHitMe_Click(object sender, EventArgs e) {

            CardUtils.Deck hand  = new CardUtils.Deck();
            CardUtils.Card card1 = new CardUtils.Card(2, CardUtils.Card.Suits.SPADES);
            CardUtils.Card card2 = new CardUtils.Card(2, CardUtils.Card.Suits.HEARTS);
            hand.Add(card1);
            hand.Add(card2);
            this.ShowPlayer1Cards(hand);
            this.ShowPlayer2Cards(hand,true);
            this.ShowPlayer3Cards(hand);
            //CardUtils.Player player1 = new CardUtils.Player("mehdi", 1);
            //player1.assignCard(card1);
            //player1.assignCard(card2);

        }

        public void BtnStand_Click(object sender, EventArgs e) {
            this.btnHitMe.Enabled = false;
        }
    }
}
