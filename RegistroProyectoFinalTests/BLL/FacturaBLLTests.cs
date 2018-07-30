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
    public class FacturaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Factura factura = new Factura();
            factura.FacturaId = 3;
            factura.Fecha = DateTime.Now;
            factura.ClienteId = 1;
            factura.UsuarioId = 1;
            factura.Itbis = 18;
            factura.SubTotal = 82;
            factura.Total = 100;

            factura.Detalle.Add(new FacturaDetalle(0, 2, 2, 2, 25, 50));
            factura.Detalle.Add(new FacturaDetalle(0, 3, 1, 1, 30, 30));
            bool paso = FacturaBLL.Guardar(factura);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            int IdFactura = FacturaBLL.GetList(x => true)[0].FacturaId;
            Factura factura = FacturaBLL.Buscar(IdFactura);
            factura.FacturaId = 3;
            factura.Fecha = DateTime.Now;
            factura.ClienteId = 1;
            factura.UsuarioId = 1;
            factura.Itbis = 18;
            factura.SubTotal = 82;
            factura.Total = 100;
            
            factura.Detalle.Add(new FacturaDetalle(0, 2, 2, 2, 25, 50));
            bool paso = FacturaBLL.Modificar(factura);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int IdFactura = FacturaBLL.GetList(x => true)[0].FacturaId;
            Factura factura = FacturaBLL.Buscar(IdFactura);
            bool paso = FacturaBLL.Eliminar(IdFactura);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int IdFactura = FacturaBLL.GetList(x => true)[0].FacturaId;
            Factura factura = FacturaBLL.Buscar(IdFactura);
            bool paso = factura.Detalle.Count > 0;
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Factura, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Factura> Lista = new List<Factura>();
            Lista = contexto.Factura.Where(expression).ToList();
            Assert.IsNotNull(Lista);
        }

        [TestMethod()]
        public void ImporteTest()
        {
            Assert.Fail();
        }
    }
}