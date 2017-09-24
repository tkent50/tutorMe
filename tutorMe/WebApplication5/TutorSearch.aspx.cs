using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

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
                   MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                   con.Open();

                   MySqlCommand cmd = new MySqlCommand("select * from classes", con);
                   MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                   DataSet ds = new DataSet();
                   adp.Fill(ds);
                   GridView1.DataSource = ds;
                   GridView1.DataBind();
                   cmd.Dispose();
                   con.Close();
        }
    }
}