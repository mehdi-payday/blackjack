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
                /*ServerClient.Client.Client client = new ServerClient.Client.Client(),
                    client2 = new ServerClient.Client.Client();
                    */
                Thread tServer = new Thread( server.Start );
                /*Thread tClient = new Thread( client.Start );
                Thread tClient2 = new Thread( client2.Start );
                */

                tServer.Start();
                Thread.Sleep( 100 );

                Interface.Form1 ui1 = new Interface.Form1();
                Thread.Sleep( 10 );
                Interface.Form1 ui2 = new Interface.Form1();
                Thread.Sleep( 10 );
                Interface.Form1 ui3 = new Interface.Form1();
                new Thread( () => Application.Run( ui1 ) ).Start();
                new Thread( () => Application.Run( ui2 ) ).Start();
                new Thread( () => Application.Run( ui3 ) ).Start();



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
