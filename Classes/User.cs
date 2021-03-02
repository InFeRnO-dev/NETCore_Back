using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back
{
    public class User
    {
        public string Id_user { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Droits { get; set; }

    }
}
