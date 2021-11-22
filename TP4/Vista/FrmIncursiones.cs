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
    public partial class FrmIncursiones : Form
    {
        
        public FrmIncursiones()
        {
            InitializeComponent();
        }

        private void FrmIncursiones_Load(object sender, EventArgs e)
        {
            ActualizarTablaIncursiones();
            CargarComboBoxes();
            
        }

        private void CargarComboBoxes()
        {
            cmbBoxColumnas.Items.Add("Por defecto");
            for (int x = 0; x < 14; x++)
            {
                cmbBoxColumnas.Items.Add(dgvIncursiones.Columns[x].HeaderText);
            }
            cmbCriterio.Items.Add("Por defecto");
            cmbCriterio.Items.Add("Ascendente");
            cmbCriterio.Items.Add("Descendente");

            cmbEscuadrones.Items.Add("Todos");
            for (int x = 1; x < 10; x++)
            {
                cmbEscuadrones.Items.Add((Escuadron.NombreEscuadron)x);
            }
            cmbBoxColumnas.Items.Remove("Horas");
            cmbBoxColumnas.SelectedIndex = 0;
            cmbCriterio.SelectedIndex = 0;
            cmbEscuadrones.SelectedIndex = 0;
        }
        private void ActualizarTablaIncursiones()
        {

            dgvIncursiones.DataSource = IncursionDB.Leer();
            dgvIncursiones.Refresh();
            dgvIncursiones.Update();
            NombrarColumnas();

        }

        private void OrdenarYActualizarTablaIncursiones(string orden, string criterio, string filtro)
        {
            dgvIncursiones.DataSource = IncursionDB.Leer(orden, criterio, filtro);
            dgvIncursiones.Refresh();
            dgvIncursiones.Update();
            NombrarColumnas();

        }

        public void NombrarColumnas()
        {
            dgvIncursiones.Columns[0].HeaderText = "Num";
            dgvIncursiones.Columns[1].HeaderText = "Salida";
            dgvIncursiones.Columns[2].HeaderText = "Llegada";
            dgvIncursiones.Columns[3].HeaderText = "Horas";
            dgvIncursiones.Columns[4].HeaderText = "Bajas";
            dgvIncursiones.Columns[5].HeaderText = "Curaciones";
            dgvIncursiones.Columns[6].HeaderText = "Artefactos";
            dgvIncursiones.Columns[7].HeaderText = "Anomalias";
            dgvIncursiones.Columns[8].HeaderText = "Lugar";
            dgvIncursiones.Columns[9].HeaderText = "Escuadron";
            dgvIncursiones.Columns[10].HeaderText = "Asalto";
            dgvIncursiones.Columns[11].HeaderText = "Medico";
            dgvIncursiones.Columns[12].HeaderText = "Tecnico";
            dgvIncursiones.Columns[13].HeaderText = "Reconocimiento";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                IncursionDB.Eliminar((int)dgvIncursiones.SelectedRows[0].Cells["NumIncursion"].Value);
                ActualizarTablaIncursiones();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila");
            }

        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            IncursionDB.EliminarTodo();
            ActualizarTablaIncursiones();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            OrdenarYActualizarTablaIncursiones(cmbBoxColumnas.SelectedItem.ToString(), cmbCriterio.SelectedItem.ToString(), cmbEscuadrones.SelectedItem.ToString());
        }

    }
}
