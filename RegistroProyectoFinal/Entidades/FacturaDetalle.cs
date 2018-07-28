using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroProyectoFinal.Entidades
{
    public class FacturaDetalle
    {
        [Key]

        public int Id { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }

        public double Cantidad { get; set; }

        public double Precio { get; set; }

        public double Importe { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Factura Factura { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }


        public FacturaDetalle()
        {
            Id = 0;
            FacturaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public FacturaDetalle(int id, int facturaId, int productoId, double cantidad, double precio, double importe)
        {
            Id = id;
            FacturaId = facturaId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }

    }
}
