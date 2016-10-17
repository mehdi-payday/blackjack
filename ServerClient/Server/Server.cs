using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ServerClient.Server {
    public class Server {
        private Socket listener;
        private List<TcpClient> clients;

        private CardUtils.Game game;

        public Server() {
            clients = new List<TcpClient>();
        }

        public Server(CardUtils.Game game ):this() {
            SetGame( game );
        }



        public void Start(  ) {
            Console.WriteLine( "STARTING SERVER" );
            string host = "127.0.0.1";
            int port = 25565;
            IPAddress addr = IPAddress.Parse( host );
            listener = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            TcpListener l = new TcpListener( addr, port );


            try {
                l.Start();
                Console.WriteLine( "SERVER LISTENING" );


                while (true) {
                    TcpClient client = l.AcceptTcpClient();
                    BufferedStream ns = new BufferedStream(client.GetStream());
                    BinaryFormatter bf = new BinaryFormatter();

                    //innitial sync
                    bf.Serialize(ns, new NETMSG( NETMSG.MSG_TYPES.SERVER_OK, null, "welcome") );
                    NETMSG r = (NETMSG)bf.Deserialize( ns );

                    if(NETMSG.MSG_TYPES.CLIENT_OK.Equals(r.Type)) {
                        //client will request game
                        r = (NETMSG)bf.Deserialize( ns );
                        if (NETMSG.MSG_TYPES.CLIENT_REQUEST_SYNC.Equals( r.Type )) {
                            //send it to client
                            bf.Serialize( ns, new NETMSG( NETMSG.MSG_TYPES.SERVER_GAME, this.game ) );

                            if (NETMSG.MSG_TYPES.CLIENT_READY.Equals( bf.Deserialize( ns ) ) ){
                                //CLIENT IS READY TO PLAY

                            }

                        }
                    }

                        

                    

                    client.Close();
                    break;

                }
                listener.Close();

            } catch (SocketException ex) {
                MessageBox.Show( "une erreur est survenue lors de la creation du serveur: " + ex.Message );
            }

            

        }


        public void SetGame(CardUtils.Game game ) {
            this.game = game;
        }
    }





    [Serializable]
    public struct NETMSG {
        public enum MSG_TYPES {
            //GAME UPDATES
            PLAYER_PASS,        //player has finished his turn
            PLAYER_PICKS,       //player asks for a new card
            PLAYER_BETS,        //player changes his bet (before he plays)
            PLAYER_CONNECTED,   //when broadcasting to clients that a new player has connected
            PLAYER_DISCONNECTED,//when a player disconnects mid-game
            END_GAME,           //broadcasting that the game is over, contains info on the winner

            //CLIENT UPDATES
            CLIENT_REQUEST_SYNC,//when connecting, transfers the Game object to the new client
            CLIENT_READY,       //client is connected and ready
            CLIENT_DISCONNECT,  //client will disconnect
            CLIENT_OK,       //initial message

            //SERVER UPDATES
            SERVER_FULL,        //when client tries to connect and server is full
            SERVER_CLOSING,     //when the server closes, broadcast this to connected clients
            SERVER_ERROR,       //for debug purposes
            SERVER_GAME,        //contains the Game object, forces the client to update its game to the server's. sent in response to CLIENT_REQUEST_SYNC or in specific cases
            SERVER_OK,       //initial message

            /*SERVER_ACCEPT,      //sent when server accepts action
            SERVER_DENY,        //sent when server denies action*/


        }
        public MSG_TYPES Type;
        public string Message;
        public Object Payload;

        public NETMSG( MSG_TYPES type,Object payload, string message = "void"  ) {
            this.Message = message;
            this.Type = type;
            this.Payload = payload;
        }

    }
}
