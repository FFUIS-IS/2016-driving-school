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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void listingOfCandidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCandidate a = new AddCandidate();
            a.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            DialogResult result = forma.ShowDialog();

            if (result == DialogResult.Cancel)
                this.Dispose();
        }

        private void additionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInstructor a = new AddInstructor();
            a.Show();
        }

        private void additionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCar a = new AddCar();
            a.Show();
        }

        private void additionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddLayingDriving a = new AddLayingDriving();
            a.Show();
        }

        private void additionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddLayingFirstHelp a = new AddLayingFirstHelp();
            a.Show();
        }

        private void additionToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AddLayingTest a = new AddLayingTest();
            a.Show();
        }

        private void additionToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AddTimeTraining a = new AddTimeTraining();
            a.Show();
        }

        private void deletionCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletionCandidate a = new DeletionCandidate();
            a.Show();
        }

        private void deletionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletionInstructor a = new DeletionInstructor();
            a.Show();
        }

        private void deletionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeletionCar a = new DeletionCar();
            a.Show();
        }

        private void deletionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void deletionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void deletionToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void deletionToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            
        }

        private void searchSearchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReviewCandidate a = new ReviewCandidate();
            a.Show();
        }

        private void reviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReviewInstructor a = new ReviewInstructor();
            a.Show();
        }

        private void reviewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReviewCar a = new ReviewCar();
            a.Show();
        }

        private void reviewToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ReviewCategory a = new ReviewCategory();
            a.Show();
        }

        private void reviewToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ReviewLayingDriving a = new ReviewLayingDriving();
            a.Show();
        }

        private void reviewToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ReviewLayingFirstHelp a = new ReviewLayingFirstHelp();
            a.Show();
        }

        private void reviewToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ReviewLayingTest a = new ReviewLayingTest();
            a.Show();
        }

        private void reviewToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ReviewMunicipalities a = new ReviewMunicipalities();
            a.Show();
        }

        private void reviewToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            
        }
    }
}
