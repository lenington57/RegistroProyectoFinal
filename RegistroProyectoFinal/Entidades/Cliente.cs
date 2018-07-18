using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroProyectoFinal.Entidades
{
    public class Cliente
    {
        [Key]

        public int ClienteId { get; set; }

        public string Nombres { get; set; }

        public string NoTelefono { get; set; }

        public string Direccion { get; set; }


        public Cliente()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            NoTelefono = string.Empty;
            Direccion = string.Empty;
        }

    }
}
