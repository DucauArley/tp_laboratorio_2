using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Testea que la lista de paquetes no sea null
        /// </summary>
        [TestMethod]
        public void TestListaDePaquetesEnCorreo()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c.Paquetes);
        }


        /// <summary>
        /// Testea que se lance la excepcion TrackingIdRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void VerificarTrackingId()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Carlos Tejedor 255", "1234567890");
            Paquete p2 = new Paquete("Paraguay 325", "1234567890");

            c += p1;
            c += p2;
        }

    }
}
