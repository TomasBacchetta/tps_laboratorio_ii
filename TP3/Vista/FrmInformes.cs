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
    public partial class FrmInformes : Form
    {
        Cuartel cuartel;
        public FrmInformes(Cuartel cuartel)
        {
            InitializeComponent();
            this.cuartel = cuartel;
            ImprimirInforme();
        }
        /// <summary>
        /// guarda el informe en txt en alguna ruta determinada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarInforme_Click(object sender, EventArgs e)
        {

            SaveFileDialog ventanaGuardar = new SaveFileDialog();
            ventanaGuardar.Filter = "Archivos txt (*.txt)|*.txt";
            ventanaGuardar.ShowDialog();
            string path = ventanaGuardar.FileName;


            /// <summary>
            /// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, como también la teoría de la clase 14, Archivos y serialización
            /// </summary>
            ArchivoTxt archivoTxtAGuardar = new ArchivoTxt();
            try
            {
                archivoTxtAGuardar.GuardarComo(rtbInforme.Text, path);
            }
            catch (ErrorDeArchivoExcepcion ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (path != "")
                {
                    MessageBox.Show("Se guardó el archivo", "Informe guardado");
                }
                else
                {
                    MessageBox.Show("Error al guardar", "Error de archivo");
                }
            }
            
   
        }

    
        /// <summary>
        /// verifica que se haya cumplido alguna mision con algun escuadron
        /// </summary>
        /// <returns></returns>
        private bool ComprobarSiHuboAlgunaIncursion()
        {
            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                if (itemEscuadron.NumeroIncursionesTotales > 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// imprimie el informe en el richtextbox
        /// </summary>
        private void ImprimirInforme()
        {
            StringBuilder buffer = new StringBuilder();

            if (!ComprobarSiHuboAlgunaIncursion() && cuartel.ListaDeSoldados.Count == 0)
            {
                rtbInforme.Text = "Sin información que mostrar";
            } else
            {
                if (cuartel.ListaDeSoldados.Count > 0)
                {
                    buffer.AppendLine($"{DeterminarSoldadoConMayorEdad()}");
                    buffer.AppendLine($"{DeterminarSoldadoConMenorEdad()}");
                    buffer.AppendLine($"{DeterminarSoldadoConMasBajas()}");
                    buffer.AppendLine($"{DeterminarSoldadoConMasCuraciones()}");
                    buffer.AppendLine($"{DeterminarSoldadoConMasArtefactos()}");
                    buffer.AppendLine($"{DeterminarSoldadoConMasAnomaliasVistas()}");

                }
                if (ComprobarSiHuboAlgunaIncursion())
                {
                    buffer.AppendLine($"\n{DeterminarEscuadronConMasBajas()}");
                    buffer.AppendLine($"{DeterminarEscuadronConMasCuraciones()}");
                    buffer.AppendLine($"{DeterminarEscuadronConMasArtefactos()}");
                    buffer.AppendLine($"{DeterminarEscuadronConMasAnomalias()}");
                }

                rtbInforme.Text = buffer.ToString();
            }
        }
       
        private string DeterminarSoldadoConMayorEdad()
        {
            int mayorEdad = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con mayor edad es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                int edadDelSoldado = int.Parse(cuartel.ListaDeSoldados[x].Edad);
                if (x == 0)
                {
                    mayorEdad = edadDelSoldado;
                } else
                {
                    if (edadDelSoldado >= mayorEdad)
                    {
                        mayorEdad = edadDelSoldado;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {
                int edad = int.Parse(itemSoldado.Edad);
                if (edad >= mayorEdad)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {edad} años.");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMenorEdad()
        {
            int menorEdad = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con menor edad es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                int edadDelSoldado = int.Parse(cuartel.ListaDeSoldados[x].Edad);
                if (x == 0)
                {
                    menorEdad = edadDelSoldado;
                }
                else
                {
                    if (edadDelSoldado <= menorEdad)
                    {
                        menorEdad = edadDelSoldado;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {
                int edad = int.Parse(itemSoldado.Edad);
                if (edad <= menorEdad)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {edad} años.");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMasBajas()
        {
            int mayorBaja = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más bajas es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                if (x == 0)
                {
                    mayorBaja = cuartel.ListaDeSoldados[x].CantidadBajas;
                }
                else
                {
                    if (cuartel.ListaDeSoldados[x].CantidadBajas >= mayorBaja)
                    {
                        mayorBaja = cuartel.ListaDeSoldados[x].CantidadBajas;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {
                
                if (itemSoldado.CantidadBajas >= mayorBaja)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {itemSoldado.CantidadBajas} bajas.");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMasCuraciones()
        {
            int mayorCuracion = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más curaciones es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                if (x == 0)
                {
                    mayorCuracion = cuartel.ListaDeSoldados[x].CantidadCuraciones;
                }
                else
                {
                    if (cuartel.ListaDeSoldados[x].CantidadCuraciones >= mayorCuracion)
                    {
                        mayorCuracion = cuartel.ListaDeSoldados[x].CantidadCuraciones;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {

                if (itemSoldado.CantidadCuraciones >= mayorCuracion)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {itemSoldado.CantidadCuraciones} curaciones.");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMasArtefactos()
        {
            int mayorArtefacto = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más artefactos es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                if (x == 0)
                {
                    mayorArtefacto = cuartel.ListaDeSoldados[x].CantidadArtefactosEncontrados;
                }
                else
                {
                    if (cuartel.ListaDeSoldados[x].CantidadArtefactosEncontrados >= mayorArtefacto)
                    {
                        mayorArtefacto = cuartel.ListaDeSoldados[x].CantidadArtefactosEncontrados;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {

                if (itemSoldado.CantidadArtefactosEncontrados >= mayorArtefacto)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {itemSoldado.CantidadArtefactosEncontrados} artefactos encontrados.");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarSoldadoConMasAnomaliasVistas()
        {
            int mayorAnomalia = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más anomalias vistas es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                if (x == 0)
                {
                    mayorAnomalia = cuartel.ListaDeSoldados[x].CantidadAnomaliasEncontradas;
                }
                else
                {
                    if (cuartel.ListaDeSoldados[x].CantidadAnomaliasEncontradas >= mayorAnomalia)
                    {
                        mayorAnomalia = cuartel.ListaDeSoldados[x].CantidadAnomaliasEncontradas;
                    }
                }

            }

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {

                if (itemSoldado.CantidadAnomaliasEncontradas >= mayorAnomalia)
                {
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} con {itemSoldado.CantidadAnomaliasEncontradas} anomalias vistas.");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarEscuadronConMasBajas()
        {
            int mayorBaja = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los escuadron/es con más bajas es/son: ");
            for (int x = 0; x < cuartel.ListaDeEscuadrones.Count; x++)
            {
                if (x == 0)
                {
                    mayorBaja = cuartel.ListaDeEscuadrones[x].NumeroDeBajasTotales;
                }
                else
                {
                    if (cuartel.ListaDeEscuadrones[x].NumeroDeBajasTotales >= mayorBaja)
                    {
                        mayorBaja = cuartel.ListaDeEscuadrones[x].NumeroDeBajasTotales;
                    }
                }

            }

            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {

                if (itemEscuadron.NumeroDeBajasTotales >= mayorBaja)
                {
                    buffer.AppendLine($"{itemEscuadron.Nombre} con {itemEscuadron.NumeroDeBajasTotales} bajas.");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarEscuadronConMasCuraciones()
        {
            int mayorCuracion = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los escuadron/es con más curaciones es/son: ");
            for (int x = 0; x < cuartel.ListaDeEscuadrones.Count; x++)
            {
                if (x == 0)
                {
                    mayorCuracion = cuartel.ListaDeEscuadrones[x].NumeroDeCuracionesTotales;
                }
                else
                {
                    if (cuartel.ListaDeEscuadrones[x].NumeroDeCuracionesTotales >= mayorCuracion)
                    {
                        mayorCuracion = cuartel.ListaDeEscuadrones[x].NumeroDeCuracionesTotales;
                    }
                }

            }

            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {

                if (itemEscuadron.NumeroDeCuracionesTotales >= mayorCuracion)
                {
                    buffer.AppendLine($"{itemEscuadron.Nombre} con {itemEscuadron.NumeroDeCuracionesTotales} curaciones.");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarEscuadronConMasArtefactos()
        {
            int mayorArtefacto = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los escuadron/es con más artefactos es/son: ");
            for (int x = 0; x < cuartel.ListaDeEscuadrones.Count; x++)
            {
                if (x == 0)
                {
                    mayorArtefacto = cuartel.ListaDeEscuadrones[x].NumeroDeArtefactosObtenidosTotales;
                }
                else
                {
                    if (cuartel.ListaDeEscuadrones[x].NumeroDeArtefactosObtenidosTotales >= mayorArtefacto)
                    {
                        mayorArtefacto = cuartel.ListaDeEscuadrones[x].NumeroDeArtefactosObtenidosTotales;
                    }
                }

            }

            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {

                if (itemEscuadron.NumeroDeArtefactosObtenidosTotales >= mayorArtefacto)
                {
                    buffer.AppendLine($"{itemEscuadron.Nombre} con {itemEscuadron.NumeroDeArtefactosObtenidosTotales} artefactos.");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarEscuadronConMasAnomalias()
        {
            int mayorAnomalia = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los escuadron/es con más anomalias vistas es/son: ");
            for (int x = 0; x < cuartel.ListaDeEscuadrones.Count; x++)
            {
                if (x == 0)
                {
                    mayorAnomalia = cuartel.ListaDeEscuadrones[x].NumeroDeAnomaliasVistas;
                }
                else
                {
                    if (cuartel.ListaDeEscuadrones[x].NumeroDeAnomaliasVistas >= mayorAnomalia)
                    {
                        mayorAnomalia = cuartel.ListaDeEscuadrones[x].NumeroDeAnomaliasVistas;
                    }
                }

            }

            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {

                if (itemEscuadron.NumeroDeAnomaliasVistas >= mayorAnomalia)
                {
                    buffer.AppendLine($"{itemEscuadron.Nombre} con {itemEscuadron.NumeroDeAnomaliasVistas} anomalías.");
                }
            }

            return buffer.ToString();
        }
    }
}
