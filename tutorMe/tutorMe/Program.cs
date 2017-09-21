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
            con.ConnectionString = "server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True"; //Mysql server
            try
            {
                con.Open();
                Console.WriteLine("Made it.");
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
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
