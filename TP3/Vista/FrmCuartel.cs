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
using System.IO;

namespace Vista
{
    public partial class FrmCuartel : Form
    {
        private Cuartel cuartel;
        private string path;

        public FrmCuartel()
        {
            InitializeComponent();
            this.cuartel = new Cuartel(Cuartel.CargarEscuadrones());
            ActualizarListas();
            OcultarVistaSoldado();
            lblIntegrantesEscua.Visible = false;
            path = "";

        }

       

        private void btnAgregarSoldado_Click(object sender, EventArgs e)
        {
            Soldado nuevoSoldado = new Soldado();
            FrmAltaSoldado frmAltaSoldado = new FrmAltaSoldado(cuartel);
            frmAltaSoldado.ShowDialog();

            this.ActualizarListas();

        }
        /// <summary>
        /// actualiza las listas de datos
        /// </summary>
        public void ActualizarListas()
        {
            lstbSoldados.Items.Clear();
            
            if (cuartel.ListaDeSoldados.Count > 0)
            {
                MostrarVistaSoldado();
                foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
                {
                    lstbSoldados.Items.Add(itemSoldado);
                }
                lstbSoldados.DisplayMember = "NombreYApellido";
                lstbSoldados.SelectedIndex = 0;

            }
            else
            {
                OcultarVistaSoldado();
            }

            lstbEscuadrones.Items.Clear();

            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                lstbEscuadrones.Items.Add(itemEscuadron);
            }
            lstbEscuadrones.DisplayMember = "Nombre";
            lstbEscuadrones.SelectedIndex = 0;
        }


        /// <summary>
        /// actualiza el dossier del soldado
        /// </summary>
        private void ActualizarVistaSoldado()
        {
            if (lstbSoldados.SelectedItem is not null)
            {
                Soldado auxSoldado = (Soldado)lstbSoldados.SelectedItem;
                MostrarVistaSoldado();
                lblNombreSoldado.Text = auxSoldado.NombreYApellido;
                ptbSoldado.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject($"_{auxSoldado.CodigoRetrato}");
                rtbDatosSoldado.Text = auxSoldado.ToString();
            }
            else
            {
                OcultarVistaSoldado();
            }
            
        }

        private void lstbSoldados_SelectedIndexChanged(object sender, EventArgs e)
        {
            gpbSoldado.Visible = true;
            ActualizarVistaSoldado();
        }

        private void MostrarVistaSoldado()
        {
            gpbSoldado.Visible = true;
        }
        private void OcultarVistaSoldado()
        {
            gpbSoldado.Visible = false;
        }
        /// <summary>
        /// expulsa a un soldado del cuartel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEcharSoldado_Click(object sender, EventArgs e)
        {
            Soldado soldadoARemover = (Soldado)lstbSoldados.SelectedItem;
            if (cuartel - soldadoARemover)
            {
                MessageBox.Show("Soldado removido del cuartel");
                Escuadron auxEscuadron = cuartel.ObtenerEscuadronPorSuNombre(soldadoARemover.EscuadronAsignado);
                if (auxEscuadron - soldadoARemover)
                {
                    MessageBox.Show($"Soldado removido del escuadrón {auxEscuadron.Nombre}");
                }
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se pudo remover");
            }
        }

        /// <summary>
        /// asigna un soldado a un escuadron
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Escuadron auxEscuadron = (Escuadron)lstbEscuadrones.SelectedItem;
            Soldado auxSoldado = (Soldado)lstbSoldados.SelectedItem;
            if (auxEscuadron + auxSoldado)
            {
                MessageBox.Show($"Soldado agregado a escuadrón {auxEscuadron.Nombre}");
                ImprimirIntegrantesEscuadron();
                ActualizarVistaSoldado();
            }
        }
        
        private void lstbEscuadrones_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIntegrantesEscua.Text = "";
            ImprimirIntegrantesEscuadron();



        }
        /// <summary>
        /// imprime los integrantes del escuadron en el label correspondiente
        /// </summary>
        private void ImprimirIntegrantesEscuadron()
        {
            Escuadron escuadraSeleccionada = (Escuadron)lstbEscuadrones.SelectedItem;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine("Integrantes: ");
            if (escuadraSeleccionada is not null)
            {
                foreach (Soldado itemSoldado in escuadraSeleccionada.MiembrosEscuadron)
                {
                    buffer.AppendLine($"{itemSoldado.Nombre} {itemSoldado.Apellido} ({itemSoldado.ClaseDelSoldado})");
                    lblIntegrantesEscua.Visible = true;
                    lblIntegrantesEscua.Text = $"{buffer}";
                }
            } else
            {
                lblIntegrantesEscua.Visible = false;
            }
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == "")
            {
                GuardarComo();
            }
            else
            {
                Guardar();
            }

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }
        /// <summary>
        /// abre un archivo
        /// </summary>
        private void Abrir()
        {

            OpenFileDialog ventanaAbrir = new OpenFileDialog();
            ventanaAbrir.Filter = "Archivos Xml (*.xml)|*.xml|Archivos json (*.json)|*.json";
            ventanaAbrir.ShowDialog();
            path = ventanaAbrir.FileName;
            
            switch (Path.GetExtension(path))
            {
                case ".xml":
                    /// <summary>
                    /// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    ArchivoXml<Cuartel> archivoXmlALeer = new ArchivoXml<Cuartel>();
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    try
                    {
                        this.cuartel = archivoXmlALeer.Abrir(path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (ArchivoIncorrectoOCorruptoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case ".json":
                    /// <summary>
                    /// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos
                    /// </summary>
                    ArchivoJson<Cuartel> archivoJsonALeer = new ArchivoJson<Cuartel>();
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización

                    /// </summary>
                    try
                    {
                        this.cuartel = archivoJsonALeer.Abrir(path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (ArchivoIncorrectoOCorruptoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

            }
            if (!string.IsNullOrWhiteSpace(path))
            {
                RevincularListasAlAbrirArchivo();
                ActualizarListas();
            }
            

        }
        /// <summary>
        /// actualiza las listas de escuadrones del cuartel, reetableciendo el vinculo de referencia entre ellas. Es necesaria luego de reserializar ya que los objetos se instancian de nuevo
        /// </summary>
        private void RevincularListasAlAbrirArchivo()
        {
            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                List<Soldado> listaAuxSoldados = new List<Soldado>();
                foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
                {
                    if (itemSoldado.EscuadronAsignado == itemEscuadron.Nombre)
                    {
                        listaAuxSoldados.Add(itemSoldado);
                    }
                }
                itemEscuadron.MiembrosEscuadron = listaAuxSoldados;
            }
            


        }
        /// <summary>
        /// guarda el archivo
        /// </summary>
        private void Guardar()
        {
            switch (Path.GetExtension(path))
            {
                case ".xml":
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    ArchivoXml<Cuartel> archivoXmlAGuardar = new ArchivoXml<Cuartel>();
                    try
                    {
                        archivoXmlAGuardar.Guardar(this.cuartel, path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    
                    break;
                case ".json":
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    ArchivoJson<Cuartel> archivoJsonAGuardar = new ArchivoJson<Cuartel>();
                    try
                    {
                        archivoJsonAGuardar.Guardar(this.cuartel, path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

            }
        }
        /// <summary>
        /// guarda el archivo en algun directorio si es que el camino al archivo esta vacio
        /// </summary>
        private void GuardarComo()
        {
            SaveFileDialog ventanaGuardar = new SaveFileDialog();
            ventanaGuardar.Filter = "Archivos Xml (*.xml)|*.xml|Archivos json (*.json)|*.json";
            ventanaGuardar.ShowDialog();
            path = ventanaGuardar.FileName;

            switch (Path.GetExtension(path))
            {
                case ".xml":
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    ArchivoXml<Cuartel> archivoXmlAGuardar = new ArchivoXml<Cuartel>();
                    try
                    {
                        archivoXmlAGuardar.GuardarComo(this.cuartel, path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case ".json":
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10, y la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
                    /// </summary>
                    ArchivoJson<Cuartel> archivoJsonAGuardar = new ArchivoJson<Cuartel>();
                    try
                    {
                        archivoJsonAGuardar.GuardarComo(this.cuartel, path);
                    }
                    catch (ErrorDeArchivoExcepcion ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

            }
        }
        /// <summary>
        /// elimina los miembros de un escuadron
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVaciarEscuadron_Click(object sender, EventArgs e)
        {
            Escuadron auxEscuadron = (Escuadron)lstbEscuadrones.SelectedItem;
            if (auxEscuadron.MiembrosEscuadron.Count > 0)
            {
                foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
                {
                    if (itemSoldado.EscuadronAsignado == auxEscuadron.Nombre)
                    {
                        itemSoldado.EscuadronAsignado = Escuadron.NombreEscuadron.Ninguno;
                    }
                    
                }
                auxEscuadron.MiembrosEscuadron.Clear();
                ActualizarListas();
                ImprimirIntegrantesEscuadron();
            }
        }
        /// <summary>
        /// envia a los soldados a una mision
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesplegar_Click(object sender, EventArgs e)
        {
            Escuadron auxEscuadron = (Escuadron)lstbEscuadrones.SelectedItem;
            if (lstbEscuadrones.SelectedItem is not null)
            {
                if (auxEscuadron.MiembrosEscuadron.Count == 4)
                {
                    StringBuilder buffer = new StringBuilder();
                    foreach (Soldado itemSoldado in auxEscuadron.MiembrosEscuadron)
                    {
                        
                        int bajasRealizadas = itemSoldado.Atacar();
                        int curacionesRealizadas = itemSoldado.Curar();
                        int artefactosEncontrados = itemSoldado.EncontrarArtefactos();
                        int anomaliasRegistradas = itemSoldado.EncontrarAnomalias();

                        auxEscuadron.NumeroDeBajasTotales += bajasRealizadas;
                        auxEscuadron.NumeroDeCuracionesTotales += curacionesRealizadas;
                        auxEscuadron.NumeroDeArtefactosObtenidosTotales += artefactosEncontrados;
                        auxEscuadron.NumeroDeAnomaliasVistas += anomaliasRegistradas;

                        buffer.AppendLine($"{itemSoldado.Nombre} {itemSoldado.Apellido} ({itemSoldado.ClaseDelSoldado})");
                        buffer.AppendLine($"{bajasRealizadas} bajas confirmadas");
                        buffer.AppendLine($"{curacionesRealizadas} curaciones realizadas");
                        buffer.AppendLine($"{artefactosEncontrados} artefactos encontrados");
                        buffer.AppendLine($"{anomaliasRegistradas} anomalias encontradas");
                        buffer.AppendLine("\n");
                    }
                    MessageBox.Show($"{buffer}", "Nuestros hombres han vuelto");
                    auxEscuadron.NumeroIncursionesTotales += 1;
                    ActualizarListas();
                    ActualizarVistaSoldado();
                } else
                {
                    MessageBox.Show("El escuadrón necesita cuatro miembros para ser desplegado en la Zona");
                }
            }
        }
        /// <summary>
        /// permite modificar los atributos de un soldado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifSoldado_Click(object sender, EventArgs e)
        {
            if (lstbSoldados.SelectedItem is not null)
            {
                Soldado auxSoldado = (Soldado)lstbSoldados.SelectedItem;
                FrmModificarSoldado frmModificar = new FrmModificarSoldado(cuartel, auxSoldado);
                frmModificar.ShowDialog();
            }
            ActualizarVistaSoldado();
            ActualizarListas();

            
        }
        /// <summary>
        /// permite ver los detalles de un escuadron
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerEscuadron_Click(object sender, EventArgs e)
        {
            if (lstbEscuadrones.SelectedItem is not null)
            {
                Escuadron auxEscuadron = (Escuadron)lstbEscuadrones.SelectedItem;
                FrmVerEscuadron frmVerEscuadron = new FrmVerEscuadron(cuartel, auxEscuadron);
                frmVerEscuadron.ShowDialog();
                ActualizarListas();
                ActualizarVistaSoldado();
                lstbEscuadrones.SelectedIndex = 0;
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformes frmInforme = new FrmInformes(cuartel);
            frmInforme.ShowDialog();
        }
    }
}
