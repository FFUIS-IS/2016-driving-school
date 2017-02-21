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
    public partial class ReviewCar : Form
    {
        

        public ReviewCar()
        {
            InitializeComponent();
        }

        private void ReviewCar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM car;";

                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    listBox1.Items.Add(rdr.GetString(1) + "-" + rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Connection has failed");
                return;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int id = int.Parse(listBox1.SelectedItem.ToString().Substring(listBox1.SelectedItem.ToString().LastIndexOf('-') + 1));
            SqlConnection con = new SqlConnection(Form1.path);
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM car WHERE id = " + id + ";", con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                richTextBox1.Text += "type: " + reader.GetString(1) + "\n";
            }
            con.Close();
        }
    }
}
