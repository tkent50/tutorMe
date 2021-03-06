﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace WebApplication5
{
    public partial class UserSettings : System.Web.UI.Page
    {
        static string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /* setUserSchedule(25, "2013-03-27 11:45:30", "2013-03-27 13:45:30", 5, "CS354");
             setUserSchedule(27, "2013-03-27 11:45:30", "2013-03-27 13:45:30", 5, "CS354");
             setUserSchedule(28, "2013-03-27 11:45:30", "2013-03-27 13:45:30", 5, "CS354"); */

            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (userIdCookie == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                userId = userIdCookie.Value;
            }
        }

        protected void SubmitChanges(object sender, EventArgs e)
        {
            bool emailUpdated = false;
            bool passUpdated = false;
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (email.Text != "")
            {
                if  (new EmailAddressAttribute().IsValid(email.Text))
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
                    if (password.Text != "")
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
                                    int newHash = CalculateHash(currentEmail, password.Text);
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

        public class studentSchedInfo
        {
            public int studentID;
            public string text;
            public string startTime;
            public string endTime;
        }

        [WebMethod]
        public static string deleteUserSchedule(string startTime, string endTime)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "DELETE from studentSchedules where userID = @userId AND startTime = @startTime AND endTime = @endTime", connection: con);
                cmd.Parameters.AddWithValue("@userID", userId);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return null;
            }
        }

        [WebMethod]
        public static string setUserSchedule(string startTime, string endTime, string text)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO studentSchedules(userID, startTime, endTime, text) VALUES(@userID, @startTime, @endTime, @text)", connection: con);
                cmd.Parameters.AddWithValue("@userID", userId);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@text", text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return null;
            }
        }

        [WebMethod]
        public static string getUserSchedule()
        {
            List<studentSchedInfo> tutorSched = new List<studentSchedInfo>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM studentSchedules WHERE userID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int studID = Convert.ToInt32(userId);
                string startTime = "";
                string endTime = "";
                string text = "";
                while (reader.Read())
                {
                    startTime = reader["startTime"].ToString();
                    endTime = reader["endTime"].ToString();
                    text = reader["text"].ToString();
                    tutorSched.Add(new studentSchedInfo { studentID = studID, startTime = startTime, endTime = endTime, text = text });
                }

            }
            con.Close();
            var json = new JavaScriptSerializer().Serialize(tutorSched);
            return json;
        }

        /*int studentID = 24;
            if (studentID == 23)
            {
                tutorSched = new List<studentSchedInfo>
                {
                    new studentSchedInfo{calID = 3, studentID = 23, startTime = "2013-03-24T02:00:00", endTime = "2013-03-24T04:00:00", text = "Event 1"},
                    new studentSchedInfo{calID = 4, studentID = 23, startTime = "2013-03-25T12:00:00", endTime = "2013-03-25T15:00:00", text = "Event 2"},
                    new studentSchedInfo{calID = 5, studentID = 23, startTime = "2013-03-26T18:00:00", endTime = "2013-03-26T23:59:00", text = "Event 3"},
                    new studentSchedInfo{calID = 6, studentID = 23, startTime = "2013-03-27T02:00:00", endTime = "2013-03-29T13:00:00", text = "Event 4"},
                };
            }
            else if (studentID == 24)
            {
                tutorSched = new List<studentSchedInfo>
                {
                    new studentSchedInfo{calID = 1, studentID = 24, startTime = "2013-03-24T02:00:00", endTime = "2013-03-24T04:00:00", text = "Event 1"},
                    new studentSchedInfo{calID = 2, studentID = 24, startTime = "2013-03-27T12:00:00", endTime = "2013-03-27T15:00:00", text = "Event 2"},

                };
            }
            else if (studentID == 25)
            {
                tutorSched = new List<studentSchedInfo>
                {
                    new studentSchedInfo{calID = 7, studentID = 25, startTime = "2013-03-24T18:00:00", endTime = "2013-03-25T23:59:00", text = "Event 1"},
                    new studentSchedInfo{calID = 8, studentID = 25, startTime = "2013-03-24T02:00:00", endTime = "2013-03-25T13:00:00", text = "Event 2"},
                };
            }
            else
            {
                tutorSched = null;
            }
            var json = new JavaScriptSerializer().Serialize(tutorSched);
            return json;

        }
    }*/
    }
}