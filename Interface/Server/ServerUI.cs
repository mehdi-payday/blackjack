using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Server {
    public partial class ServerUI : Form {
        int port;
        string host;
        public ServerUI(ServerClient.Server.Server s, string host, int port) {
            InitializeComponent();
            this.host = host;
            this.port = port;
            label1.Text = "host: " + host;
            label2.Text = "port: " + port;
            
        }

        private void button1_Click( object sender, EventArgs e ) {
            Application.Exit( );
            
        }

        private void label2_Click( object sender, EventArgs e ) {

        }

        private void label3_Click( object sender, EventArgs e ) {

        }
    }
}
