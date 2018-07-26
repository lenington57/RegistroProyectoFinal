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
    public class EntradasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 3;
            entrada.Fecha = DateTime.Now;
            entrada.ProductoId = 2;
            entrada.Cantidad = 10;
            paso = EntradasBLL.Guardar(entrada);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 3;
            entrada.Fecha = DateTime.Now;
            entrada.ProductoId = 2;
            entrada.Cantidad = 20;
            paso = EntradasBLL.Modificar(entrada);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = EntradasBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Entradas entrada = new Entradas();
            entrada = EntradasBLL.Buscar(id);
            Assert.IsNotNull(entrada);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Entradas, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Entradas> ListEntradas = new List<Entradas>();
            ListEntradas = contexto.Entrada.Where(expression).ToList();
            Assert.IsNotNull(ListEntradas);
        }

        [TestMethod()]
        public void ModificarBienTest()
        {
            Assert.Fail();
        }
    }
}