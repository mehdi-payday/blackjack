﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ServerClient.Server;
using System.Threading;
using System.Windows.Forms;

namespace ServerClient.Client {
    public class Client {
        private string CLIENT_TAG;
        private IPAddress serverAddress = IPAddress.Parse( "127.0.0.1" );
        private int serverPort = 25565;
        private IPEndPoint serverEndPoint;
        private BufferedStream networkStream;
        private TcpClient socket;
        private NETMSG toSend;
        private bool exitRequested;
        private Interface.Form1 ui;
        private bool isPlaying;

        public BinaryFormatter Bf;
        public CardUtils.Game Game;
        public Thread MainLoopThread;
        public List<NETMSG> sendStack;
        public uint playerID;
        public Action RefreshUI;
        public Action StartPlaying;
        public Action StopPlaying;
        public Action ShowWinner;
        public bool IsPlaying {
            get {
                return this.isPlaying;
            }
            private set {
                this.isPlaying = value;
                if (value) {
                    printl( "unlocking controls");
                    StartPlaying();
                }else {
                    printl( "locking controls" );
                    StopPlaying();
                }
                
            }
        }
        public bool ExitRequested{
            get {
                return this.exitRequested;
            }
            set {
                exitRequested = value;
                if (value == true) {
                    handleExitRequest();
                }
            }
        }


        #region contructors
        public Client(Interface.Form1 ui) {
            CLIENT_TAG = "[CLIENT*: "+ this.GetHashCode()+"]";
            serverEndPoint = new IPEndPoint( serverAddress, serverPort );
            Bf = new BinaryFormatter();
            exitRequested = false;
            sendStack = new List<NETMSG>();
            this.ui = ui;
        }
        #endregion

        public static void Main() {
            new Client(null);
        }


        public void Start() {
            printl( "starting." );
            socket = new TcpClient();
            try {
                socket.Connect( serverEndPoint );
                Thread.Sleep( 100 );
                this.networkStream = new BufferedStream( socket.GetStream() );
                NETMSG n = receive();//= (Server.NETMSG)Bf.Deserialize( networkStream );


                if (NETMSG.MSG_TYPES.SERVER_OK.Equals( n.Type )) {
                    send( new NETMSG( NETMSG.MSG_TYPES.CLIENT_OK, null ) );

                    //get game
                    send( new NETMSG( NETMSG.MSG_TYPES.CLIENT_REQUEST_SYNC, null ) );
                    NETMSG g = receive();
                    processServerMessage( g );

                    send( new NETMSG( NETMSG.MSG_TYPES.CLIENT_REQUEST_UID, null ) );

                    //given player uid
                    NETMSG uid_msg = receive();
                    processServerMessage( uid_msg );
                    printl( "i am now player #" + playerID );
                    CLIENT_TAG = "[CLIENT: "+playerID+"]" ;


                    if (this.Game != null) {

                        send( new NETMSG( NETMSG.MSG_TYPES.CLIENT_READY, null ) );

                        //ready to play
                        //thread not to freeze UI
                        MainLoopThread = new Thread( () => this.MainLoop(/*this*/) );

                        ui.init();
                        MainLoopThread.Start();

                    }

                }

            } catch (Exception e) {
                printl( "ERROR >> " + e.Message );
                printl( e.StackTrace );
                ExitRequested = true;
            }

            
        }


        //MAIN LOGIC
        public void MainLoop() {
            printl( "i entered MainLoop." );
            IsPlaying = false;

            while (!this.exitRequested && socket.Connected) {
                //client sends first
                if (sendStack.Count() > 0) {
                    toSend = sendStack[0];
                    sendStack.RemoveAt(0);

                }else {
                    toSend = new NETMSG( NETMSG.MSG_TYPES.CLIENT_OK, null );
                }
                send( toSend );
                NETMSG m = receive();
                processServerMessage(m);
                Thread.Sleep( 10 );
                
            }

        }

        private void handleExitRequest() {
            send( new NETMSG( NETMSG.MSG_TYPES.CLIENT_DISCONNECT, objToBytes(playerID) ) );
            socket.Close();

        }

        #region socket io
        private void send( NETMSG msg ) {
            MemoryStream mem = new MemoryStream();

            Bf.Serialize( mem, msg );//ns
            byte[] b = mem.ToArray();
            byte[] len = BitConverter.GetBytes( b.Length );
            socket.GetStream().Write( len, 0, 4 );
            socket.GetStream().Write( b, 0, b.Length );

        }

        private NETMSG receive() {
            try {
                int br = 0; ;
                byte[] b = new byte[256];
                MemoryStream mem = new MemoryStream();
                int len;
                byte[] lenb = new byte[4];

                //read length (server always sends length first as 4bytes)
                socket.GetStream().Read( lenb, 0, 4 );
                len = BitConverter.ToInt32( lenb, 0 );

                int toread = len;
                int read = 0;

                do {
                    if (toread < 256) {
                        br = socket.GetStream().Read( b, 0, toread );
                    } else {
                        br = socket.GetStream().Read( b, 0, 256 );
                    }
                    mem.Write( b, 0, br );
                    read += br;

                } while (br == 256);

                mem.Position = 0;
                NETMSG msg = (Server.NETMSG)Bf.Deserialize( mem );
                //Console.WriteLine( "CLient received: " + msg.Type.ToString() );

                return msg;

            } catch(Exception e) {
                printl( "Exception while receiving: " + e.Message + " at " + e.StackTrace);
                return new NETMSG( NETMSG.MSG_TYPES.SERVER_ERROR, objToBytes( e ), e.Message);

            }

        }

        public void AddToSendQueue(NETMSG msg ) {
            this.sendStack.Add( msg );
        }
        #endregion

       
        private void processServerMessage(NETMSG msg ) {
            switch (msg.Type) {
                case NETMSG.MSG_TYPES.SERVER_OK:
                    //this is a sync message
                    
                    break;
                case NETMSG.MSG_TYPES.SERVER_GAME:
                    this.Game = (CardUtils.Game)NETMSG.bytesToObj( msg.Payload );

                    break;
                case NETMSG.MSG_TYPES.SERVER_FULL:
                    MessageBox.Show( "The server is full. Closing connection." );
                    ExitRequested = true;
                    break;
                case NETMSG.MSG_TYPES.SERVER_ERROR:
                    MessageBox.Show( "SERVER_ERROR received from Server: \n" + msg.Message + "." );
                    break;
                case NETMSG.MSG_TYPES.SERVER_CLOSING:
                    MessageBox.Show( "The server will close or you were kicked.  Disconnecting from server." );
                    ExitRequested = true;
                    break;
                case NETMSG.MSG_TYPES.SERVER_PLAYER_UID:
                    this.playerID = ((CardUtils.Player)NETMSG.bytesToObj( msg.Payload )).ID;
                    break;
                case NETMSG.MSG_TYPES.PLAYER_BETS:
                    this.Game.Bet( ((BET)NETMSG.bytesToObj( msg.Payload )).PlayerID, ((BET)NETMSG.bytesToObj( msg.Payload )).betTOAdd );
                    //ui.RefreshView();
                    RefreshUI();
                    break;
                case NETMSG.MSG_TYPES.PLAYER_CONNECTED:
                    CardUtils.Player pla = (CardUtils.Player)NETMSG.bytesToObj( msg.Payload );
                    if (Game.Players.Where(_player => _player.ID == pla.ID).Count() > 0) {
                        printl( "... real funny, william, but player " + pla.ID + " seems to already be in the list..." );
                        break;
                    }
                    printl( "adding a new player: " + pla.ID );
                    Game.AddPlayer( pla );
                    //printl( playerID + " sees total count:" + Game.Players.Count );
                    if (Game.Players.Count == 1) {
                        printl("i should now be the one playing. "+ pla.ID);
                        Game.PlayingPlayer = Game.Players[0];
                    }else if(Game.Players.Count > 3){
                        foreach(CardUtils.Player _p in Game.Players) {
                            printl( "- " + _p.ID );
                        }
                    }


                    //ui.RefreshView();
                    RefreshUI();
                    break;
                case NETMSG.MSG_TYPES.PLAYER_DISCONNECTED:
                    uint id = (uint)NETMSG.bytesToObj( msg.Payload );
                    this.Game.Disconnect( id );
                    //ui.RefreshView();
                    RefreshUI();
                    break;
                case NETMSG.MSG_TYPES.PLAYER_PASS:
                    uint passedID = (uint)NETMSG.bytesToObj( msg.Payload );
                    this.Game.Pass( passedID );
                    printl( passedID + "told me he passed, i think " + Game.PlayingPlayer.ID + " is now playing.");
                    if(this.Game.PlayingPlayer.ID == this.playerID) {
                        printl( "i will now be playing.");
                        this.IsPlaying = true;
                    }
                    ShowWinner();
                    RefreshUI();
                    break;
                case NETMSG.MSG_TYPES.PLAYER_PICKS:
                    PICK pick = ((PICK)NETMSG.bytesToObj(msg.Payload));
                    this.Game.PickCard(pick.PlayerID, pick.Card);
                    ShowWinner();
                    RefreshUI();
                    break;

                case NETMSG.MSG_TYPES.END_GAME:
                    //say who won
                    //ui.RefreshView
                    RefreshUI();
                    break;
                case NETMSG.MSG_TYPES.PLAYER_YOURTURN:
                    //this.Game.PlayingPlayer = this.Game.FindPlayer( playerID );
                    printl( "i will be the first player." );
                    IsPlaying = true;
                    //ui.RefreshView();
                    RefreshUI();
                    break;
                default:
                    MessageBox.Show( "Unknown NETMSG struct object received" );
                    break;

            }



        }


        private byte[] objToBytes( Object o ) {
            if (o != null) {
                MemoryStream mem = new MemoryStream();
                (new BinaryFormatter()).Serialize( mem, o );
                return mem.ToArray();
            }
            return null;
        }

        private void printl(string s ) {
            Console.WriteLine( CLIENT_TAG + ">> " + s);
        }

        public void HitMe() {
            AddToSendQueue( new NETMSG( NETMSG.MSG_TYPES.PLAYER_PICKS, objToBytes(playerID) ) );
        }
        public void Stand() {
            AddToSendQueue(new NETMSG(NETMSG.MSG_TYPES.PLAYER_PASS, objToBytes(playerID)));
        }
        public void Bet(float amount) {
            BET b = new ServerClient.Server.BET();
            b.PlayerID = this.playerID;
            b.betTOAdd = amount;
            AddToSendQueue(new NETMSG(NETMSG.MSG_TYPES.PLAYER_BETS, objToBytes(b)));
        }
    }
}
