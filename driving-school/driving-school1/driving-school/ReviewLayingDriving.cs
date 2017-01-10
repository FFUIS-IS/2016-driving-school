﻿using System;
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
    public partial class ReviewLayingDriving : Form
    {
        public static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\w7\Desktop\driving-school1\driving-school\Databas.mdf;Integrated Security=True;Encrypt=False;User Instance=False;Context Connection=False";

        public ReviewLayingDriving()
        {
            InitializeComponent();
        }

        private void ReviewLayingDriving_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ReviewLayingDriving.path);

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

            command.CommandText = "SELECT * FROM laying_driving ";

            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                listBox1.Items.Add(rdr.GetString(1));
            }

        }
    }
}
