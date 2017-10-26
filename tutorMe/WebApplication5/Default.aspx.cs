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
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (userIdCookie != null)
            {
                Response.Redirect("/TutorSearch.aspx");
            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            int hash = CalculateHash(user_input.Text, pass_input.Text);
            List<Object> arrList = new List<Object>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
               MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * from users WHERE email = @email", connection: con);
                con.Open();
                cmd.Parameters.AddWithValue("@email", user_input.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["passHash"]) == hash)
                    {
                        CreateUserIdCookie(reader["userID"].ToString());
                        Response.Redirect("TutorSearch.aspx", false);
                    }
                }
                con.Close();
                pass_input.Text = "";
                this.Show("Incorrect email or password");
            }
        }
        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx", false);
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
        protected void CreateUserIdCookie(string userId)
        {
            HttpCookie userIdCookie = new HttpCookie("userId");
            userIdCookie.Value = userId;
            Response.Cookies.Add(userIdCookie);
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