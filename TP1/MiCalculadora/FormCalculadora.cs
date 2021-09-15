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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

            if (string.IsNullOrEmpty(cmbOperador.Text))
            {
                cmbOperador.Text = "+";
            }

            lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }

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

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

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

    

