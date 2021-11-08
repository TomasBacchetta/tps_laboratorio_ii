using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
/// <summary>
/// Aquí se pone en práctica la teoría de la clase 11
/// </summary>
namespace Test
{
    [TestClass]
    public class TestMiscelaneos
    {
        [TestMethod]
        public void LaObrecargaDelOperadorMasDeCuartel_AlAgregarUnSoldadoNuevo_DeberiaDevolverTrue()
        {
            //arrange
            Cuartel cuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            bool expected = true;
            //act
            bool actual = cuartel + soldado1;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMasDeCuartel_AlAgregarUnSoldadoYaPresente_DeberiaDevolverFalse()
        {
            //arrange
            Cuartel cuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            Soldado soldado2 = new Soldado(DateTime.Now, "Peter", "Brinsky", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            _ = cuartel + soldado1;
            bool expected = false;
            //act
            bool actual = cuartel + soldado2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMasDeCuartel_AlAgregarUnSoldadoNuevo_DeberiaAgregarEseSoldadoALaListaSoldados()
        {
            //arrange
            Cuartel cuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            
            _ = cuartel + soldado1;
            bool expected = true;
            //act
            bool actual = cuartel.ListaDeSoldados.Contains(soldado1);
            //assert
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMasDeEscuadron_AlAgregarUnSoldadoNuevo_DeberiaDevolverTrue()
        {
            //arrange
            Escuadron escuadron = new Escuadron(Escuadron.NombreEscuadron.ALFA);
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            bool expected = true;
            //act
            bool actual = escuadron + soldado1;
            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void LaObrecargaDelOperadorMasDeEscuadron_AlAgregarUnSoldadoYaPresente_DeberiaDevolverFalse()
        {
            //arrange
            Escuadron escuadron = new Escuadron(Escuadron.NombreEscuadron.ALFA);
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            Soldado soldado2 = new Soldado(DateTime.Now, "Peter", "Brinsky", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            _ = escuadron + soldado1;
            bool expected = false;
            //act
            bool actual = escuadron + soldado2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMasDeEscuadron_AlAgregarUnSoldadoDeLaMismaClase_DeberiaDevolverFalse()
        {
            //arrange
            Escuadron escuadron = new Escuadron(Escuadron.NombreEscuadron.ALFA);
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Reconocimiento);
            Soldado soldado2 = new Soldado(DateTime.Now, "Peter", "Brinsky", "54546", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Reconocimiento);
            _ = escuadron + soldado1;
            bool expected = false;
            //act
            bool actual = escuadron + soldado2;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMenosDeCuartel_AlQuitarUnSoldadoExistente_DeberiaDevolverTrue()
        {
            //arrange
            Cuartel cuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            _ = cuartel + soldado1;
            bool expected = true;
            //act
            bool actual = cuartel - soldado1;
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LaObrecargaDelOperadorMenosDeCuartel_AlQuitarUnSoldadoNuevo_DeberiaDevolverFalse()
        {
            //arrange
            Cuartel cuartel = new Cuartel();
            Soldado soldado1 = new Soldado(DateTime.Now, "Jorge", "Corona", "1121345", Soldado.Rango.Sargento, Soldado.ClaseSoldado.Asalto);
            
            bool expected = false;
            //act
            bool actual = cuartel - soldado1;
            //assert
            Assert.AreEqual(expected, actual);
        }


    }
}
