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
    }
}
