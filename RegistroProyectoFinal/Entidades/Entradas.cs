﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroProyectoFinal.Entidades
{
    public class Entradas
    {
        [Key]

        public int EntradaId { get; set; }

        public DateTime Fecha { get; set; }

        public int ProductoId { get; set; }

        public double Cantidad { get; set; }


        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ProductoId = 0;
            Cantidad = 0;
        }

    }
}
