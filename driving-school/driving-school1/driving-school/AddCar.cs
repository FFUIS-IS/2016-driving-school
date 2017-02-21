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
        

        public AddCar()
        {
            InitializeComponent();
        }

        private void AddCar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {

                con.Close();
                con.Open();
                SqlCommand command = con.CreateCommand();

                command.CommandText = "SELECT * FROM category ";

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr.GetString(1));
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Connection has failed\n" + ee.ToString());
                return;
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

            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("you did not enter the category of the car !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection(Form1.path);

                try
                {

                    con.Close();
                    con.Open();

                    SqlCommand command = con.CreateCommand();

                    command.CommandText = "SELECT Id FROM category WHERE name = '" + comboBox1.SelectedItem.ToString() + "';";

                    SqlDataReader rdr = command.ExecuteReader();
                    rdr.Read();
                    int d = rdr.GetInt32(0);
                    rdr.Close();

                    command.CommandText = "INSERT INTO car ( category_id, type) VALUES ( " + d + ",'" + textBox1.Text + "');";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successfully entered candidate");
                    textBox1.Clear();
                    comboBox1.SelectedIndex = -1;
                    con.Close();
                    

                }
                catch (Exception ee)
                {
                    MessageBox.Show("Connection has failed\n" + ee.ToString());
                    return;
                }
}
        }
    }
}
