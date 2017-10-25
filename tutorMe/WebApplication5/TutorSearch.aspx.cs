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
using System.Web.Script.Serialization;
using System.Diagnostics;

public class ClassTutor // USED FOR TUTORINFO
{
    public string firstname;
    public string lastname;
    public int userId;

    public ClassTutor(string firstname, string lastname, string userId)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.userId = Int32.Parse(userId);
    }
}

public class Tutor // USED FOR TUTOR DETAILS
{
    public string firstname;
    public string lastname;
    public string bio;
    public string email;
    public string phone;
    public double rating;

    public Tutor(string firstname, string lastname, string bio, string email, string phone, string rating)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.bio = bio;
        this.email = email;
        this.phone = phone;
        this.rating = Double.Parse(rating);
    }
}

namespace WebApplication5
{
    public partial class TutorSearch : System.Web.UI.Page
    {
        static string userId = "";

        public string CommandText { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            Debug.WriteLine(GetClasses());
            string cs250 = getClassTutors("CS250");
            System.Diagnostics.Trace.WriteLine("cs250 --");
            System.Diagnostics.Trace.WriteLine(cs250);
            string cs251 = getClassTutors("CS251");
            System.Diagnostics.Trace.WriteLine("cs251 --");
            System.Diagnostics.Trace.WriteLine(cs251);
            string details = getTutorDetails(16);
            System.Diagnostics.Trace.WriteLine("16 --");
            System.Diagnostics.Trace.WriteLine(details);
            */
            getTutorSchedule(25);
            setTutorSchedule(28, "2013-03-27 11:45:30", "2013-03-27 13:45:30", 5, "CS354");
            setTutorSchedule(28, "2013-03-27 09:45:30", "2013-03-27 10:45:30", 5, "CS354");


            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            if (userIdCookie == null)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                userId = userIdCookie.Value;
            }
            changeButton();
        }

        [WebMethod] // DONE
        public static string[] GetClasses()
        {
            string[] classList;
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                con.Open();
                //get total number of classes
                MySqlCommand countCom = new MySqlCommand("SELECT COUNT(*) FROM classes", con);
                Int32 count = Convert.ToInt32(countCom.ExecuteScalar());
                classList = new string[count + 1];
                string countString = count.ToString();
                classList[0] = countString;

                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM classes", connection: con);
                MySqlDataReader reader = cmd.ExecuteReader();

                int classCount = 1;
                while (reader.Read())
                {
                    classList[classCount++] = reader["className"].ToString();
                }
                con.Close();
                for (int j = 0; j < classCount; j++)
                {
                    System.Diagnostics.Trace.WriteLine(classList[j]);
                }
            }

            Debug.WriteLine(classList);
            return classList;
        }

        [WebMethod] // DONE
        public static string getClassTutors(string className)
        {
            List<ClassTutor> tutorList = new List<ClassTutor>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText: $"SELECT * FROM users JOIN tutorClasses ON users.userID = tutorClasses.tutorID WHERE tutorClasses.className = '{className}' AND userID != @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string first = reader["firstname"].ToString();
                    string last = reader["lastname"].ToString();
                    string id = reader["userID"].ToString();
                    ClassTutor newTutor = new ClassTutor(first, last, id);
                    tutorList.Add(newTutor);

                }

                con.Close();
            }
            string classTutors = JsonConvert.SerializeObject(tutorList);
            return classTutors;
        }

        [WebMethod] // DONE - SHARES A RATING FOR ALL CLASSES
        public static string getTutorDetails(int tutorID)
        {
            List<Tutor> tutorDetails = new List<Tutor>();
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @tutorID", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                //TODO write tutor data to tutor object
                string first = reader["firstname"].ToString();
                string last = reader["lastname"].ToString();
                string bio = reader["bio"].ToString();
                string email = reader["email"].ToString();
                string phone = reader["phoneNumber"].ToString();
                con.Close();


                MySqlCommand cmd2 = new MySqlCommand(cmdText: "SELECT * FROM tutorRatings WHERE tutorID = @tutorID", connection: con);
                cmd2.Parameters.AddWithValue("@tutorID", tutorID);
                con.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                bool found = false;
                while (reader2.Read())
                {
                    found = true;
                }

                string rating = "0";
                if (found)
                {
                    rating = reader2["rating"].ToString();
                }
                con.Close();

                Tutor newTutor = new Tutor(first, last, bio, email, phone, rating);
                tutorDetails.Add(newTutor);

            }
            string tutorDetail = JsonConvert.SerializeObject(tutorDetails);
            return tutorDetail;
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
        protected bool UserIsTutor(string userID)
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
                }
                con.Close();
            }
            return isTutor;
        }
        protected void changeButton()
        {
            // Add a try catch there
            /* 
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            string userId = userIdCookie.Value;
            if (UserIsTutor(userId))
            {
                become_tutor.Text = "Tutor Settings";
            }
            */

        }


        /*********************************** EVERYTHING BELOW ARE TEST METHODS ***********************************/

        public class tutor
        {
            public string name;
            public int id;
        }

        public class tutorInfo
        {
            public string name;
            public string description;
            public string email;
            public string phone;
            public double rating;
        }

        [WebMethod]
        public static string[] getClassesTest()
        {
            var classes = new string[] { "3", "class1", "class2", "class3" }; // First number is size of array

            return classes;
        }
        [WebMethod]
        public static string getTutorsTest(string input)
        {

            Debug.WriteLine("getTutorsTest recieved " + input);
            List<tutor> classTutors;

            if (String.Compare(input, "class1") == 0)
            {
                classTutors = new List<tutor>
                {
                    new tutor{name = "John", id = 1},
                    new tutor{name = "Jane", id = 2}
                };
            }
            else if (String.Compare(input, "class2") == 0)
            {
                classTutors = new List<tutor>
                {
                    new tutor{name = "Jack", id = 3},
                    new tutor{name = "Jill", id = 4}
                };
            }
            else if (String.Compare(input, "class3") == 0)
            {
                classTutors = new List<tutor>
                {
                    new tutor{name = "John", id = 1},
                    new tutor{name = "Jack", id = 3}
                };
            }
            else
            {
                classTutors = null;
            }

            // Normally, return this variable. It's a json string.
            var json = new JavaScriptSerializer().Serialize(classTutors);

            return json;
        }


        [WebMethod]
        public static string getTutorInfoTest(string id)
        {

            Debug.WriteLine("getTutorInfoTest recieved " + id);

            tutorInfo info = new tutorInfo
            {
                name = "Test Name",
                description = "Test description",
                email = "test@email.com",
                phone = "867-5309",
                rating = 2.5
            };

            var json = new JavaScriptSerializer().Serialize(info);
            return json;
        }

        public class tutorSchedInfo
        {
            public int calID;
            public int tutorID;
            public string text;
            public string startTime;
            public string endTime;
        }


        [WebMethod]
        public static int setTutorSchedule(int userId, string startTime, string endTime, int calId, string text)
        {
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO tutorSchedules(tutorID,startTime,endTime,calID,text) VALUES(@tutorID, @startTime,@endTime,@calID,@text)", connection: con);
                cmd.Parameters.AddWithValue("@tutorID", userId);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@calID", calId);
                cmd.Parameters.AddWithValue("@text", text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
        }
        [WebMethod]
        public static string getTutorSchedule(int userId)
        {
            List<tutorSchedInfo> tutorSched = new List<tutorSchedInfo>();

            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorSchedules WHERE tutorID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int calID = 0;
                int tutorID = Convert.ToInt32(userId);
                string startTime = "";
                string endTime = "";
                string text = "";
                while (reader.Read())
                {
                    calID = Convert.ToInt32(reader["calID"].ToString());
                    startTime = reader["startTime"].ToString();
                    endTime = reader["endTime"].ToString();
                    text = reader["text"].ToString();
                    tutorSched.Add(new tutorSchedInfo { calID = calID, tutorID = tutorID, startTime = startTime, endTime = endTime, text = text });
                }
                con.Close();
                var json = new JavaScriptSerializer().Serialize(tutorSched);
                return json;

            }
        }
    }
}