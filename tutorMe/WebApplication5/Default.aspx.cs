using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;
using System.Collections;

namespace WebApplication5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {
            List<Object> arrList = new List<Object>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
               MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * from users", connection: con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Basic Validation
                    if (reader["email"].ToString() == user_input.Text) {
                        if (reader["passHash"].ToString() == pass_input.Text)
                        {
                            Response.Redirect("TutorSearch.aspx", false);
                        }
                    }
                }
                con.Close();
                pass_input.Text = "";
                this.Show("Login Denied!");
            }
        }
        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx", false);
        }
    }
    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('"+ Message +"');</script>"
            );
        }
    }
}