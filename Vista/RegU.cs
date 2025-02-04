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
    public partial class RegU : Form
    {
        public RegU()
        {
            InitializeComponent();
        }

        private void btnRegistrar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Rellene todos los campos.");

            }
            else
            {
                Add add = new Add("", "", "");
                add.saveAdd();
                MessageBox.Show("Registro completado con éxito.");

            }
        }
    }
}
