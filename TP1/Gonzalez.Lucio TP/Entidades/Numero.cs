using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        
        private double numero;

        #endregion

        #region Propiedades

        /// <summary>
        /// Valida y asigna un valor al atributo número.
        /// </summary>
        public string SetNumero
        {
            set 
            { 
                numero = ValidarNumero(value); 
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Asigna valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Asigna el valor recibido al atributo numero.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Valida y asigna el valor recibido al atributo numero.
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Comprueba que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el string recibido en formato double. Caso contrario, retornará 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numValidado = 0;

            double.TryParse(strNumero, out numValidado);

            return numValidado;
        }

        /// <summary>
        /// Valida que la cadena de caracteres esté compuesta SOLAMENTE por caracteres '0' o '1'.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>True: si la cadena es binaria. False: si la cadena contiene un digito distinto de '0' o '1'.</returns>
        private bool EsBinario(string binario)
        {
            bool rta=true;
            if(binario!="")
            {
                foreach (char auxBinario in binario)
                {
                    if (auxBinario != '0' && auxBinario != '1')
                    {
                        rta=false;
                        break;
                    }
                }
            }
            else
            {
                rta = false;
            }
            return rta;
        }

        /// <summary>
        /// Valida que la cadena sea binaria y luego la convierte de binario a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>La cadena binaria de forma decimal. Caso contrario retornará "Valor inválido".</returns>
        public string BinarioDecimal(string binario)
        {
            string valor = "Valor invalido";
            int auxDecimal;
            
            if (EsBinario(binario))
            {
                auxDecimal = Convert.ToInt32(binario, 2);
                valor = auxDecimal.ToString();
            }

            return valor;
        }

        /// <summary>
        /// Convierte un double a binario.(Toma el valor absoluto y entero del double).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Cadena con el valor entero en binario. Caso contrario retornará "Valor inválido".</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        /// <summary>
        /// Convierte un double a binario.(Toma el valor absoluto y entero del double).
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Cadena con el valor entero en binario. Caso contrario retornará "Valor inválido".</returns>
        public string DecimalBinario(string numero)
        {
            string valor = "Valor invalido";
            double num;
            int num1;

            if (double.TryParse(numero, out num))   //Verifica si la cadena es numerica, y la convierto en un double.
            {
                num1 = (int)num;                    //Tomo la parte entera del double.
                num1=Math.Abs(num1);                //Tomo el valor absoluto del entero.
                valor = Convert.ToString(num1, 2);  //Convierto el entero a binario.
            }

            return valor;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Suma el contenido del atributo numero de un objeto Numero.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Resultado de la suma de dos objetos Numero.</returns>
        public static double operator +(Numero x, Numero y)
        {
            return x.numero + y.numero;
        }

        /// <summary>
        /// Resta el contenido del atributo numero de un objeto Numero.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Resultado de la resta de dos objetos Numero.</returns>
        public static double operator -(Numero x, Numero y)
        {
            return x.numero - y.numero;
        }

        /// <summary>
        /// Multiplica el contenido del atributo numero de un objeto Numero.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Resultado de la multiplicacion de dos objetos Numero.</returns>
        public static double operator *(Numero x, Numero y)
        {
            return x.numero * y.numero;;
        }

        /// <summary>
        /// Divide el contenido del atributo numero de un objeto Numero.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Resultado de la division de dos objetos Numero.En caso de ser 0 retorna MinValue</returns>
        public static double operator /(Numero x, Numero y)
        {
            double resul;

            if(x.numero!=0 && y.numero!=0)
            {
                resul = x.numero / y.numero;
            }
            else
            {
                resul=double.MinValue;
            }

            return resul;
        }

        #endregion
    }
}
