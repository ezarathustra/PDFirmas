using PdfSharp.Pdf;
using System.Windows.Forms;

namespace ProyectoPDF
{
    public partial class PDF : Form
    {
        public string rutaImagen = "";
        public string nombreArchivo = "";
        public int x;
        public int y;
        public int alto;
        public int ancho;
        public int numeroPagina;
        public PDF()
        {
            InitializeComponent();
            //this.FormClosed += (s, e) => Application.Exit();
            for (int i = 0; i < DatosGlobales.rutasCompletas.Count; i++)
            {
                nombreArchivo = Path.GetFileName(DatosGlobales.rutasCompletas[i]);
                comboBox1.Items.Add(nombreArchivo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog rutaCarpeta = new FolderBrowserDialog())
            {
                rutaCarpeta.Description = "Selecciona una carpeta";
                rutaCarpeta.RootFolder = Environment.SpecialFolder.StartMenu;

                if (rutaCarpeta.ShowDialog() == DialogResult.OK)
                {
                    DatosGlobales.rutaCarpeta = rutaCarpeta.SelectedPath;
                    textBox1.Text = DatosGlobales.rutaCarpeta;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] rutas = Directory.GetFiles(DatosGlobales.rutaCarpeta, "*.pdf", SearchOption.AllDirectories);
            foreach (string ruta in rutas)
            {
                Leer leerPDF = new Leer(ruta, rutaImagen, x, y, ancho, alto, numeroPagina);
                string test = leerPDF.LeerDocumentos();
            }
            MessageBox.Show($"Terminado..");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DatosGlobales.rutaCarpeta = textBox1.Text;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Carta
            x = 135;
            y = 280;
            ancho = 100;
            alto = 100;
            numeroPagina = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Fichas
            x = 380;
            y = 485;
            ancho = 60;
            alto = 60;
            numeroPagina = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Planos Firma Medio
            x = 2094;
            y = 1470;
            ancho = 40;
            alto = 40;
            numeroPagina = 0;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Sin Formato
            x = 50;
            y = 50;
            ancho = 80;
            alto = 80;
            numeroPagina = 0;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //Planos Firma Bajo
            x = 2094;
            y = 1504;
            ancho = 40;
            alto = 40;
            numeroPagina = 0;
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //Planos Firma Arriba
            x = 2094;
            y = 1436;
            ancho = 35;
            alto = 35;
            numeroPagina = 100;
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            //Planos Firma Mas Arriba
            x = 2094;
            y = 1415;
            ancho = 35;
            alto = 35;
            numeroPagina = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < DatosGlobales.rutasCompletas.Count; i++)
            {
                nombreArchivo = Path.GetFileName(DatosGlobales.rutasCompletas[i]);
                if (nombreArchivo == comboBox1.Text)
                {
                    rutaImagen = DatosGlobales.rutasCompletas[i];
                }
            }
        }
    }
}
