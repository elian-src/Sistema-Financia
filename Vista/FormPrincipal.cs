using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private Form openForm = null;

        public void OpenForm(Form form)
        {
            if (openForm != null)
            {
                this.panel3.Controls.Remove(openForm);
                openForm.Close();
            }

            openForm = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Tag = panel3.Tag;
            form.TopLevel = false;

            panel3.Controls.Add(form);
            panel3.BringToFront();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegPrestamo f = new RegPrestamo();
            OpenForm(f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistroCliente f = new RegistroCliente();
            OpenForm(f);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnMinimizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnMinimizar.Visible = false;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
