using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class main_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class eventObj
        {
            public int eventID;
            public int tutorId;
            public string text;
            public string start;
            public string end;
        }

        [WebMethod]
        public static string setTutorScheduleTest()
        {
            List<eventObj> tutorSched;

            int tutorID = 23;

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