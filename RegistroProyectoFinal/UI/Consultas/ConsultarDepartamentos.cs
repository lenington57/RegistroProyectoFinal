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
    public partial class ConsultarDepartamentos : Form
    {
        private List<Departamento> departamentos = new List<Departamento>();

        public ConsultarDepartamentos()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Departamento, bool>> filtro = d => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Departamento.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = d => d.DepartamentoId == id;
                    break;
                case 1://Filtrando por Nombre del Departamento.
                    filtro = d => d.Nombre.Contains(CriterioTextBox.Text);
                    break;
            }

            departamentos = DepartamentoBLL.GetList(filtro);
            DepartamentoConsultaDataGridView.DataSource = departamentos;
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            if (departamentos.Count == 0)
            {
                MessageBox.Show("No hay datos pra mostrar en el Reporte");
                return;
            }
            DepartamentosReviewer departamentosReviewer = new DepartamentosReviewer(departamentos);
            departamentosReviewer.ShowDialog();
        }
    }
}
