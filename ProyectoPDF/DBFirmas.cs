using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.ApplicationServices;

namespace ProyectoPDF
{
    class DBFirmas
    {
        public string rutaDB = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBFirmas.txt");
        public string CrearFirma = "";
        public string BorrarFirma = "";

        public DBFirmas() 
        {
        }

        public void InicioDB()
        {
            
            using (StreamWriter escritor = new StreamWriter(rutaDB, append: true)) 
            {
                
            }
            DatosGlobales.rutasCompletas = File.ReadAllLines(rutaDB).ToList();
        }
        public void InsertarFirmas(String nombreFirmas)
        {
            CrearFirma = nombreFirmas;

            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaDB, append: true))
                {
                    //Escribe la ruta de la firma en el archivo de texto
                    escritor.WriteLine(CrearFirma);
                }
            }
            catch (Exception e) { }
        }
        public void EliminarFirmas(String nombreFirmas)
        {
            BorrarFirma = nombreFirmas;
            try
            {
                using (StreamWriter escritor = new StreamWriter(rutaDB, append: true))
                {
                    
                }
                // Extrae toda la informacion el archivo
                var contenidoArchivo = File.ReadAllLines(rutaDB).ToList();
                // Solo extrae la informacion             Parametros - Separador del parametro - Expresion
                contenidoArchivo = contenidoArchivo.Where(contenidoArchivo => !contenidoArchivo.Contains(BorrarFirma)).ToList();
                // Se sobreescriben todas las lineas de texto en el archivo
                File.WriteAllLines(rutaDB, contenidoArchivo);
            }
            catch (Exception e) { }
        }
    }
}
