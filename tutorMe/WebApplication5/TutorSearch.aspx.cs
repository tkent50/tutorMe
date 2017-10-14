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

                   MySqlCommand cmd = new MySqlCommand("SELECT * FROM classes", con);
                   MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                   DataSet ds = new DataSet();
                   //adp.Fill(ds);
                   //GridView1.DataSource = ds;
                   //GridView1.DataBind();
                   cmd.Dispose();
                   con.Close();
        }
        protected void GetClasses()
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM classes", connection: con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write classes to class object
                    reader["classID"].ToString();
                    reader["className"].ToString();
                }
                con.Close();
            }
        }
        protected void GetTutorNames(int classID)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: ("SELECT * FROM users JOIN tutorClasses ON users.userID = tutorClasses.tutorID WHERE tutorClasses.classID = " + classID.ToString()), connection: con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write user data to user object
                    reader["firstname"].ToString();
                    reader["lastname"].ToString();
                    reader["userID"].ToString();
                }
                con.Close();
            }
        }
        protected void GetTutorDetails(int tutorID, int classID)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @tutorID", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write tutor data to tutor object
                    reader["firstname"].ToString();
                    reader["lastname"].ToString();
                    reader["bio"].ToString();
                    reader["email"].ToString();
                }
                con.Close();
            }

            MySqlConnection con2 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorClasses WHERE tutorID = @tutorID AND classID = @classID", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                cmd.Parameters.AddWithValue("@classID", classID);
                con2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write tutor data to tutor object
                    reader["price"].ToString();
                    reader["avgRating"].ToString();
                }
                con2.Close();
            }

            MySqlConnection con3 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorSchedules WHERE tutorID = @tutorID AND classID = @classID", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                cmd.Parameters.AddWithValue("@classID", classID);
                con3.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write tutor data to tutor object
                    reader["startTime"].ToString();
                    reader["endTime"].ToString();
                }
                con3.Close();
            }
        }
        protected void RateTutor(int userID, int tutorID, int classID, int rating)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO tutorRatings(userID, tutorID, classID, rating) VALUES('@userID', '@tutorID', '@classID', '@rating'", connection: con);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                cmd.Parameters.AddWithValue("@classID", classID);
                cmd.Parameters.AddWithValue("@rating", rating);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void GetClassSchedule(int classID)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorSchedules WHERE classID = @classID", connection: con);
                cmd.Parameters.AddWithValue("@classID", classID);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //TODO write schedule data to class schedule object
                    reader["startTime"].ToString();
                    reader["endTime"].ToString();
                }
                con.Close();
            }
        }
        protected bool UserIsTutor(int userID)
        {
            bool isTutor = false;
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: ("SELECT * FROM users WHERE userID = @userID"), connection: con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((bool)reader["isTutor"] == true)
                    {
                        isTutor = true;
                    }
                    reader["endTime"].ToString();
                }
                con.Close();
            }
            return isTutor;
        }

        [WebMethod]
        public static string[] getClasses()
        {
            var classes = new string[] { "6", "class1", "class2", "class3", "class4", "class5", "class6" }; // First number is size of array
            
            return classes;
        }
    }
}