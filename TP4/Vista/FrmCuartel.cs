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
using System.Threading;

namespace Vista
{

    public partial class FrmCuartel : Form
    {
        private Cuartel cuartel;
        private string path;
        private List<Incursion> incursiones;

        public FrmCuartel()
        {
            InitializeComponent();
            this.cuartel = new Cuartel(Cuartel.CargarEscuadrones());
            ActualizarListas();
            OcultarVistaSoldado();
            lblIntegrantesEscua.Visible = false;
            path = "";
            this.incursiones = new List<Incursion>();

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

            if (soldadoARemover.Desplegado)
            {
                MessageBox.Show("El soldado no está en el cuartel. Espere a que vuelva de su misión");
            } else
            {
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
            if (auxSoldado.Desplegado || auxEscuadron.Desplegado)
            {
                MessageBox.Show("O el soldado o el escuadrón están actualmente en una misión. No se puede asignar");
            } else
            {
                try
                {
                    if (auxEscuadron + auxSoldado)
                    {
                        MessageBox.Show($"Soldado agregado a escuadrón {auxEscuadron.Nombre}");
                        ImprimirIntegrantesEscuadron();
                        ActualizarVistaSoldado();
                    }
                    else
                    {
                        MessageBox.Show($"No se pudo asignar. Recuerde que un escuadrón deberá tener cuatro miembros, y todas las clases de soldado deben estar presentes (Asalto, Médico, Técnico y Reconocimiento).");
                    }
                }
                catch (SoldadoYaEnOtroEscuadronException ex)
                {
                    MessageBox.Show(ex.Message, "Atención");
                }
                
                
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
                if (escuadraSeleccionada.Desplegado)
                {
                    buffer.AppendLine("---EN MISIÓN---");
                }
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
            if (ComprobarSiHayEscuadronesDesplegados())//esto evita que no pueda abrirse un estado donde escuadrones (y soldados) estan desplegados, evitando posibles conflictos
            {
                MessageBox.Show("Espere a que vuelvan los escuadrones desplegados antes de abrir archivos");

            } else {
                Abrir();

            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ComprobarSiHayEscuadronesDesplegados())//esto evita que no pueda guardarse un estado donde escuadrones (y soldados) estan desplegados, evitando posibles conflictos
            {
                MessageBox.Show("Espere a que vuelvan los escuadrones desplegados antes de guardar archivos");
            } else
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
            

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ComprobarSiHayEscuadronesDesplegados())//esto evita que no pueda guardarse un estado donde escuadrones (y soldados) estan desplegados, evitando posibles conflictos
            {
                MessageBox.Show("Espere a que vuelvan los escuadrones desplegados antes de guardar archivos");

            } else
            {
                GuardarComo();

            }
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

        private bool ComprobarSiHayEscuadronesDesplegados()
        {
            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                if (itemEscuadron.Desplegado)
                {
                    return true;
                }
            }
            return false;
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

            if (auxEscuadron.Desplegado)
            {
                MessageBox.Show("El escuadrón no está en el cuartel. Espere a que vuelva de la misión");
            } else
            {
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
            
        }

        /// <summary>
        /// envia a los soldados a una mision
        ///Aquí se aplican los conceptos de hilos de la clase 18 y expresiones lambda, de la clase 17, como así tambien manejo de 
        ///Eventos de la clase 19.
        ///Se instancia un nuevo hilo y se le asigna como parámetro una expresión lambda, que suplanta a un delegado de tipo Action,
        ///que recibe void, y devuelve el método que quiero que el hilo ejecute, en este el método de instancia RealizarIncursion() de
        ///la instancia nuevaIncursion (de la clase Incursion)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesplegar_Click(object sender, EventArgs e)
        {
            
            Escuadron auxEscuadron = (Escuadron)lstbEscuadrones.SelectedItem;

            if (auxEscuadron.Desplegado)
            {
                MessageBox.Show("El escuadrón no está en la base. Espere a que vuelva de su misión");
            } else
            {
                if (lstbEscuadrones.SelectedItem is not null)
                {
                    if (auxEscuadron.MiembrosEscuadron.Count == 4)
                    {
                        Incursion nuevaIncursion = new Incursion(auxEscuadron);

                        ///Aquí se está suscribiendo el método CargarYMostrarResultadosIncursion(Incursion incursion), al evento AvisarFinDeIncursion de la clase nuevaIncursion
                        nuevaIncursion.AvisarFinDeIncursion += CargarYMostrarResultadosIncursion;
                        this.incursiones.Add(nuevaIncursion);
                        FrmMapa frmMapa = new FrmMapa(nuevaIncursion);
                        frmMapa.ShowDialog();
                        ActualizarListas();
                        ActualizarVistaSoldado();
                        ///Aquí se aplican los conceptos de hilos de la clase 18 y expresiones lambda, de la clase 17 
                        ///Se instancia un nuevo hilo y se le asigna como parámetro una expresión lambda, que suplanta a un delegado de tipo Action,
                        ///que recibe void, y devuelve el método que quiero que el hilo ejecute, en este el método de instancia RealizarIncursion() de
                        ///la instancia nuevaIncursion (de la clase Incursion)
                        Task nuevoHiloIncursion = new Task(() => nuevaIncursion.RealizarIncursion());
                        nuevoHiloIncursion.Start();
                    }
                    else
                    {
                        MessageBox.Show("El escuadrón necesita cuatro miembros para poder ser desplegado en la Zona");
                    }
                }
            }
            

        }

        /// <summary>
        /// Aquí se aplican los conceptos de la clase 19 de eventos, como así también hilos de la clase 18.
        /// Este método se encarga de cargar y mostrar los datos de la incursión.
        /// Este método está suscrito al evento AvisarFinDeIncursion, por lo que al momento de ejecutar el método RealizarIncursion(),
        /// el hilo activo invoca el evento, que a su vez llama éste método.
        /// Si no fuese por ese evento, no sería posible mostrar el messagebox que muestra este método, ya que Incursion no es una clase de formulario. 
        /// En otras palabras, FrmCuartel no tendría forma de saber cuándo el hilo terminó.
        /// </summary>
        /// <param name="incursion"></param>
        private void CargarYMostrarResultadosIncursion(Incursion incursion)
        {
            if (InvokeRequired)
            {
                Action<Incursion> cargarYMostrarResultadoIncursion = CargarYMostrarResultadosIncursion;
                Invoke(cargarYMostrarResultadoIncursion, incursion);
            }
            else
            {
                StringBuilder buffer = new StringBuilder();
                Escuadron auxEscuadron = incursion.Escuadron;
                foreach (Soldado itemSoldado in auxEscuadron.MiembrosEscuadron)
                {

                    int bajasRealizadas = itemSoldado.Atacar();
                    int curacionesRealizadas = itemSoldado.Curar();
                    int artefactosEncontrados = itemSoldado.EncontrarArtefactos();
                    int anomaliasRegistradas = itemSoldado.EncontrarAnomalias();

                    incursion.NumBajas += bajasRealizadas;
                    incursion.NumCuraciones += curacionesRealizadas;
                    incursion.NumArtefactos += artefactosEncontrados;
                    incursion.NumAnomalias += anomaliasRegistradas;


                    buffer.AppendLine($"{itemSoldado.Nombre} {itemSoldado.Apellido} ({itemSoldado.ClaseDelSoldado})");
                    buffer.AppendLine($"{bajasRealizadas} bajas confirmadas");
                    buffer.AppendLine($"{curacionesRealizadas} curaciones realizadas");
                    buffer.AppendLine($"{artefactosEncontrados} artefactos encontrados");
                    buffer.AppendLine($"{anomaliasRegistradas} anomalias encontradas");
                    buffer.AppendLine("\n");
                }
                
                //establece el tiempo de llegada de la incursión, ajustando los segundos a horas
                incursion.TiempoFinal = DateTime.Now;
                //incursion.TiempoFinal = incursion.TiempoFinal.AddHours(incursion.DuracionIncursionEnSegundos);

                //creo un registro de escuadro en base a los datos de auxEscuadron que necesito guardar
                Escuadron registroEscuadron = new Escuadron(auxEscuadron.MiembrosEscuadron);
                auxEscuadron.Desplegado = false;
                ActualizarListas();
                ActualizarVistaSoldado();
                ///Aquí guarda la incursion y los nombres de los soldados del escuadrón en la base de datos, aplicando los visto en clases 15 y 16
                IncursionDB.Guardar(incursion);
                EscuadronDB.Guardar(registroEscuadron);
                MessageBox.Show($"{buffer}", $"El escuadrón {auxEscuadron.Nombre} ha vuelto");
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
                if (((Soldado)lstbSoldados.SelectedItem).Desplegado)
                {
                    MessageBox.Show("El soldado no está en el cuartel. Espere a que vuelva");
                } else
                {
                    Soldado auxSoldado = (Soldado)lstbSoldados.SelectedItem;
                    FrmModificarSoldado frmModificar = new FrmModificarSoldado(cuartel, auxSoldado);
                    frmModificar.ShowDialog();
                }
                
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

        private void incursionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncursiones frmIncursiones = new FrmIncursiones();
            frmIncursiones.ShowDialog();
        }

        private void FrmCuartel_Load(object sender, EventArgs e)
        {
            try
            {
                IncursionDB.ProbarConexion();
            }
            catch(Exception)
            {
                MessageBox.Show("Error de conexión con la base de datos. Recuerde ejecutar el script proporcionado en la carpeta de la solución, o importar en SQL Studio la base de datos. Se cerrará el programa", "Error de conexión");
                this.Close();
            }
            
        }

        private void FrmCuartel_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Si lo desea puede abrir un archivo .xml de serialización demo en la carpeta de la solución", "Bienvenido, comandante");

        }

        private void FrmCuartel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComprobarSiHayMisionesActivas())
            {
                e.Cancel = true;
                MessageBox.Show("Espere a que vuelvan todos los escuadrones para salir", "Atención");
            }
        }

        private bool ComprobarSiHayMisionesActivas()
        {
            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                if (itemEscuadron.Desplegado)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
