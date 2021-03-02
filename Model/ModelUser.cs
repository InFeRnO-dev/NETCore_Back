using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelUser
    {
        public List<User> GetAll()
        {
            var users = new List<User>();
            string select = "SELECT * FROM user";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var user = new User();
                user.Id_user = sdr.GetString(0);
                user.Username = sdr.GetString(1);
                user.Password = sdr.GetString(2);
                user.Droits = sdr.GetInt32(3);
                users.Add(user);
            }
            return users;
        }
        public User GetById(string id)
        {
            var user = new User();
            string select = $"SELECT * FROM user WHERE id_user = '{id}'";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            user.Id_user = sdr.GetString(0);
            user.Username = sdr.GetString(1);
            user.Password = sdr.GetString(2);
            user.Droits = sdr.GetInt32(3);
            return user;

        }
    }
}
