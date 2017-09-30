using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Services;
using Newtonsoft.Json;


public class tester
{
    public string Name;
    public int Num;
}

namespace WebApplication5
{
    public partial class TutorSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                 BindData();
        }
        public void BindData()
        {
                   /*MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                   con.Open();

                   MySqlCommand cmd = new MySqlCommand("select * from classes", con);
                   MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                   DataSet ds = new DataSet();
                   adp.Fill(ds);
                   cmd.Dispose();
                   con.Close();*/
        }

        [WebMethod]
        public static tester getClasses()
        {
            return new tester { Name = "Jake", Num = 1 };
           
        }

        [WebMethod]
        public static string MyMethod(string name)
        {
            return "Hello " + name;
        }
    }
}