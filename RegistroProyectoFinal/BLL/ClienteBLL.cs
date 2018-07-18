﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroProyectoFinal.Entidades;
using RegistroProyectoFinal.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RegistroProyectoFinal.BLL
{
    public class ClienteBLL
    {
        public static bool Guardar(Cliente cliente)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Cliente.Add(cliente) != null)
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


        public static bool Modificar(Cliente cliente)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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
                Cliente cliente = contexto.Cliente.Find(id);

                contexto.Cliente.Remove(cliente);

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


        public static Cliente Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cliente cliente = new Cliente();
            try
            {
                cliente = contexto.Cliente.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }


        public static List<Cliente> GetList(Expression<Func<Cliente, bool>> expression)
        {
            List<Cliente> clientes = new List<Cliente>();
            Contexto contexto = new Contexto();

            try
            {
                clientes = contexto.Cliente.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return clientes;
        }

    }
}
