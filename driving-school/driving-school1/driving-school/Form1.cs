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
            if (string.IsNullOrEmpty(user.Text))
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
            else
            {
                SqlConnection con = new SqlConnection(Form1.path);
                try
                {
                    con.Close();
                    con.Open();

                    SqlCommand command = con.CreateCommand();
                    command.CommandText = "SELECT * FROM  Registration WHERE user_name = '" + user.Text + "' AND password = '" + password.Text + "';";

                    SqlDataReader rdr = command.ExecuteReader();

                    if (rdr.Read())
                    {
                        User = rdr[1].ToString();
                        Password = rdr[2].ToString();
                            
                        DialogResult = DialogResult.OK;
                        con.Close();

                        this.Dispose();
                    }
                    else
                        MessageBox.Show("NESTO ne Valja");
                    con.Close();


                }

                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration a = new Registration();
            a.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.PasswordChar = '*';
            }
            else
                password.PasswordChar = '\0';
        }
    }
}
