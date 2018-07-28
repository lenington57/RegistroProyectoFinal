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
    public class UsuarioBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Usuario usuario = new Usuario();
            usuario.UsuarioId = 1;
            usuario.Nombres = "Lenington del Orbe";
            usuario.NoTelefono = "1234567890";
            usuario.Email = "yonose@gmail.com";
            usuario.Contraseña = "12356";
            paso = UsuarioBLL.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Usuario usuario = new Usuario();
            usuario.UsuarioId = 3;
            usuario.Nombres = "Julio Alberto";
            usuario.NoTelefono = "0123456789";
            usuario.Email = "Jalbert@gmail.com";
            usuario.Contraseña = "3026";
            paso = UsuarioBLL.Modificar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = UsuarioBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Usuario usuario = new Usuario();
            usuario = UsuarioBLL.Buscar(id);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Usuario, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Usuario> ListUsuarios = new List<Usuario>();
            ListUsuarios = contexto.Usuario.Where(expression).ToList();
            Assert.IsNotNull(ListUsuarios);
        }
    }
}