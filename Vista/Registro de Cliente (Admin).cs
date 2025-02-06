using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Vista
{
    public partial class RegistroCliente : Form
    {
        public RegistroCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtTel.Text) ||
                    string.IsNullOrWhiteSpace(txtDir.Text) ||
                    string.IsNullOrWhiteSpace(txtGarantía.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtSalario.Text))
                    {
                        MessageBox.Show("Rellene todos los campos.");
                
                    }
            if (string.IsNullOrWhiteSpace(txtGarantía.Text))
            {
                MessageBox.Show("Ingrese una garantía valida.");
            }
            else
            {
                Cliente add = new Cliente("", "", "", "", "", "", "");
                add.saveCliente();
                MessageBox.Show("Registro completado con éxito.");
                
            }
        }
    }
}
