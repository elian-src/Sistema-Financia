using System;
using System.Windows.Forms;
using Conexión;

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
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTel.Text) ||
                string.IsNullOrWhiteSpace(txtDir.Text) ||
                string.IsNullOrWhiteSpace(txtGarantía.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el salario sea un número válido
            if (!decimal.TryParse(txtSalario.Text, out decimal salario))
            {
                MessageBox.Show("El salario debe ser un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear conexión y llamar al método saveCliente
            Connec connec = new Connec();
            bool registroExitoso = connec.saveCliente(
                txtNombre.Text,
                txtApellido.Text,
                txtTel.Text,
                txtDir.Text,
                txtGarantía.Text,
                txtCorreo.Text,
                salario // El salario ya está convertido a decimal
            );

            if (registroExitoso)
            {
                MessageBox.Show("Registro realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para validar un correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTel.Clear();
            txtDir.Clear();
            txtGarantía.Clear();
            txtCorreo.Clear();
            txtSalario.Clear();
        }

        private void RegistroCliente_Load(object sender, EventArgs e)
        {
        }
    }
}
