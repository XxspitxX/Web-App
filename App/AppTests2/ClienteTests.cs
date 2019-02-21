using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Tests
{
    [TestClass()]
    public class ClienteTests
    {
        [TestMethod()]
        public void insertarClienteTest()
        {
            Cliente clte = new Cliente();
            clte.IdCliente = 6524;
            clte.NombreCliente = "Carlos";
            clte.DireccionCliente = "Carrera 12";
            clte.TelefonoCliente = "7854";
            Console.WriteLine();
            Console.Read();
            int expected = 1;
            int actual;
            actual = clte.insertarCliente();
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void modificarClienteTest()
        {
            Cliente clte = new Cliente();
            clte.IdCliente = 6524;
            clte.NombreCliente = "Juan";
            clte.DireccionCliente = "Carrera 10";
            clte.TelefonoCliente = "5874";
            int expected = 1;
            int actual;
            actual = clte.modificarCliente();

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void eliminarClienteTest()
        {
            Cliente clte = new Cliente();
            clte.IdCliente = 2458;
            int expected = 1;
            int actual;
            actual = clte.eliminarCliente();
            Assert.AreEqual(actual, expected);
        }

       [TestMethod()]
        public void consultarClienteTest()
        {
            bool expected = true;
            List<Cliente> lista;
            lista = Cliente.consultarCliente();
            int resultado = lista.Count;
            if (resultado>0){
                bool actual = true;
                Assert.AreEqual(expected, actual);
            }
            else
            {
                bool actual = false;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}  