using System;
using Entidades;

namespace TestConsola
{
    class Test
    {
        static void Main(string[] args)
        {
            Cuartel miCuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            Soldado soldado2 = new Soldado(DateTime.Now, "Johnny", "Allon", "65463541", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Tecnico);
            Soldado soldado3 = new Soldado(DateTime.Now, "Dmitri", "Rodnoy", "55454", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Medico);
            Soldado soldado4 = new Soldado(DateTime.Now, "Vladimir", "Petete", "654654", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Reconocimiento);
            
            Soldado soldado5 = new Soldado(DateTime.Now, "Ramiro", "Sanguineti", "654654", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Reconocimiento);//en el programa no se puede ni siquiera dar de alta con el mismo dni

            if (miCuartel + soldado1)
            {
                Console.WriteLine("Soldado agregado con éxito");
            } else
            {
                Console.WriteLine("No se pudo agregar");
            }
            if (miCuartel + soldado2)
            {
                Console.WriteLine("Soldado agregado con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }
            if (miCuartel + soldado3)
            {
                Console.WriteLine("Soldado agregado con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }
            if (miCuartel + soldado4)
            {
                Console.WriteLine("Soldado agregado con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }
            Console.WriteLine("no deberia poder agregar ya que tiene el mismo dni que otro soldado");
            if (miCuartel + soldado5)//no deberia poder agregar ya que tiene el mismo dni que otro soldado
            {
                Console.WriteLine("Soldado agregado con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }

            if (miCuartel - soldado4)
            {
                Console.WriteLine("Soldado removido con exito");
            } else {
                Console.WriteLine("No se pudo remover el soldado");
            }
            Console.WriteLine("Ahora deberia poder agregar");
            if (miCuartel + soldado5)
            {
                Console.WriteLine("Soldado agregado con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo agregar");
            }
            Escuadron nuevoEscuadron = new Escuadron(Escuadron.NombreEscuadron.ALFA);
            if(nuevoEscuadron + soldado1)
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
            if (nuevoEscuadron + soldado2)
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
            if (nuevoEscuadron + soldado3)
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
            if (nuevoEscuadron + soldado4)
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }

            Soldado soldado6 = new Soldado(DateTime.Now, "Strelok", "Pliskin", "55487654", Soldado.Rango.Cabo, Soldado.ClaseSoldado.Asalto);
            Console.WriteLine("no deberia poder agregarlo, ya que ya hay 4 soldados");
            if (nuevoEscuadron + soldado6)
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
            if (nuevoEscuadron - soldado4)
            {
                Console.WriteLine("Soldado removido del escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo remover del escuadron");
            }
            Console.WriteLine("no deberia poder agregarlo tampoco, ya que ya hay un soldado de tipo Asalto en el escuadrón");
            if (nuevoEscuadron + soldado6)//
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
            Console.WriteLine("ahora cambio ese soldado nuevo por un soldado de reconocimiento");
            soldado6 = new Soldado(DateTime.Now, "Strelok", "Pliskin", "55487654", Soldado.Rango.Cabo, Soldado.ClaseSoldado.Reconocimiento);//
            Console.WriteLine("ya deberia poder agregarlo");
            if (nuevoEscuadron + soldado6)//
            {
                Console.WriteLine("Soldado agregado al escuadron");
            }
            else
            {
                Console.WriteLine("No se pudo agregar al escuadron");
            }
        }
    }
}
