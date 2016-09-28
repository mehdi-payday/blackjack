using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClient {
    public partial class ServerGUI : Form {

        private TcpListener tcpListener;

        public ServerGUI() {
            InitializeComponent();
        }

      

        private void button1_Click( object sender, EventArgs e ) {
            string host = ipTF.Text;
            int port;
            IPAddress addr;
            bool portValidate = int.TryParse( portTF.Text, out port);
            bool hostValidate = IPAddress.TryParse( host, out addr );

            if(!hostValidate || !portValidate) {
                MessageBox.Show( "hote ou port invalide" );
                return;
            }

            try {
                tcpListener = new TcpListener( addr, port );
                tcpListener.Start();
                while (true) {
                    // Always use a Sleep call in a while(true) loop 
                    // to avoid locking up your CPU.
                    Thread.Sleep( 10 );
                    // Create a TCP socket. 
                    // If you ran this server on the desktop, you could use 
                    // Socket socket = tcpListener.AcceptSocket() 
                    // for greater flexibility.
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    // Read the data stream from the client. 
                    byte[] bytes = new byte[256];
                    NetworkStream stream = tcpClient.GetStream();
                    
                }

            } catch (SocketException ex) {
                MessageBox.Show( "une erreur est survenue lors de la creation du serveur: " + ex.Message );
            }
            
        }
    }
}
