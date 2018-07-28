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
using RegistroProyectoFinal.UI.Reportes;

namespace RegistroProyectoFinal.UI.Consultas
{
    public partial class ConsultarEntradas : Form
    {
        private List<Entradas> entradas = new List<Entradas>();

        public ConsultarEntradas()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Entradas, bool>> filtro = ea => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID de la Entrada.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = ea => ea.EntradaId == id;
                    break;
                case 1://Filtrando por la Fecha de la Entrada.
                    filtro = ea => ea.Fecha >= DesdeDateTimePicker.Value.Date && ea.Fecha <= HastaDateTimePicker.Value.Date;
                    break;
                case 2://Filtrando por Nombre del Producto.
                    filtro = ea => ea.ProductoId.Equals(CriterioTextBox.Text) && (ea.Fecha >= DesdeDateTimePicker.Value.Date && ea.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 3://Filtrando por Cantidad de Entrada del Producto.
                    filtro = ea => ea.Cantidad.Equals(CriterioTextBox.Text) && (ea.Fecha >= DesdeDateTimePicker.Value.Date && ea.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
            }

            entradas = EntradasBLL.GetList(filtro);
            EntradasConsultaDataGridView.DataSource = entradas;
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

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            if (entradas.Count == 0)
            {
                MessageBox.Show("No hay datos pra mostrar en el Reporte");
                return;
            }
            EntradasReviewer entradasReviewer = new EntradasReviewer(entradas);
            entradasReviewer.ShowDialog();
        }
    
    }
}
