using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace driving_school
{
    public partial class ReviewCategory : Form
    {
        
        public ReviewCategory()
        {
            InitializeComponent();
        }

        private void ReviewCategory_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Close();
                con.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Connection has failed\n" + ee.ToString());
                return;
            }

            SqlCommand command = con.CreateCommand();

                command.CommandText = "SELECT * FROM category ";

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    listBox1.Items.Add(rdr.GetString(1));
                }
                con.Close();
            }
            
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
