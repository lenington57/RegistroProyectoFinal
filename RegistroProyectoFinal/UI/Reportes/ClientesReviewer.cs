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
    public partial class ClientesReviewer : Form
    {
        private List<Cliente> clientes = new List<Cliente>();

        public ClientesReviewer(List<Cliente> Lista)
        {
            InitializeComponent();
            this.clientes = Lista;
        }

        private void ClientesCrystalReportViewer_Load(object sender, EventArgs e)
        {
            ClientesCrystalReport clientesCrystalReport = new ClientesCrystalReport();
            clientesCrystalReport.SetDataSource(clientes);
            ClientesCrystalReportViewer.ReportSource = clientesCrystalReport;
            clientesCrystalReport.Refresh();
        }
    }
}
