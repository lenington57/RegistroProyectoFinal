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
    public class FacturaBLL
    {
        public static bool Guardar(Factura factura)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Factura.Add(factura) != null)
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


        public static bool Modificar(Factura factura)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(factura).State = EntityState.Modified;
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
                Factura factura = contexto.Factura.Find(id);

                contexto.Factura.Remove(factura);

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


        public static Factura Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Factura factura = new Factura();
            try
            {
                factura = contexto.Factura.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return factura;
        }


        public static List<Factura> GetList(Expression<Func<Factura, bool>> expression)
        {
            List<Factura> facturas = new List<Factura>();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Factura.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return facturas;
        }

    }
}
