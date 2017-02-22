using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace driving_school
{
    public partial class AddLayingTest : Form
    {
        SqlConnection con = new SqlConnection(Form1.path);
        SqlCommand command;
        SqlDataReader reader;


        public AddLayingTest()
        {
            InitializeComponent();
        }

        private void AddLayingTest_Load(object sender, EventArgs e)
        {
            con.Open();
            command.Connection = con;
            command.CommandText = "SELECT * FROM candidate;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(1) + " " + reader.GetString(2) + "-" + reader.GetInt32(0));
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kandidatID = int.Parse(comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().LastIndexOf('-') + 1));
            command.CommandText = "INSERT INTO laying_test(date, candidat_id) VALUES "
                + "('" + dateTimePicker1.Text + "', " + kandidatID + ");";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
