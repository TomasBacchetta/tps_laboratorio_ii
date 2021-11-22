using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Aquí se aplican los conceptos vistos en la clase 20 sobre métodos de extensión. Facilitan el uso de tipos conocidos, como el datetime y el double, entre otros
    /// </summary>
    public static class Extensiones
    {
        /// <summary>
        /// calcula el intervalo en segundos de dos puntos en el tiempo
        /// </summary>
        /// <param name="tiempoFinal"></param>
        /// <param name="tiempoIncial"></param>
        /// <returns>devuelve el valor en double</returns>
        public static double CalcularDuracionEnSegundos(this DateTime tiempoFinal, DateTime tiempoIncial)
        {
            return tiempoFinal.Subtract(tiempoIncial).TotalSeconds;
        }
        /// <summary>
        /// calcula el intervalo en horas de dos puntos en el tiempo
        /// </summary>
        /// <param name="tiempoFinal"></param>
        /// <param name="tiempoIncial"></param>
        /// <returns>devuelve el valor en double</returns>
        public static double CalcularDuracionEnHoras(this DateTime tiempoFinal, DateTime tiempoIncial)
        {
            return tiempoFinal.Subtract(tiempoIncial).TotalHours;
        }

        /// <summary>
        /// Devuelve un valor double redondeado hasta dos decimales
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static double RedondearValorDouble(this double valor)
        {
            return Math.Round(valor, 2);
        }


    }
}
