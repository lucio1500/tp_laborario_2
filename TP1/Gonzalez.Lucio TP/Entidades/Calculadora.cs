using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos

        /// <summary>
        /// Valida que el operador recibido sea +, -, / o*. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador validado.</returns>
        private static string ValidarOperador(char operador)
        {
            string operadorValidado = "+";

            if (operador == '+' || operador == '*' || operador == '-' || operador == '/')
            {
                operadorValidado = operador.ToString();
            }

            return operadorValidado;
        }


        /// <summary>
        /// Valida y realiza la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion realizada.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resul=0;

            operador = ValidarOperador(Convert.ToChar(operador));

            switch (operador)
            {
                case "+":
                    resul = num1 + num2;
                    break;
                case "-":
                    resul = num1 - num2;
                    break;
                case "/":
                    resul = num1 / num2;
                    break;
                case "*":
                    resul = num1 * num2;
                    break;
            }

            return resul;
        }

        #endregion
    }
}
