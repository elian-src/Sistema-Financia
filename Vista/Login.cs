using System;
using System.Runtime.InteropServices;
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnMinimizar.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnMinimizar.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
