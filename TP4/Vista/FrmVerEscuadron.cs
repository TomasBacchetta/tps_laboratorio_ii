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
    public partial class FrmVerEscuadron : Form
    {
        Escuadron escuadronSeleccionado;
        Cuartel cuartel;
        private int[] arrayEstadisticas;
        public FrmVerEscuadron(Cuartel cuartel, Escuadron escuadronSeleccionado)
        {
            InitializeComponent();
            this.escuadronSeleccionado = escuadronSeleccionado;
            this.cuartel = cuartel;
            lstbMiembros.Visible = false;
            gpbSoldado.Visible = false;
            CargarListaMiembrosEscuadron();
            ActualizarVistaSoldado();
            lblNombreEscuadron.Text = escuadronSeleccionado.Nombre.ToString();
            arrayEstadisticas = EscuadronDB.DevolverEstadisticasHistoricasDeEscuadron(escuadronSeleccionado.Nombre);
            lblNumeroIncursiones.Text = $"Número de Incursiones: {arrayEstadisticas[4]}";
            lblNumeroBajas.Text = $"Cantidad de bajas realizadas: {arrayEstadisticas[0]}";
            lblNumeroCuraciones.Text = $"Cantidad de curaciones realizadas: {arrayEstadisticas[1]}";
            lblNumeroArtefactos.Text = $"Cantidad de artefactos encontrados: {arrayEstadisticas[2]}";
            lblNumeroAnomalias.Text = $"Cantidad de anomalías vistas: {arrayEstadisticas[3]}";


        }

        /// <summary>
        /// actualiza el listbox de miembros de escuadron
        /// </summary>
        private void CargarListaMiembrosEscuadron()
        {
            lstbMiembros.Items.Clear();
            if (escuadronSeleccionado.MiembrosEscuadron.Count > 0)
            {
                foreach (Soldado itemSoldado in escuadronSeleccionado.MiembrosEscuadron)
                {
                    lstbMiembros.Items.Add(itemSoldado);
                    lstbMiembros.DisplayMember = "NombreYApellido";
                }
                lstbMiembros.SelectedIndex = 0;
            }
            
        }
        /// <summary>
        /// actualiza el dossier del soldado seleccionado
        /// </summary>
        private void ActualizarVistaSoldado()
        {
            if (escuadronSeleccionado.MiembrosEscuadron.Count > 0)
            {
                lstbMiembros.Visible = true;
                if (lstbMiembros.SelectedItem is not null)
                {
                    gpbSoldado.Visible = true;
                    lblNombre.Text = ((Soldado)lstbMiembros.SelectedItem).Nombre;
                    lblApellido.Text = ((Soldado)lstbMiembros.SelectedItem).Apellido;
                    ptbSoldado.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"_{((Soldado)lstbMiembros.SelectedItem).CodigoRetrato}");
                    rtbDatosSoldado.Text = ((Soldado)lstbMiembros.SelectedItem).ToString();
                }
                else
                {
                    gpbSoldado.Visible = false;
                }
            }
            

        }

        private void lstbMiembros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaSoldado();
            if (lstbMiembros.Items.Count == 0)
            {
                lstbMiembros.Visible = false;
            }
        }
        /// <summary>
        /// expulsa a un soldado particular del escuadron
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEchar_Click(object sender, EventArgs e)
        {
            if (escuadronSeleccionado.Desplegado)
            {
                MessageBox.Show("El escuadron no está en el cuartel. Espere a que vuelva de su misión");
            } else
            {
                if (escuadronSeleccionado - (Soldado)lstbMiembros.SelectedItem)
                {

                    MessageBox.Show($"Soldado removido del escuadrón {escuadronSeleccionado.Nombre}");

                    CargarListaMiembrosEscuadron();
                    ActualizarVistaSoldado();
                }
            }
   
        }


        
    }
}
