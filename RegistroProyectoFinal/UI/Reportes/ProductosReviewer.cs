using RegistroProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroProyectoFinal.UI.Reportes
{
    public partial class ProductosReviewer : Form
    {
        private List<Producto> productos = null;

        public ProductosReviewer(List<Producto> Lista)
        {
            InitializeComponent();
            this.productos = Lista;
        }

        private void ProductoCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ProductosCrystalReport productosCrystalReport = new ProductosCrystalReport();
            productosCrystalReport.SetDataSource(productos);
            ProductoCrystalReportViewer.ReportSource = productosCrystalReport;
            productosCrystalReport.Refresh();
        }
    }
}
