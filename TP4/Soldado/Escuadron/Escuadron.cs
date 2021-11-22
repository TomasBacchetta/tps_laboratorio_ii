using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Escuadron
    {
        private List<Soldado> miembrosEscuadron;
        private NombreEscuadron nombre;
        private bool desplegado;


        
        public enum NombreEscuadron {  
    
            Ninguno,
            ALFA,     
            BETA ,     
            GAMMA,            
            DELTA,           
            EPSILON,          
            LAMBDA,        
            TAU,
            SIGMA,
            OMEGA
              
        }

        /// <summary>
        /// esta propiedad y atributo va a ser utilizada a la hora de crear registros de escuadrones, pero no para los escuadrones activos del cuartel
        /// </summary>
     
        public bool Desplegado
        {
            get
            {
                return this.desplegado;
            }
            set
            {
                foreach (Soldado itemSoldado in this.miembrosEscuadron)
                {
                    itemSoldado.Desplegado = value;
                }
                this.desplegado = value;
                
                
            }
        }

        public NombreEscuadron Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        

        public List<Soldado> MiembrosEscuadron
        {
            get
            {
                return this.miembrosEscuadron;
            }
            set
            {
                this.miembrosEscuadron = value;
            }
        }

        public Escuadron()
        {
            this.MiembrosEscuadron = new List<Soldado>();
            this.desplegado = false;

        }
        public Escuadron(NombreEscuadron nombreEscuadron):this()
        {

            this.nombre = nombreEscuadron;
            this.desplegado = false;
        }

        /// <summary>
        /// Este constructor se usa para registros de escuadrones, donde solo preciso el nombre y los soldados
        /// </summary>
        /// <param name="nombreEscuadron"></param>
        /// <param name="listaSoldados"></param>
        public Escuadron(List<Soldado> listaSoldados)
        {
            this.miembrosEscuadron = listaSoldados;
        }

        /// <summary>
        /// Determina si ya esta presente un soldado en un escuadron, o si ya esta presente una clase de soldado en ese escuadron
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator ==(Escuadron escuadron, Soldado soldado)
        {
            if (escuadron.MiembrosEscuadron is not null)
            {
                foreach (Soldado item in escuadron.MiembrosEscuadron)
                {
                    if (item == soldado || item | soldado)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        /// <summary>
        /// determina si el nombre de un escuadron corresponde con el de otro escuadron
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="nombreEscuadron"></param>
        /// <returns></returns>
        public static bool operator ==(Escuadron escuadron, NombreEscuadron nombreEscuadron)
        {
            if (escuadron.nombre == nombreEscuadron)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// determina si un nombre de escuadron no corresponde con el nombre de otro escuadron
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="nombreEscuadron"></param>
        /// <returns></returns>
        public static bool operator !=(Escuadron escuadron, NombreEscuadron nombreEscuadron)
        {
            return !(escuadron == nombreEscuadron);
        }
        /// <summary>
        /// determina si no esta presente un soldado en un escuadron
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator !=(Escuadron escuadron, Soldado soldado)
        {
            return !(escuadron == soldado);
        }

        /// <summary>
        /// agrega un soldado al escuadron
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator +(Escuadron escuadron, Soldado soldado)
        {
            if (soldado is not null && escuadron != soldado && soldado.EscuadronAsignado == NombreEscuadron.Ninguno)
            {
                soldado.EscuadronAsignado = escuadron.nombre;
                escuadron.MiembrosEscuadron.Add(soldado);
                return true;
            }
            return false;
        }
        /// <summary>
        /// elimina a un soldado de un escuadron, siempre que este presente
        /// </summary>
        /// <param name="escuadron"></param>
        /// <param name="soldado"></param>
        /// <returns></returns>
        public static bool operator -(Escuadron escuadron, Soldado soldado)
        {
            if (escuadron == soldado && escuadron is not null)
            {
                soldado.EscuadronAsignado = NombreEscuadron.Ninguno;
                escuadron.miembrosEscuadron.Remove(soldado);
                return true;
            }
            return false;
        }
        
        public override bool Equals(object obj)
        {
            var item = obj as Escuadron;

            if (item is null)
            {
                return false;
            }

            return this.nombre.Equals(item.nombre);

        }
        
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.nombre);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Devuelve el miembro del escuadron que sea de la clase especificada
        /// </summary>
        /// <param name="clase"></param>
        /// <returns></returns>
        public Soldado BuscarSoldadoPorClase(Soldado.ClaseSoldado clase)
        {
            foreach (Soldado itemSoldado in this.miembrosEscuadron)
            {
                if (itemSoldado.ClaseDelSoldado == clase)
                {
                    return itemSoldado;
                }
            }
            return null;
        }
      
       
    }
}
