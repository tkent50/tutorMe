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
using System.Net.Mail;
using System.Net;

namespace WebApplication5
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (last_name.Text.Length > 32 || first_name.Text.Length > 32)
            {
                this.Show("Names must be less than 32 characters long");
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
            if (user_password.Text.Length < 8 || user_password.Text.Length > 16)
            {
                this.Show("Password must be between 8 and 16 characters long");
                return;
            }
            if (user_password.Text != confirm_password.Text)
            {
                this.Show("Passwords do not match");
                return;
            }
            bool emailInDatabase = false;
            MySqlConnection con1 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE email = @email", connection: con1);
                cmd.Parameters.AddWithValue("@email", email.Text);
                con1.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emailInDatabase = true;
                }
                con1.Close();
            }
            if (emailInDatabase)
            {
                this.Show("That email address is already associated with an account");
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
                    SendRegistrationEmail(email.Text);
                    Response.Redirect("Default.aspx", false);
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
        protected void SendRegistrationEmail(string email)
        {
            var fromAddress = new MailAddress("tutorapp408@gmail.com", null);
            var toAddress = new MailAddress(email, null);
            const string fromPassword = "5515hebt";
            const string subject = "Test registration";
            const string body = "You've registered for TutorMe!!!!!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}