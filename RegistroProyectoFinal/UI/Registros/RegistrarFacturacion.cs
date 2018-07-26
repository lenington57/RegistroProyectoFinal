﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroProyectoFinal.BLL;
using RegistroProyectoFinal.DAL;
using RegistroProyectoFinal.Entidades;

namespace RegistroProyectoFinal.UI.Registro
{
    public partial class RegistrarFacturacion : Form
    {
        public RegistrarFacturacion()
        {
            InitializeComponent();
            LlenarComboBox();
            CargarUsuario();
        }

        private void RegistrarFacturacion_Load(object sender, EventArgs e)
        {

        }

        //Métodos       
        private void LlenarComboBox()
        {
            Repositorio<Cliente> CliRepositorio = new Repositorio<Cliente>(new Contexto());
            Repositorio<Producto> ProRepositorio = new Repositorio<Producto>(new Contexto());

            ClienteComboBox.DataSource = CliRepositorio.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";
            ProductoComboBox.DataSource = ProRepositorio.GetList(c => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";
        }

        private void CargarUsuario()
        {
            UsuarioTextBox.DataBindings.Clear();
            var Usuario = UsuarioBLL.GetList(c=> true);
            Binding doBinding = new Binding("Text", Usuario, "Nombres");
            UsuarioTextBox.DataBindings.Add(doBinding);
        }
 
        private void LlenaCampos(Factura factura)
        {
            FacturaIdNumericUpDown.Value = factura.FacturaId;
            ClienteComboBox.SelectedValue = factura.ClienteId;
            FechaDateTimePicker.Value = factura.Fecha;
            SubTotalTextBox.Text = factura.SubTotal.ToString();
            ItbisTextBox.Text = factura.Itbis.ToString();
            TotalTextBox.Text = factura.Total.ToString();

            FacturaDetalleDataGridView.DataSource = factura.Detalle;

            FacturaDetalleDataGridView.Columns["Id"].Visible = false;
            FacturaDetalleDataGridView.Columns["FacturaId"].Visible = false;
        }

        private Factura LlenaClase()
        {
            Factura factura = new Factura();

            factura.FacturaId = Convert.ToInt32(FacturaIdNumericUpDown.Value);
            factura.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedValue);
            factura.Fecha = FechaDateTimePicker.Value;
            factura.SubTotal = Convert.ToSingle(SubTotalTextBox.Text);
            factura.Itbis = Convert.ToSingle(ItbisTextBox.Text);
            factura.Total = Convert.ToSingle(TotalTextBox.Text);

            foreach (DataGridViewRow item in FacturaDetalleDataGridView.Rows)
            {
                factura.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["FacturaId"].Value),
                    ToInt(item.Cells["ClienteId"].Value),
                    ToInt(item.Cells["ProductoId"].Value),
                    ToDouble(item.Cells["Cantidad"].Value),
                    ToDouble(item.Cells["Precio"].Value),
                    ToDouble(item.Cells["Importe"].Value)
                );
            }

            FacturaDetalleDataGridView.Columns["Id"].Visible = false;
            FacturaDetalleDataGridView.Columns["FacturaId"].Visible = false;

            return factura;
        }

        private void LimpiaObjetos()
        {
            FacturaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ClienteComboBox.SelectedIndex = 0;
            ProductoComboBox.SelectedIndex = 0;
            CantidadTextBox.Clear();
            PrecioTextBox.Clear();
            ImporteTextBox.Clear();
            FacturaDetalleDataGridView.DataSource = null;
            SubTotalTextBox.Clear();
            ItbisTextBox.Clear();
            TotalTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        private void FormatoMoneda(object sender, ConvertEventArgs e)
        {
            double valor = 0;
            double.TryParse(e.Value.ToString(), out valor);
            e.Value = valor.ToString("#,##.00;(#,##.00);0.00");
        }

        private void CambiarPrecio()
        {
            PrecioTextBox.DataBindings.Clear();
            Binding doBinding = new Binding("Text", ProductoComboBox.DataSource, "Precio");
            doBinding.Format += new ConvertEventHandler(FormatoMoneda);
            PrecioTextBox.DataBindings.Add(doBinding);
        }

        private void LlenarPrecio()
        {
            List<Producto> ListProductos = ProductoBLL.GetList(c => c.Descripcion == ProductoComboBox.Text);
            foreach (var item in ListProductos)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenarImporte()
        {
            double cantidad, precio;

            cantidad = ToDouble(CantidadTextBox.Text);
            precio = ToDouble(PrecioTextBox.Text);
            ImporteTextBox.Text = FacturaBLL.Importe(cantidad, precio).ToString();
        }

        private void LlenarValores()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            double Total = 0;
            double Itbis = 0;
            double SubTotal = 0;
            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private void RebajarValores()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            double Total = 0;
            double Itbis = 0;
            double SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = Total * 0.18f;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItbisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private bool ContarCantidadInventario()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)FacturaDetalleDataGridView.DataSource;
            }

            Repositorio<Producto> repositorio = new Repositorio<Producto>(new Contexto());

            Producto producto = (Producto)ProductoComboBox.SelectedItem;

            double CantidadCotizada = 0;
            foreach (var item in detalle)
            {
                CantidadCotizada += item.Cantidad;
            }

            double CantidadProducto = producto.CantidadIventario;

            bool paso = false;

            if (Convert.ToInt32(CantidadTextBox.Text) > producto.CantidadIventario)
            {
                MyErrorProvider.SetError(CantidadTextBox, "Error");
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Falló!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            CantidadProducto -= CantidadCotizada;

            if (CantidadProducto < CantidadCotizada)
            {
                MessageBox.Show($"Solo quedan {CantidadProducto} del articulo deseado!!", "Articulo Agotado!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            return paso;
        }


        private bool HayErrores()
        {
            bool HayErrores = false;

            if (FacturaDetalleDataGridView.RowCount == 0)
            {
                MyErrorProvider.SetError(FacturaDetalleDataGridView,
                    "Debe Agregar los Productos ");
                HayErrores = true;
            }

            return HayErrores;
        }

        //Programación de los Botones
        private void AgregarButtton_Click(object sender, EventArgs e)
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (FacturaDetalleDataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)FacturaDetalleDataGridView.DataSource;
            }
            if (ContarCantidadInventario())
            {
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (CantidadTextBox.Text == "0")
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
                    new FacturaDetalle(
                       id: 0,
                       facturaId: (int)FacturaIdNumericUpDown.Value,
                       clienteId: (int)ClienteComboBox.SelectedValue,
                       productoId: (int)ProductoComboBox.SelectedValue,
                       cantidad: (double)Convert.ToDouble(CantidadTextBox.Text),
                       precio: (double)Convert.ToDouble(PrecioTextBox.Text),
                       importe: (double)Convert.ToDouble(ImporteTextBox.Text)
               ));

                FacturaDetalleDataGridView.DataSource = null;
                FacturaDetalleDataGridView.DataSource = detalle;

                LlenarValores();
            }
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (FacturaDetalleDataGridView.Rows.Count > 0 && FacturaDetalleDataGridView.CurrentRow != null)
            {
                List<FacturaDetalle> detalle = (List<FacturaDetalle>)FacturaDetalleDataGridView.DataSource;

                detalle.RemoveAt(FacturaDetalleDataGridView.CurrentRow.Index);

                FacturaDetalleDataGridView.DataSource = null;
                FacturaDetalleDataGridView.DataSource = detalle;

                RebajarValores();
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(FacturaIdNumericUpDown.Value);
            Factura factura = FacturaBLL.Buscar(id);

            if (factura != null)
            {
                LlenaCampos(factura);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Factura factura;
            bool Paso = false;

            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            factura = LlenaClase();

            if (FacturaIdNumericUpDown.Value == 0)
                Paso = FacturaBLL.Guardar(factura);
            else
            {
                int id = Convert.ToInt32(FacturaIdNumericUpDown.Value);
                Factura fac = FacturaBLL.Buscar(id);

                if (factura != null)
                {
                    Paso = FacturaBLL.Modificar(LlenaClase());
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                NuevoButton.PerformClick();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(FacturaIdNumericUpDown.Value);

            Factura factura = FacturaBLL.Buscar(id);

            if (factura != null)
            {
                if (FacturaBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiaObjetos();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Eventos de los Botones
        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se puede digitar Números", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            CambiarPrecio();
            LlenarImporte();
        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarPrecio();
            if (CantidadTextBox.Text != "0")
            {
                LlenarImporte();
            }
            CambiarPrecio();
        }
    }
}
