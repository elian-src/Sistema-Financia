using Conexión;
using Logica;
using System.Windows.Forms;
using System;

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
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text, out int idCliente) ||
                !decimal.TryParse(textBox2.Text, out decimal monto) ||
                !decimal.TryParse(textBox3.Text, out decimal interes) ||
                !int.TryParse(textBox4.Text, out int duracion))
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Connec connec = new Connec();
            bool registroExitoso = connec.savePrestamo(idCliente, monto, interes, duracion);

            if (registroExitoso)
            {
                MessageBox.Show("Préstamo registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar el préstamo. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!decimal.TryParse(textBox2.Text, out decimal montoSolicitado))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            if (!int.TryParse(textBox4.Text, out int duracionMeses))
            {
                MessageBox.Show("Ingrese la duración del préstamo en meses.");
                return;
            }

            Connec con = new Connec();
            decimal sueldo = con.getSueldoCliente(idCliente);
            decimal maxPrestamo = sueldo * 4;

            if (montoSolicitado > maxPrestamo)
            {
                MessageBox.Show($"El préstamo solicitado excede el límite permitido.\nMáximo permitido: {maxPrestamo:C}");
                return;
            }

            decimal porcentajeInteres = CalcularInteres(duracionMeses);
            decimal interesCalculado = montoSolicitado * porcentajeInteres;

            Prestamo prestamo = new Prestamo(
                idCliente,
                montoSolicitado,
                interesCalculado,
                duracionMeses
            );
            prestamo.savePrestamo();
            MessageBox.Show($"Préstamo registrado con éxito.\nInterés aplicado: {porcentajeInteres * 100}%");
        }
    }
}