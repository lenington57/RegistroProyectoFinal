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
    public class DepartamentoBLL
    {
        public static bool Guardar(Departamento departamento)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Departamento.Add(departamento) != null)
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


        public static bool Modificar(Departamento departamento)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(departamento).State = EntityState.Modified;
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
                Departamento departamento = contexto.Departamento.Find(id);

                contexto.Departamento.Remove(departamento);

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


        public static Departamento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Departamento departamento = new Departamento();
            try
            {
                departamento = contexto.Departamento.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return departamento;
        }


        public static List<Departamento> GetList(Expression<Func<Departamento, bool>> expression)
        {
            List<Departamento> departamentos = new List<Departamento>();
            Contexto contexto = new Contexto();

            try
            {
                departamentos = contexto.Departamento.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return departamentos;
        }

    }
}
