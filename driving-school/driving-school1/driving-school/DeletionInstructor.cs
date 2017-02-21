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
    public partial class DeletionInstructor : Form
    {
        SqlConnection conn = new SqlConnection(Form1.path);
        SqlCommand command = new SqlCommand("");
        SqlDataReader reader;

        public DeletionInstructor()
        {
            InitializeComponent();
        }

        private void DeletionInstructor_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            command.Connection = conn;
            try
            {
                conn.Close();
                conn.Open();
                command.CommandText = "SELECT * FROM instructor;";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(1) + " " + reader.GetString(2) + "-" + reader.GetInt32(0));
                }
            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Error");
            }
            else
            {
                Boolean validEnter = false;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString().Equals(comboBox1.Text))
                    {
                        validEnter = true;
                        break;
                    }
                }
                if (validEnter)
                {
                    int id = int.Parse(comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().LastIndexOf('-') + 1));

                    conn.Close();
                    conn.Open();
                    DialogResult result = MessageBox.Show("Upozorenje", "Da li ste sigurni da zelite da izbrisete kandidata " + comboBox1.SelectedItem, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        command.CommandText = "DELETE FROM instructor WHERE id = " + id + ";";
                        command.ExecuteNonQuery();
                        DeletionInstructor_Load(sender, e);

                    }
                    conn.Close();

                }
                else
                {
                    MessageBox.Show("Ne postoji u bazi.");
                }
            }
        }
    }
}



