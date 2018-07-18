using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroProyectoFinal.Entidades;
using RegistroProyectoFinal.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RegistroProyectoFinal.BLL
{
    public class ProductoBLL
    {
        public static bool Guardar(Producto producto)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Producto.Add(producto) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Producto producto)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Producto producto = contexto.Producto.Find(id);

                contexto.Producto.Remove(producto);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Producto Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Producto producto = new Producto();
            try
            {
                producto = contexto.Producto.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }


        public static List<Producto> GetList(Expression<Func<Producto, bool>> expression)
        {
            List<Producto> productos = new List<Producto>();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.Producto.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }

    }
}
