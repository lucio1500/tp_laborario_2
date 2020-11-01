using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos del T recibido en un XML.
        /// </summary>
        /// <param name="archivo">Path.</param>
        /// <param name="datos">T a Serializar.</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    ser.Serialize(writer, datos);
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        /// <summary>
        /// Deserializa los datos del T que hay en un XML.
        /// </summary>
        /// <param name="archivo">Path.</param>
        /// <param name="datos">T a Serializar.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));

                    datos = (T)ser.Deserialize(reader);
                }
                return true;
            }
            catch
            {
                datos = default(T);
                return false;
            }
        }
    }
}
