﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin" && txtContraseña.Text == "0000")
            {
                FormPrincipal frmRegC = new FormPrincipal();
                this.Hide();
                frmRegC.button1.Visible = true;
                frmRegC.Show();
            }
            else if (txtUsuario.Text == "JuanitoHernz" && txtContraseña.Text == "1234")
            {
                FormPrincipal frmU = new FormPrincipal();
                this.Hide();
                frmU.button1.Visible = false;
                frmU.Show();
            }
            else 
            {
                MessageBox.Show("Los datos ingresados son incorrectos.");
                txtUsuario.Clear();
                txtContraseña.Clear();
            }
        }
    }
}
