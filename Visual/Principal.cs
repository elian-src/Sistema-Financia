using System;
using System.Windows.Forms;

namespace Visual
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "admin" && txtContraseña.Text == "0000")
            {
                RegistroCliente frmReg = new RegistroCliente();
                this.Hide();
                frmReg.Show();
            }
            else if (txtUsuario.Text == "JuanitoHernd" && txtContraseña.Text == "1234")
            {
                RegistroCliente frmReg = new RegistroCliente();
                this.Hide();
                frmReg.Show();
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
