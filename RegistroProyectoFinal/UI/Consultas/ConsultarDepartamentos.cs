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
    public partial class ConsultarDepartamentos : Form
    {
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

            DepartamentoConsultaDataGridView.DataSource = DepartamentoBLL.GetList(filtro);
        }
    }
}
