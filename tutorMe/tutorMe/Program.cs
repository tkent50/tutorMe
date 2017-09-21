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
            con.ConnectionString = "server=127.0.0.1;user id=root;database=test;port=3306"; //My local mysql server
            try
            {
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
