using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        private int legajo;

        #endregion

        #region Constructores

        public Universitario()
            : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que sea un Objeto de tipo Universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Universitario)
            {
                rta = this == (Universitario)obj;
            }

            return rta;
        }

        /// <summary>
        /// Muestra los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo: " + this.legajo);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo));
        }

        /// <summary>
        /// Dos Universitario serán distintos si NO son del mismo Tipo 
        /// y su Legajo o DNI NO son iguales.
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
