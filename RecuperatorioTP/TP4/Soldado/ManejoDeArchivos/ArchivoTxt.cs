using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, como así también Interfaces, como también la teoría de la clase 14, Archivos y serialización
/// </summary>
namespace Entidades
{
    public class ArchivoTxt : Archivo, IManejoDeArchivos<string>
    {
        protected override string ExtensionDeArchivo
        {
            get
            {
                return ".txt";
            }
            
        }

        

        public string Abrir(string path)
        {
            if (ValidarExtensionDeArchivo(path) && ValidarSiElArchivoExiste(path))
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        return streamReader.ReadToEnd();
                    }

                }
                catch
                {
                    throw new ArchivoIncorrectoOCorruptoExcepcion("Archivo incorrecto o corrupto");
                }
                
            }
            return null;
        }

        public void Guardar(string data, string path)
        {
            if (ValidarExtensionDeArchivo(path) && ValidarSiElArchivoExiste(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write(path);
                }


            }
        }

        public void GuardarComo(string data, string path)
        {
            if (ValidarExtensionDeArchivo(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.Write(data);
                }
            }
        }
    }
}
