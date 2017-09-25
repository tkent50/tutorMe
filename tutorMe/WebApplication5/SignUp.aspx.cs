using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace WebApplication5
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void SubmitRegistration_Click(object sender, EventArgs e)
        {

            //CHECK FOR NULL ENTRIES! 

            //Make Connection
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
            MySqlCommand cmd = new MySqlCommand(cmdText: "insert into users(firstname, lastname, email, passHash) Values(@firstname, @lastname, @email, @passHash)", connection: con);
                cmd.Parameters.AddWithValue("@firstname", first_name.Text);
                cmd.Parameters.AddWithValue("@lastname", last_name.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@passHash", user_password.Text);

                con.Open();
                try
                {
                    //Execute Command
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle nonunique emails, or bad entries.
                }
                finally
                {
                    con.Close();
                }
  
            }
        }
    }
}