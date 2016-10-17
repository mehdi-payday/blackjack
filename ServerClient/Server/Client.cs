using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerClient.Client {
    public class Client {
        private IPAddress serverAddress = IPAddress.Parse( "127.0.0.1" );
        private int serverPort = 25565;
        private IPEndPoint serverEndPoint;

        private BinaryFormatter binaryformatter;

        public Client() {
            
            serverEndPoint = new IPEndPoint( serverAddress, serverPort );
            binaryformatter = new BinaryFormatter();

        }

        public static void Main() {
            new Client();
        }

        public void Start() {
            Console.WriteLine( "CLIENT START" );
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            TcpClient socket = new TcpClient();
            try {

                socket.Connect( serverEndPoint );
                byte[] bytes = new byte[256];
                BufferedStream ns = new BufferedStream(socket.GetStream());
                StreamWriter outs = new StreamWriter( ns );
                StreamReader ins = new StreamReader( ns );

                for (int i =0; i < 3; i++) {

                    Server.NETMSG n = (Server.NETMSG)binaryformatter.Deserialize( ns );
                    Console.WriteLine( "SERVER SAYS >> " + n.id + ": " + n.Message );



                    n = (Server.NETMSG)binaryformatter.Deserialize( ns );
                    Console.WriteLine( "SERVER SAYS 2>> " + n.id + ": " + n.Message );

                    outs.WriteLine( "hello!" );
                    outs.Flush();

                }



            } catch (Exception e) {
                Console.WriteLine( "ERROR >> " + e.Message );
            }

            //socket.Shutdown( SocketShutdown.Both );
            socket.Close();
        }


    }
}
