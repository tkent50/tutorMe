using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;
using System.ComponentModel.DataAnnotations;

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
            if (first_name.Text == "")
            {
                this.Show("First name field is required");
                return;
            }
            if (last_name.Text == "")
            {
                this.Show("Last name field is required");
                return;
            }
            if (!(new EmailAddressAttribute().IsValid(email.Text)))
            {
                this.Show("Not a valid email address");
                return;
            }
            if (user_password.Text == "")
            {
                this.Show("Password field is required");
                return;
            }
            if (user_password.Text != confirm_password.Text)
            {
                this.Show("Passwords do not match");
                return;
            }

            int hash = CalculateHash(email.Text, user_password.Text);

            //Make Connection
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
            MySqlCommand cmd = new MySqlCommand(cmdText: "insert into users(firstname, lastname, email, passHash) Values(@firstname, @lastname, @email, @passHash)", connection: con);
                cmd.Parameters.AddWithValue("@firstname", first_name.Text);
                cmd.Parameters.AddWithValue("@lastname", last_name.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@passHash", hash);

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
        protected int CalculateHash(string email, string password)
        {
            int hash = 0;
            for (int i = 0; i < email.Length; i++)
            {
                hash = hash + ((i + 1) * email[i]);
            }
            for (int i = 0; i < password.Length; i++)
            {
                hash = hash + ((i + 1) * password[i]);
            }
            return hash;
        }
    }
}