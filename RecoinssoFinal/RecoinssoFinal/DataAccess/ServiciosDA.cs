using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.Logica;
using RecoinssoFinal.Presentación.Servicios;

namespace RecoinssoFinal.DataAccess
{
    internal class ServiciosDA
    {
        ConexionDA conexion;
        public ServiciosDA()
        {
            conexion = new ConexionDA();
        }

        public DataSet MostrarServicios()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Servicios");
            return conexion.EjecutarSentencia(sentencia);
        }

        /// Falta insertar FECHA
        public bool Agregar(ServiciosLB objServiciosLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Servicios (nombre, costo, descripcion, foto, dias) VALUES (@Nombre, @Costo, @Descripcion, @Foto, @Dias)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objServiciosLB.nombre;
            SQLComando.Parameters.Add("@Costo", SqlDbType.VarChar).Value = objServiciosLB.costo;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objServiciosLB.descripcion;
            SQLComando.Parameters.Add("@Foto", SqlDbType.Image).Value = objServiciosLB.Foto;
            SQLComando.Parameters.Add("@Dias", SqlDbType.Int).Value = objServiciosLB.dias;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(ServiciosLB objServiciosLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Servicios SET nombre = @Nombre, costo = @Costo, descripcion = @Descripcion, foto = @Foto, dias = @Dias" +
                " WHERE [ID-servicios] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objServiciosLB.ID;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objServiciosLB.nombre;
            SQLComando.Parameters.Add("@Costo", SqlDbType.VarChar).Value = objServiciosLB.costo;
            SQLComando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = objServiciosLB.descripcion;
            SQLComando.Parameters.Add("@Foto", SqlDbType.Image).Value = objServiciosLB.Foto;
            SQLComando.Parameters.Add("@Dias", SqlDbType.Int).Value = objServiciosLB.dias;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(ServiciosLB objServiciosLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Servicios WHERE [ID-servicios] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objServiciosLB.ID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
