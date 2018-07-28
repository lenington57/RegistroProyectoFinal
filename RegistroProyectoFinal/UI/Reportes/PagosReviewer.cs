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
    public partial class PagosReviewer : Form
    {
        private List<Pago> pagos = null;

        public PagosReviewer(List<Pago> Lista)
        {
            InitializeComponent();
            this.pagos = Lista;
        }

        private void PagosCrystalReportViewer_Load(object sender, EventArgs e)
        {
            PagosCrystalReport pagosCrystalReport = new PagosCrystalReport();
            pagosCrystalReport.SetDataSource(pagos);
            PagosCrystalReportViewer.ReportSource = pagosCrystalReport;
            pagosCrystalReport.Refresh();
        }
    }
}
