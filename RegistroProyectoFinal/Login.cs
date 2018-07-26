using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroProyectoFinal
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EntrarButton_Click(object sender, EventArgs e)
        {
            //SqlConnection conexion = new SqlConnection("Data Source = LAPTOP-YOJAIRI; Initial Catalog = FinalDb; "
            //  + "Integrated Security=true;");

            //conexion.Open();
            //string cadena = "select Email, Contraseña from Usuarios where Email ='" + EmailTextBox.Text + "' and Contraseña = '" + ContraseñaTextBox.Text + "' ";
            //SqlCommand comando = new SqlCommand(cadena, conexion);
            //SqlDataReader registro = comando.ExecuteReader();
            //if (registro.Read())
            //{

            //    if (registro["Email"].ToString() == EmailTextBox.Text && registro["Contraseña"].ToString() == ContraseñaTextBox.Text)
            //    {
            //        MessageBox.Show("Correcto");
            //        Principal principal = new Principal();
            //        principal.Show();
            //        this.Hide();
            //    }
            //}
            //else
            //    MessageBox.Show("El Email o la Contraseña estan incorrectos", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //conexion.Close();

            Principal principal = new Principal();
            principal.Show();
            this.Hide();
        }
    }
}
