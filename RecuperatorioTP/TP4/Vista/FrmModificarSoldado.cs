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

namespace Vista
{
    public partial class FrmModificarSoldado : Form
    {
        private Soldado soldadoAModificar;
        private Cuartel cuartel;
        public FrmModificarSoldado(Cuartel cuartel, Soldado soldadoAModificar)
        {
            InitializeComponent();
            this.cuartel = cuartel;
            for (Soldado.Rango x = Soldado.Rango.Cabo; x <= Soldado.Rango.Capitan; x++)
            {
                cmbRango.Items.Add(x.ToString());
            }
            this.soldadoAModificar = soldadoAModificar;
            txtbNombre.Text = soldadoAModificar.Nombre;
            txtbApellido.Text = soldadoAModificar.Apellido;
            txtbDocumento.Text = soldadoAModificar.Documento;
            dtpFechaNac.Value = soldadoAModificar.FechaDeNacimiento;
            lblArmaSeleccionada.Text = soldadoAModificar.Arma.Modelo;

            foreach (RadioButton itemRadioBoton in gpbClase.Controls)
            {
                if (itemRadioBoton.Tag.ToString() == soldadoAModificar.ClaseDelSoldado.ToString())
                {
                    itemRadioBoton.Checked = true;
                }
            }

            cmbRango.SelectedItem = soldadoAModificar.RangoSoldado.ToString();
            
        }

        private void btnCambiarArma_Click(object sender, EventArgs e)
        {
            FrmArmeria nuevoFrmArmerica = new FrmArmeria(soldadoAModificar);
            nuevoFrmArmerica.ShowDialog();
            lblArmaSeleccionada.Text = soldadoAModificar.Arma.Modelo;
        }

        private void btnEstablecer_Click(object sender, EventArgs e)
        {
            if (ValidarInputSoldado())
            {
                soldadoAModificar.Nombre = txtbNombre.Text;
                soldadoAModificar.Apellido = txtbApellido.Text;
                soldadoAModificar.Documento = txtbDocumento.Text;
                soldadoAModificar.FechaDeNacimiento = dtpFechaNac.Value;
                foreach (RadioButton itemBotonRadio in gpbClase.Controls)
                {
                    if (itemBotonRadio.Checked == true)
                    {
                        soldadoAModificar.ClaseDelSoldado = (Soldado.ClaseSoldado)Enum.Parse(typeof(Soldado.ClaseSoldado), itemBotonRadio.Tag.ToString());
                    }
                }
                soldadoAModificar.RangoSoldado = (Soldado.Rango)Enum.Parse(typeof(Soldado.Rango), cmbRango.SelectedItem.ToString());
                MessageBox.Show("Soldado modificado con éxito");
                this.Close();
            }
            
        }

        private bool ValidarInputSoldado()
        {

            if (!Nombre.DeterminarSiEsNombre(txtbNombre.Text))
            {
                MessageBox.Show("Nombre inválido");
                return false;
            }
            if (!Nombre.DeterminarSiEsNombre(txtbApellido.Text))
            {
                MessageBox.Show("Apellido inválido");
                return false;
            }
            /*
            if (!Tiempo.ValidarFecha(txtbFechaNac.Text))
            {
                MessageBox.Show("Fecha inválida");
                return false;
            }
            */
            if (DeterminarClase() == "")
            {
                MessageBox.Show("No se seleccionó clase");
                return false;
            }
            if (cmbRango.SelectedItem is null)
            {
                MessageBox.Show("No se seleccionó rango");
                return false;
            }
            if (!Numeros<int>.DeterminarSiUnStringEsNumerico(txtbDocumento.Text) || txtbDocumento.Text.Length > 15 || (cuartel == txtbDocumento.Text && txtbDocumento.Text != soldadoAModificar.Documento))
            {
                MessageBox.Show("Documento inválido");
                return false;
            }

            return true;

        }

        private string DeterminarClase()
        {
            string claseSeleccionada = "";
            foreach (RadioButton item in gpbClase.Controls)
            {
                if (item.Checked == true)
                {
                    claseSeleccionada = item.Tag.ToString();
                    break;
                }
            }
            return claseSeleccionada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
