using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.Logica;
using System.Data;
using System.Data.SqlClient;

namespace RecoinssoFinal.DataAccess
{ 
    internal class newUserDA {
        conexionDA conexion;
        public newUserDA()
        {
            conexion = new conexionDA();
        }
        public bool Agregar(newUserLB objNewUserLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO [dbo].[Usuarios] (usuario, nombre, apellidoMaterno, apellidoPaterno, password, correo, telefono)" +
                "VALUES(@Usuario, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Password, @Telefono, @Correo)");
            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = objNewUserLB.usuario;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objNewUserLB.nombre;
            SQLComando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objNewUserLB.apellidoPaterno;
            SQLComando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objNewUserLB.apellidoMaterno;
            SQLComando.Parameters.Add("@Password", SqlDbType.VarChar).Value = objNewUserLB.password;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objNewUserLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objNewUserLB.correo;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }
    }
}
