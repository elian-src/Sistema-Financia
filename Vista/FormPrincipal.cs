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
                this.panel2.Controls.Remove(openForm);
                openForm.Close();
            }

            openForm = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Tag = panel2.Tag;
            form.TopLevel = false;

            panel2.Controls.Add(form);
            panel2.BringToFront();
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
    }
}
