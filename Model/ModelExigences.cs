using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelExigences
    {
        public List<Exigences> GetAll()
        {
            var exigences = new List<Exigences>();
            string select = "SELECT * FROM exigences";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var exigence = new Exigences();
                exigence.Id = sdr.GetInt32(0);
                exigence.Description = sdr.GetString(1);
                exigence.Type = sdr.GetString(2);
                exigence.Fonctionnel = sdr.GetInt32(3);
                exigences.Add(exigence);
            }
            return exigences;
        }
        public Exigences GetById(int id)
        {
            var exigence = new Exigences();
            string select = $"SELECT * FROM exigence WHERE id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            exigence.Id = sdr.GetInt32(0);
            exigence.Description = sdr.GetString(1);
            exigence.Type = sdr.GetString(2);
            exigence.Fonctionnel = sdr.GetInt32(3);
            return exigence;
        }
    }
}
