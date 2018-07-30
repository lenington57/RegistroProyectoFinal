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

namespace RegistroProyectoFinal.UI.Registros
{
    public partial class RegistrarDepartamento : Form
    {
        public RegistrarDepartamento()
        {
            InitializeComponent();
        }

        //Métodos
        private Departamento LlenaClase()
        {
            Departamento departamento = new Departamento();

            departamento.DepartamentoId = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
            departamento.Nombre = NombreTextBox.Text;

            return departamento;
        }

        private void LimpiarObjetos()
        {
            DepartamentoIdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(NombreTextBox.Text))
            {
                MyErrorProvider.SetError(NombreTextBox,
                    "Debe escribir el Nombre para el Departamento");
                paso = true;
            }

            return paso;
        }

        //Progrmación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
            Departamento departamento = DepartamentoBLL.Buscar(id);

            if (departamento != null)
            {
                NombreTextBox.Text = departamento.Nombre;
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Departamento departamento;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            departamento = LlenaClase();

            if (DepartamentoIdNumericUpDown.Value == 0)
            {
                paso = DepartamentoBLL.Guardar(departamento);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);
                departamento = DepartamentoBLL.Buscar(id);

                if (departamento != null)
                {
                    paso = DepartamentoBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(DepartamentoIdNumericUpDown.Value);

            Departamento departamento = DepartamentoBLL.Buscar(id);
            if (departamento != null)
            {
                if (DepartamentoBLL.Eliminar(id))
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

        //Click sin querer
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarDepartamento_Load(object sender, EventArgs e)
        {

        }
    }
}
