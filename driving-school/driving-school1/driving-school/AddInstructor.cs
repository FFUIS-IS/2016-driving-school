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
    public partial class AddInstructor : Form
    {
        

        public AddInstructor()
        {
            InitializeComponent();
        }

        private void AddInstructor_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {
                con.Close();
                con.Open();
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
                MessageBox.Show("you did not enter the first name of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("you did not enter the first name of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            else if (textBox3.Text == "")
            {
                MessageBox.Show("you did not enter the unique identifacion number of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            else if (textBox4.Text == "")
            {
                MessageBox.Show("you did not enter the phone number of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }

            else if (textBox5.Text == "")
            {
                MessageBox.Show("you did not enter the address of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }
            else if(textBox3.Text.Length < 13)
            {
                MessageBox.Show("Unesite isprevno JMBG");
                textBox3.Clear();
                textBox3.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(Form1.path);

                try
                {

                    con.Close();
                    con.Open();

                    SqlCommand command = con.CreateCommand();

                    command.CommandText = "INSERT INTO instructor ( first_name, last_name, unique_identifacion_number, phone_number, address ) VALUES ( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "');";
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Successfully entered instructor");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        con.Close();
                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);

                        con.Close();
                        return;
                    }

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
