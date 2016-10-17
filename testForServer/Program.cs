using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerClient;
using System.Threading;

namespace testForServer {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            try {
                ServerClient.Server.Server server = new ServerClient.Server.Server();
                ServerClient.Client.Client client = new ServerClient.Client.Client();
                Thread tServer = new Thread( server.Start );
                Thread tClient = new Thread( client.Start );

                tServer.Start();
                Thread.Sleep( 100 );
                tClient.Start();

                tClient.Join();
                tServer.Join();

            } catch (Exception e) {
                Console.WriteLine( "ERROR >> " + e.Message );
            }

            Thread.Sleep( 20000 );
            //Console.ReadKey();
        }
    }
}
