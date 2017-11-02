<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorSearch.aspx.cs" Inherits="WebApplication5.TutorSearch" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent">

<html>



<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>TutorMyClass HomePage</title>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="Content/starRating/starability-all.css" />
    <link rel="stylesheet" href="css/main_page.css">
    <script src="Scripts/daypilot-all.min.js?v=217" type="text/javascript"></script>
    <script src="Scripts/main_page.js"></script>
</head>

<body onload="onPageLoad()">
  
    <form id="regform" runat="server"> <!-- .net FORM -->
        <!-- .net FORM -->
        <div id="mn-wrapper">
            <div class="mn-sidebar" style="z-index:3; min-width:130px; left:10%">
                <div class="mn-toggle">
                    <i class="fa fa-bars"></i>
                </div>
                <div class="mn-navblock">
                    <ul id="classList" class="mn-vnavigation">

                        <!--    Example structure   -->
                        <!-- 
                        <li id="class0" class="dropdown-submenu">
                        <a href="#">Front End Team</a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="#" onclick="showTutor(this.innerHTML)">Rajat Srivastava</a>
                            </li>
                            <li>
                                <a href="#" onclick="showTutor(this.innerHTML)">Matt Coker</a>
                            </li>
                            <li>
                                <a href="#" onclick="showTutor(this.innerHTML)">Srishti Gupta</a>
                            </li>
                        </ul>
                    </li>
                        -->

                    </ul>
                </div>
                <div class="bottom-mn">
                    <ul class="mn-vnavigation">
                        <li>
                            <a href="/UserSettings.aspx">User Settings</a>
                        </li>
                        <li>
                            <asp:HyperLink ID="become_tutor" runat="server" href="/TutorSettings.aspx">Become a Tutor</asp:HyperLink>
                        </li>
                        <li>
                            <asp:Button ID="logout_button" runat="server" OnClick="DeleteCookie" class="btn btn-link btn-md active" Text="Log Out" style="width: 100%"></asp:Button>
                        </li>
                    </ul>
                </div>
            </div>

         

            
            
            <div class="container" id="mn-cont">
                <div class="container" id="landing" style="width:90%;height:90%; text-align:center; padding-top: 5%; position:absolute; z-index:2; visibility:visible ">
                    <p style="font-size:50">Welcome to TutorMyClass!</p>
                    <p style="font-size:25">From here, you can find a tutor for a class you need help in. To start, click a class on the left!</p>
                </div>

                <div class="cnt-mcont" style=" z-index:1; padding-top:3%" >
                    <div id="tutorInfo" style="visibility:hidden; position: relative; top: 50%; left:50%; transform: translate(-55%, -55%);">
                        <div id="heading" style="padding-top: 6%;">
                            <p id="tutorName" style="float: left; font-size: 40px; font-weight: bold; padding-right: 100px;"></p>
                            <p id="tutorClass" style="float: left; font-size: 30px; font-weight: bold; top: 10px; left: 30px; margin-bottom: 5px; padding-top: 2px;"></p>
                        </div>

                        <div style="position: relative; clear: both; top: 10px">
                            <p style="position: relative; font-size: 20px; float: left; padding-right: 30px; padding-left: 5px;">
                                <a style="font-weight: bold; color: black;">Email: </a>
                                <a id="tutorEmail" href="mailto:" style="color: black;"></a>
                            </p>
                            <p style="position: relative; font-size: 20px; float: left; left: 30px">
                                <a style="font-weight: bold; color: black;">Phone: </a>
                                <a id="tutorPhone" href="tel:">465-867-5309</a>
                            </p>
                        </div>
                        <br>
                        <br>
                        <form style="position: absolute; float: left;  left:0px; height: 10px; padding-top:10px">
                            <fieldset class="starability-basic">
                                <input type="radio" id="no-rate" class="input-no-rate" name="rating" value="0" checked aria-label="No rating." />
                                <input type="radio" id="rate1" name="rating" value="1" onclick="saveRating(this.value)"/>
                                <label for="rate1">1 star.</label>

                                <input type="radio" id="rate2" name="rating" value="2" onclick="saveRating(this.value)"/>
                                <label for="rate2">2 stars.</label>

                                <input type="radio" id="rate3" name="rating" value="3" onclick="saveRating(this.value)"/>
                                <label for="rate3">3 stars.</label>

                                <input type="radio" id="rate4" name="rating" value="4" onclick="saveRating(this.value)"/>
                                <label for="rate4">4 stars.</label>

                                <input type="radio" id="rate5" name="rating" value="5" onclick="saveRating(this.value)"/>
                                <label for="rate5">5 stars.</label>
                            </fieldset>
                        </form>
                        <br>
                        <br>
                        <br />
                        <br />
                        <div class="container" style="padding-left:0px; padding-bottom: 5px;height=50px">
                            <p id="tutorDescription"></p>
                        </div>
                       <div id="calendar" class="container" style="padding-left:0px; border:0px">
                        <script>
                            
                            var dp;
                            
                            dp = new DayPilot.Calendar("calendar");
                            dp.startDate = "2013-03-25";
                            dp.viewType = "Week";
                            dp.timeRangeSelectedHandling = "Disabled";
                            dp.eventMoveHandling = "Disabled";
                            dp.eventResizeHandling = "Disabled";
                            //dp.init();
                            dp.headerDateFormat = "dddd";

                            dp.onEventClick = function (args) {
                                if (confirm('Do you wanna request this time slot ?')) {
                                    sendEmail(args.e.data.start.value);
                                }
                            };
                            


                        </script>
                    </div>
                    </div>

                </div>
            </div>
        </div>


        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/bootstrap.min.js"></script>

    </form>
</body>
</html>

    </asp:content>

