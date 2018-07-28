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
    public partial class EntradasReviewer : Form
    {
        private List<Entradas> entradas = null;

        public EntradasReviewer(List<Entradas> Lista)
        {
            InitializeComponent();
            this.entradas = Lista;
        }

        private void EntradasCrystalReportViewer_Load(object sender, EventArgs e)
        {
            EntradasCrystalReport entradasCrystalReport = new EntradasCrystalReport();
            entradasCrystalReport.SetDataSource(entradas);
            EntradasCrystalReportViewer.ReportSource = entradasCrystalReport;
            entradasCrystalReport.Refresh();
        }
    }
}
