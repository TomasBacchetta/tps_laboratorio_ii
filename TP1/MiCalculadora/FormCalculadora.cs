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
        public FormCalculadora()
        {
            InitializeComponent();


        }
        /// <summary>
        /// llama al método Operar de esta misma clase asignandole sus parámetros en base a los valores tomados por los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            if (string.IsNullOrEmpty(cmbOperador.Text))
            {
                cmbOperador.Text = "+";
            }

            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
        }
        /// <summary>
        /// al cargar el formulario, asigna los valores del combobox de operadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }
        /// <summary>
        /// realiza una operacion matemática en base a dos operandos y un operador
        /// </summary>
        /// <param name="numero1">el operando izquierdo en formato string</param>
        /// <param name="numero2">el operando derecho en formato string</param>
        /// <param name="operador">el operador en formato string</param>
        /// <returns>devuelve el resultado de el metodo Operar de la clase Calculadora en formato double</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando op1 = new Operando(numero1);
            Operando op2 = new Operando(numero2);
            char chrOperador;

            if (!(char.TryParse(operador, out chrOperador)))
            {
                chrOperador = ' ';
            }
            
            return Calculadora.Operar(op1, op2, chrOperador);

        }
        /// <summary>
        /// realiza la conversion a binario al hacer click en el botón correspondiente llamando el método DecimalBinario de la clase Calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            StringBuilder resultado = new StringBuilder();
            bool puntoDeCopiado = false;

            if (lstOperaciones.Items.Count > 0)
            {
                foreach (char caracter in lstOperaciones.Items[lstOperaciones.Items.Count - 1].ToString())
                {
                    if (puntoDeCopiado)
                    {
                        resultado.Append(caracter);
                    }
                    if (caracter == '=')
                    {
                        puntoDeCopiado = true;
                    }

                }
            }

            resultado.ToString().Trim();

            lblResultado.Text = Operando.DecimalBinario(resultado.ToString());
        }
        /// <summary>
        /// realiza la conversion de binario a decimal al hacer click en el botón correspondiente, llamando al método BinarioDecimal de la clase Calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }
        /// <summary>
        /// llama a la función Limpiar de la instancia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// antes de cerrar definitivamente el formulario, pide confirmación al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
        /// <summary>
        /// borra todos los datos del formulario
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = -1;
            lstOperaciones.Items.Clear();
        }
    }
}

    

