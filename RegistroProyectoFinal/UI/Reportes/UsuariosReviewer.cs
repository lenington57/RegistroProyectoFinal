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
    public partial class UsuariosReviewer : Form
    {
        private List<Usuario> usuarios = null;

        public UsuariosReviewer(List<Usuario> Lista)
        {
            InitializeComponent();
            this.usuarios = Lista;
        }

        private void UsuariosCrystalReportViewer_Load(object sender, EventArgs e)
        {
            UsuariosCrystalReport usuariosCrystalReport = new UsuariosCrystalReport();
            usuariosCrystalReport.SetDataSource(usuarios);
            UsuariosCrystalReportViewer.ReportSource = usuariosCrystalReport;
            usuariosCrystalReport.Refresh();
        }
    }
}
