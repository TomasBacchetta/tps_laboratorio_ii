using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Arma
    {
        
        public enum Tipo
        {
            Carabina,
            SubFusil,
            Ametralladora,
            Rifle,
            Pistola,
            Ninguno
        }

        private string modelo;
        private string fabricante;
        private Tipo tipo;
        private string descripcion;
        private string codigoRetrato;

        public string CodigoRetrato
        {
            get
            {
                return this.CodigoRetrato1;
            }
        }

        public string Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }

        public string Fabricante { get => fabricante; set => fabricante = value; }
        public Tipo Tipo1 { get => tipo; set => tipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string CodigoRetrato1 { get => codigoRetrato; set => codigoRetrato = value; }

        public Arma()
        {
            this.modelo = "";
            this.Fabricante = "";
            this.Tipo1 = Tipo.Ninguno;
            this.Descripcion = "";
            this.CodigoRetrato1 = "";
        }
        public Arma(string modelo, string fabricante, Tipo tipo, string descripcion, string codigoRetrato)
        {
            this.modelo = modelo;
            this.Fabricante = fabricante;
            this.Tipo1 = tipo;
            this.Descripcion = descripcion;
            this.CodigoRetrato1 = codigoRetrato;
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Tipo: {this.Tipo1}");
            buffer.AppendLine($"Modelo: {this.modelo}");
            buffer.AppendLine($"Fabricante: {this.Fabricante}");
            buffer.AppendLine($"Descripción: \n{this.Descripcion}");


            return buffer.ToString();
            
        }

    }
}
