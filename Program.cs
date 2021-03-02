using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var dbconn = new dbconnection();
            //try
            //{
            //    dbconn.dbconn().open();
            //    console.writeline("connexion a la bdd ouverte");
            //}
            //catch
            //{
            //    console.writeline("erreur de connexion a la base");
            //}
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
