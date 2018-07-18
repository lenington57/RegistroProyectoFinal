using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroProyectoFinal.UI.Registro;

namespace RegistroProyectoFinal
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarProducto registrarProducto = new RegistrarProducto();
            registrarProducto.Show();
        }

        private void entradaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEntradaProducto registrarEntradaProducto = new RegistrarEntradaProducto();
            registrarEntradaProducto.Show();
        }

        private void facturaciónProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarFacturacion registrarFacturacion = new RegistrarFacturacion();
            registrarFacturacion.Show();
        }

        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void RegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.Show();
        }
    }
}
