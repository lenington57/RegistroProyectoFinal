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
    public class ProductoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Producto producto = new Producto();
            producto.ProductoId = 3;
            producto.DepartamentoId = 1;
            producto.Descripcion = "Manzanas";
            producto.Costo = 15;
            producto.Precio = 25;
            producto.PorCientoGanancia = 10;
            producto.CantidadIventario = 0; ;
            paso = ProductoBLL.Guardar(producto);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Producto producto = new Producto();
            producto.ProductoId = 3;
            producto.DepartamentoId = 1;
            producto.Descripcion = "Manzanas Verdes";
            producto.Costo = 18;
            producto.Precio = 30;
            producto.PorCientoGanancia = 12;
            producto.CantidadIventario = 0; ;
            paso = ProductoBLL.Modificar(producto);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = ProductoBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Producto producto = new Producto();
            producto = ProductoBLL.Buscar(id);
            Assert.IsNotNull(producto);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Producto, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Producto> ListProductos = new List<Producto>();
            ListProductos = contexto.Producto.Where(expression).ToList();
            Assert.IsNotNull(ListProductos);
        }

        [TestMethod()]
        public void PorcientoGananciaTest()
        {
            Assert.Fail();
        }
    }
}