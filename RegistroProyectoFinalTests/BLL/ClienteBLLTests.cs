using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroProyectoFinal.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroProyectoFinal.Entidades;
using RegistroProyectoFinal.DAL;
using System.Linq.Expressions;

namespace RegistroProyectoFinal.BLL.Tests
{
    [TestClass()]
    public class ClienteBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteId = 2;
            cliente.Nombres = "Francisco";
            cliente.NoTelefono = "9876543210";
            cliente.NoCedula = "88888888888";
            cliente.Direccion = "San";
            cliente.Deuda = 0;
            paso = ClienteBLL.Guardar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Cliente cliente = new Cliente();
            cliente.ClienteId = 3;
            cliente.Nombres = "Juan Francisco";
            cliente.NoTelefono = "9876543210";
            cliente.NoCedula = "88888888888";
            cliente.Direccion = "San Francisco de Macorís";
            cliente.Deuda = 0;
            paso = ClienteBLL.Modificar(cliente);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = ClienteBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Cliente cliente = new Cliente();
            cliente = ClienteBLL.Buscar(id);
            Assert.IsNotNull(cliente);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Cliente, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Cliente> ListClientes = new List<Cliente>();
            ListClientes = contexto.Cliente.Where(expression).ToList();
            Assert.IsNotNull(ListClientes);
        }
    }
}