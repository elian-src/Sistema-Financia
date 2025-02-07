using System;
using System.Data.SqlClient;

namespace Conexión
{
    public class Connec
    {
        private string connestr = "Server=localhost; database=BdFinanzas; Integrated Security=True";

        public Connec() { }

        public bool saveCliente(string Nombre, string Apellido, string Telefono, string Direccion, string Garantia, string Correo, decimal Salario)
        {
            try
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

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Verifica si al menos una fila fue afectada
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en saveCliente: " + ex.Message);
                return false;
            }
        }

        public int getIDCliente(string Nombre, string Apellido)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connestr))
                {
                    con.Open();
                    string query = "SELECT IDCliente FROM Cliente WHERE Nombre=@Nombre AND Apellido=@Apellido";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", Apellido);

                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1; // Retorna -1 si no se encuentra
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en getIDCliente: " + ex.Message);
                return -1;
            }
        }

        public decimal getSueldoCliente(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connestr))
                {
                    con.Open();
                    string query = "SELECT Salario FROM Cliente WHERE IDCliente=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0; // Retorna 0 si no se encuentra
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en getSueldoCliente: " + ex.Message);
                return 0;
            }
        }

        public bool savePrestamo(int IDCliente, decimal Monto, decimal Interes, int Duracion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connestr))
                {
                    con.Open();
                    string query = "INSERT INTO Prestamo (IDCliente, Monto, Interes, Duracion) VALUES (@IDCliente, @Monto, @Interes, @Duracion)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@IDCliente", IDCliente);
                        cmd.Parameters.AddWithValue("@Monto", Monto);
                        cmd.Parameters.AddWithValue("@Interes", Interes);
                        cmd.Parameters.AddWithValue("@Duracion", Duracion);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

    }
}

