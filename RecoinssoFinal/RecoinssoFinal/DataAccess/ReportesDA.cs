using RecoinssoFinal.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoinssoFinal.DataAccess
{
    internal class ReportesDA
    {
        ConexionDA conexion;
        public ReportesDA()
        {
            conexion = new ConexionDA();
        }
        public DataSet MostrarClientes()
        {
            SqlCommand sentencia = new SqlCommand(" SELECT * FROM Clientes");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarServicios()
        {
            SqlCommand sentencia = new SqlCommand(" SELECT * FROM servicios");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarReportes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT reportesID, clienteID, folio, nombreCliente, equipo, detalleEquipo, detalleProblema, solucion, estadoPago, estadoTicket, servicioID, nombre, costo, descripcion, dias FROM Reportes LEFT JOIN Servicios ON Reportes.servicioID = Servicios.[ID-servicios]");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarAlarmas()
        { //Si estado ticket es menor a cinco no esta terminado y si estado de pago no es 3 entonces no esta pagado//
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Reportes WHERE estadoTicket <= 4 AND estadoPago = 3");
            return conexion.EjecutarSentencia(sentencia);
        }

        public bool Agregar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Reportes (clienteID, folio, nombreCliente, equipo, detalleEquipo, detalleProblema, servicioID) VALUES" +
                " (@IDCliente, @Folio, @NombreCliente, @Equipo, @DetalleEquipo, @DetalleProblema, @ServicioID)");
            SQLComando.Parameters.Add("@IDCliente", SqlDbType.Int).Value = reportesLB.ID_Cliente;
            SQLComando.Parameters.Add("@Folio", SqlDbType.VarChar).Value = reportesLB.Folio;
            SQLComando.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = reportesLB.NombreCliente;
            SQLComando.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = reportesLB.Equipo;
            SQLComando.Parameters.Add("@DetalleEquipo", SqlDbType.VarChar).Value = reportesLB.DetalleEquipo;
            SQLComando.Parameters.Add("@DetalleProblema", SqlDbType.VarChar).Value = reportesLB.DetalleProblema;
            SQLComando.Parameters.Add("@ServicioID", SqlDbType.VarChar).Value = reportesLB.servicioID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Reportes SET clienteID = @IDCliente, folio = @Folio, nombreCliente = @nombreCliente, equipo = @Equipo, detalleEquipo = @detalleEquipo, detalleProblema = @detalleProblema, servicioID = @ServicioID WHERE reportesID = @ReportesID");
            SQLComando.Parameters.Add("@ReportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            SQLComando.Parameters.Add("@IDCliente", SqlDbType.Int).Value = reportesLB.ID_Cliente;
            SQLComando.Parameters.Add("@Folio", SqlDbType.VarChar).Value = reportesLB.Folio;
            SQLComando.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = reportesLB.NombreCliente;
            SQLComando.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = reportesLB.Equipo;
            SQLComando.Parameters.Add("@DetalleEquipo", SqlDbType.VarChar).Value = reportesLB.DetalleEquipo;
            SQLComando.Parameters.Add("@DetalleProblema", SqlDbType.VarChar).Value = reportesLB.DetalleProblema;
            SQLComando.Parameters.Add("@ServicioID", SqlDbType.VarChar).Value = reportesLB.servicioID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(ReportesLB reportesLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Reportes WHERE reportesID = @reportesID");
            SQLComando.Parameters.Add("@reportesID", SqlDbType.Int).Value = reportesLB.ID_ReporteProblema;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
