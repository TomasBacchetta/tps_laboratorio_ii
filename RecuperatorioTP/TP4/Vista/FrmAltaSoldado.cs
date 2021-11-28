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
    public partial class FrmAltaSoldado : Form
    {
        private Soldado soldadoNuevo;
        private Cuartel cuartel;

       
        public FrmAltaSoldado(Cuartel cuartel)
        {
            InitializeComponent();
            rbAsalto.Tag = "Asalto";
            rbTecnico.Tag = "Tecnico";
            rbMedico.Tag = "Medico";
            rbReconocimiento.Tag = "Reconocimiento";
            this.cuartel = cuartel;
            



            for (Soldado.Rango x = Soldado.Rango.Cabo; x <= Soldado.Rango.Capitan; x++)
            {
                cmbRango.Items.Add(x.ToString());
            }
            

        }

        private void btnReclutar_Click(object sender, EventArgs e)
        {
            if (ValidarInputSoldado())
            {
                
                soldadoNuevo = new Soldado(dtpFechaNac.Value, Nombre.FormatearNombre(txtbNombre.Text), Nombre.FormatearNombre(txtbApellido.Text), txtbDocumento.Text, (Soldado.Rango)cmbRango.SelectedIndex, (Soldado.ClaseSoldado)Enum.Parse(typeof(Soldado.ClaseSoldado), DeterminarClase()));
                FrmArmeria frmArmeria = new FrmArmeria(soldadoNuevo);
                frmArmeria.ShowDialog();
                if (cuartel + soldadoNuevo)
                {
                    MessageBox.Show("Soldado reclutado con éxito");
                }
                else
                {
                    MessageBox.Show("El soldado no pudo agregarse");
                }
                this.Close();
                
                
                
            }
            
        }

     

        /// <summary>
        /// valida los cambos de input del alta de soldado
        /// </summary>
        /// <returns></returns>
        private bool ValidarInputSoldado()
        {
            
            if (!Nombre.DeterminarSiEsNombre(txtbNombre.Text))
            {
                txtbNombre.Text = "";
                MessageBox.Show("Nombre inválido");
                return false;
            }
            if (!Nombre.DeterminarSiEsNombre(txtbApellido.Text))
            {
                txtbApellido.Text = "";
                MessageBox.Show("Apellido inválido");
                return false;
            }
            /*
            if (!Tiempo.ValidarFecha(txtbFechaNac.Text))
            {
                txtbFechaNac.Text = "";
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
            if (!Numeros<int>.DeterminarSiUnStringEsNumerico(txtbDocumento.Text) || txtbDocumento.Text.Length > 9 || cuartel == txtbDocumento.Text)
            {
                MessageBox.Show("Documento inválido");
                return false;
            }

            
            return true;
            
            
        }

       
        /// <summary>
        /// determina la clase seleccionada en base al radiobutton en cuestion
        /// </summary>
        /// <returns></returns>
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

        
    }
}
