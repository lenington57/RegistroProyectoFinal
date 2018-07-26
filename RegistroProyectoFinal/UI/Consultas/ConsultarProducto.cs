using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using RegistroProyectoFinal.BLL;
using RegistroProyectoFinal.Entidades;

namespace RegistroProyectoFinal.UI.Consultas
{
    public partial class ConsultarProducto : Form
    {
        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Producto, bool>> filtro = p => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Producto.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = p => p.ProductoId == id;
                    break;
                case 1://Filtrando por la Descripcion del Producto.
                    filtro = p => p.Descripcion.Contains(CriterioTextBox.Text);
                    break;
                case 2://Filtrando por Costo del Producto.
                    filtro = p => p.Costo.Equals(CriterioTextBox.Text);
                    break;
                case 3://Filtrando por Precio del Producto.
                    filtro = p => p.Precio.Equals(CriterioTextBox.Text);
                    break;
                case 4://Filtrando por PorcientoGanacia del Producto.
                    filtro = p => p.PorCientoGanancia.Equals(CriterioTextBox.Text);
                    break;
                case 5://Filtrando por Cantidad en el Inventario del Producto.
                    filtro = p => p.CantidadIventario.Equals(CriterioTextBox.Text);
                    break;
            }

            ProductoConsultaDataGridView.DataSource = ProductoBLL.GetList(filtro);
        }
    }
}
