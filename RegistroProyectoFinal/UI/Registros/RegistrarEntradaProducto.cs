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
    public partial class RegistrarEntradaProducto : Form
    {
        public RegistrarEntradaProducto()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        //Métodos
        private void LlenarComboBox()
        {
            Repositorio<Producto> ArtRepositorio = new Repositorio<Producto>(new Contexto());

            ProductoComboBox.DataSource = ArtRepositorio.GetList(c => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";
        }

        private Entradas LlenaClase()
        {
            Entradas entrada = new Entradas();

            entrada.EntradaId = Convert.ToInt32(EntradaIdNumericUpDown.Value);
            entrada.Fecha = FechaDateTimePicker.Value;
            entrada.ProductoId = Convert.ToInt32(ProductoComboBox.SelectedValue);
            entrada.Cantidad = Convert.ToDouble(CantidadTextBox.Text);

            return entrada;
        }

        private void LimpiarObjetos()
        {
            EntradaIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ProductoComboBox.SelectedIndex = 0; ;
            CantidadTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(CantidadTextBox.Text))
            {
                MyErrorProvider.SetError(CantidadTextBox,
                    "Debe digitar un Cantidad de Entrada para el Producto");
                paso = true;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
           Entradas entrada = EntradasBLL.Buscar(id);

            if (entrada != null)
            {
                FechaDateTimePicker.Value = entrada.Fecha;
                ProductoComboBox.SelectedValue = entrada.ProductoId;
                CantidadTextBox.Text = entrada.Cantidad.ToString();
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Entradas entrada;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            entrada = LlenaClase();

            if (EntradaIdNumericUpDown.Value == 0)
            {
                paso = EntradasBLL.Guardar(entrada);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                
            else
            {
                int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);
                entrada = EntradasBLL.Buscar(id);

                if (entrada != null)
                {
                    paso = EntradasBLL.Modificar(LlenaClase());
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                LimpiarObjetos();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaIdNumericUpDown.Value);

            Entradas entrada = EntradasBLL.Buscar(id);
            if (entrada != null)
            {
                if (EntradasBLL.Eliminar(id))
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
    }
}
