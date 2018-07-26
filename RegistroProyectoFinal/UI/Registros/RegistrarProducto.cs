using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroProyectoFinal.Entidades;
using RegistroProyectoFinal.BLL;
using RegistroProyectoFinal.DAL;

namespace RegistroProyectoFinal.UI.Registro
{
    public partial class RegistrarProducto : Form
    {
        public RegistrarProducto()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        //Métodos
        private void LlenarComboBox()
        {
            Repositorio<Departamento> DepRepositorio = new Repositorio<Departamento>(new Contexto());

            DepartamentoComboBox.DataSource = DepRepositorio.GetList(c => true);
            DepartamentoComboBox.ValueMember = "DepartamentoId";
            DepartamentoComboBox.DisplayMember = "Nombre";
        }

        private Producto LlenaClase()
        {
            Producto producto = new Producto();

            producto.ProductoId = Convert.ToInt32(ProductoIdNumericUpDown.Value);
            producto.DepartamentoId = Convert.ToInt32(DepartamentoComboBox.SelectedValue);
            producto.FechaVencimiento = FechaDateTimePicker.Value;
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = Convert.ToDouble(CostoTextBox.Text);
            producto.Precio = Convert.ToDouble(PrecioTextBox.Text);
            producto.PorCientoGanancia = Convert.ToDouble(PctGananciaTextBox.Text);
            producto.CantidadIventario = 0;

            return producto;
        }

        private void LimpiarObjetos()
        {
            ProductoIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            DepartamentoComboBox.SelectedIndex = 0;
            DescripcionTextBox.Clear();
            CostoTextBox.Clear();
            PrecioTextBox.Clear();
            PctGananciaTextBox.Clear();
            InventarioTextBox.Clear();
        }

        private double ToDouble(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        private void CalcularGanancia()
        {
            double costo, precio;
            costo = ToDouble(CostoTextBox.Text);
            precio = ToDouble(PrecioTextBox.Text);
            PctGananciaTextBox.Text = ProductoBLL.PorcientoGanancia(costo, precio).ToString();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                MyErrorProvider.SetError(DescripcionTextBox,
                    "Debe escribir una Descripción para el Producto");
                paso = true;
            }
            if (String.IsNullOrEmpty(CostoTextBox.Text))
            {
                MyErrorProvider.SetError(CostoTextBox,
                    "Debe ingresar un Costo para el Producto");
                paso = true;
            }
            if (String.IsNullOrEmpty(PrecioTextBox.Text))
            {
                MyErrorProvider.SetError(PrecioTextBox,
                    "Debe ingresar un Precio para el Producto");
                paso = true;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ProductoIdNumericUpDown.Value);
            Producto producto = ProductoBLL.Buscar(id);

            if (producto != null)
            {
                DepartamentoComboBox.SelectedValue = producto.DepartamentoId;
                DescripcionTextBox.Text = producto.Descripcion;
                CostoTextBox.Text = producto.Costo.ToString();
                PrecioTextBox.Text = producto.Precio.ToString();
                PctGananciaTextBox.Text = producto.PorCientoGanancia.ToString();
                InventarioTextBox.Text = producto.CantidadIventario.ToString();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Producto producto;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            producto = LlenaClase();

            if (ProductoIdNumericUpDown.Value == 0)
                paso = ProductoBLL.Guardar(producto);
            else
            {
                int id = Convert.ToInt32(ProductoIdNumericUpDown.Value);
                producto = ProductoBLL.Buscar(id);

                if (producto != null)
                {
                    paso = ProductoBLL.Modificar(LlenaClase());
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarObjetos();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ProductoIdNumericUpDown.Value);

            Producto producto = ProductoBLL.Buscar(id);
            if (producto != null)
            {
                if (ProductoBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarObjetos();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Eventos de los Objetos
        private void RegistrarProducto_Load(object sender, EventArgs e)
        {

        }

        private void CostoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PrecioTextBox.Text != string.Empty)
            {
                CalcularGanancia();
            }
        }

        private void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PrecioTextBox.Text != string.Empty)
            {
                CalcularGanancia();
            }
        }

        private void CostoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
