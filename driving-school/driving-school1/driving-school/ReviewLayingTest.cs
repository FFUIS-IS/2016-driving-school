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
    public partial class ReviewLayingTest : Form
    {
        

        public ReviewLayingTest()
        {
            InitializeComponent();
        }

        private void ReviewLayingTest_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();

                command.CommandText = "SELECT * FROM laying_test ";

                SqlDataReader rdr = command.ExecuteReader();
                string data;
                string[] identity = new string[2];
                SqlCommand command2 = con.CreateCommand();
                SqlDataReader reader;
                int count = 0;
                while (rdr.Read())
                {
                    identity[0] = rdr.GetDateTime(1).ToString();
                    identity[1] = rdr.GetInt32(2).ToString();
                    
                    rdr.Close();
                    command2.CommandText = "SELECT first_name, last_name FROM Candidate " +
                     "Where id = " + int.Parse(identity[1]) + ";";
                    reader = command2.ExecuteReader();
                    reader.Read();
                    string candidate = reader.GetString(0) + " " + reader.GetString(1);
                    reader.Close();
                    
                    data = "Date: " + identity[0] + "\t Candidate: " + candidate ;

                    listBox1.Items.Add(data);

                    reader.Close();
                    rdr = command.ExecuteReader();
                    for (int i = 0; i <= count; i++)
                        rdr.Read();
                    count++;
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return;
            }


        }
    }
}
