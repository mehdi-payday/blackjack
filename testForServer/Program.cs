using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerClient;
using System.Threading;
using CardUtils;

namespace testForServer {
    static class Program {
        static void tests() {
            // Some tests
            Game game = new Game();
            Player player1 = new Player("adam", game.generatePlayerId());
            game.AddPlayer(player1);
            Player player2 = new Player("jey", game.generatePlayerId());
            game.AddPlayer(player2);
            Player player3 = new Player("hamidi", game.generatePlayerId());
            game.AddPlayer(player3);

            game.PlayingPlayer = player1;

            Deck deck = new Deck();

            player1.assignCard(new Card(1, Card.Suits.CLUBS));
            player1.assignCard(new Card(1, Card.Suits.DIAMONDS));
            player1.assignCard(new Card(1, Card.Suits.HEARTS));
            player1.assignCard(new Card(8, Card.Suits.HEARTS));
            
            game.Pass(player1);

            player2.assignCard(new Card(7, Card.Suits.CLUBS));
            player2.assignCard(new Card(8, Card.Suits.CLUBS));
            player2.assignCard(new Card(7, Card.Suits.CLUBS));
            player2.assignCard(new Card(7, Card.Suits.CLUBS));
            
            game.Pass(player2);

            game.PickCard(player3);
            game.PickCard(player3);
            game.PickCard(player3);
            game.Pass(player3);

            // End Of The Game
            player1.displayCards();
            player2.displayCards();
            player3.displayCards();

            if (!game.Finished) {
                throw new Exception("Game has gone to his end maaan. How come .Finished has not been set to true ?!");
            }

            Console.WriteLine("Winner :");
            game.Winner.displayCards();

            Console.Read();
            //Console.ReadLine();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            tests();

            try {
                ServerClient.Server.Server server = new ServerClient.Server.Server();
                /*ServerClient.Client.Client client = new ServerClient.Client.Client(),
                    client2 = new ServerClient.Client.Client();
                    */
                Thread tServer = new Thread( server.Start );
                /*Thread tClient = new Thread( client.Start );
                Thread tClient2 = new Thread( client2.Start );
                */

                tServer.Start();
                Thread.Sleep( 100 );

                
                new Thread( () => Application.Run( new Interface.Form1() ) ).Start();
                Thread.Sleep( 100 );
                new Thread( () => Application.Run( new Interface.Form1() ) ).Start();
                Thread.Sleep( 100 );
                new Thread( () => Application.Run( new Interface.Form1() ) ).Start();



                /*tClient.Start();
                Thread.Sleep( 1000 );
                tClient2.Start();

                tClient.Join();
                tClient2.Join();*/
                tServer.Join();

            } catch (Exception e) {
                Console.WriteLine( "ERROR >> " + e.Message );
            }

            Console.WriteLine( "EOP" );
            Thread.Sleep( 20000 );
            //Console.ReadKey();
        }
    }
}
