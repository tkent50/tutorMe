﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace WebApplication5
{
    public partial class TutorSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitChanges(object sender, EventArgs e)
        {
            bool emailUpdated = false;
            bool passUpdated = false;
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (email.Text != "")
            {
                if (new EmailAddressAttribute().IsValid(email.Text))
                {
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
                    else if (password.Text != "")
                    {
                        string currentEmail = "";
                        MySqlConnection con2 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                        {
                            MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @userId", connection: con2);
                            cmd.Parameters.AddWithValue("@userId", userIdCookie.Value);
                            con2.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                currentEmail = reader["email"].ToString();
                            }
                            con2.Close();
                        }
                        int hash = CalculateHash(currentEmail, password.Text);
                        MySqlConnection con3 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                        {
                            MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @userId", connection: con3);
                            cmd.Parameters.AddWithValue("@userId", userIdCookie.Value);
                            con3.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                if (Convert.ToInt32(reader["passHash"]) == hash)
                                {
                                    int newHash = CalculateHash(email.Text, password.Text);
                                    MySqlConnection con4 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                                    {
                                        MySqlCommand cmd1 = new MySqlCommand(cmdText: "UPDATE users SET email = @newEmail, passHash = @newHash WHERE userID = @userId", connection: con4);
                                        cmd1.Parameters.AddWithValue("@userId", userIdCookie.Value);
                                        cmd1.Parameters.AddWithValue("@newEmail", email.Text);
                                        cmd1.Parameters.AddWithValue("@newHash", newHash);
                                        con4.Open();
                                        cmd1.ExecuteNonQuery();
                                        con4.Close();
                                    }
                                    emailUpdated = true;
                                }
                                else
                                {
                                    this.Show("Incorrect password");
                                    return;
                                }
                            }
                            con3.Close();
                        }

                    }
                    else
                    {
                        this.Show("Please provide your current password");
                        return;
                    }
                }
                else
                {
                    this.Show("Not a valid email address");
                    return;
                }
            }
            if (newPassword.Text != "")
            {
                if (newPassword.Text.Length < 8 || newPassword.Text.Length > 32)
                {
                    this.Show("Password must be between 8 and 32 characters long");
                    return;
                }
                if (newPassword.Text != confirmPassword.Text)
                {
                    this.Show("New password and password confirmation do not match");
                    return;
                }
                string email = "";
                MySqlConnection con1 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                {
                    MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT email FROM users WHERE userID = @userId", connection: con1);
                    cmd.Parameters.AddWithValue("@userId", userIdCookie.Value);
                    con1.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        email = reader["email"].ToString();
                    }
                    con1.Close();
                }
                int oldHash = CalculateHash(email, password.Text);
                MySqlConnection con2 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                {
                    MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT passHash FROM users WHERE userID = @userId", connection: con2);
                    cmd.Parameters.AddWithValue("@userId", userIdCookie.Value);
                    con2.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["passHash"].ToString()) == oldHash)
                        {
                            int newHash = CalculateHash(email, newPassword.Text);
                            MySqlConnection con3 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                            {
                                MySqlCommand cmd1 = new MySqlCommand(cmdText: "UPDATE users SET passHash = @newHash WHERE userID = @userId", connection: con3);
                                cmd1.Parameters.AddWithValue("@userId", userIdCookie.Value);
                                cmd1.Parameters.AddWithValue("@newHash", newHash);
                                con3.Open();
                                cmd1.ExecuteNonQuery();
                                con3.Close();
                                passUpdated = true;
                            }
                        }
                        else
                        {
                            this.Show("Current password is incorrect");
                            return;
                        }
                    }
                    con2.Close();
                }
            }
            string message = "";
            if (emailUpdated && passUpdated)
            {
                message = "Email and password updated successfully";
            }
            else if (emailUpdated)
            {
                message = "Email successfully updated";
            }
            else if (passUpdated)
            {
                message = "Password successfully updated";
            }
            this.Show(message);
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