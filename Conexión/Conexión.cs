using Logica;
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

        public void SaveAdd(Add add)
        {
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            using (SqlConnection con = new SqlConnection(connestr))
            {
                con.Open();
                string query = "INSERT INTO DatosIngresados (Sueldo, Direccion, Duracion) VALUES (@Sueldo, @Direccion, @Duracion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Sueldo", add.Sueldo);
                    cmd.Parameters.AddWithValue("@Direccion", add.Direccion);
                    cmd.Parameters.AddWithValue("@Duracion", add.Duracion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
}   }
