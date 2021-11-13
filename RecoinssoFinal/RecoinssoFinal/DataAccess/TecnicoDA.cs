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
    internal class TecnicoDA
    {
        conexionDA conexion;
        public TecnicoDA()
        {
            conexion = new conexionDA();
        }

        public DataSet MostrarTecnicos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Tecnicos");
            return conexion.EjecutarSentencia(sentencia);
        }

        public bool Agregar(tecnicosLB objTecnicoLB)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Tecnicos (nombre, telefono, correo, rfc, especialidad, puesto) VALUES (@Nombre, @Telefono, @Correo, @RFC, @Especialidad, @Puesto)");
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objTecnicoLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.Int).Value = objTecnicoLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objTecnicoLB.correo;
            SQLComando.Parameters.Add("@RFC", SqlDbType.VarChar).Value = objTecnicoLB.rfc;
            SQLComando.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = objTecnicoLB.especialidad;
            SQLComando.Parameters.Add("@Puesto", SqlDbType.VarChar).Value = objTecnicoLB.puesto;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(tecnicosLB objTecnicoLB)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Tecnicos SET nombre = @Nombre, telefono = @Telefono," +
                " correo = @Correo, rfc = @RFC, especialidad = @Especialidad, puesto = @Puesto WHERE [ID-Tecnico] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objTecnicoLB.ID;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objTecnicoLB.nombre;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.Int).Value = objTecnicoLB.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objTecnicoLB.correo;
            SQLComando.Parameters.Add("@RFC", SqlDbType.VarChar).Value = objTecnicoLB.rfc;
            SQLComando.Parameters.Add("@Especialidad", SqlDbType.VarChar).Value = objTecnicoLB.especialidad;
            SQLComando.Parameters.Add("@Puesto", SqlDbType.VarChar).Value = objTecnicoLB.puesto;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(tecnicosLB objTecnicoLB)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Tecnicos WHERE [ID-Tecnico] = @ID");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = objTecnicoLB.ID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }
    }
}
