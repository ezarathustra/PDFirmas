using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPDF
{
    public partial class Firmas : Form
    {
        private string RutaImagen = "";
        private DBFirmas DbFirmas = new DBFirmas();
        public Firmas()
        {
            InitializeComponent();
            for (int i = 0; i < DatosGlobales.rutasCompletas.Count; i++)
            {
                string nombreArchivo = Path.GetFileName(DatosGlobales.rutasCompletas[i]);
                listBox1.Items.Add(nombreArchivo);
            }
            //this.FormClosed += (s, e) => Application.Exit();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton Quitar
            if (listBox1.SelectedIndex != -1)
            {
                DbFirmas.EliminarFirmas(DatosGlobales.rutasCompletas[listBox1.SelectedIndex]);
                //Borrar dato seleccionado de la lista global
                DatosGlobales.rutasCompletas.RemoveAt(listBox1.SelectedIndex);
                //Borrar dato seleccionado del listBox
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lista de imagenes
            for (int i = 0; i < DatosGlobales.rutasCompletas.Count; i++)
            {
                string nombreArchivo = Path.GetFileName(DatosGlobales.rutasCompletas[i]);
                if (listBox1.Text.ToString() == nombreArchivo)
                {
                    RutaImagen = DatosGlobales.rutasCompletas[i];
                    //Imagen
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Load(RutaImagen);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Agregar
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Filter = "Archivos PNG (*.png)|*.png";
                openFileDialog.Title = "Seleccionar un archivo";

                // Mostrar el cuadro de diálogo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado
                    string rutaArchivo = openFileDialog.FileName;
                    // Obtener el nombre del archivo
                    string nombreArchivo = Path.GetFileName(rutaArchivo);
                    // Agregar al listBox
                    if (!listBox1.Items.Contains(nombreArchivo))
                    {
                        //Guardar ruta completa
                        DatosGlobales.rutasCompletas.Add(rutaArchivo);
                        listBox1.Items.Add(nombreArchivo);
                        DbFirmas.InsertarFirmas(rutaArchivo);
                        //MessageBox.Show($"'{nombreArchivo}' agregado correctamente.");
                    }
                    else
                    {
                        //MessageBox.Show($"'{nombreArchivo}' ya está agregado.");
                    }
                }
            }
        }
    }
}
