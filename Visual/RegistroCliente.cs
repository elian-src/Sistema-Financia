﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void bRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
        string.IsNullOrWhiteSpace(txtApellido.Text) ||
        string.IsNullOrWhiteSpace(txtTel.Text) ||
        string.IsNullOrWhiteSpace(txtDir.Text) ||
        string.IsNullOrWhiteSpace(txtGarantía.Text) ||
        string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Rellene todos los campos");
            }  

            else
            {
                MessageBox.Show("Registro completado con exito");
            }
              
        }
        
    }
}
