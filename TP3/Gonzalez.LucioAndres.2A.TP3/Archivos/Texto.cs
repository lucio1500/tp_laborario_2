using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un Archivo de texto.
        /// </summary>
        /// <param name="archivo">Path.</param>
        /// <param name="datos">Cadena a Guardar.</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                }

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>
        /// Lee los datos de un archivo de texto.
        /// </summary>
        /// <param name="archivo">Path.</param>
        /// <param name="datos">Cadena a Leer.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch
            {
                datos = null;
                return false;
            }                              
        }
    }
}
