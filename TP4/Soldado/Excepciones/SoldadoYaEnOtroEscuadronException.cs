using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SoldadoYaEnOtroEscuadronException : Exception
    {
        /// <summary>
        /// Esta excepcion se va a lanzar cuando haya errores en el guardado del archivo
        /// </summary>
        public SoldadoYaEnOtroEscuadronException() : base() { }

        /// <summary>
        /// Esta excepcion se va a lanzar cuando haya errores de lectura de archivo
        /// </summary>
        /// <param name="mensaje"></param>
        public SoldadoYaEnOtroEscuadronException(string mensaje) : base(mensaje) { }



    }
}
