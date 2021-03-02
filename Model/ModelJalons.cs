using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelJalons
    {
        public List<Jalons> GetAll()
        {
            var jalons = new List<Jalons>();
            string select = "SELECT * FROM jalons";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var jalon = new Jalons();
                jalon.Id = sdr.GetInt32(0);
                jalon.Libelle = sdr.GetString(1);
                jalon.Id_user = sdr.GetString(2);
                jalon.Date_livraison_prevue = sdr.GetDateTime(3);
                jalon.Date_livraison_reelle = sdr.GetDateTime(4);
                jalons.Add(jalon);
            }
            return jalons;
        }
        public Jalons GetById(int id)
        {
            var jalon = new Jalons();
            string select = $"SELECT * FROM jalons WHERE id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            jalon.Id = sdr.GetInt32(0);
            jalon.Libelle = sdr.GetString(1);
            jalon.Id_user = sdr.GetString(2);
            jalon.Date_livraison_prevue = sdr.GetDateTime(3);
            jalon.Date_livraison_reelle = sdr.GetDateTime(4);
            return jalon;
        }
    }
}
