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

public class tutor
{
    public string name;
    public string email;
    public string phoneNumber;
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
        public static string[] getClasses()
        {
            var classes = new string[] { "4", "class1", "class2", "class3", "class4" }; // First number is size of array

            /*
            classList.Add("class1", new tutor[2]);
            classList["class1"][0] = new tutor { name = "Jake", email = "jake@purdue.edu", phoneNumber = "111-111-1111" };
            classList["class1"][1] = new tutor { name = "John", email = "john@purdue.edu", phoneNumber = "222-222-2222" };

            classList.Add("class2", new tutor[2]);
            classList["class2"][0] = new tutor { name = "Jack", email = "jack@purdue.edu", phoneNumber = "333-333-3333" };
            classList["class2"][0] = new tutor { name = "Jane", email = "jane@purdue.edu", phoneNumber = "444-444-4444" };
            */
            return classes;
        }
        
    }
}