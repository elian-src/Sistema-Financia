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
            public int IDCliente { get; set; }
            public decimal Monto { get; set; }
            public decimal Interes { get; set; }
            public int Duracion { get; set; }


        public Prestamo(int IDCliente, decimal Monto, decimal Interes, int Duracion)
            {
                this.IDCliente = IDCliente;
                this.Monto = Monto;
                this.Interes = Interes;
                this.Duracion = Duracion;
            }

            Connec conn = new Connec();
            
            public void savePrestamo()
            {
                conn.savePrestamo(IDCliente, Monto, Interes, Duracion);
            }
        }
}

