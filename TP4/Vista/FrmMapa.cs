using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmMapa : Form
    {
        Incursion incursion;
        public FrmMapa(Incursion incursion)
        {
            InitializeComponent();
            this.incursion = incursion;
            
        }

        private void btnDesplegar_Click(object sender, EventArgs e)
        {
            string auxLocacion = ObtenerLocacion();

            if (auxLocacion is not null)
            {
                this.incursion.Locacion = auxLocacion;
                this.incursion.TiempoInicial = DateTime.Now;
                this.incursion.Escuadron.Desplegado = true;
                MessageBox.Show("Escuadrón asignado a la locación");
                this.Close();
            } else
            {
                MessageBox.Show("No eligió locación de despliegue");
            }

        }

        private string ObtenerLocacion()
        {
            foreach (Control item in this.Controls)
            {
                if (item is RadioButton && ((RadioButton)item).Checked)
                {
                    return item.Text;
                }
            }
            return null;
        }

       
    }

    
}
