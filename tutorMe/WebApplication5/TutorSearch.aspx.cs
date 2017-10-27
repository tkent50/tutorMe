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
using System.Net.Mail;
using System.Net;

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

        [WebMethod]
        public static void RateTutor(int tutorID, int classID, int rating)
        {
            bool alreadyRated = false;
            MySqlConnection con1 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorRatings WHERE userID = @userID AND tutorID = @tutorID", connection: con1);
                cmd.Parameters.AddWithValue("@userID", userId);
                cmd.Parameters.AddWithValue("@tutorID", tutorID);
                con1.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    alreadyRated = true;
                }
                con1.Close();
            }
            if (alreadyRated)
            {
                MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                {
                    MySqlCommand cmd = new MySqlCommand(cmdText: "UPDATE tutorRatings SET rating = @rating WHERE tutorID = @tutorID AND userID = @userID", connection: con);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
                {
                    MySqlCommand cmd = new MySqlCommand(cmdText: "INSERT INTO tutorRatings(userID, tutorID, rating) VALUES('@userID', '@tutorID', '@rating'", connection: con);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@tutorID", tutorID);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
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
            HttpCookie userIdCookie = Request.Cookies.Get("userId");
            string userId = userIdCookie.Value;
            if (UserIsTutor(userId))
            {
                become_tutor.Text = "Tutor Settings";
            }
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
            public int tutorID;
            public string text;
            public string startTime;
            public string endTime;
        }

<<<<<<< HEAD
        /*
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
        */
=======
>>>>>>> master
        [WebMethod]
        public static string getTutorSchedule(int tutorId)
        {
            List<tutorSchedInfo> tutorSched = new List<tutorSchedInfo>();

            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM tutorSchedules WHERE tutorID = @userId", connection: con);
                cmd.Parameters.AddWithValue("@userId", tutorId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int tutorID = Convert.ToInt32(tutorId);
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

        [WebMethod]
        public static void SendReservationRequest(int tutorId, string startTime, string className)
        {
            //Get tutor's email and name
            string tutorEmail = "";
            string tutorFirst = "";
            string tutorLast = "";
            MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @tutorId", connection: con);
                cmd.Parameters.AddWithValue("@tutorId", tutorId);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tutorEmail = reader["email"].ToString();
                    tutorFirst = reader["firstName"].ToString();
                    tutorLast = reader["lastName"].ToString();
                }
                con.Close();
            }
            string tutorFull = tutorFirst + " " + tutorLast;

            //Get student's email and name
            string studentEmail = "";
            string studentFirst = "";
            string studentLast = "";
            MySqlConnection con1 = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            {
                MySqlCommand cmd = new MySqlCommand(cmdText: "SELECT * FROM users WHERE userID = @userId", connection: con1);
                cmd.Parameters.AddWithValue("@userId", userId);
                con1.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    studentEmail = reader["email"].ToString();
                    studentFirst = reader["firstName"].ToString();
                    studentLast = reader["lastName"].ToString();
                }
                con1.Close();
            }
            string studentFull = studentFirst + " " + studentLast;

            //Parse time string
            string[] startTimeSplit = startTime.Split(new Char['T']);
            string[] startDateSplit = startTimeSplit[0].Split(new Char['-']);
            string dayOfWeekNumber = startDateSplit[2];
            string dayOfWeek = "";

            switch(dayOfWeekNumber)
            {
                case "24":
                    dayOfWeek = "Sunday";
                    break;
                case "25":
                    dayOfWeek = "Monday";
                    break;
                case "26":
                    dayOfWeek = "Tuesday";
                    break;
                case "27":
                    dayOfWeek = "Wednesday";
                    break;
                case "28":
                    dayOfWeek = "Thursday";
                    break;
                case "29":
                    dayOfWeek = "Friday";
                    break;
                case "30":
                    dayOfWeek = "Saturday";
                    break;
            }

            string[] timeSplit = startTimeSplit[1].Split(new Char[':']);
            string hour = timeSplit[0];
            string minute = timeSplit[1];
            string ampm = "AM";
            string time = "";

            switch (hour)
            {
                case "00":
                    hour = "12";
                    break;
                case "01":
                    hour = "1";
                    break;
                case "02":
                    hour = "2";
                    break;
                case "03":
                    hour = "3";
                    break;
                case "04":
                    hour = "4";
                    break;
                case "05":
                    hour = "5";
                    break;
                case "06":
                    hour = "6";
                    break;
                case "07":
                    hour = "7";
                    break;
                case "08":
                    hour = "8";
                    break;
                case "09":
                    hour = "9";
                    break;
                case "10":
                    break;
                case "11":
                    break;
                case "12":
                    ampm = "PM";
                    break;
                case "13":
                    hour = "1";
                    ampm = "PM";
                    break;
                case "14":
                    hour = "2";
                    ampm = "PM";
                    break;
                case "15":
                    hour = "3";
                    ampm = "PM";
                    break;
                case "16":
                    hour = "4";
                    ampm = "PM";
                    break;
                case "17":
                    hour = "5";
                    ampm = "PM";
                    break;
                case "18":
                    hour = "6";
                    ampm = "PM";
                    break;
                case "19":
                    hour = "7";
                    ampm = "PM";
                    break;
                case "20":
                    hour = "8";
                    ampm = "PM";
                    break;
                case "21":
                    hour = "9";
                    ampm = "PM";
                    break;
                case "22":
                    hour = "10";
                    ampm = "PM";
                    break;
                case "23":
                    hour = "11";
                    ampm = "PM";
                    break;
            }

            string bodyText = studentFull + " would like to be tutored in " + className + " on " + dayOfWeek + " at " + hour + ":" + minute + " " + ampm + ".";
            string subjectText = studentFull + "wants to be tutored!";

            MailAddress fromAddress = new MailAddress("tutorapp408@gmail.com", "TutorMe");
            MailAddress toAddress = new MailAddress(tutorEmail, tutorFull);
            MailAddress copy = new MailAddress(studentEmail, studentFull);
            const string fromPassword = "5515hebt";
            
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subjectText;
            message.Body = bodyText;
            message.CC.Add(copy);
            smtp.Send(message);
        }
    }
}