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
    public partial class ReviewLayingDriving : Form
    {
        

        public ReviewLayingDriving()
        {
            InitializeComponent();
        }

        private void ReviewLayingDriving_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();

                command.CommandText = "SELECT * FROM laying_driving ";

                SqlDataReader rdr = command.ExecuteReader();
                string data;
                string[] identity= new string[4];
                SqlCommand command2 = con.CreateCommand();
                SqlDataReader reader;
                int count = 0;
                while (rdr.Read())
                {
                    identity[0] = rdr.GetDateTime(1).ToString();
                    identity[1] = rdr.GetInt32(2).ToString();
                    identity[2] = rdr.GetInt32(3).ToString();
                    identity[3] = rdr.GetInt32(4).ToString();
                    rdr.Close();
                    command2.CommandText = "SELECT first_name, last_name FROM Candidate " +
                     "Where id = " + int.Parse(identity[1]) + ";";
                    reader = command2.ExecuteReader();
                    reader.Read();
                    string candidate = reader.GetString(0) + " " + reader.GetString(1);
                    reader.Close();
                    command2.CommandText = "SELECT first_name, last_name FROM Instructor " +
                        "Where id = " + int.Parse(identity[3]) + ";";
                    reader = command2.ExecuteReader();
                    reader.Read();
                    string instructor = reader.GetString(0) + " " + reader.GetString(1);
                    reader.Close();
                    command2.CommandText = "SELECT type FROM Car " +
                        "Where id = " + int.Parse(identity[2]) + ";";
                    reader = command2.ExecuteReader();
                    reader.Read();
                    data = "Date: " + identity[0] + "\t Candidate: " + candidate + "\t Instructor: " + instructor + "\t Car: " + reader.GetString(0);

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
/*              
*/