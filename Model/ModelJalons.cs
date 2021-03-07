using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelJalons
    {
        public int GetLastId()
        {
            string select = "SELECT id from jalons order by id desc limit 1";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            return sdr.GetInt32(0);
        }

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
        public void Insert(Jalons jalons)
        {
            string debut_prevue = jalons.Date_livraison_prevue.ToString("yyyy-MM-dd hh:mm:ss");
            string debut_reel = jalons.Date_livraison_reelle.ToString("yyyy-MM-dd hh:mm:ss");

            string insert = $"INSERT INTO jalons(Libelle, Id_user, Date_livraison_prevue, Date_livraison_reelle) values ('{jalons.Libelle}', '{jalons.Id_user}', '{debut_prevue}', '{debut_reel}')";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(insert, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }

        public void Update(Jalons jalons)
        {
            string debut_prevue = jalons.Date_livraison_prevue.ToString("yyyy-MM-dd hh:mm:ss");
            string debut_reel = jalons.Date_livraison_reelle.ToString("yyyy-MM-dd hh:mm:ss");

            string update = $"UPDATE jalons SET Libelle = '{jalons.Libelle}', Id_user ='{jalons.Id_user}', Date_livraison_prevue = '{debut_prevue}', Date_livraison_reelle = '{debut_reel}' WHERE Id = {jalons.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(update, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
        public void Delete(Jalons jalons)
        {
            string delete = $"DELETE FROM jalons WHERE id = {jalons.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(delete, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
    }
}
