using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Aquí pongo en práctica la teoría de la clase 12, Tipos Genéricos, como también la clase 13, Interfaces, como también la teoría de la clase 14, Archivos y serialización
/// </summary>
namespace Entidades
{
    public interface IManejoDeArchivos<T>
    {
        public T Abrir(string path);

        public void Guardar(T data, string path);


        public void GuardarComo(T data, string path);


        
    }
}
