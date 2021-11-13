using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoinssoFinal.DataAccess
{
    internal class MainMenuDA
    {
        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;

        public MainMenuDA()
        {
            this.Conexion = new SqlConnection(this.connectionData);
        }
  
    }
}
