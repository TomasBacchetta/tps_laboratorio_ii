using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
/// <summary>
/// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, como así también la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
/// </summary>
namespace Entidades
{
    public class ArchivoXml<T> : Archivo, IManejoDeArchivos<T> where T : class
    {
        protected override string ExtensionDeArchivo
        {
            get
            {
                return ".xml";
            }
        }

        public T Abrir(string path)
        {
            if (ValidarExtensionDeArchivo(path) && ValidarSiElArchivoExiste(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    T puntoXml;
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10
                    /// </summary>
                    try
                    {
                        puntoXml = xmlSerializer.Deserialize(streamReader) as T;
                    }
                    catch
                    {
                        throw new ArchivoIncorrectoOCorruptoExcepcion("Archivo incorrecto o corrupto");
                    }

                    return puntoXml;
                }
            }

            return null;
        }

        public void Guardar(T data, string path)
        {
            if (ValidarExtensionDeArchivo(path) && ValidarSiElArchivoExiste(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, data);

                }
            }
        }

        public void GuardarComo(T data, string path)
        {
            if (ValidarExtensionDeArchivo(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, data);

                }
            }
        }
    }
}
