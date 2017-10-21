/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;


namespace WebApplication5
{
    public partial class main_page_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData()
        {
            //MySqlConnection con = new MySqlConnection("server=tutormedatabase.c9h5bv0oz1hd.us-east-2.rds.amazonaws.com;user id=tutormaster;port=3306;database=tutormedb1;persistsecurityinfo=True;password=5515hebt");
            // con.Open();
            /*
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM classes", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            */
            //adp.Fill(ds);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
            //cmd.Dispose();
            //con.Close();
        }


        /******************* Testing **************************************************/
       /*
        public class eventObj
        {
            public int eventID;
            public int tutorId;
            public string text;
            public string start;
            public string end;
        }

        [WebMethod]
        public static string setTutorScheduleTest(int tutorID)
        {
            List<eventObj> tutorSched;

            if (tutorID == 23)
            {
                tutorSched = new List<eventObj>
                {
                    new eventObj{eventID = 3, tutorId = 23, start = "2013-03-24T02:00:00", end = "2013-03-25T04:00:00", text = "Event 1"},
                    new eventObj{eventID = 4, tutorId = 23, start = "2013-03-24T12:00:00", end = "2013-03-25T15:00:00", text = "Event 2"},
                    new eventObj{eventID = 5, tutorId = 23, start = "2013-03-24T18:00:00", end = "2013-03-25T23:59:00", text = "Event 3"},
                    new eventObj{eventID = 6, tutorId = 23, start = "2013-03-24T02:00:00", end = "2013-03-25T13:00:00", text = "Event 4"},
                };

            }
            else if (tutorID == 24)
            {
                tutorSched = new List<eventObj>
                {
                    new eventObj{eventID = 1, tutorId = 24, start = "2013-03-24T02:00:00", end = "2013-03-25T04:00:00", text = "Event 1"},
                    new eventObj{eventID = 2, tutorId = 24, start = "2013-03-24T12:00:00", end = "2013-03-25T15:00:00", text = "Event 2"},

                };
            }
            else if (tutorID == 25)
            {
                tutorSched = new List<eventObj>
                {
                    new eventObj{eventID = 7, tutorId = 25, start = "2013-03-24T18:00:00", end = "2013-03-25T23:59:00", text = "Event 1"},
                    new eventObj{eventID = 8, tutorId = 25, start = "2013-03-24T02:00:00", end = "2013-03-25T13:00:00", text = "Event 2"},
                };
            }
            else
            {
                tutorSched = null;
            }

            var json = new JavaScriptSerializer().Serialize(tutorSched);

            return json;

        }


    }
}
*/