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
    public partial class ConsultarFacturacion : Form
    {
        public ConsultarFacturacion()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Factura, bool>> filtro = f => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID de la Factura.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = f => f.FacturaId == id;
                    break;
                case 1://Filtrando por la Fecha de la Factura.
                    filtro = f => f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date;
                    break;
                case 2://Filtrando por UsuarioId de la Factura.
                    filtro = f => f.UsuarioId.Equals(CriterioTextBox.Text) && (f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 3://Filtrando por ClienteId de la Factura.
                    filtro = f => f.ClienteId.Equals(CriterioTextBox.Text) && (f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 4://Filtrando por SubTotal de la Factura.
                    filtro = f => f.SubTotal.Equals(CriterioTextBox.Text) && (f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 5://Filtrando por Cantidad Itbis de la Factura.
                    filtro = f => f.Itbis.Equals(CriterioTextBox.Text) && (f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 6://Filtrando por Total de la Factura.
                    filtro = f => f.Total.Equals(CriterioTextBox.Text) && (f.Fecha >= DesdeDateTimePicker.Value.Date && f.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
            }

            FacturaConsultaDataGridView.DataSource = FacturaBLL.GetList(filtro);
        }

        private void FiltroComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltroComboBox.SelectedIndex == 1)
            {
                CriterioTextBox.Visible = false;
                CriterioLabel.Visible = false;
            }
            else
            {
                CriterioTextBox.Visible = true;
                CriterioLabel.Visible = true;
            }
        }
    }
}
