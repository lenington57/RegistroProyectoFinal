﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroProyectoFinal.Entidades
{
    public class Departamento
    {
        [Key]

        public int DepartamentoId { get; set; }

        public string Nombre { get; set; }


        public Departamento()
        {
            DepartamentoId = 0;
            Nombre = string.Empty;
        }

    }
}
