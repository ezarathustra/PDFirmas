using System;
using System.Windows.Forms;


namespace ProyectoPDF
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            DBFirmas dBFirmas = new DBFirmas();
            dBFirmas.InicioDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PDF Pdf = new PDF();
            Pdf.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Firmas Firmas = new Firmas();
            Firmas.Show();
            //this.Hide();
        }
    }
}
