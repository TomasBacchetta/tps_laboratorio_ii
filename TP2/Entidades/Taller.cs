using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
           
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            Type tipoVehiculo = null;//tiene que tener un valor por defecto

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            switch (tipo)//el switch se encuentra ahora fuera del foreach, dependiendo del tipo de vehiculo en el argumento, asigno a la variable type tipoVehiculo el tipo correspondiente
            {
                case ETipo.Ciclomotor:
                    tipoVehiculo = typeof(Ciclomotor);
                    break;
                case ETipo.Sedan:
                    tipoVehiculo = typeof(Sedan);
                    break;
                case ETipo.SUV:
                    tipoVehiculo = typeof(Suv);
                    break;
            }

            foreach (Vehiculo v in t.vehiculos)
            {

                if (v.GetType() == tipoVehiculo || tipo == ETipo.Todos)//lo unico que hago es preguntar si es del tipo heredado o si el tipo del argumento es "todos"
                {
                    sb.AppendLine((string)v);
                }
            }

            return $"{sb}";
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }

                taller.vehiculos.Add(vehiculo);
                return taller;
            }
            else
            {
                return taller;
            }

        }
        /// <summary>
        /// Quitará un elemento de la lista, SE AGREGÓ QUE SI EXISTE, LO BORRA
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.RemoveAt(taller.vehiculos.IndexOf(v));

                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
