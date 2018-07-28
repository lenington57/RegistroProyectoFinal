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
    public partial class DepartamentosReviewer : Form
    {
        private List<Departamento> departamentos = null;

        public DepartamentosReviewer(List<Departamento> Lista)
        {
            InitializeComponent();
            this.departamentos = Lista;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DepartamentosCrystalReport departamentosCrystalReport = new DepartamentosCrystalReport();
            departamentosCrystalReport.SetDataSource(departamentos);
            DepartamentoCrystalReportViewer.ReportSource = departamentosCrystalReport;
            departamentosCrystalReport.Refresh();
        }
    }
}
