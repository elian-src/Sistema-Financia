using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexión;

namespace Logica
{
    public class AddADM
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public string Correo { get; set; }


        public AddADM(string Nombre, string Apellido, string Telefono, string Direccion, string Garantia, string Correo)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Garantia = Garantia;
            this.Correo = Correo;
        }

         Connec conn = new Connec();

        public void saveAddADM()
        {
            conn.saveAddADM(Nombre, Apellido, Telefono, Direccion, Garantia, Correo);
        }
    }
}
