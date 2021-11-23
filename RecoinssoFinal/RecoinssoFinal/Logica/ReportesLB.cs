using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoinssoFinal.Logica
{
    internal class ReportesLB
    {
        public int ID_ReporteProblema { get; set; }
        public int ID_Cliente { get; set; }
        public string Folio { get; set; }
        public string NombreCliente { get; set; }
        public string Equipo { get; set; }
        public string DetalleEquipo { get; set; }
        public string DetalleProblema { get; set; }
        public string Solucion { get; set; }
        public int estadoPago { get; set; }
        public int estadoTicket { get; set; }
        public int servicioID { get; set; }
        public DateTime fecha { get; set; }
    }
}
