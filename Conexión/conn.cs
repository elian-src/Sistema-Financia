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

        public void SaveAdd(string Sueldo, string Direccion, string Duracion)
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
}   }
