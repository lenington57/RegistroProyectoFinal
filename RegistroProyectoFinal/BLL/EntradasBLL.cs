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
    public class EntradasBLL
    {
        public static bool Guardar(Entradas entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entrada.Add(entrada) != null)
                {
                    contexto.Producto.Find(entrada.ProductoId).CantidadIventario += entrada.Cantidad;

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


        public static bool Modificar(Entradas entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entradas EntrAnt = EntradasBLL.Buscar(entrada.EntradaId);

                if (EntrAnt.ProductoId != entrada.ProductoId)
                {
                    ModificarBien(entrada, EntrAnt);
                }

                double modificado = entrada.Cantidad - EntrAnt.Cantidad;

                var Producto = contexto.Producto.Find(entrada.ProductoId);
                Producto.CantidadIventario += modificado;
                ProductoBLL.Modificar(Producto);

                contexto.Entry(entrada).State = EntityState.Modified;
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
                Entradas entrada = contexto.Entrada.Find(id);

                contexto.Producto.Find(entrada.ProductoId).CantidadIventario -= entrada.Cantidad;

                contexto.Entrada.Remove(entrada);

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


        public static Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }


        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            List<Entradas> entradas = new List<Entradas>();
            Contexto contexto = new Contexto();

            try
            {
                entradas = contexto.Entrada.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }

        public static void ModificarBien(Entradas entradas, Entradas EntradasAnteriores)
        {
            Contexto contexto = new Contexto();
            var Producto = contexto.Producto.Find(entradas.ProductoId);
            var ProductosAnteriores = contexto.Producto.Find(EntradasAnteriores.ProductoId);

            Producto.CantidadIventario += entradas.Cantidad;
            ProductosAnteriores.CantidadIventario -= EntradasAnteriores.Cantidad;
            ProductoBLL.Modificar(Producto);
            ProductoBLL.Modificar(ProductosAnteriores);
        }

    }
}
