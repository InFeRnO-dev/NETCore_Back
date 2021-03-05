using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back
{
    public class Taches
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public string Id_user { get; set; }
        public DateTime Date_debut_theorique { get; set; }
        public DateTime Date_debut_reelle { get; set; }
        public int Charge { get; set; }
        public int Encours { get; set; }
        public int Termine { get; set; }
        public int Id_tache_liee { get; set; }
    
    }
}
