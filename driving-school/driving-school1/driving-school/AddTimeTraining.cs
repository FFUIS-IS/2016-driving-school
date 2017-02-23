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
    public partial class AddTimeTraining : Form
    {
        SqlConnection con = new SqlConnection(Form1.path);
        SqlCommand command;
        SqlDataReader reader;
        
        public AddTimeTraining()
        {
            InitializeComponent();
        }

        private void AddTimeTraining_Load(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                command = new SqlCommand("SELECT * FROM instructor;", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(1) + " " + reader.GetString(2) + "-" + reader.GetInt32(0));
                }

                reader.Close();
                command.CommandText = "SELECT * FROM candidate;";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(1) + " " + reader.GetString(2) + "-" + reader.GetInt32(0));
                }
                reader.Close();
                command.CommandText = "SELECT * FROM car;";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString(1) + "-" + reader.GetInt32(0));
                }

                reader.Close();
            }
            catch(InvalidOperationException ee)
            {
                MessageBox.Show(ee.ToString());
            }
            con.Close();
        }

        private void timePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string datum = dateTimePicker1.Text + " " + timePicker1.Value.TimeOfDay;
                int instruktorID = int.Parse(comboBox1.SelectedItem.ToString().Substring(comboBox1.SelectedItem.ToString().LastIndexOf('-') + 1));
                int kandidatID = int.Parse(comboBox2.SelectedItem.ToString().Substring(comboBox2.SelectedItem.ToString().LastIndexOf('-') + 1));
                int carID = int.Parse(comboBox3.SelectedItem.ToString().Substring(comboBox3.SelectedItem.ToString().LastIndexOf('-') + 1));
                command.CommandText = "INSERT INTO time_training(date, instructor_id, candidat_id, car_id) VALUES "
                    + "('" + datum + "', " + instruktorID + ", " + kandidatID + ", " + carID + ");";

            try
            {
                con.Close();
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Uneseno u bazu.");
                con.Close();
            }
            catch (SqlException ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
    }
}
