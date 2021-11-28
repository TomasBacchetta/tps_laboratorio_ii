using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Aquí se utiliza el concepto de delegados de la clase 17. Con este delegado encapsularé el evento declarado más adelante
    /// </summary>
    /// <param name="incursion"></param>
    public delegate void FinalDeIncursion(Incursion incursion);
    public class Incursion
    {
        private DateTime tiempoInicial;
        private DateTime tiempoFinal;
        private int numBajas;
        private int numCuraciones;
        private int numArtefactos;
        private int numAnomalias;
        private string locacion;
        private Escuadron escuadron;
        
        /// <summary>
        /// Aquí se utiliza el concepto de eventos de la clase 19
        /// </summary>
        public event FinalDeIncursion AvisarFinDeIncursion;

        /// <summary>
        /// Devuelve los segundos pasados entre el tiempo inicial y el final en segundos (considerados horas por el programa)
        /// </summary>
        /// 

        public DateTime TiempoInicial { get => tiempoInicial; set => tiempoInicial = value; }

        public DateTime TiempoFinal { get => tiempoFinal; set => tiempoFinal = value; }

        
       public string Locacion { get => locacion; set => locacion = value; }
        
        public Escuadron Escuadron { get => escuadron; set => escuadron = value; }


        public string NombreEscuadron { get => escuadron.Nombre.ToString(); }

        public int NumBajas { get => numBajas; set => numBajas = value; }
        public int NumAnomalias { get => numAnomalias; set => numAnomalias = value; }
        public int NumCuraciones { get => numCuraciones; set => numCuraciones = value; }
        public int NumArtefactos { get => numArtefactos; set => numArtefactos = value; }

 
        

        public Incursion(Escuadron escuadron)
        {
            this.escuadron = escuadron;
            this.TiempoInicial = DateTime.MinValue;
            this.TiempoFinal = DateTime.MaxValue;

        }

       
        public Incursion(int numIncursion, Escuadron escuadron, DateTime tiempoInicial, DateTime tiempoFinal, int numBajas, int numCuraciones, int numArtefactos, int numAnomalias, string locacion)
        {
            this.escuadron = escuadron;
            this.TiempoInicial = tiempoInicial;
            this.TiempoFinal = tiempoFinal;
            this.numBajas = numBajas;
            this.numCuraciones = numCuraciones;
            this.numArtefactos = numArtefactos;
            this.numAnomalias = numAnomalias;
            this.locacion = locacion;


        }
        /// <summary>
        /// Aquí se aplican conceptos de eventos de la clase 19, clase 18, ya que el hilo declarado en FrmCuartel va a llamar a este método, como también clase 17 ya que me valgo de la
        /// firma del delegado FinalDeIncursion establecida en este namespace Entidades
        /// Realiza una incursion, estableciendo el tiempoInicial de la incursion en el actual, haciendo que el hilo espere cierta cantidad de tiempo con EsperarTiempoDeIncursion(),
        /// y luego asigna a tiempoFinal la hora actual luego de ese momento. 
        /// </summary>
        public void RealizarIncursion()
        {
            this.TiempoInicial = DateTime.Now;
            EsperarTiempoDeIncursion();
            this.TiempoFinal = DateTime.Now;
            ///Aquí se invoca el evento AvisarFinDeIncursion, activando los métodos sucriptos, pasando como parámetro esta instancia (tal como el delegado FinalDeIncursion dictamina) 
            ///como será CargarYMostrarResultadosIncursion(Incursion incursion)
            AvisarFinDeIncursion.Invoke(this);
        }

        /// <summary>
        /// Hace que el hilo espere una cierta cantidad de segundos (para el programa son horas) dependiendo de la zona asignada a la incursion
        /// </summary>
        private void EsperarTiempoDeIncursion()
        {
            Random random = new Random();
            int duracionIncursion = 0;
            string locacionStr = this.locacion.ToString();
            switch (locacionStr)
            {
                case "Puesto de avanzada":
                    duracionIncursion = random.Next(1000, 3001);//de 1 a 3 segundos (para el programa son horas)
                    break;
                case "Aldea":
                    duracionIncursion = random.Next(5000, 8001);//de 5 a 8 segundos (para el programa son horas)
                    break;
                case "Laboratorio Subterráneo":
                    duracionIncursion = random.Next(10000, 15001);//de 10 a 15 segundos (para el programa son horas)
                    break;
                case "Granja":
                    duracionIncursion = random.Next(7000, 13001);//de 7 a 13 segundos (para el programa son horas)
                    break;
                case "Estación De Tren":
                    duracionIncursion = random.Next(9000, 13001);//de 9 a 13 segundos (para el programa son horas)
                    break;
                case "Campamento Bandido":
                    duracionIncursion = random.Next(11000, 20000);//de 11 a 20 segundos (para el programa son horas)
                    break;
            }
            Thread.Sleep(duracionIncursion);
        }
       
    }
}
