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
    public partial class ConsultarUsuario : Form
    {
        public ConsultarUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuario, bool>> filtro = u => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Usuario.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = u => u.UsuarioId == id;
                    break;
                case 1://Filtrando por Nombres del Usuario.
                    filtro = u => u.Nombres.Contains(CriterioTextBox.Text);
                    break;
                case 2://Filtrando por NoTelefono del Usuario.
                    filtro = u => u.NoTelefono.Equals(CriterioTextBox.Text);
                    break;
                case 3://Filtrando por Email del Usuario.
                    filtro = u => u.Email.Equals(CriterioTextBox.Text);
                    break;
                case 5://Filtrando por Contraseña del Usuario.
                    filtro = u => u.Contraseña.Equals(CriterioTextBox.Text);
                    break;
            }

            UsuarioConsultaDataGridView.DataSource = UsuarioBLL.GetList(filtro);
        }
    }
}
