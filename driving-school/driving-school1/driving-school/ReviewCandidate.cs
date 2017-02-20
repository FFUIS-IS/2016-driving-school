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
    public partial class ReviewCandidate : Form
    {
        
        public ReviewCandidate()
        {
            InitializeComponent();
        }

        private void ReviewCandidate_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Open();
            
            SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT * FROM candidate;";

                SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        listBox1.Items.Add(rdr.GetString(1) + " " + rdr.GetString(2) + "-" + rdr.GetInt32(0));
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
            SqlCommand command = new SqlCommand("SELECT * FROM Candidate WHERE id = " + id + ";", con);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                richTextBox1.Text += "Ime: " + reader.GetString(1) + "\n";
                richTextBox1.Text += "Prezime: " + reader.GetString(2) + "\n";
                richTextBox1.Text += "JMBG: " + reader.GetString(3) + "\n";
                richTextBox1.Text += "BRLK: " + reader.GetString(4) + "\n";
                richTextBox1.Text += "adresa: " + reader.GetString(5) + "\n";
                richTextBox1.Text += "Telefon: " + reader.GetString(6) + "\n";
            }
            con.Close();
        }
    }
}
