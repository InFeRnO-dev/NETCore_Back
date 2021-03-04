using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelLiaison
    {
        public List<Exigences> GetExigencesByProjet(int id)
        { 
            var exigences = new List<Exigences>();
            string select = $"SELECT * FROM exigences LEFT JOIN liaison ON liaison.Id_Exigences = exigences.Id WHERE Id_Projets = {id}";
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
        public void InsertExigenceForProjet(Liaison liaison)
        {
            string insert = $"INSERT INTO liaison(Id_Projets, Id_Exigences) values ({liaison.Id_Projets}, {liaison.Id_Exigences})";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(insert, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }

        public void Update(Exigences exigences)
        {
            string update = $"UPDATE exigences SET Description = '{exigences.Description}', Type ='{exigences.Type}', Fonctionnel = {exigences.Fonctionnel} WHERE Id = {exigences.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(update, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
        public void Delete(Exigences exigences)
        {
            string delete = $"DELETE FROM exigences WHERE id = {exigences.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(delete, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
    }
}
