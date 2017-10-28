using System;
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
    public partial class TutorSettings : System.Web.UI.Page
    {
        static string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (userIdCookie == null)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                userId = userIdCookie.Value;
            }
        }

        protected void SubmitChanges(object sender, EventArgs e)
        {
            HttpCookie userIdCookie = Request.Cookies.Get("userId");

            if(addBio.Text != "")
            {
                UpdateBio(addBio.Text);
            }

            if(addPhone.Text != "")
            {
                UpdatePhoneNumber(addPhone.Text);
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

        public class tutorSchedInfo
        {
            public int tutorID;
            public string text;
            public string startTime;
            public string endTime;
        }

        [WebMethod]
        public static int addClass(string className)
        {
            string trimmed = className.Replace(" ", "");
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO classes(className) VALUES(@className)", connection: con);
                cmd.Parameters.AddWithValue("@className", trimmed);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
        }
        [WebMethod]
        public static string deleteTutorSchedule(string startTime, string endTime)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "DELETE from tutorSchedules where tutorID = @userId AND startTime = @startTime", connection: con);
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
        public static int setTutorClass(string className, double rate)
        {
            int classId = 0;

            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM classes WHERE className = @className", connection: con);
                cmd.Parameters.AddWithValue("@className", className);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classId = Convert.ToInt32(reader["classID"].ToString());
                }
                con.Close();
            }  

            MySqlConnection con2 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                double avgRate = 0.0;
                MySqlCommand cmd2 = new MySqlCommand(cmdText: "INSERT INTO tutorClasses(tutorID,classID,price,avgRating,className) VALUES(@tutorID, @classID,@price,@avgRating,@className)", connection: con2);
                cmd2.Parameters.AddWithValue("@tutorID", userId);
                cmd2.Parameters.AddWithValue("@classID", classId);
                cmd2.Parameters.AddWithValue("@price", rate);
                cmd2.Parameters.AddWithValue("@avgRating", avgRate);
                cmd2.Parameters.AddWithValue("@className", className);
                con2.Open();
                cmd2.ExecuteNonQuery();
                con2.Close();
            }
            return 1;
        }
	
        [WebMethod]
        public static string setTutorSchedule(string startTime, string endTime, string text)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO tutorSchedules(tutorID, startTime, endTime, text) VALUES(@tutorID, @startTime, @endTime, @text)", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", userId);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@text", text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "success";
            }
        }
        [WebMethod]
        public static string getTutorSchedule()
        {
            List<tutorSchedInfo> tutorSched = new List<tutorSchedInfo>();

            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorSchedules WHERE tutorID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int tutorID = Convert.ToInt32(userId);
                string startTime = "";
                string endTime = "";
                string text = "";
                while (reader.Read())
                {
                    startTime = reader["startTime"].ToString();
                    endTime = reader["endTime"].ToString();
                    text = reader["text"].ToString();
                    tutorSched.Add(new tutorSchedInfo { tutorID = tutorID, startTime = startTime, endTime = endTime, text = text });
                }
                con.Close();
                var json = new JavaScriptSerializer().Serialize(tutorSched);
                return json;

            }
        }

        public class tutorRate
        {
            public string className;
            public double rate;
        }




        [WebMethod]
        public static string classRate()
        {
            List<tutorRate> tutorRate = new List<tutorRate>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorClasses WHERE tutorID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string className = reader["className"].ToString();
                    double rate = Convert.ToDouble(reader["price"].ToString());
                    tutorRate.Add(item: new tutorRate { className = className, rate = rate });
                }
                con.Close();
                var json = new JavaScriptSerializer().Serialize(tutorRate);
                return json;

            }
        }


        [WebMethod]
        public static int deleteTutorClass(string className)
        {
            List<tutorRate> tutorRate = new List<tutorRate>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "DELETE from tutorClasses where tutorId = @userId AND className = @className", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@className", className);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
        }

        [WebMethod]
        public static void UpdateBio(string bio)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "UPDATE users SET bio = @bio WHERE userID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@bio", bio);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        [WebMethod]
        public static void UpdatePhoneNumber(string phoneNumber)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "UPDATE users SET phoneNumber = @phoneNumber WHERE userID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}