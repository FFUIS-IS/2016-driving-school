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
    public partial class Form1 : Form
    {
        public static string User;
        public static string Password;
        public static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\w7\Desktop\2016-driving-school\driving-school\driving-school1\driving-school\Databas.mdf;Integrated Security = True";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                MessageBox.Show("You did not enter Username !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user.Focus();
                return;
            }
            else if (password.Text == "")
            {
                MessageBox.Show("You did not enter the code !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Focus();
                return;
            }

            SqlConnection con = new SqlConnection(Form1.path);
            try
            {
                con.Open();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return;
            }

            SqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM  Registration WHERE user_name = '" + user.Text + "' AND password = '" + password.Text + "';";

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                if (user.Text == rdr[0].ToString() && password.Text == rdr[1].ToString().Trim())
                {
                    User = rdr[0].ToString();
                    Password = rdr[1].ToString();
                }
            }

            if (user.Text == User && password.Text == Password.Trim())
            {

                HomePage a = new HomePage();
                a.Show();
                this.Hide();
            }

            else
            {
                try
                {
                    HomePage a = new HomePage();
                    a.Show();
                    this.Hide();
                    user.Clear();
                    password.Clear();
                    user.Focus();
                }
                catch (Exception ee)
                { MessageBox.Show(ee.Message); }
               
            }
            
            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration a = new Registration();
            a.Show();
        }
    }
}
