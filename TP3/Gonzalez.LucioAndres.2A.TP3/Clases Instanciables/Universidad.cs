using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Clases_Instanciables
{    

    public class Universidad
    {
        #region Enumerados

        /// <summary>
        /// Tipos de Clases.
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #endregion

        #region Atributos

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

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

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i > this.jornada.Count || i < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[i];
                }
            }
            set
            {
                if (i < this.jornada.Count && i >= 0)
                {
                    this.jornada[i] = value;
                }
                else if (i == this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Serializará los datos del Universidad en un XML,
        /// </summary>
        /// <param name="uni">Universidad.</param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Retorna una Universidad con todos los datos previamente serializados.
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Universidad.Guardar(this);

            return this;
        }

        /// <summary>
        /// Muestra todos los datos de una Universidad.
        /// </summary>
        /// <param name="uni">Universidad.</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornada)
                sb.AppendLine(item.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Muestra todos los datos de una Universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Operadores

        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == p)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            return new Profesor();
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.alumnos)
            {
                if (item == a)
                    throw new AlumnoRepetidoException();

            }

            u.alumnos.Add(a);

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == p)
                    return u;
            }

            u.profesores.Add(p);

            return u;
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, u == clase);

            foreach (Alumno item in u.alumnos)
            {
                if (item == clase)
                    nuevaJornada.Alumnos.Add(item);
            }

            u.jornada.Add(nuevaJornada);

            return u;
        }

        #endregion
    }
}
