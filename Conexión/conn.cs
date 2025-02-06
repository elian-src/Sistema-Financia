using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Conexión
{
    public class Connec
    {
        public Connec() { }

        private string connestr = "Server=localhost; database=BdFinanzas; Integrated Security=True";

        public void SaveAddU(string Sueldo, string Direccion, string Duracion)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "INSERT INTO DatosIngresados (Sueldo, Direccion, Duracion) VALUES (@Sueldo, @Direccion, @Duracion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Sueldo", Sueldo);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Duracion", Duracion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void saveAddADM(string Nombre, string Apellido, string Telefono, string Direccion, string Garantia, string Correo)
        {
            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "INSERT INTO DatosIngresados (Nombre, Apellido, Telefono, Direccion, Garantia, Correo) VALUES (@Nombre, @Apellido, @Telefono, @Direccion, @Garantia, @Correo)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Garantia", Garantia);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }   
}
