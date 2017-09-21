using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace tutorMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                con.ConnectionString = "1"; //Fix this !!
                con.Open();
                Console.WriteLine("Made it.");
            }
            catch {
                Console.WriteLine("Maybe next time.");
            }
            finally
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
