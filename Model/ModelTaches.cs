using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelTaches
    {
        public int GetLastId()
        {
            string select = "SELECT id from taches order by id desc limit 1";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            return sdr.GetInt32(0);
        }
        public List<Taches> GetAll()
        {
            var taches = new List<Taches>();
            string select = "SELECT * FROM taches";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var tache = new Taches();
                tache.Id = sdr.GetInt32(0);
                tache.Libelle = sdr.GetString(1);
                tache.Description = sdr.GetString(2);
                tache.Id_user = sdr.GetString(3);
                tache.Date_debut_theorique = sdr.GetDateTime(4);
                tache.Date_debut_reelle = sdr.GetDateTime(5);
                tache.Charge = sdr.GetInt32(6);
                tache.Encours = sdr.GetInt32(7);
                tache.Termine = sdr.GetInt32(8);
                tache.Id_tache_liee = sdr.GetInt32(9);
                taches.Add(tache);
            }
            return taches;
        }
        public Taches GetById(int id)
        {
            var tache = new Taches();
            string select = $"SELECT * FROM taches WHERE id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            tache.Id = sdr.GetInt32(0);
            tache.Libelle = sdr.GetString(1);
            tache.Description = sdr.GetString(2);
            tache.Id_user = sdr.GetString(3);
            tache.Date_debut_theorique = sdr.GetDateTime(4);
            tache.Date_debut_reelle = sdr.GetDateTime(5);
            tache.Charge = sdr.GetInt32(6);
            tache.Encours = sdr.GetInt32(7);
            tache.Termine = sdr.GetInt32(8);
            tache.Id_tache_liee = sdr.GetInt32(9);
            return tache;

        }
        public void Insert(Taches taches)
        {
            string debut_theorique = taches.Date_debut_theorique.ToString("yyyy-MM-dd hh:mm:ss");
            string debut_reel = taches.Date_debut_reelle.ToString("yyyy-MM-dd hh:mm:ss");

            string insert = $"INSERT INTO taches(Libelle, Description, Id_user, Date_debut_theorique, Date_debut_reelle, Charge, Encours, Termine, Id_tache_liee) values ('{taches.Libelle}', '{taches.Description}', '{taches.Id_user}', '{debut_theorique}', '{debut_reel}', {taches.Charge}, {taches.Encours}, {taches.Termine}, {taches.Id_tache_liee})";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(insert, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }

        public void Update(Taches taches)
        {
            string debut_theorique = taches.Date_debut_theorique.ToString("yyyy-MM-dd hh:mm:ss");
            string debut_reel = taches.Date_debut_reelle.ToString("yyyy-MM-dd hh:mm:ss");

            string update = $"UPDATE taches SET Libelle = '{taches.Libelle}', Description = '{taches.Description}', Id_user ='{taches.Id_user}', Date_debut_theorique = '{debut_theorique}', Date_debut_reelle = '{debut_reel}', Charge = {taches.Charge}, Encours = {taches.Encours}, Termine = {taches.Termine}, Id_tache_liee = {taches.Id_tache_liee} WHERE Id = {taches.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(update, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
        public void Delete(Taches taches)
        {
            string delete = $"DELETE FROM taches WHERE id = {taches.Id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(delete, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
    }
}
