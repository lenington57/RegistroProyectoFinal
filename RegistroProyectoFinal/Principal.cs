using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroProyectoFinal.UI.Registro;
using RegistroProyectoFinal.UI.Registros;
namespace RegistroProyectoFinal
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarProducto registrarProducto = new RegistrarProducto();
            registrarProducto.MdiParent = this;
            registrarProducto.Show();
        }

        private void entradaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEntradaProducto registrarEntradaProducto = new RegistrarEntradaProducto();
            registrarEntradaProducto.MdiParent = this;
            registrarEntradaProducto.Show();
        }

        private void facturaciónProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarFacturacion registrarFacturacion = new RegistrarFacturacion();
            registrarFacturacion.MdiParent = this;
            registrarFacturacion.Show();
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarCliente registrarCliente = new RegistrarCliente();
            registrarCliente.MdiParent = this;
            registrarCliente.Show();
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.MdiParent = this;
            registrarUsuario.Show();
        }

        private void registrarDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarDepartamento registrarDepartamento = new RegistrarDepartamento();
            registrarDepartamento.MdiParent = this;
            registrarDepartamento.Show();
        }

        private void registrarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarPago registrarPago = new RegistrarPago();
            registrarPago.MdiParent = this;
            registrarPago.Show();
        }
    }
}
