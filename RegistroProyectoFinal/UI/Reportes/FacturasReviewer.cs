using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroProyectoFinal.Entidades;

namespace RegistroProyectoFinal.UI.Reportes
{
    public partial class FacturasReviewer : Form
    {
        private List<Factura> facturas = null;

        public FacturasReviewer(List<Factura> Lista)
        {
            InitializeComponent();
            this.facturas = Lista;
        }

        private void FacturasCrystalReportViewer_Load(object sender, EventArgs e)
        {
            FacturasCrystalReport facturasCrystalReport = new FacturasCrystalReport();
            facturasCrystalReport.SetDataSource(facturas);
            FacturasCrystalReportViewer.ReportSource = facturasCrystalReport;
            facturasCrystalReport.Refresh();
        }
    }
}
