using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException()
            :base("Error en la carga o lectura de archivo")
        {

        }

        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }

        public ArchivosException(Exception innerException)
            :base("Error en la carga o lectura de archivo",innerException)
        {

        }

    }
}
