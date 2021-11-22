using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Aquí se pone en prática la teoría de la clase 14, Archivos y serialización
/// </summary>
namespace Entidades
{
    public abstract class Archivo
    {
        protected abstract string ExtensionDeArchivo { get; }

        public enum TipoArchivo
        {
           xmlTxtJson,
           xml
        }
        public bool ValidarExtensionDeArchivo(string path)
        {
            if (Path.GetExtension(path) == this.ExtensionDeArchivo)
            {
                return true;
            }
            /// <summary>
            /// Aquí se implementan los conceptos de la clase 10
            /// </summary>
            throw new ErrorDeArchivoExcepcion($"El archivo no tiene la extensión {this.ExtensionDeArchivo}");
        }

        public bool ValidarSiElArchivoExiste(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            /// <summary>
            /// Aquí se implementan los conceptos de la clase 10
            /// </summary>
            throw new ErrorDeArchivoExcepcion("No se encontró archivo");
        }
    }
}
