using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Aquí se implementan los conceptos de la clase 10
/// </summary>
namespace Entidades
{
    public class ErrorDeArchivoExcepcion : Exception
    {
        /// <summary>
        /// Esta excepcion se va a lanzar cuando haya errores en el guardado del archivo
        /// </summary>
        public ErrorDeArchivoExcepcion() : base() { }

        /// <summary>
        /// Esta excepcion se va a lanzar cuando haya errores de lectura de archivo
        /// </summary>
        /// <param name="mensaje"></param>
        public ErrorDeArchivoExcepcion(string mensaje) : base(mensaje) { }

        

    }
}
