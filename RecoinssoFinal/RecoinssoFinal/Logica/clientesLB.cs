using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoinssoFinal.Logica
{
    internal class ClientesLB
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string equipo { get; set; }
        public byte[] Foto { get; set; }
        public string direccion { get; set; }
        public string detalleEquipo { get; set; }
    }
}
