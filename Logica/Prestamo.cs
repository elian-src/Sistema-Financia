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
        public class Prestamo
        {
            public string IDCliente { get; set; }
            public string Monto { get; set; }
            public string Interes { get; set; }
            public string Fecha { get; set; }


        public Prestamo(string IDCliente, string Monto, string Interes, string Fecha)
            {
                this.IDCliente = IDCliente;
                this.Monto = Monto;
                this.Interes = Interes;
                this.Fecha = Fecha;
            }

            Connec conn = new Connec();
            
            public void savePrestamo()
            {
                conn.savePrestamo(IDCliente, Monto, Interes, Fecha);
            }
        }
}

