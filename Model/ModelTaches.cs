using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelTaches
    {
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
                tache.Termine = sdr.GetInt32(7);
                tache.Id_Tache_Liee = sdr.GetInt32(8);
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
            tache.Termine = sdr.GetInt32(7);
            tache.Id_Tache_Liee = sdr.GetInt32(8);
            return tache;

        }
    }
}
