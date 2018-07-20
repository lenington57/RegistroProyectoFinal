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
    public partial class RegistrarCliente : Form
    {
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        //Métodos
        private Cliente LlenaClase()
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = Convert.ToInt32(ClienteIdNumericUpDown.Value);
            cliente.Nombres = NombresTextBox.Text;
            cliente.NoTelefono = NoTelefonoMaskedTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;

            return cliente;
        }

        private void LimpiarObjetos()
        {
            ClienteIdNumericUpDown.Value = 0;
            NombresTextBox.Clear();
            NoTelefonoMaskedTextBox.Clear();
            DireccionTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, 
                    "Debe ingresar el Nombre Completo para el cliente");
                paso = true;
            }
            if (String.IsNullOrEmpty(NoTelefonoMaskedTextBox.Text))
            {
                MyErrorProvider.SetError(NoTelefonoMaskedTextBox,
                    "Debe ingresar el Número de Teléfono para el cliente");
                paso = true;
            }
            if (String.IsNullOrEmpty(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox,
                    "Debe ingresar la Dirección para el cliente");
                paso = true;
            }

            return paso;
        }

        //Programación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ClienteIdNumericUpDown.Value);
            Cliente cliente = ClienteBLL.Buscar(id);

            if (cliente != null)
            {
                NombresTextBox.Text = cliente.Nombres;
                NoTelefonoMaskedTextBox.Text = cliente.NoTelefono;
                DireccionTextBox.Text = cliente.Direccion;
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Cliente cliente;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados","Validación",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);

            cliente = LlenaClase();

            if (ClienteIdNumericUpDown.Value == 0)
                paso = ClienteBLL.Guardar(cliente);
            else
            {
                int id = Convert.ToInt32(ClienteIdNumericUpDown.Value);
                cliente = ClienteBLL.Buscar(id);

                if (cliente != null)
                {
                    paso = ClienteBLL.Modificar(LlenaClase());
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
            int id = Convert.ToInt32(ClienteIdNumericUpDown.Value);

            Cliente cliente = ClienteBLL.Buscar(id);
            if (cliente != null)
            {
                if (ClienteBLL.Eliminar(id))
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

        //Eventos de los Objetos(click sin querer)
        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
