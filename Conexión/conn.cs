using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Conexión
{
    public class Connec
    {
        public Connec() { }

        private string connestr = "Server=localhost; database=BdFinanzas; Integrated Security=True";

        public void savePrestamo(string IDCliente, string Monto, string Interes, string Fecha)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "INSERT INTO Prestamo (IDCliente, Monto, Interes, Fecha) VALUES (@IDCliente, @Monto, @Interes, Fecha)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                    cmd.Parameters.AddWithValue("@Monto", Monto);
                    cmd.Parameters.AddWithValue("@Interes", Interes);
                    cmd.Parameters.AddWithValue("@Fecha", Fecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void saveCliente(string Nombre, string Apellido, string Telefono, string Direccion, string Garantia, string Correo, string Salario)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "INSERT INTO Cliente (Nombre, Apellido, Telefono, Direccion, Garantia, Correo, Salario) VALUES (@Nombre, @Apellido, @Telefono, @Direccion, @Garantia, @Correo, @Salario)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Garantia", Garantia);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Salario", Salario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void getIDCliente(string Nombre, string Apellido)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "SELECT IDCliente FROM Clientes WHERE Nombre=@Nombre AND Apellido=@Apellido";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Apellido);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public decimal getSueldoCliente(int id)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "SELECT Sueldo FROM Clientes WHERE IDCliente=@id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader r = cmd.ExecuteReader()) {
                        decimal Sueldo = 0;

                        if (r.Read()) {
                            Sueldo = r.GetDecimal(0);
                        }
                        return Sueldo;

                    }
                }
            }
        }
    }   
}
