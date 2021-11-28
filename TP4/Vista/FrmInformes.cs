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
        Dictionary<string, int[]> estadisticasDeEscuadrones;
        public FrmInformes(Cuartel cuartel)
        {
            InitializeComponent();
            this.cuartel = cuartel;
            InicializarEstadisticasEscuadrones();
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
        /// Inicializa las estadisticas de los escuadrones
        /// </summary>
        private void InicializarEstadisticasEscuadrones()
        {
            estadisticasDeEscuadrones = new Dictionary<string, int[]>();
            foreach (Escuadron itemEscuadron in cuartel.ListaDeEscuadrones)
            {
                int[] estadisticas = EscuadronDB.DevolverEstadisticasHistoricasDeEscuadron(itemEscuadron.Nombre);
                estadisticasDeEscuadrones.Add(itemEscuadron.Nombre.ToString(), estadisticas);
            }
        }

    
        /// <summary>
        /// verifica que se haya cumplido alguna mision con algun escuadron
        /// </summary>
        /// <returns></returns>
        private bool ComprobarSiHuboAlgunaIncursion()
        {
            
            foreach (KeyValuePair<string, int[]> itemEstadEscu in estadisticasDeEscuadrones)
            {
                if (itemEstadEscu.Value[4] > 0)
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
                    buffer.AppendLine($"{DeterminarArmaMasUsada()}");
                    buffer.AppendLine($"{ListarArmas()}");

                }
                
                if (ComprobarSiHuboAlgunaIncursion())
                {
                    buffer.AppendLine($"Estadísticas históricasde escuadrones: (base de datos) \n");
                    buffer.AppendLine($"{DeterminarEscuadronConMayorValorPorTipo(TipoInforme.incursiones)}");
                    buffer.AppendLine($"{DeterminarEscuadronConMayorValorPorTipo(TipoInforme.bajas)}");
                    buffer.AppendLine($"{DeterminarEscuadronConMayorValorPorTipo(TipoInforme.curaciones)}");
                    buffer.AppendLine($"{DeterminarEscuadronConMayorValorPorTipo(TipoInforme.artefactos)}");
                    buffer.AppendLine($"{DeterminarEscuadronConMayorValorPorTipo(TipoInforme.anomalias)}");
                    buffer.AppendLine($"{DeterminarQueLugarSeVisitoMasVeces()}");
                    


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
            int cantidadBajasTotales = 0;
            double promedioBajas = 0;

            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más bajas es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                cantidadBajasTotales += cuartel.ListaDeSoldados[x].CantidadBajas;

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
                    if (cantidadBajasTotales != 0)
                    {
                        promedioBajas = CalcularPromedio(itemSoldado.CantidadBajas, cantidadBajasTotales);
                    }
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} de clase {itemSoldado.ClaseDelSoldado} con {itemSoldado.CantidadBajas} bajas ({promedioBajas.RedondearValorDouble()}% del total).");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMasCuraciones()
        {
            int mayorCuracion = 0;
            int cantidadCuracionesTotales = 0;
            double promedioCuraciones = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más curaciones es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                cantidadCuracionesTotales += cuartel.ListaDeSoldados[x].CantidadCuraciones;
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
                    if (cantidadCuracionesTotales != 0)
                    {
                        promedioCuraciones = CalcularPromedio(itemSoldado.CantidadCuraciones, cantidadCuracionesTotales);
                    }
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} de clase {itemSoldado.ClaseDelSoldado} con {itemSoldado.CantidadCuraciones} curaciones ({promedioCuraciones.RedondearValorDouble()}% del total).");
                }
            }

            return buffer.ToString();
        }

        private string DeterminarSoldadoConMasArtefactos()
        {
            int mayorArtefacto = 0;
            int cantidadArtefactosTotales = 0;
            double promedioArtefactos = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más artefactos es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                cantidadArtefactosTotales += cuartel.ListaDeSoldados[x].CantidadArtefactosEncontrados;
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
                    if (cantidadArtefactosTotales != 0)
                    {
                        promedioArtefactos = CalcularPromedio(itemSoldado.CantidadArtefactosEncontrados, cantidadArtefactosTotales);
                    }
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} de clase {itemSoldado.ClaseDelSoldado} con {itemSoldado.CantidadArtefactosEncontrados} artefactos encontrados ({promedioArtefactos.RedondearValorDouble()}% del total).");
                }
            }

            return buffer.ToString();
        }
        private string DeterminarSoldadoConMasAnomaliasVistas()
        {
            int mayorAnomalia = 0;
            int cantidadAnomalias = 0;
            double promedioAnomalias = 0;
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"El/los soldado/s con más anomalias vistas es/son: ");
            for (int x = 0; x < cuartel.ListaDeSoldados.Count; x++)
            {
                cantidadAnomalias += cuartel.ListaDeSoldados[x].CantidadAnomaliasEncontradas;
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
                    if (cantidadAnomalias != 0)
                    {
                        promedioAnomalias = CalcularPromedio(itemSoldado.CantidadAnomaliasEncontradas, cantidadAnomalias);
                    }
                    buffer.AppendLine($"{itemSoldado.NombreYApellido} de clase {itemSoldado.ClaseDelSoldado} con {itemSoldado.CantidadAnomaliasEncontradas} anomalias vistas ({promedioAnomalias.RedondearValorDouble()}% del total).");
                }
            }

            return buffer.ToString();
        }
        /// <summary>
        /// determina que arma fue más elegida por los soldados
        /// </summary>
        /// <returns></returns>
        public string DeterminarArmaMasUsada()
        {
            Dictionary<string, int> cantidadPorArma = new Dictionary<string, int>();
            StringBuilder bufferArma = new StringBuilder();
            int mayor = 0;
            double promedioUsoDeArma = 0;

            bufferArma.AppendLine("El/las armas más utilizada/s es/son: ");

            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {
                if (cantidadPorArma.ContainsKey(itemSoldado.Arma.Modelo))
                {
                    cantidadPorArma[itemSoldado.Arma.Modelo]++;
                } else
                {
                    cantidadPorArma.Add(itemSoldado.Arma.Modelo, 1);
                }
            }

            foreach (KeyValuePair<string, int> itemCantArma in cantidadPorArma)
            {
                if (itemCantArma.Value >= mayor)
                {
                    mayor = itemCantArma.Value;
                }
            }

            foreach (KeyValuePair<string, int> itemCantArma in cantidadPorArma)
            {
                if (itemCantArma.Value >= mayor)
                {
                    if (cuartel.ListaDeSoldados.Count > 0)
                    {
                        promedioUsoDeArma = CalcularPromedio(itemCantArma.Value, cuartel.ListaDeSoldados.Count);
                    }
                    bufferArma.AppendLine($"{itemCantArma.Key}, utilizada por {itemCantArma.Value} soldados ({promedioUsoDeArma}% del total)");
                }
            }

            return bufferArma.ToString();
        }

        public string ListarArmas()
        {
            Dictionary<Arma, int[]> armas = new Dictionary<Arma, int[]>();
            StringBuilder buffer = new StringBuilder();
            int bajasTotales = 0;
            int curacionesTotales = 0;
            int artefactosTotales = 0;
            int anomaliasTotales = 0;
            int[] bajasTotalesPorClase = new int[] {0,0,0,0}; //asalto/medico/tecnico/recon
            int[] curacionesTotalesPorClase = new int[] {0,0,0,0}; //asalto/medico/tecnico/recon
            int[] artefactosTotalesPorClase = new int[] {0,0,0,0}; //asalto/medico/tecnico/recon
            int[] anomaliasTotalesPorClase = new int[] {0,0,0,0}; //asalto/medico/tecnico/recon
            double promedioBajasTotales = 0;
            double promedioCuracionesTotales = 0;
            double promedioArtefactosTotales = 0;
            double promedioAnomaliasTotales = 0;
            double promedioBajasPorClase = 0;
            double promedioCuracionesPorClase = 0;
            double promedioArtefactosPorClase = 0;
            double promedioAnomaliasPorClase = 0;

            buffer.AppendLine("LISTADO DE ARMAS: \n");
            foreach (Soldado itemSoldado in cuartel.ListaDeSoldados)
            {
                if (armas.ContainsKey(itemSoldado.Arma))
                {
                    armas[itemSoldado.Arma][0] += itemSoldado.CantidadBajas;
                    armas[itemSoldado.Arma][1] += itemSoldado.CantidadCuraciones;
                    armas[itemSoldado.Arma][2] += itemSoldado.CantidadArtefactosEncontrados;
                    armas[itemSoldado.Arma][3] += itemSoldado.CantidadAnomaliasEncontradas;
                } else
                {
                    armas.Add(itemSoldado.Arma, new int[] {itemSoldado.CantidadBajas,
                            itemSoldado.CantidadCuraciones,
                            itemSoldado.CantidadArtefactosEncontrados,
                            itemSoldado.CantidadAnomaliasEncontradas});
                }
                bajasTotales += itemSoldado.CantidadBajas;
                curacionesTotales += itemSoldado.CantidadCuraciones;
                artefactosTotales += itemSoldado.CantidadArtefactosEncontrados;
                anomaliasTotales += itemSoldado.CantidadAnomaliasEncontradas;

                bajasTotalesPorClase[(int)itemSoldado.ClaseDelSoldado] += itemSoldado.CantidadBajas;
                curacionesTotalesPorClase[(int)itemSoldado.ClaseDelSoldado] += itemSoldado.CantidadCuraciones;
                artefactosTotalesPorClase[(int)itemSoldado.ClaseDelSoldado] += itemSoldado.CantidadAnomaliasEncontradas;
                anomaliasTotalesPorClase[(int)itemSoldado.ClaseDelSoldado] += itemSoldado.CantidadAnomaliasEncontradas;
                   
            }

            

            foreach (KeyValuePair<Arma, int[]> itemArma in armas)
            {
               
                promedioBajasTotales = CalcularPromedio(itemArma.Value[0], bajasTotales);
                promedioCuracionesTotales = CalcularPromedio(itemArma.Value[1], curacionesTotales);
                promedioArtefactosTotales = CalcularPromedio(itemArma.Value[2], artefactosTotales);
                promedioAnomaliasTotales = CalcularPromedio(itemArma.Value[3], anomaliasTotales);

                promedioBajasPorClase = CalcularPromedio(itemArma.Value[0], bajasTotalesPorClase[(int)itemArma.Key.RetornarClaseDeSoldadoParaEstaArma()]);
                promedioCuracionesPorClase = CalcularPromedio(itemArma.Value[1], curacionesTotalesPorClase[(int)itemArma.Key.RetornarClaseDeSoldadoParaEstaArma()]);
                promedioArtefactosPorClase = CalcularPromedio(itemArma.Value[2], artefactosTotalesPorClase[(int)itemArma.Key.RetornarClaseDeSoldadoParaEstaArma()]);
                promedioAnomaliasPorClase = CalcularPromedio(itemArma.Value[3], anomaliasTotalesPorClase[(int)itemArma.Key.RetornarClaseDeSoldadoParaEstaArma()]);
                

                buffer.AppendLine($"{itemArma.Key.Fabricante.ToUpper()} {itemArma.Key.Modelo.ToUpper()}: \n");
                buffer.AppendLine($"Bajas de esta arma: {itemArma.Value[0]}");
                buffer.AppendLine($"{promedioBajasPorClase}% de las bajas totales de los soldados de clase {itemArma.Key.RetornarClaseDeSoldadoParaEstaArma().ToString()}");
                buffer.AppendLine($"{promedioBajasTotales}% de las bajas totales");
                buffer.AppendLine($"Curaciones hechas portando esta arma: {itemArma.Value[1]}");
                buffer.AppendLine($"{promedioCuracionesPorClase}% de las curaciones totales de los soldados de clase {itemArma.Key.RetornarClaseDeSoldadoParaEstaArma().ToString()}");
                buffer.AppendLine($"{promedioCuracionesTotales}% de las bajas totales");
                buffer.AppendLine($"Artefactos encontrados portando esta arma: {itemArma.Value[2]}");
                buffer.AppendLine($"{promedioArtefactosPorClase}% de los artefactos totales de los soldados de clase {itemArma.Key.RetornarClaseDeSoldadoParaEstaArma().ToString()}");
                buffer.AppendLine($"{promedioArtefactosTotales}% de las bajas totales");
                buffer.AppendLine($"Anomalías encontradas portando esta arma: {itemArma.Value[3]}");
                buffer.AppendLine($"{promedioAnomaliasPorClase}% de las anomalias totales de los soldados de clase {itemArma.Key.RetornarClaseDeSoldadoParaEstaArma().ToString()}");
                buffer.AppendLine($"{promedioAnomaliasTotales}% de las bajas totales");

                buffer.AppendLine($"--------\n");
            }

            return buffer.ToString();
        }

        //

        public enum TipoInforme
        {
            bajas,
            curaciones,
            artefactos,
            anomalias,
            incursiones
        }

        /// <summary>
        /// Determina el escuadron con mayor valor historico, depediendo del tipo de valor que recibe como parametro
        /// </summary>
        /// <param name="tipo">el tipo de consulta a realizar</param>
        /// <returns>retorna el string con el escuadron con más de dicho valor, mas su valor</returns>
        private string DeterminarEscuadronConMayorValorPorTipo(TipoInforme tipo)
        {
            int valorMayor = 0;
            StringBuilder bufferNombreMayor = new StringBuilder();

            bufferNombreMayor.AppendLine($"El/los escuadron/es con más {tipo.ToString()} es/son: ");

            foreach (KeyValuePair<string, int[]> itemEstadEscua in estadisticasDeEscuadrones)
            {
                if (itemEstadEscua.Value[(int)tipo] >= valorMayor)
                {
                    valorMayor = itemEstadEscua.Value[(int)tipo];
                }
            }
            foreach (KeyValuePair<string, int[]> itemEstadEscua in estadisticasDeEscuadrones)
            {
                if (itemEstadEscua.Value[(int)tipo] >= valorMayor)
                {
                    bufferNombreMayor.AppendLine($"{itemEstadEscua.Key}, con {valorMayor} {tipo.ToString()}");
                }
            }

            return bufferNombreMayor.ToString();
        }

        /// <summary>
        /// Determina que lugar se visitó más veces en misiones
        /// </summary>
        /// <returns>retorna el string con el lugar más veces visitado, y la cantidad de veces que fue visitado</returns>
        private string DeterminarQueLugarSeVisitoMasVeces()
        {
            StringBuilder bufferLugares = new StringBuilder();
            Dictionary<string, int> cantidadVecesPorLugar = IncursionDB.DevolverCantidadDeVecesQueAparecenLosLugares();
            int mayor = 0;
            bufferLugares.AppendLine($"El/los lugar/es más visitado/s fue/fueron: ");

            foreach (KeyValuePair<string, int> itemDiccionario in cantidadVecesPorLugar)
            {
                if (itemDiccionario.Value >= mayor)
                {
                    mayor = itemDiccionario.Value;
                }
            }

            foreach (KeyValuePair<string, int> itemDiccionario in cantidadVecesPorLugar)
            {
                if (itemDiccionario.Value >= mayor)
                {
                    bufferLugares.AppendLine($"{itemDiccionario.Key.Trim()}, con {mayor} visitas");
                }
            }

            return bufferLugares.ToString();


        }

        private double CalcularPromedio(int num1, int num2)
        {
            double promedio = 0;
            if (num2 != 0)
            {
                promedio = (((double)num1 / (double)num2) * 100).RedondearValorDouble();
            }
            return promedio;
        }


    }

}

 
   

