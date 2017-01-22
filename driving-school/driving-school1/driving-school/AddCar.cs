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
    public partial class AddCar : Form
    {
        public static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\w7\Desktop\driving-school1\driving-school\Databas.mdf;Integrated Security=True;Encrypt=False;User Instance=False;Context Connection=False";

        public AddCar()
        {
            InitializeComponent();
        }

        private void AddCar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(AddCandidate.path);

            try
            {
                con.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Connection has failed");
                return;
            }

            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM category ";

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr.GetString(1));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("you did not enter the type of the car !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            else if (comboBox1.Text == "")
            {
                MessageBox.Show("you did not enter the category of the car !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection con = new SqlConnection(AddCandidate.path);

            try
            {
                con.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Connection has failed");
                return;
            }

            SqlCommand command = con.CreateCommand();

            command.CommandText = "SELECT Id FROM category WHERE name = '" + comboBox1.Text + "';";

            SqlDataReader rdr = command.ExecuteReader();
            rdr.Read();
            int d = rdr.GetInt32(0);

            command.CommandText = "INSERT INTO candidate ( category_id, type) VALUES ( " + d + ",'" + textBox1.Text + "');";
            try
            {
                command.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

                con.Close();
                return;
            }
            MessageBox.Show("Successfully entered car");
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            
        }
    }
}
