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
    public partial class AddCandidate : Form
    {
        
        public AddCandidate()
        {
            InitializeComponent();
        }

        private void AddCandidate_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form1.path);

            try
            {

                con.Close();
                con.Open();
                SqlCommand command = con.CreateCommand();

                command.CommandText = "SELECT * FROM municipalities ";

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    Municipalities.Items.Add(rdr.GetString(1));
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
            int broj;
            if (FirstName.Text == "")
            {
                MessageBox.Show("you did not enter the first name of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FirstName.Focus();
                return;
            }

            else if (LastName.Text == "")
            {
                MessageBox.Show("you did not enter the first name of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LastName.Focus();
                return;
            }

            else if (UniqueIN.Text == "")
            {
                MessageBox.Show("you did not enter the unique identifacion number of the candidate !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UniqueIN.Focus();
                return;
            }

            else if (IDNumber.Text == "")
            {
                MessageBox.Show("you did not enter the ID number of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IDNumber.Focus();
                return;
            }

            else if (Address.Text == "")
            {
                MessageBox.Show("you did not enter the address of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Address.Focus();
                return;
            }

            else if (PhoneNumber.Text == "" && Int32.TryParse(PhoneNumber.Text, out broj))
            {
                MessageBox.Show("you did not enter the phone number of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneNumber.Focus();
                return;
            }

            else if (Municipalities.Text == "")
            {
                MessageBox.Show("you did not enter the municipalities of the candidate !", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (UniqueIN.Text.Length < 13)
            {
                MessageBox.Show("Unesite isprevno JMBG");
                UniqueIN.Clear();
                UniqueIN.Focus();
            }

            else if (UniqueIN.Text.Length > 13)
            {
                MessageBox.Show("Unesite isprevno JMBG");
                UniqueIN.Clear();
                UniqueIN.Focus();
            }

            else if (IDNumber.Text.Length < 9)
            {
                MessageBox.Show("Unesite isprevno BRLK");
                IDNumber.Clear();
                IDNumber.Focus();
            }

            else if (IDNumber.Text.Length > 9)
            {
                MessageBox.Show("Unesite isprevno BRLK");
                IDNumber.Clear();
                IDNumber.Focus();
            }

            else
            {
                SqlConnection con = new SqlConnection(Form1.path);

                try
                {
                    con.Close();
                    con.Open();

                    SqlCommand command = con.CreateCommand();

                    command.CommandText = "SELECT Id FROM municipalities WHERE name = '" + Municipalities.SelectedItem.ToString() + "';";

                    SqlDataReader rdr = command.ExecuteReader();
                    rdr.Read();
                    int d = rdr.GetInt32(0);
                    rdr.Close();

                    command.CommandText = "INSERT INTO candidate ( municipalities_id, first_name, last_name, unique_identifacion_number, Id_number, address, phone_number) VALUES ( " + d + ",'" + FirstName.Text + "','" + LastName.Text + "','" + UniqueIN.Text + "','" + IDNumber.Text + "','" + Address.Text + "'," + int.Parse(PhoneNumber.Text) + ");";
                   command.ExecuteNonQuery();
                    MessageBox.Show("Successfully entered candidate");
                        FirstName.Clear();
                        LastName.Clear();
                        UniqueIN.Clear();
                        IDNumber.Clear();
                        Address.Clear();
                        PhoneNumber.Clear();
                        Municipalities.SelectedIndex = -1;
                    con.Close();

                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee.ToString());
                    return;
                }
            }
        }
    }
}
