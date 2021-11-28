using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegistroIncursion
    {
        private int numIncursion;
        private DateTime tiempoInicial;
        private DateTime tiempoFinal;
 
        private int numBajas;
        private int numCuraciones;
        private int numArtefactos;
        private int numAnomalias;
        private string locacion;
        private string nombreEscuadron;
        private string soldadoAsalto;
        private string soldadoMedico;
        private string soldadoTecnico;
        private string soldadoReconocimiento;

        public int NumIncursion { get => numIncursion; set => numIncursion = value; }
        public DateTime TiempoInicial { get => tiempoInicial; set => tiempoInicial = value; }
        public DateTime TiempoFinal { get => tiempoFinal; set => tiempoFinal = value; }
        public double Duracion
        {
            get
            {
                return this.tiempoFinal.CalcularDuracionEnHoras(tiempoInicial).RedondearValorDouble();//aquí se aplican dos métodos de extensión (Clase 20)
            }
        }
        public int NumBajas { get => numBajas; set => numBajas = value; }
        public int NumCuraciones { get => numCuraciones; set => numCuraciones = value; }
        public int NumArtefactos { get => numArtefactos; set => numArtefactos = value; }
        public int NumAnomalias { get => numAnomalias; set => numAnomalias = value; }
        public string Locacion { get => locacion; set => locacion = value; }
        public string NombreEscuadron { get => nombreEscuadron; set => nombreEscuadron = value; }
        public string SoldadoAsalto { get => soldadoAsalto; set => soldadoAsalto = value; }
        public string SoldadoMedico { get => soldadoMedico; set => soldadoMedico = value; }
        public string SoldadoTecnico { get => soldadoTecnico; set => soldadoTecnico = value; }
        public string SoldadoReconocimiento { get => soldadoReconocimiento; set => soldadoReconocimiento = value; }

        public RegistroIncursion(int numIncursion, DateTime tiempoInicial, DateTime tiempoFinal, int numBajas, int numCuraciones, int numArtefactos, int numAnomalias, string locacion, string nombreEscuadron, string soldadoAsalto, string soldadoMedico, string soldadoTecnico, string soldadoReconocimiento)
        {
            this.numIncursion = numIncursion;
            this.tiempoInicial = tiempoInicial;
            this.tiempoFinal = tiempoFinal.AddHours(tiempoFinal.CalcularDuracionEnSegundos(tiempoInicial));//aquí se aplica el método de extensión (Clase 20)
            this.numBajas = numBajas;
            this.numCuraciones = numCuraciones;
            this.numArtefactos = numArtefactos;
            this.numAnomalias = numAnomalias;
            this.locacion = locacion;
            this.nombreEscuadron = nombreEscuadron;
            this.soldadoAsalto = soldadoAsalto;
            this.soldadoMedico = soldadoMedico;
            this.soldadoTecnico = soldadoTecnico;
            this.soldadoReconocimiento = soldadoReconocimiento;

        }
    }
}
