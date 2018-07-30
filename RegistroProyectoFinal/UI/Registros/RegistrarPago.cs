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

namespace RegistroProyectoFinal.UI.Registros
{
    public partial class RegistrarPago : Form
    {
        public RegistrarPago()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        //Métodos
        private void LlenarComboBox()
        {
            Repositorio<Cliente> CliRepositorio = new Repositorio<Cliente>(new Contexto());

            ClienteComboBox.DataSource = CliRepositorio.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";
        }

        private Pago LlenaClase()
        {
            Pago pago = new Pago();

            pago.PagoId = Convert.ToInt32(PagoIdNumericUpDown.Value);
            pago.Fecha = FechaDateTimePicker.Value;
            pago.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedValue);
            pago.MontoPago = Convert.ToDouble(MontoTextBox.Text);

            return pago;
        }        

        private void LimpiarObjetos()
        {
            PagoIdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            ClienteComboBox.SelectedIndex = 0;
            MontoTextBox.Clear();
            MyErrorProvider.Clear();
        }

        private bool HayErrores()
        {
            bool paso = false;

            if (String.IsNullOrEmpty(MontoTextBox.Text))
            {
                MyErrorProvider.SetError(MontoTextBox,
                    "Debe ingresar un Monto para el Pago");
                paso = true;
            }

            return paso;
        }

        //Programación de los Botones
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PagoIdNumericUpDown.Value);
            Pago pago = PagoBLL.Buscar(id);

            if (pago != null)
            {
                FechaDateTimePicker.Value = pago.Fecha;
                ClienteComboBox.SelectedValue = pago.ClienteId;
                MontoTextBox.Text = pago.MontoPago.ToString();
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            LimpiarObjetos();
        }

        public  bool Monto(Pago pago)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            int MontoActual = Convert.ToInt32(MontoTextBox.Text);
            int MontoAnterior = Convert.ToInt32(contexto.Cliente.Find(pago.ClienteId).Deuda);

            if (MontoActual > MontoAnterior)
            {
                MessageBox.Show($"La deuda del cliente es de {MontoAnterior}");
                paso = true;
            }
            return paso;
        }

        public bool MontoModifi(Pago pago)
        {
            Pago PagoAnt = PagoBLL.Buscar(pago.PagoId);
            Contexto contexto = new Contexto();
            bool paso = false;

             if (PagoAnt.ClienteId == pago.ClienteId)
             {
                if (pago.MontoPago > PagoAnt.MontoPago)
                {
                    MessageBox.Show($"La deuda del cliente es de {PagoAnt.MontoPago}");
                    MessageBox.Show("Ingrese la cantidad correcta");
                    paso = true;
                }

                return paso;
             }

            int MontoActual = Convert.ToInt32(MontoTextBox.Text);
            int MontoAnterior = Convert.ToInt32(contexto.Cliente.Find(pago.ClienteId).Deuda);

            if (MontoActual > MontoAnterior)
            {
                MessageBox.Show($"La deuda del cliente es de {MontoAnterior}");
                paso = true;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            Pago pago;
            bool paso = false;

            if (HayErrores())
                MessageBox.Show("Debe llenar los campos indicados", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            

            pago = LlenaClase();

            if (Monto(pago))
            {
                MessageBox.Show("Cantidad Mayor", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (PagoIdNumericUpDown.Value == 0)
                {
                    paso = PagoBLL.Guardar(pago);
                    MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    int id = Convert.ToInt32(PagoIdNumericUpDown.Value);
                    pago = PagoBLL.Buscar(id);

                    if (pago != null)
                    {
                        MontoModifi(pago);
                        paso = PagoBLL.Modificar(LlenaClase());
                        MessageBox.Show("Modificado", "Exito",
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
            
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PagoIdNumericUpDown.Value);

            Pago pago = PagoBLL.Buscar(id);
            if (pago != null)
            {
                if (PagoBLL.Eliminar(id))
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
        private void MontoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
