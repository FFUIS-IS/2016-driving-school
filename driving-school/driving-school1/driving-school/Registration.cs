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
    public partial class Registration : Form
    {
        public static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\w7\Desktop\2016-driving-school\driving-school\driving-school1\driving-school\Databas.mdf;Integrated Security = True";

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '*';
            }
            else
                textBox2.PasswordChar = '\0';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("you did not enter your username !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("you did not enter your password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            SqlConnection con = new SqlConnection(Registration.path);
            try
            {
                con.Open();
            }

            catch (Exception ee)
            {
                MessageBox.Show("connection has failed");
                return;

            }

            SqlCommand command = con.CreateCommand();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
