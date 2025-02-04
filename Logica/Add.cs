using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Conexión;

namespace Logica
{
        public class Add
        {
            public string Sueldo { get; set; }
            public string Direccion { get; set; }
            public string Duracion { get; set; }


            public Add(string Sueldo, string Direccion, string Duracion)
            {
                this.Sueldo = Sueldo;
                this.Direccion = Direccion;
                this.Duracion = Duracion;
            }

            Connec conn = new Connec();
            
            public void saveAdd()
            {
                conn.SaveAdd(Sueldo, Direccion, Duracion);
            }
        }
}

