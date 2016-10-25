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
        private Dictionary<TcpClient, List<NETMSG>> clients;
        private const string SERVER_TAG = "[SERVER]";
        private CardUtils.Game game;

        #region contructors
        public Server() {
            this.game = new CardUtils.Game();
            clients = new Dictionary<TcpClient, List<NETMSG>>();
        }

        public Server(CardUtils.Game game ):this() {
            SetGame( game );
        }
        #endregion



        public void Start(  ) {
            Console.WriteLine( "STARTING SERVER" );
            string host = "127.0.0.1";
            int port = 25565;
            IPAddress addr = IPAddress.Parse( host );
            listener = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            TcpListener l = new TcpListener( addr, port );


            try {
                l.Start();
                printl( "listening" );
                List<Thread> threads = new List<Thread>();


                int i = 0;
                while (i < 4) {
                    //TODO, move clients to new THREADs
                    TcpClient client = l.AcceptTcpClient();
                    printl( "client connection accepted." );
                    //thread or no thread
                    Thread clientThread = new Thread( () => handleNewClient( client ) );
                    threads.Add( clientThread );

                    clientThread.Start();
                    
                    i++;

                }
                while (!game.Finished) {
                    Thread.Sleep( 1000 );
                }
                printl( "Game ended. broadcasting disconnection messages" );
                
                FullBroadCast( new NETMSG( NETMSG.MSG_TYPES.SERVER_CLOSING, null ) );
                Thread.Sleep( 5000 );
                listener.Close();

            } catch (SocketException ex) {
                MessageBox.Show( "[FATAL] une erreur est survenue lors de la creation du serveur: " + ex.Message );
                Application.Exit();
            }

            

        }


        private void handleNewClient(TcpClient client) {
            try {
                printl( "new client: "+ client.GetHashCode() );
                clients.Add( client, new List<NETMSG>() );
                BufferedStream ns = new BufferedStream( client.GetStream() );
                BinaryFormatter bf = new BinaryFormatter();

                //innitial sync
                SendClient(client, new NETMSG( NETMSG.MSG_TYPES.SERVER_OK, null, "welcome, " + client.GetHashCode() ) );
                NETMSG r = ReceiveClient(client);

                if (NETMSG.MSG_TYPES.CLIENT_OK.Equals( r.Type )) {
                    //client will request game
                    r = ReceiveClient( client );
                    if (NETMSG.MSG_TYPES.CLIENT_REQUEST_SYNC.Equals( r.Type )) {
                        //send it to client
                        SendClient( client, new NETMSG( NETMSG.MSG_TYPES.SERVER_GAME, objToBytes( this.game )) );

                        NETMSG m = ReceiveClient( client );
                        ProcessClientMessage( client, m);

                        if (NETMSG.MSG_TYPES.CLIENT_READY.Equals( ReceiveClient(client).Type )) {
                            //handleClient
                            handleClientMainLoop( client );

                        }

                    }
                }

            } catch (Exception e) {
                printl( e.Message + "\n" + e.StackTrace );
            }

        }

        private void handleClientMainLoop(TcpClient client) {
            NETMSG defaultMSG = new NETMSG( NETMSG.MSG_TYPES.SERVER_OK, null );
            NETMSG toSend;
            printl( "entering main handler loop for client : " + client.GetHashCode() );

            while (client.Connected && clients.ContainsKey(client)) {
                NETMSG m = ReceiveClient( client );
                ProcessClientMessage( client, m );

                if (clients.ContainsKey( client )) {
                    if (clients[client].Count > 0) {
                        //send to client then remove from queue
                        toSend = clients[client][0];
                        //Console.WriteLine( "TOSEND:" + toSend.Type.ToString());
                        SendClient( client, toSend );
                        clients[client].RemoveAt( 0 );
                    } else {
                        SendClient( client, defaultMSG );
                    }
                }else {
                    break;
                }
            }


        }


        #region SOCKET IO
        public void SendClient(TcpClient client, NETMSG msg ) {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            //Console.WriteLine( "SENDING" );

            bf.Serialize( mem, msg );//ns
            byte[] b = mem.ToArray();
            byte[] len = BitConverter.GetBytes(b.Length);
            client.GetStream().Write( len, 0, 4 );
            client.GetStream().Write(b, 0, b.Length);

        }

        public NETMSG ReceiveClient(TcpClient client) {
            BinaryFormatter Bf = new BinaryFormatter();
            try {
                int br = 0; ;
                byte[] b = new byte[256];
                MemoryStream mem = new MemoryStream();
                int len;
                byte[] lenb = new byte[4];

                //read length (client always sends length first as 4bytes)
                client.GetStream().Read( lenb, 0, 4 );
                len = BitConverter.ToInt32( lenb, 0 );

                int toread = len;
                int read = 0;

                do {
                    if (toread < 256) {
                        br = client.GetStream().Read( b, 0, toread );
                    } else {
                        br = client.GetStream().Read( b, 0, 256 );
                    }
                    mem.Write( b, 0, br );
                    read += br;

                } while (br == 256);

                mem.Position = 0;
                NETMSG msg = (NETMSG)Bf.Deserialize( mem );
                //Console.WriteLine( "server received: " + msg.Type.ToString() );
                return msg;

            } catch(Exception e) {
                return new NETMSG( NETMSG.MSG_TYPES.CLIENT_ERROR, objToBytes( e ), e.Message );
            }
        }

        public void FullBroadCast(NETMSG msg) {
            foreach(TcpClient client in clients.Keys) {
                clients[client].Add( msg );
                //SendClient( client, msg );
            }
        }

        public void BroadCastExceptForClient(TcpClient client, NETMSG msg) {
            foreach (TcpClient c in clients.Keys) {
                if(c != client) {
                    clients[client].Add(msg);
                    //SendClient( c, msg );
                }
            }
            Console.WriteLine( "partial bc done" );
        }
        #endregion


        public void ProcessClientMessage(TcpClient client,NETMSG msg) {
            switch (msg.Type) {
                case NETMSG.MSG_TYPES.CLIENT_REQUEST_SYNC:
                    SendClient( client, new NETMSG( NETMSG.MSG_TYPES.SERVER_GAME, objToBytes( this.game ) ) );
                    break;
                case NETMSG.MSG_TYPES.CLIENT_DISCONNECT:
                    this.clients.Remove( client );
                    printl( "client disconnected" );
                    game.Disconnect( (uint)NETMSG.bytesToObj(msg.Payload));
                    FullBroadCast( new NETMSG(NETMSG.MSG_TYPES.PLAYER_DISCONNECTED, msg.Payload ) );
                    break;
                case NETMSG.MSG_TYPES.CLIENT_OK:
                    //for sync purposes
                    break;
                case NETMSG.MSG_TYPES.CLIENT_READY:
                    //for sync purposes
                    break;
                case NETMSG.MSG_TYPES.CLIENT_REQUEST_UID:
                    CardUtils.Player p = game.createPlayer();
                    game.AddPlayer(p);

                    if(game.Players.Count == 1) {
                        printl( p.ID + " is the first so he starts." );
                        game.PlayingPlayer = game.Players[0];
                        clients[client].Add( new NETMSG( NETMSG.MSG_TYPES.PLAYER_YOURTURN, null ) );

                    }
                    SendClient( client, new NETMSG(NETMSG.MSG_TYPES.SERVER_PLAYER_UID, objToBytes( p ) ) );
                    
                    FullBroadCast( new NETMSG( NETMSG.MSG_TYPES.PLAYER_CONNECTED, objToBytes( p ) ) );
                    break;
                case NETMSG.MSG_TYPES.PLAYER_PASS:
                    uint passingID = (uint)NETMSG.bytesToObj( msg.Payload );
                    printl( passingID + " passed." );
                    game.Pass( passingID );
                    FullBroadCast( msg );

                    break;
                case NETMSG.MSG_TYPES.PLAYER_PICKS:
                    printl( "player picked: "+ (uint) NETMSG.bytesToObj(msg.Payload));
                    uint pid = (uint)NETMSG.bytesToObj(msg.Payload);
                    CardUtils.Card picked = game.PickCard(pid);

                    FullBroadCast(
                        new NETMSG(
                            NETMSG.MSG_TYPES.PLAYER_PICKS, 
                            objToBytes(
                                new PICK(
                                    pid,
                                    picked
                                )
                            )
                        )
                    );
                    break;
                case NETMSG.MSG_TYPES.PLAYER_BETS:
                    game.Bet( ((BET)NETMSG.bytesToObj( msg.Payload )).PlayerID, ((BET)NETMSG.bytesToObj( msg.Payload )).betTOAdd);

                    FullBroadCast(msg);
                    //BroadCastExceptForClient(client, msg);
                    break;

                default:
                    break;
            }

        }

        private void printl(String s ) {
            Console.WriteLine(SERVER_TAG + ">> " + s);
        }

        public void SetGame(CardUtils.Game game ) {
            this.game = game;
        }


        private byte[] objToBytes( Object o ) {
            if (o != null) {
                MemoryStream mem = new MemoryStream();
                (new BinaryFormatter()).Serialize( mem, o );
                return mem.ToArray();
            }
            return null;
        }

    }



    #region utils structs
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
            PLAYER_YOURTURN,

            //CLIENT UPDATES
            CLIENT_REQUEST_SYNC,//when connecting, transfers the Game object to the new client
            CLIENT_READY,       //client is connected and ready
            CLIENT_DISCONNECT,  //client will disconnect
            CLIENT_OK,          //initial message
            CLIENT_ERROR,       //client error
            CLIENT_REQUEST_UID, //client wants to be assigned a player

            //SERVER UPDATES
            SERVER_FULL,        //when client tries to connect and server is full
            SERVER_CLOSING,     //when the server closes, broadcast this to connected clients
            SERVER_ERROR,       //for debug purposes
            SERVER_GAME,        //contains the Game object, forces the client to update its game to the server's. sent in response to CLIENT_REQUEST_SYNC or in specific cases
            SERVER_OK,          //initial message
            SERVER_PLAYER_UID,  //when the server creates a player for a client, this is sent to the client with the uid

            /*SERVER_ACCEPT,      //sent when server accepts action
            SERVER_DENY,        //sent when server denies action*/


        }
        public MSG_TYPES Type;
        public string Message;
        public byte[] Payload;

        public NETMSG( MSG_TYPES type, byte[] payload, string message = "void"  ) {
            this.Message = message;
            this.Type = type;
            this.Payload = payload;
            
        }

        public static Object bytesToObj( byte[] b ) {
            MemoryStream mem = new MemoryStream( b );
            return (new BinaryFormatter()).Deserialize( mem );
        }

    }

    [Serializable]
    public struct BET {
        public uint PlayerID;
        public float betTOAdd;

        public BET(uint p, float b ) {
            this.PlayerID = p;
            this.betTOAdd = b;
        }
    }

    [Serializable]
    public struct PICK {
        public uint PlayerID;
        public CardUtils.Card Card;

        public PICK(uint playerId, CardUtils.Card card) {
            this.Card = card;
            this.PlayerID = playerId;
        }
    }
    #endregion
}
