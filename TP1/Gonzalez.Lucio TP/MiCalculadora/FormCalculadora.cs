using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor predeterminado.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.AddRange(new string[] { "+", "-", "/", "*" });
        }

        #region Metodos

        /// <summary>
        /// Recibe los dos números y el operador retorna el resultado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion realizada.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1,num2,operador);;
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Realiza la operacion entre los dos numeros que hay en los texbox utilizando el operador seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operar_Click(object sender, EventArgs e)
        {
            double resultado;

            if (cmbOperador.Text != "" && cmbOperador.Text.Length < 2)
            {
                resultado=Operar(txtNumero1.Text,txtNumero2.Text,cmbOperador.Text);
            }
            else
            {
                resultado=Operar(txtNumero1.Text, txtNumero2.Text,"+");
            }
            
            lblResultado.Text = resultado.ToString();            
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Limpia la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Convierte a binario (si es posible) el resultado que se encuentre en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertirBinario_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            lblResultado.Text = n1.DecimalBinario(lblResultado.Text);;
        }

        /// <summary>
        /// Convierte a decimal (si es posible) el resultado que se encuentre en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertirDecimal_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();         
            lblResultado.Text = n1.BinarioDecimal(lblResultado.Text);
        }

        #endregion
    }
}
