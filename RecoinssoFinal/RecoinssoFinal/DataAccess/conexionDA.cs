using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using RecoinssoFinal.Presentación;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Configuration;


namespace RecoinssoFinal.DataAccess
{

    internal class conexionDA
    {
        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;
        Core core = new Core();

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }

        public bool ejecturarComandosSinRetornoDatos(SqlCommand SQLComando, String mensajeBox)
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexión();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                core.messageBox(mensajeBox);
                return true;
            }
            catch
            {
                core.messageBox("Ha ocurrido un error al realizar la consulta");
                return false;
            }
        }
        /*SELECT (Retorno de datos) */
        public DataSet EjecutarSentencia(SqlCommand sqlCommand)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlCommand;
                Comando.Connection = EstablecerConexión();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }
        public void logins(loginLB loginLB)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {
                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand("SELECT puesto, usuario, password FROM Usuarios WHERE usuario = '" + loginLB.usuario + "' AND password ='" + loginLB.password + "'", conexion)) { 
                        SqlDataReader registro = commando.ExecuteReader();

                        if (registro.Read()) {
                            core.messageBox("Login exitoso.");
                            LoginForm loginForm = new LoginForm();
                            loginForm.Hide();
                            mainMenu mainMenu = new mainMenu();
                            mainMenu.lblUser.Text = registro["usuario"].ToString();
                            mainMenu.lblPuesto.Text = "Puesto: " + registro["puesto"].ToString();
                            mainMenu.Show();
                        }
                        else {
                            core.messageBox("Datos incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}
