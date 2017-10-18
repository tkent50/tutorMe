﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorSearch.aspx.cs" Inherits="WebApplication5.TutorSearch" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">

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
    <script src="Scripts/addTutor.js"></script>
</head>

<body onload="onPageLoad()">
    <div id="mn-wrapper">
        <div class="mn-sidebar">
            <div class="mn-toggle">
                <i class="fa fa-bars"></i>
            </div>
            <div class="mn-navblock">
                <ul id="classList" class="mn-vnavigation">

                    <li id="testParentParent" class="dropdown-submenu">
                        <a tabindex="-1" href="#">Front End Team</a>
                        <ul id="testParent" class="dropdown-menu">
                            <li id="test">
                                <a tabindex="-1" href="#" onclick="alert(this.parentNode.parentNode.parentNode.id)">Rajat Srivastava</a>
                            </li>
                            <li>
                                <a href="#" onclick="showTutor(this.innerHTML)">Matt Coker</a>
                            </li>
                            <li>
                                <a href="#" onclick="showTutor(this.innerHTML)">Srishti Gupta</a>
                            </li>
                        </ul>
                    </li>

                </ul>
            </div>
            <div class="bottom-mn">
                <ul class="mn-vnavigation">
                    <li>
                        <a href="#">My Favourite</a>
                    </li>
                    <li>
                        <a href="#">Most Popular</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="container" id="mn-cont">
            <div class="cnt-mcont">
                <div id="tutorInfo">
                    <h1></h1>
                    <div id="heading">
                        <p id="tutorName" style="float:left; font-size: 40px; font-weight: bold; padding-right: 100px;">Tutor Name</p>
                        <p id="tutorClass" style="float: left; font-size: 30px; font-weight: bold; top: 10px; left: 30px; margin-bottom: 5px; padding-top: 2px;">CS 408</p>
                    </div>

                    <div style="position: relative; clear:both; top:10px">
                        <p id="tutorEmail" style="position: relative; font-size: 20px; float: left; padding-right: 30px; padding-left: 5px;">
                            <a style="font-weight: bold; color:black;">Email: </a>
                            <a href="mailto:" style="color:black;">username@purdue.edu</a>
                        </p>
                        <p style="position: relative; font-size: 20px; float: left; left:30px">
                            <a style="font-weight: bold; color:black;">Phone: </a>
                            <a href="tel:">465-867-5309</a>
                        </p>
                    </div>
                    <br>
                    <hr size="100" style="position: relative; width: 100%; font-weight: bold; "></hr>
                    <div style="position: relative; height:10px">
                        <p style="position: relative; font-size: 20px; top: 5px; float: left;  height: 10px; left: 5px;">$$$/hr</p>
                        <br>
                        <br>
                        <form style="position: absolute; float: left;  left: 50; height: 10;">
                            <fieldset class="starability-heart">

                                <input type="radio" id="rate1" name="rating" value="1" />
                                <label for="rate1">1 star.</label>

                                <input type="radio" id="rate2" name="rating" value="2" />
                                <label for="rate2">2 stars.</label>

                                <input type="radio" id="rate3" name="rating" value="3" />
                                <label for="rate3">3 stars.</label>

                                <input type="radio" id="rate4" name="rating" value="4" />
                                <label for="rate4">4 stars.</label>

                                <input type="radio" id="rate5" name="rating" value="5" />
                                <label for="rate5">5 stars.</label>
                            </fieldset>
                        </form>
                    </div>
                    <br>
                    <br>
                    <br>
                    <br>
                    <div class="container" style="padding-left:0px; padding-bottom:5px">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pretium mattis nisl non accumsan. Lorem
                            ipsum dolor sit amet, consectetur adipiscing elit. Mauris risus orci, laoreet ac lacus malesuada,
                            viverra iaculis tellus. Mauris suscipit augue at augue finibus, id aliquet mauris commodo. Morbi
                            eu rhoncus velit. Proin leo risus, vulputate tempus scelerisque sit amet, congue non velit. Donec
                            risus mauris, imperdiet eu tincidunt id, scelerisque nec quam. Quisque mattis pellentesque est,
                            vel suscipit metus iaculis sed. Maecenas elit nisl, imperdiet quis dui id, rhoncus tempus ligula.
                            In hac habitasse platea dictumst. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Interdum
                            et malesuada fames ac ante ipsum primis in faucibus. Aenean fringilla congue enim, id posuere
                            ex ornare id.</p>
                    </div>
                    <div id="dp" class="container" style="padding-left:0px; border:0px">
                    <script type="text/javascript">
                        var dp = new DayPilot.Calendar("dp");
                        // view
                        dp.startDate = "2013-03-25";  // or just dp.startDate = "2013-03-25";
                        dp.viewType = "Week";
                        // event creating
                        dp.onTimeRangeSelected = function (args) {
                            var name = prompt("New event name:", "Event");
                            if (!name) return;
                            var e = new DayPilot.Event({
                                start: args.start,
                                end: args.end,
                                id: DayPilot.guid(),
                                text: name
                            });
                            dp.events.add(e);
                            dp.clearSelection();
                        };
                        dp.onEventClick = function (args) {
                            alert("clicked: " + args.e.id());
                        };
                        dp.headerDateFormat = "dddd";
                        dp.init();
                        var e = new DayPilot.Event({
                            start: new DayPilot.Date("2013-03-25T12:00:00"),
                            end: new DayPilot.Date("2013-03-25T12:00:00").addHours(3).addMinutes(15),
                            id: "1",
                            text: ""
                        });
                        dp.events.add(e);
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
    <script src="js/main_page.js"></script>

</body>
    </html>
</asp:Content>

