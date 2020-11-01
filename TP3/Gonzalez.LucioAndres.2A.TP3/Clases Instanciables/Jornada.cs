using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }

        }

        #endregion

        #region Constructores

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {

            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda en un archivo de texto todos los datos de la Jornada.
        /// </summary>
        /// <param name="jornada">Jornada.</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();

            archivoTexto.Guardar("Jornada.txt", jornada.ToString());

            return true;
        }

        /// <summary>
        /// Devuelve todos los datos de una Jornada.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASE DE : " + this.Clase.ToString());
            sb.AppendLine("PROFESOR: ");
            sb.AppendLine(this.instructor.ToString());
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
                sb.AppendLine(item.ToString());


            return sb.ToString();
        }

        /// <summary>
        /// Muestra todos los datos de una Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Leer();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada.</param>
        /// <param name="a">Alumno.</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.Clase);
        }

        /// <summary>
        /// Una Jornada será distinto a un Alumno si el mismo NO participa de la clase.
        /// </summary>
        /// <param name="j">Jornada.</param>
        /// <param name="a">Alumno.</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la Jornada, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="j">Jornada.</param>
        /// <param name="a">Alumno.</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                    return j;
            }

            j.alumnos.Add(a);

            return j;
        }

        #endregion
    }
}
