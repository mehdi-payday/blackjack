using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;


namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e ) {
            String co = @"Server=127.0.0.1; DATABASE=tahuntsic; UID=root ";
            
            try {
                MySql.Data.MySqlClient.MySqlConnection c = new MySql.Data.MySqlClient.MySqlConnection( co );
                c.Open();

                MySql.Data.MySqlClient.MySqlCommand comm = c.CreateCommand();
                comm.CommandText = "SELECT * FROM users";

                MySql.Data.MySqlClient.MySqlDataReader r = comm.ExecuteReader();

                while (r.Read()) {
                    Console.WriteLine(r.GetString(0) + "\t" + r.GetString(1) + "\t" + r.GetString(3));
                }


            } catch (MySql.Data.MySqlClient.MySqlException ex) {
                MessageBox.Show( ex.Message );
            }

        }
    }
}
