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
    public class PagoBLL
    {
        public static bool Guardar(Pago pago)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pago.Add(pago) != null)
                {
                    contexto.Cliente.Find(pago.ClienteId).Deuda -= pago.MontoPago;

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


        public static bool Modificar(Pago pago)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Pago PagoAnt = PagoBLL.Buscar(pago.PagoId);

                if (PagoAnt.ClienteId != pago.ClienteId)
                {
                    ModificarBien(pago, PagoAnt);
                }               

                double modificado = pago.MontoPago - PagoAnt.MontoPago;

                var Cliente = contexto.Cliente.Find(pago.ClienteId);
                Cliente.Deuda += modificado;
                ClienteBLL.Modificar(Cliente);

                contexto.Entry(pago).State = EntityState.Modified;
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
                Pago pago = contexto.Pago.Find(id);

                contexto.Cliente.Find(pago.ClienteId).Deuda += pago.MontoPago;

                contexto.Pago.Remove(pago);

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


        public static Pago Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pago pago = new Pago();

            try
            {
                pago = contexto.Pago.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }


        public static List<Pago> GetList(Expression<Func<Pago, bool>> expression)
        {
            List<Pago> pagos = new List<Pago>();
            Contexto contexto = new Contexto();

            try
            {
                pagos = contexto.Pago.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return pagos;
        }

        public static void ModificarBien(Pago pago, Pago PagoAnterior)
        {
            Contexto contexto = new Contexto();
            var Cliente = contexto.Cliente.Find(pago.ClienteId);
            var ClienteAnterior = contexto.Cliente.Find(PagoAnterior.ClienteId);

            Cliente.Deuda += pago.MontoPago;
            ClienteAnterior.Deuda -= PagoAnterior.MontoPago;
            ClienteBLL.Modificar(Cliente);
            ClienteBLL.Modificar(ClienteAnterior);
        }
        
    }
}
