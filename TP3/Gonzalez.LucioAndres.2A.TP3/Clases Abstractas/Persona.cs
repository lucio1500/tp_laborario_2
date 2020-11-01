using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados

        /// <summary>
        /// Nacionalidad de la Persona.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #endregion

        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.apellido = value;
            }

        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                if (ValidarNombreApellido(value) != null)
                    this.nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.Apellido = apellido;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna todos los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Nombre: ");
            sb.AppendLine(this.Nombre);
            sb.Append("Apellido: ");
            sb.AppendLine(this.Apellido);
            sb.Append("Nacionalidad: ");
            sb.AppendLine(this.Nacionalidad.ToString());
            sb.Append("DNI: ");
            sb.AppendLine(this.DNI.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el entero recibido este en los siguientes rangos segun ENacionalidad.
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999.
        /// Caso contrario, se lanzará una excepción.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona.</param>
        /// <param name="dato">Dni de la Personna.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }

        /// <summary>
        /// Valida que el string recibido no tenga fallas en el formato.
        /// Caso contrario, se lanzará una excepción.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona.</param>
        /// <param name="dato">Dni de la Personna.</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length == 0 || dato.Length > 8)
            {
                throw new DniInvalidoException();
            }

            foreach (char letra in dato)
            {
                if (!char.IsDigit(letra))
                    throw new DniInvalidoException();
            }
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres.
        /// Caso contrario retornara null.
        /// </summary>
        /// <param name="dato">Nombre o Apellido de la Persona.</param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato.Length == 0 || null == dato)
            {
                return null;
            }
            foreach (char item in dato)
            {
                if (!char.IsLetter(item))
                {
                    return null;
                }
            }

            return dato;
        }

        #endregion
    }

}
