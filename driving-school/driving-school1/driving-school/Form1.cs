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

            

            HomePage a = new HomePage();
            a.Show();
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
