using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace driving_school
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void prikazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikazKandidata a = new PrikazKandidata();
            a.Show();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosKandidata a = new UnosKandidata();
            a.Show();
        }

        private void brisanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrisanjeKandidata a = new BrisanjeKandidata();
            a.Show();
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PretragaKandidata a = new PretragaKandidata();
            a.Show();
        }

        private void prikazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrikazInstruktora a = new PrikazInstruktora();
            a.Show();
        }

        private void unosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UnosInstruktora a = new UnosInstruktora();
            a.Show();
        }

        private void brisanjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BrisanjeInstruktora a = new BrisanjeInstruktora();
            a.Show();
        }

        private void prikazToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SpisakKategorija a = new SpisakKategorija();
            a.Show();
        }

        private void prikazToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PrikazVozila a = new PrikazVozila();
            a.Show();
        }

        private void unosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UnosVozila a = new UnosVozila();
            a.Show();
        }

        private void brisanjeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BrisanjeVozila a = new BrisanjeVozila();
            a.Show();
        }

        private void unosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UnosPolaganjeVoznje a = new UnosPolaganjeVoznje();
            a.Show();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledPolaganjaVoznje a = new PregledPolaganjaVoznje();
            a.Show();
        }

        private void brisanjeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BrisanjeRasporedaPolaganjaVoznje a = new BrisanjeRasporedaPolaganjaVoznje();
            a.Show();
        }

        private void unosToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            UnosPolaganjaPrvePomoci a = new UnosPolaganjaPrvePomoci();
            a.Show();
        }

        private void pregledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PregledRasporedaPolaganjaPrvePomoci a = new PregledRasporedaPolaganjaPrvePomoci();
            a.Show();
        }

        private void brisanjeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BrisanjeRasporedaPolaganjaPrvePomoci a = new BrisanjeRasporedaPolaganjaPrvePomoci();
            a.Show();
        }

        private void unosToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            UnosPolaganjaTestova a = new UnosPolaganjaTestova();
            a.Show();
        }

        private void pregledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PregledPolaganjaTestova a = new PregledPolaganjaTestova();
            a.Show();
        }

        private void brisanjeToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            BrisanjePolaganjaTestova a = new BrisanjePolaganjaTestova();
            a.Show();
        }

        private void prikazOpstinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikazOpstina a = new PrikazOpstina();
            a.Show();
        }

        private void unosToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            UnosVremenaObuke a = new UnosVremenaObuke();
            a.Show();
        }

        private void brisanjeToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            BrisanjeVremenaObuke a = new BrisanjeVremenaObuke();
            a.Show();
        }

        private void rasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RasporedVremenaObuke a = new RasporedVremenaObuke();
            a.Show();
        }
    }
}
