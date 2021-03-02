using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back.Model
{
    public class ModelProjets
    {
        public List<Projets> GetAll()
        {
            var projets = new List<Projets>();
            string select = "SELECT * FROM projets";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var projet = new Projets();
                projet.Id = sdr.GetInt32(0);
                projet.Id_user = sdr.GetString(1);
                projet.Nom = sdr.GetString(2);
                projets.Add(projet);
            }
            return projets;
        }
        public Projets GetById(int id)
        {
            var projet = new Projets();
            string select = $"SELECT * FROM projets WHERE id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(select, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
            projet.Id = sdr.GetInt32(0);
            projet.Id_user = sdr.GetString(1);
            projet.Nom = sdr.GetString(2);
            return projet;

        }
        public void Insert(Projets projets)
        {
            string insert = $"INSERT INTO projets(Id_user, Nom) values ('{projets.Id_user}', '{projets.Nom}')";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(insert, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }

        public void Update(int id, Projets projets)
        {
            string update = $"UPDATE projets SET Id_user = '{projets.Id_user}', Nom ='{projets.Nom}' WHERE Id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(update, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
        public void Delete(int id)
        {
            string delete = $"DELETE FROM projets WHERE id = {id}";
            var conn = new DbConnection();
            var cmd = new MySqlCommand(delete, conn.Dbconn());
            MySqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            sdr.Read();
        }
    }
}
