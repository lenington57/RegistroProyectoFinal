﻿using System;
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
    public partial class ConsultarCliente : Form
    {
        public ConsultarCliente()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Cliente, bool>> filtro = c => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Cliente.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = c => c.ClienteId == id;
                    break;
                case 1://Filtrando por Nombres del Cliente.
                    filtro = c => c.Nombres.Contains(CriterioTextBox.Text);
                    break;
                case 2://Filtrando por NoTelefono del Cliente.
                    filtro = c => c.NoTelefono.Equals(CriterioTextBox.Text);
                    break;
                case 3://Filtrando por NoCedula del Cliente.
                    filtro = c => c.NoCedula.Equals(CriterioTextBox.Text);
                    break;
                case 4://Filtrando por Direccion del Cliente.
                    filtro = c => c.Direccion.Equals(CriterioTextBox.Text);
                    break;
                case 5://Filtrando por Deuda del Cliente.
                    filtro = c => c.Deuda.Equals(CriterioTextBox.Text);
                    break;
            }

            ClienteConsultaDataGridView.DataSource = ClienteBLL.GetList(filtro);
        }
    }
}
