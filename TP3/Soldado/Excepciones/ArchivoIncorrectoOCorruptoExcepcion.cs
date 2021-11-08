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
    public class ArchivoIncorrectoOCorruptoExcepcion : Exception
    {
        public ArchivoIncorrectoOCorruptoExcepcion() : base() { }
        public ArchivoIncorrectoOCorruptoExcepcion(string mensaje) : base(mensaje) { }



    }
}
