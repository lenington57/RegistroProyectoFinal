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

                    foreach (var item in factura.Detalle)
                    {
                        contexto.Producto.Find(item.ProductoId).CantidadIventario -= item.Cantidad;
                    }

                contexto.Cliente.Find(factura.ClienteId).Deuda += factura.Total;

                contexto.SaveChanges();
                paso = true;

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
                var FactAnt = FacturaBLL.Buscar(factura.FacturaId);

                ModificarBien(factura, FactAnt);

                //foreach (var item in FactAnt.Detalle)
                //{
                //    contexto.Producto.Find(item.ProductoId).CantidadIventario += item.Cantidad;

                //    if (!factura.Detalle.ToList().Exists(v => v.Id == item.Id))
                //    {
                //        item.Producto = null;
                //        contexto.Entry(item).State = EntityState.Deleted;
                //    }
                //}

                //foreach (var item in factura.Detalle)
                //{
                //    contexto.Producto.Find(item.ProductoId).CantidadIventario -= item.Cantidad;
                //    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                //    contexto.Entry(item).State = estado;
                //}

                Factura FactAnterior = FacturaBLL.Buscar(factura.FacturaId);
                double modificado = factura.Total - FactAnterior.Total;

                var Cliente = contexto.Cliente.Find(factura.FacturaId);
                Cliente.Deuda += modificado;
                ClienteBLL.Modificar(Cliente);

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

                foreach (var item in factura.Detalle)
                {
                    var EliminInventario = contexto.Producto.Find(item.ProductoId);
                    EliminInventario.CantidadIventario += item.Cantidad;
                }

                contexto.Cliente.Find(factura.ClienteId).Deuda -= factura.Total;

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

                if (factura != null)
                {
                    factura.Detalle.Count();

                    foreach (var item in factura.Detalle)
                    {

                        string s = item.Producto.Descripcion;
                        string ss = item.Factura.FacturaId.ToString();
                    }
                }
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

        public static double Importe(double cantidad, double precio)
        {
            double CalImporte = 0;
            CalImporte = cantidad * precio;

            return CalImporte;
        }

        public static void ModificarBien(Factura factura, Factura FacturasAnteriores)
        {
            Contexto contexto = new Contexto();
            var Cliente = contexto.Cliente.Find(factura.ClienteId);
            var ClientesAnteriores = contexto.Cliente.Find(FacturasAnteriores.ClienteId);

            if (ClientesAnteriores.ClienteId != Cliente.ClienteId)
            {
                Cliente.Deuda += factura.Total;
                ClientesAnteriores.Deuda -= FacturasAnteriores.Total;
                ClienteBLL.Modificar(Cliente);
                ClienteBLL.Modificar(ClientesAnteriores);
            }
        }

    }
}

