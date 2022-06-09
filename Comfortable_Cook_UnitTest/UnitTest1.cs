using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using COMFORTABLE_COOK.Models;
using COMFORTABLE_COOK;

namespace Comfortable_Cook_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public string correo = "acb@gmail.com";
        public string clave = "tiamu amú";
        public int idUsuario = 1;
        public int idReceta = 23;
        
        [TestMethod]
        public void GuardarUsuarioTest()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var resultado = bd.GuardarUsuario(correo, clave);
            bool valorEsperado = true;
            Assert.AreEqual(resultado, valorEsperado);
        }

        [TestMethod]
        public void GuardarRecetaTest()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var resultado = bd.GuardarReceta(correo, clave, idUsuario);
            bool valorEsperado = true;
            Assert.AreEqual(resultado, valorEsperado);
        }

        [TestMethod]
        public void EliminarRecetaTest()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var resultado = bd.EliminarReceta(idReceta);
            bool valorEsperado = true;
            Assert.AreEqual(resultado, valorEsperado);
        }

        [TestMethod]
        public void MarcarFavoritoTest()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var resultado = bd.MarcarFavorito(idReceta);
            bool valorEsperado = true;
            Assert.AreEqual(resultado, valorEsperado);
        }

        [TestMethod]
        public void EliminarFavoritoTest()
        {
            BaseDeDatos bd = new BaseDeDatos();
            var resultado = bd.EliminarFavorito(idReceta);
            bool valorEsperado = true;
            Assert.AreEqual(resultado, valorEsperado);
        }

    }
}
