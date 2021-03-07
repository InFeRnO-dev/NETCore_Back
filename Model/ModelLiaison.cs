using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelLiaison
    {
        public List<Jalons> GetJalonsByIdExigence(int id)
        {
            var jalons = new List<Jalons>();
            string select = $"SELECT DISTINCT jalons.Id, jalons.Libelle, jalons.Id_user, jalons.Date_livraison_prevue, jalons.Date_livraison_reelle FROM jalons LEFT JOIN liaison ON liaison.Id_jalons = jalons.Id WHERE Id_Exigences = {id}";
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
        public List<Taches> GetTachesByIdExigence(int id)
        {
            var taches = new List<Taches>();
            string select = $"SELECT * FROM taches LEFT JOIN liaison ON liaison.Id_taches = taches.Id WHERE Id_Exigences = {id}";
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
        public List<Taches> GetTachesByIdJalon(int id)
        {
            var taches = new List<Taches>();
            string select = $"SELECT * FROM taches LEFT JOIN liaison ON liaison.Id_taches = taches.Id WHERE Id_Jalons = {id}";
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
        public void InsertTacheIntoJalonExigence(Liaison liaison)
        {
            string insert = $"INSERT INTO liaison(Id_Taches, Id_Exigences, Id_Jalons) values ({liaison.Id_Taches}, {liaison.Id_Exigences}, {liaison.Id_Jalons})";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(insert, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
        public void InsertJalonForExigence(Liaison liaison)
        {
            Console.WriteLine(liaison);
            string insert = $"INSERT INTO liaison(Id_Exigences, Id_Jalons) values ({liaison.Id_Exigences},{liaison.Id_Jalons})";
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
