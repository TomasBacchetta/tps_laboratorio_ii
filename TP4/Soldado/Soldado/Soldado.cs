using System;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    
    public class Soldado 
    {

        public enum Rango
        {
            Cabo,
            Sargento,
            Subteniente,
            Teniente,
            Capitan
        }

        public enum Estado
        {
            Vivo,
            Muerto
        }

        public enum ClaseSoldado
        {
            Asalto,
            Medico,
            Tecnico,
            Reconocimiento
        }

        private DateTime fechaDeNacimiento;
        private string nombre;
        private string apellido;
        private string documento;
        private int cantidadBajas;
        private int cantidadCuraciones;
        private int cantidadArtefactosEncontrados;
        private int cantidadAnomaliasEncontradas;
        private Rango rangoSoldado;
        private Arma arma;
        private int codigoRetrato;
        private Escuadron.NombreEscuadron escuadronAsignado;
        private ClaseSoldado claseDelSoldado;
        private bool desplegado;

        public bool Desplegado
        {
            get
            {
                return this.desplegado;
            }
            set
            {
                this.desplegado = value;
            }
        }

        public int CantidadBajas { get => cantidadBajas; set => cantidadBajas = value; }
        public int CantidadCuraciones { get => cantidadCuraciones; set => cantidadCuraciones = value; }
        public int CantidadArtefactosEncontrados { get => cantidadArtefactosEncontrados; set => cantidadArtefactosEncontrados = value; }
        public int CantidadAnomaliasEncontradas { get => cantidadAnomaliasEncontradas; set => cantidadAnomaliasEncontradas = value; }
        public Escuadron.NombreEscuadron EscuadronAsignado
        {
            get
            {
                return this.escuadronAsignado;
            }
            set
            {
                this.escuadronAsignado = value;
            }
        }
        public int CodigoRetrato
        {
            get
            {
                return this.codigoRetrato;
            }
            set
            {
                this.codigoRetrato = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string Documento
        {
            get
            {
                return this.documento;
            }
            set
            {
                this.documento = value;
            }
        }
        public Arma Arma
        {
            get
            {
                return this.arma;
            }
            set
            {
                this.arma = value;
            }
        }

        public ClaseSoldado ClaseDelSoldado
        {
            get
            {
                return this.claseDelSoldado;
            }
            set
            {
                this.claseDelSoldado = value;
            }
        }
        public DateTime FechaDeNacimiento
        {
            get
            {
                return this.fechaDeNacimiento;
            }
            set
            {
                this.fechaDeNacimiento = value;
            }

        }

        public Rango RangoSoldado
        {
            get
            {
                return this.rangoSoldado;
            }
            set
            {
                this.rangoSoldado = value;
            }
        }
        public Soldado()
        {
            this.desplegado = false;

        }


        public Soldado(DateTime fechaDeNacimiento, string nombre, string apellido, string documento, Rango rangoSoldado, ClaseSoldado claseDelSoldado)
        {
            Random codigoRetRnd = new Random();
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.CantidadBajas = 0;
            this.CantidadCuraciones = 0;
            this.CantidadArtefactosEncontrados = 0;
            this.CantidadAnomaliasEncontradas = 0;
            this.rangoSoldado = rangoSoldado;
            this.arma = null;
            this.codigoRetrato = codigoRetRnd.Next(1, 30);
            this.escuadronAsignado = Escuadron.NombreEscuadron.Ninguno;
            this.claseDelSoldado = claseDelSoldado;
            this.desplegado = false;

        }
        
        public string NombreYApellido
        {
            get
            {
                return $"{this.nombre} {this.apellido}";
            }
        }

        
        public string Edad
        {
            get
            {
                return Tiempo.CalcularTiempoPasadoEnAños(this.fechaDeNacimiento, DateTime.Now);
            }

        }

        public int Atacar()
        {
            int valorMinimo = 0;
            int valorMaximo = 2;
            

            Random bajas = new Random();

            if (this.ClaseDelSoldado == ClaseSoldado.Asalto)
            {
                valorMinimo +=  ((int)this.rangoSoldado + 1);
                valorMaximo +=  ((int)this.rangoSoldado + 1) + ((int)this.rangoSoldado);
            }
            int bajasNuevas = bajas.Next(valorMinimo, valorMaximo+1);
            this.cantidadBajas += bajasNuevas;

            return bajasNuevas;
        }
        public int Curar()
        {
            int valorMinimo = 0;
            int valorMaximo = 2;
            
            Random curaciones = new Random();

            if (this.ClaseDelSoldado == ClaseSoldado.Medico)
            {
                valorMinimo += ((int)this.RangoSoldado + 1);
                valorMaximo += ((int)this.RangoSoldado + 1) + ((int)this.rangoSoldado);
            }

            int curacionesNuevas = curaciones.Next(valorMinimo, valorMaximo+1);
            this.cantidadCuraciones += curacionesNuevas;



            return curacionesNuevas;
        }
        public int EncontrarArtefactos()
        {
            int valorMinimo = 0;
            int valorMaximo = 3;

            Random artefactos = new Random();

            if (this.ClaseDelSoldado == ClaseSoldado.Tecnico)
            {
                valorMinimo += ((int)this.RangoSoldado + 1);
                valorMaximo += ((int)this.RangoSoldado + 1) + ((int)this.rangoSoldado);
            }
            int artefactosNuevos = artefactos.Next(valorMinimo, valorMaximo+1);
            this.cantidadArtefactosEncontrados += artefactosNuevos;

            return artefactosNuevos;
        }
        public int EncontrarAnomalias()
        {
            int valorMinimo = 0;
            int valorMaximo = 5;

            Random anomalias = new Random();

            if (this.ClaseDelSoldado == ClaseSoldado.Reconocimiento)
            {
                valorMinimo += ((int)this.RangoSoldado + 1);
                valorMaximo += ((int)this.RangoSoldado + 1) + ((int)this.rangoSoldado);
            }

            int anomaliasNuevas = anomalias.Next(valorMinimo, valorMaximo+1);
            this.cantidadAnomaliasEncontradas += anomaliasNuevas;

            return anomaliasNuevas;
        }

        public string MostrarSoldado()
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine($"Nombre: {this.nombre}");
            buffer.AppendLine($"Apellido: {this.apellido}");
            buffer.AppendLine($"Documento: {this.documento}");
            buffer.AppendLine($"Edad: {this.Edad} años");
            buffer.AppendLine($"Clase: {this.claseDelSoldado}");
            buffer.AppendLine($"Rango: {this.rangoSoldado}");
            buffer.AppendLine($"Cantidad de bajas: {this.CantidadBajas}");
            buffer.AppendLine($"Cantidad de curaciones: {this.cantidadCuraciones}");
            buffer.AppendLine($"Cantidad de artefactos encontrados: {this.cantidadArtefactosEncontrados}");
            buffer.AppendLine($"Cantidad de anomalías vistas: {this.cantidadAnomaliasEncontradas}");
            buffer.AppendLine($"Armamento: {this.arma.Modelo}");
            buffer.AppendLine($"Asignado a escuadrón: {this.escuadronAsignado}");
            if (this.desplegado)
            {
                buffer.AppendLine("-----EN MISIÓN-----");
            }

            return $"{buffer}";
        }

        public override string ToString()
        {
            return MostrarSoldado();
        }
        /// <summary>
        /// determina que dos soldados sean iguales, en base a sus documentos
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator ==(Soldado s1, Soldado s2)
        {
            if (s1 is not null && s2 is not null)
            {
                if (s1.documento == s2.documento)
                {
                    return true;
                }

            }
            
            return false;
        }
        /// <summary>
        /// determina que un numero de documento corresponda al de un soldado
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="documento"></param>
        /// <returns></returns>
        public static bool operator ==(Soldado s1, string documento)
        {
            if (s1 is not null)
            {
                if (s1.documento == documento)
                {
                    return true;
                }

            }

            return false;
        }

        public static bool operator !=(Soldado s1, string documento)
        {
            return !(s1 == documento);
        }


        /// <summary>
        /// Determina si dos soldados son del mismo tipo
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator |(Soldado s1, Soldado s2)
        {
            if (s1.ClaseDelSoldado == s2.ClaseDelSoldado)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// determina que dos soldados no sean iguales
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator !=(Soldado s1, Soldado s2)
        {
            return !(s1 == s2);
        }

        public override bool Equals(object obj)
        {
            var item = obj as Soldado;

            if (item is null)
            {
                return false;
            }

            return this.documento.Equals(item.documento);
        }
        
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(documento);
            
            return hash.ToHashCode();
           
        }
        
        
    }
}
