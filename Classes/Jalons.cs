using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back
{
    public class Jalons
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Id_user { get; set; }
        public DateTime Date_livraison_prevue { get; set; }
        public DateTime Date_livraison_reelle { get; set; }
    }
}
