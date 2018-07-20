using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroProyectoFinal.Entidades
{
    public class Producto
    {
        [Key]

        public int ProductoId { get; set; }

        public int DepartamentoId { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; }

        public double Costo { get; set; }

        public double Precio { get; set; }

        public double PorCientoGanancia { get; set; }

        public double CantidadIventario { get; set; }


        public Producto()
        {
            ProductoId = 0;
            DepartamentoId = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            PorCientoGanancia = 0;
            CantidadIventario = 0;
        }

    }
}
