using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NETCore_Back
{
    public class DbConnection
    {
        string Hostname = "localhost";
        string UserId = "root";
        string Password = "";
        string DbName = "NETCore";

        public MySqlConnection Dbconn()
        {
            MySqlConnection connection = new MySqlConnection($"server={Hostname}; database={DbName}; user id={UserId}; password={Password};");
            connection.Open();
            return connection;
        }
    }
}
