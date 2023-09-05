using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Persistencia
{
    public abstract class ConeccionSql
    {
        private readonly string connectionString;
        public ConeccionSql()     {       
            
            connectionString =    ConfigurationManager.ConnectionStrings["BdConection"].ConnectionString;


        }
        protected MySqlConnection GetSqlConnection()
        {

            return new MySqlConnection(connectionString);
        }
    }
}