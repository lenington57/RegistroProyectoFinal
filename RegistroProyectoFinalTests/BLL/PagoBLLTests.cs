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
    public class PagoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Pago pago = new Pago();
            pago.PagoId = 3;
            pago.Fecha = DateTime.Now;
            pago.ClienteId = 2;
            pago.MontoPago = 100;
            paso = PagoBLL.Guardar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Pago pago = new Pago();
            pago.PagoId = 3;
            pago.Fecha = DateTime.Now;
            pago.ClienteId = 2;
            pago.MontoPago = 200;
            paso = PagoBLL.Modificar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = PagoBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Pago pago = new Pago();
            pago = PagoBLL.Buscar(id);
            Assert.IsNotNull(pago);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Pago, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Pago> ListPagos = new List<Pago>();
            ListPagos = contexto.Pago.Where(expression).ToList();
            Assert.IsNotNull(ListPagos);
        }

        [TestMethod()]
        public void ModificarBienTest()
        {
            Assert.Fail();
        }
    }
}