using RecoinssoFinal.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoinssoFinal.DataAccess
{
    internal class TicketsDA
    {
        ConexionDA conexion;
        public TicketsDA()
        {
            conexion = new ConexionDA();
        }
        public DataSet MostrarEstadoTicket()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM estadoTicket");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarReportesEstadoPago()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM reportes LEFT JOIN TicketsPagos ON reportes.estadoPago = TicketsPagos.ID_Pagos LEFT JOIN estadoTicket ON Reportes.estadoTicket = estadoTicket.EstadoTicketID ");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarReportes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM reportes");
            return conexion.EjecutarSentencia(sentencia);
        }

        public bool Modificar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Reportes SET estadoTicket = @EstadoTicket WHERE reportesID = @ReportesID");
            SQLComando.Parameters.Add("@ReportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            SQLComando.Parameters.Add("@EstadoTicket", SqlDbType.Int).Value = reportesLB.estadoTicket;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Reportes SET estadoTicket = NULL WHERE reportesID = @ReportesID");
            SQLComando.Parameters.Add("@reportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
 