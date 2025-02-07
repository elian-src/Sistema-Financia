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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Conexión;

namespace Vista
{


    public partial class RegPrestamo : Form
    {
        private decimal CalcularInteres(int meses)
        {
            if (meses >= 1 && meses <= 3)
                return 0.10m; // 10%
            else if (meses >= 4 && meses <= 6)
                return 0.08m; // 8%
            else if (meses >= 7 && meses <= 12)
                return 0.07m; // 7%
            else if (meses > 12)
                return 0.05m; // 5%
            else
                throw new ArgumentException("Duración del préstamo inválida.");
        }

        public RegPrestamo()
        {
            InitializeComponent();
        }

        private void btnRegistrar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Rellene todos los campos.");
                return;
            }

            // Obtener el ID del cliente desde textBox1
            if (!int.TryParse(textBox1.Text, out int idCliente))
            {
                MessageBox.Show("Ingrese un ID de cliente válido.");
                return;
            }

            // Crear instancia de conexión y obtener el sueldo del cliente
            Connec con = new Connec();
            decimal sueldo = con.getSueldoCliente(idCliente);
            decimal maxPrestamo = sueldo * 4;

            // Obtener el monto ingresado
            if (!decimal.TryParse(textBox2.Text, out decimal montoSolicitado))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            // Validar la regla de negocio
            if (montoSolicitado > maxPrestamo)
            {
                MessageBox.Show($"El préstamo solicitado excede el límite permitido.\nMáximo permitido: {maxPrestamo:C}");
                return;
            }

            // Si todo está correcto, registrar el préstamo
            Prestamo add = new Prestamo(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            add.savePrestamo();
            MessageBox.Show("Registro de préstamo completado con éxito.");

        }

        private void btnRegistrar2_Click_1(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Rellene todos los campos.");
                    return;
                }

                // Obtener IDCliente
                if (!int.TryParse(textBox1.Text, out int idCliente))
                {
                    MessageBox.Show("Ingrese un ID de cliente válido.");
                    return;
                }

                // Obtener monto solicitado
                if (!decimal.TryParse(textBox2.Text, out decimal montoSolicitado))
                {
                    MessageBox.Show("Ingrese un monto válido.");
                    return;
                }

                // Obtener duración en meses
                if (!int.TryParse(textBox4.Text, out int duracionMeses))
                {
                    MessageBox.Show("Ingrese la duración del préstamo en meses.");
                    return;
                }

                // Verificar sueldo del cliente y validar monto
                Connec con = new Connec();
                decimal sueldo = con.getSueldoCliente(idCliente);
                decimal maxPrestamo = sueldo * 4;

                if (montoSolicitado > maxPrestamo)
                {
                    MessageBox.Show($"El préstamo solicitado excede el límite permitido.\nMáximo permitido: {maxPrestamo:C}");
                    return;
                }

                // Calcular interés según la duración
                decimal porcentajeInteres = CalcularInteres(duracionMeses);
                decimal interesCalculado = montoSolicitado * porcentajeInteres;

                // Registrar el préstamo
                Prestamo prestamo = new Prestamo(
                    textBox1.Text,
                    montoSolicitado.ToString(),
                    interesCalculado.ToString(),
                    textBox4.Text
                );
                prestamo.savePrestamo();
                MessageBox.Show($"Préstamo registrado con éxito.\nInterés aplicado: {porcentajeInteres * 100}%");
            }
        }
    }
}