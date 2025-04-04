using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Xml.Linq;

namespace ProyectoPDF
{
    class Leer
    {
        public string Ruta { get; set; }
        public string RutaImagen { get; set; }
        public int X { get; set; }
        public int Y { get; set; } 
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public int NumeroPagina { get; set; }

        public Leer(string ruta, string rutaImagen, int x, int y, int ancho, int alto, int numeroPagina)
        {
            Ruta = ruta;
            RutaImagen = rutaImagen;
            X = x;
            Y = y;
            Ancho = ancho;
            Alto = alto;
            NumeroPagina = numeroPagina;
        }
        public string LeerDocumentos()
        {
            // Abrir PDF
            PdfDocument documento = PdfReader.Open(Ruta, PdfDocumentOpenMode.Modify);

            if (NumeroPagina == 100)
            {
                for (int i = 0; i < documento.PageCount; i++)
                {
                    // Numero de pagina
                    PdfPage pagina = documento.Pages[i];
                    XGraphics gfx = XGraphics.FromPdfPage(pagina);

                    // Insertar imagen en coordenadas específicas
                    XImage image = XImage.FromFile(RutaImagen);
                    gfx.DrawImage(image, X, Y, Ancho, Alto);
                }
            }
            else
            {
                // Numero de pagina
                PdfPage pagina = documento.Pages[NumeroPagina];
                XGraphics gfx = XGraphics.FromPdfPage(pagina);

                // Insertar imagen en coordenadas específicas
                XImage image = XImage.FromFile(RutaImagen);
                gfx.DrawImage(image, X, Y, Ancho, Alto);
            }
            // Guardar el resultado
            string rutaModificados = Path.GetDirectoryName(Ruta);
            if (!Directory.Exists(rutaModificados))
            {
                Directory.CreateDirectory(rutaModificados);
            }
            string NombreArchivo = rutaModificados + @"\" + Path.GetFileName(Ruta);
            documento.Save(NombreArchivo);

            return "Imagen insertada al documento";
        }
    }
}
