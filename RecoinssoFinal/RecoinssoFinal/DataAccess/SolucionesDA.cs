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
    internal class SolucionesDA
    {
        ConexionDA conexion;
        public SolucionesDA()
        {
            conexion = new ConexionDA();
        }
        public DataSet MostrarReportes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Reportes");
            return conexion.EjecutarSentencia(sentencia);
        }
         
        public bool Modificar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Reportes SET solucion = @Solucion WHERE reportesID = @ReportesID");
            SQLComando.Parameters.Add("@ReportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            SQLComando.Parameters.Add("@Solucion", SqlDbType.VarChar).Value = reportesLB.Solucion;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Reportes SET solucion = @Solucion WHERE reportesID = @ReportesID");
            SQLComando.Parameters.Add("@reportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            SQLComando.Parameters.Add("@Solucion", SqlDbType.VarChar).Value = "";
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }
    }
}
