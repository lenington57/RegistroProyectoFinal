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
    public class DepartamentoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Departamento departamento = new Departamento();
            departamento.DepartamentoId = 3;
            departamento.Nombre = "Electrodomesticos";
            paso = DepartamentoBLL.Guardar(departamento);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Departamento departamento = new Departamento();
            departamento.DepartamentoId = 3;
            departamento.Nombre = "Electrodomesticos y mas";
            paso = DepartamentoBLL.Modificar(departamento);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = DepartamentoBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Departamento departamento = new Departamento();
            departamento = DepartamentoBLL.Buscar(id);
            Assert.IsNotNull(departamento);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Departamento, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Departamento> ListDepartamentos = new List<Departamento>();
            ListDepartamentos = contexto.Departamento.Where(expression).ToList();
            Assert.IsNotNull(ListDepartamentos);
        }
    }
}