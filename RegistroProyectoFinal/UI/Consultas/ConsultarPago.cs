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
    public partial class ConsultarPago : Form
    {
        public ConsultarPago()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            Expression<Func<Pago, bool>> filtro = pa => true;
            int id;
            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Filtrando por ID del Pago.
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = pa => pa.PagoId == id;
                    break;
                case 1://Filtrando por la Fecha del Pago.
                    filtro = pa => pa.Fecha >= DesdeDateTimePicker.Value.Date && pa.Fecha <= HastaDateTimePicker.Value.Date;
                    break;
                case 2://Filtrando por Nombre del CLiente.
                    filtro = pa => pa.ClienteId.Equals(CriterioTextBox.Text) && (pa.Fecha >= DesdeDateTimePicker.Value.Date && pa.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
                case 3://Filtrando por MontoPago del Pago.
                    filtro = pa => pa.MontoPago.Equals(CriterioTextBox.Text) && (pa.Fecha >= DesdeDateTimePicker.Value.Date && pa.Fecha <= HastaDateTimePicker.Value.Date);
                    break;
            }

            PagoConsultaDataGridView.DataSource = PagoBLL.GetList(filtro);
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
