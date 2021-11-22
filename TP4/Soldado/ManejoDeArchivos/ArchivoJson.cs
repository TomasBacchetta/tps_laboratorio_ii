using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
/// <summary>
/// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
/// </summary>
namespace Entidades
{
    public class ArchivoJson<T> : Archivo, IManejoDeArchivos<T> where T: class
    {
        protected override string ExtensionDeArchivo
        {
            get
            {
                return ".json";
            }
        }

        public T Abrir(string path)
        {
            if (ValidarSiElArchivoExiste(path) && ValidarExtensionDeArchivo(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string jsonString = streamReader.ReadToEnd();
                    T contenido;
                    /// <summary>
                    /// Aquí se implementan los conceptos de la clase 10
                    /// </summary>
                    try
                    {
                        contenido = JsonSerializer.Deserialize<T>(jsonString);
                    }
                    catch
                    {
                        throw new ArchivoIncorrectoOCorruptoExcepcion("Archivo incorrecto o corrupto");
                    }
                 
                    return contenido;
                }
            }
            return null;
        }

        public void Guardar(T data, string path)
        {
            if (ValidarSiElArchivoExiste(path) && ValidarExtensionDeArchivo(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(data);
                    streamWriter.Write(json);

                }
            }
        }

        public void GuardarComo(T data, string path)
        {
            if (ValidarExtensionDeArchivo(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;

                    string json = JsonSerializer.Serialize(data);
                    streamWriter.Write(json);

                }
            }
        }
    }
}
