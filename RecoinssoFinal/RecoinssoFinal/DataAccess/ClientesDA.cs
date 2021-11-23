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
        ConexionDA conexion;
        public ClientesDA()
        {
            conexion = new ConexionDA();
        }

        public DataSet MostrarClientes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM clientes WHERE [ID-Cliente] > 23");
            return conexion.EjecutarSentencia(sentencia);
        }

        public bool Agregar(ClientesLB objClientesLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Clientes (nombre, telefono, correo, equipo, foto, direccion, detalleEquipo) VALUES (@Nombre, @Telefono, @Correo, @Equipo, @Foto, @Direccion, @DetalleEquipo)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objClientesLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objClientesLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objClientesLB.correo;
            SQLComando.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = objClientesLB.equipo;
            SQLComando.Parameters.Add("@Foto", SqlDbType.Image).Value = objClientesLB.Foto;
            SQLComando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = objClientesLB.direccion;
            SQLComando.Parameters.Add("@DetalleEquipo", SqlDbType.VarChar).Value = objClientesLB.detalleEquipo;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(ClientesLB objClientesLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Clientes SET nombre = @Nombre, telefono = @Telefono, correo = @Correo, equipo = @Equipo, foto = @Foto, direccion = @Direccion, detalleEquipo = @DetalleEquipo" +
                " WHERE [ID-Cliente] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objClientesLB.ID;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objClientesLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objClientesLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objClientesLB.correo;
            SQLComando.Parameters.Add("@Equipo", SqlDbType.VarChar).Value = objClientesLB.equipo;
            SQLComando.Parameters.Add("@Foto", SqlDbType.Image).Value = objClientesLB.Foto;
            SQLComando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = objClientesLB.direccion;
            SQLComando.Parameters.Add("@DetalleEquipo", SqlDbType.VarChar).Value = objClientesLB.detalleEquipo;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(ClientesLB objClientesLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Clientes WHERE [ID-Cliente] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objClientesLB.ID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
