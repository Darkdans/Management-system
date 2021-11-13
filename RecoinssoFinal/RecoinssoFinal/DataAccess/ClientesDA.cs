using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.Logica;
using RecoinssoFinal.Presentación.Clientes;

namespace RecoinssoFinal.DataAccess
{
    internal class ClientesDA
    {
        conexionDA conexion;
        public ClientesDA()
        {
            conexion = new conexionDA();
        }

        public DataSet MostrarClientes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM clientes");
            return conexion.EjecutarSentencia(sentencia);
        }

        public bool Agregar(clientesLB objClientesLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Clientes (nombre, telefono, correo, rfc) VALUES (@Nombre, @Telefono, @Correo, @RFC)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objClientesLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.Int).Value = objClientesLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objClientesLB.correo;
            SQLComando.Parameters.Add("@RFC", SqlDbType.VarChar).Value = objClientesLB.rfc;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(clientesLB objClientesLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Clientes SET nombre = @Nombre, telefono = @Telefono, correo = @Correo, rfc = @RFC" +
                " WHERE [ID-Cliente] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objClientesLB.ID;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objClientesLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.Int).Value = objClientesLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objClientesLB.correo;
            SQLComando.Parameters.Add("@RFC", SqlDbType.VarChar).Value = objClientesLB.rfc;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(clientesLB objClientesLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Clientes WHERE [ID-Cliente] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objClientesLB.ID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
