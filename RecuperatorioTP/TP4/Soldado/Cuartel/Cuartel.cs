using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Cuartel
    {
        private List<Soldado> listaDeSoldados;
        private List<Escuadron> listaDeEscuadrones;
        
        public List<Soldado> ListaDeSoldados
        {
            get
            {
                return this.listaDeSoldados;
            }
            set
            {
                this.listaDeSoldados = value;
            }
        }

        public List<Escuadron> ListaDeEscuadrones
        {
            get
            {
                return this.listaDeEscuadrones;
            }
            set
            {
                this.listaDeEscuadrones = value;
            }
        }

        
        public Cuartel()
        {
            listaDeSoldados = new List<Soldado>();
            listaDeEscuadrones = new List<Escuadron>(); 
           
        }

        public Cuartel(List<Escuadron> escuadrones):this()
        {
            this.listaDeEscuadrones = escuadrones;
        }

        public static List<Escuadron> CargarEscuadrones()
        {
            List<Escuadron> escuadrones = new List<Escuadron>();
            
            for (Escuadron.NombreEscuadron x = Escuadron.NombreEscuadron.ALFA; x <= Escuadron.NombreEscuadron.OMEGA; x++)
            {
                escuadrones.Add(new Escuadron(x));
            }
            
            
            return escuadrones;
        }
        /// <summary>
        /// Determian si un cuartel tiene ya un soldado en su lista de soldados
        /// </summary>
        /// <param name="cuartel">el cuartel</param>
        /// <param name="soldado">el soldado</param>
        /// <returns>true si esta, false si no</returns>
        public static bool operator ==(Cuartel cuartel, Soldado soldado)
        {
            foreach (Soldado itemSoldado in cuartel.listaDeSoldados)
            {
                if (itemSoldado == soldado)
                {
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// Deetermina si un cuartel tiene un soldado con determinado documento
        /// </summary>
        /// <param name="cuartel">el cuartel</param>
        /// <param name="documento">el documento</param>
        /// <returns>retorna true si lo encontro, false si no</returns>
        public static bool operator ==(Cuartel cuartel, string documento)
        {
            foreach (Soldado itemSoldado in cuartel.listaDeSoldados)
            {
                if (itemSoldado == documento)
                {
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// determina si no esta presente un documento en un cuartel
        /// </summary>
        /// <param name="cuartel"></param>
        /// <param name="documento"></param>
        /// <returns></returns>
        public static bool operator !=(Cuartel cuartel, string documento)
        {
            return !(cuartel == documento);

        }
        /// <summary>
        /// determina si no esta presente un soldado en un cuartel
        /// </summary>
        /// <param name="cuartel"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator !=(Cuartel cuartel, Soldado soldado)
        {
            return !(cuartel == soldado);
        }

        /// <summary>
        /// agrega un soldado a la lista de soldados del cuartel, siempre que este ya no se encuentre
        /// </summary>
        /// <param name="cuartel"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator +(Cuartel cuartel, Soldado soldado)
        {
            if (cuartel != soldado)
            {
                cuartel.listaDeSoldados.Add(soldado);
                return true;
            }
            return false;
        }
        /// <summary>
        /// elimina a un soldado del cuartel, siemrpe que este ya se encuentre
        /// </summary>
        /// <param name="cuartel"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator -(Cuartel cuartel, Soldado soldado)
        {
            if (cuartel == soldado)
            {
                cuartel.listaDeSoldados.Remove(soldado);
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Cuartel;

            if (item is null)
            {
                return false;
            }

            return this.listaDeSoldados.Equals(item.listaDeSoldados) && this.listaDeEscuadrones.Equals(item.listaDeEscuadrones);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.listaDeSoldados);
            hash.Add(this.listaDeEscuadrones);

            return hash.ToHashCode();

        }
        /// <summary>
        /// obtiene un escuadron por su nombre
        /// </summary>
        /// <param name="nombreEscuadron"></param>
        /// <returns></returns>
        public Escuadron ObtenerEscuadronPorSuNombre(Escuadron.NombreEscuadron nombreEscuadron)
        {
            foreach (Escuadron itemEscuadron in this.listaDeEscuadrones)
            {
                if (itemEscuadron == nombreEscuadron)
                {
                    return itemEscuadron;
                }

            }
            return null;
        }

       
    }
}
