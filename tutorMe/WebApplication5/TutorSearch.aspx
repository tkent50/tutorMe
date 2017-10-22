<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorSearch.aspx.cs" Inherits="WebApplication5.TutorSearch" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent">



<html>
<style type="text/css">
    /* Tutor info pane */

    #tutorInfo {
        height: 100%;
        width: calc(100% - 285px);
        position: absolute;
        float: right;
        margin-left: 300px;
        visibility: hidden;
        background: gray;
        color: black;
        padding-left: 60px;
    }
</style>


<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="Content/starRating/starability-all.css"/>
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="Content/normalize.css" />
    <link rel="stylesheet" type="text/css" href="Content/demo.css" />
    <link rel="stylesheet" type="text/css" href="Content/icons.css" />
    <link rel="stylesheet" type="text/css" href="Content/component.css" />
    <!-- Bootstrap -->
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">
    <script src="Scripts/modernizr.custom.js"></script>
    <script src="Scripts/addTutor.js"></script>

    <script src="Scripts/daypilot-all.min.js?v=217" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>

    <title>Find a Tutor!</title>
</head>
<body onload="onPageLoad()">
    <div class="container-fluid">
   <!-- Div that loads tutor content -->
   <div id="tutorInfo">

    <div id="heading" style="position: relative; width: 400; top:20">
        <p id="tutorName" style="position: relative; float:left;font-size: 40; font-weight: bold;"></p>
        <p id="tutorClass" style="position: relative; float: left; font-size: 30; font-weight: bold; top: 10; left: 30; ">CS 408</p>    
    </div>

    <div style="position: relative; clear:both; top:10">
        <p id="tutorEmail" style="position: relative; font-size: 20; float: left;"><a href="mailto:" style="color:black;">username@purdue.edu</a></p>
        <p style="position: relative; font-size: 20; float: left; left:30">465-867-5309</p>
    </div>

    <hr style="position: relative; top:10; left:-30; width: 100%" >

    <div style="position: relative; height:10px">
        <p style="position: relative; font-size: 20; top: 5; float: left;  height: 10">$$$ / hr</p>

        <form style="position: relative; float: left;  left: 50; height: 10">
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

    <div style="position:relative; top:20; padding-left:5; border:1px solid black; float: left; right:3%; overflow-y: scroll; height: 60px">
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pretium mattis nisl non accumsan. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris risus orci, laoreet ac lacus malesuada, viverra iaculis tellus. Mauris suscipit augue at augue finibus, id aliquet mauris commodo. Morbi eu rhoncus velit. Proin leo risus, vulputate tempus scelerisque sit amet, congue non velit. Donec risus mauris, imperdiet eu tincidunt id, scelerisque nec quam. Quisque mattis pellentesque est, vel suscipit metus iaculis sed. Maecenas elit nisl, imperdiet quis dui id, rhoncus tempus ligula. In hac habitasse platea dictumst. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean fringilla congue enim, id posuere ex ornare id.</p>
    </div>

    <div id="dp" style="position:relative;float: left; right:3%; top:5%; border: 0px"></div>

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
<!-- end of tutor info -->

<!-- div for main page -->
<div class="container-fluid">
    <!-- Push Wrapper -->
    <div class="mp-pusher" id="mp-pusher">
        <!-- mp-menu -->
        <nav id="mp-menu" style="left:300; " class="mp-menu">
            <div class="mp-level">
                <h2>Classes</h2>
                    <ul id="classList">
                        <li class="icon icon-arrow-left" >
                            <a href="#">Class A</a>
                            <div class="mp-level">
                                <h2>Class A</h2>
                                <a class="mp-back" onclick="closeTutorInfo()">back</a>
                                <ul id="tutorAList">
                                    <li><a onclick="showTutor(this.innerHTML)">Tutor 1</a></li>
                                    <li><a onclick="showTutor(this.innerHTML)">Tutor 2</a></li>
                                </ul>
                            </div>
                        </li>
                            <li class="icon icon-arrow-left">
                                <a href="#">Class B</a>
                                <div class="mp-level">
                                    <h2>Class B</h2>
                                    <a class="mp-back" onclick="closeTutorInfo()">back</a>
                                    <ul>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 3</a></li>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 4</a></li>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 5</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li class="icon icon-arrow-left">
                                <a href="#">Class C</a>
                                <div class="mp-level">
                                    <h2 >Class C</h2>
                                    <a class="mp-back" onclick="closeTutorInfo()">back</a>
                                    <ul>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 6</a></li>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 7</a></li>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 8</a></li>
                                        <li><a onclick="showTutor(this.innerHTML)">Tutor 9</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </nav>
                <!-- /mp-menu -->

                <div class="scroller">

                    <!-- this is for emulating position fixed of the nav -->
                    <div class="scroller-inner" style="width: 80%; float: right">
                        <!-- Top Navigation -->
                        <header class="codrops-header">
                            <h1>Welcome to TutorMe!<span>Select 'View Classes' to begin</span></h1>
                        </header>
                        <div class="content clearfix">
                            <div class="block block-40 clearfix">
                                <p><a href="#" id="trigger" class="menu-trigger"></a></p>
                            </div>
                            <div class="block block-60">
                                <p><strong>To Start:</strong> Select 'View Classes'</p>
                                <p>Simple implementation. Can add multiple classes, tutors, etc.</p> 
                                <p>Eventually the inital menu will be permanent.</p>
                            </div>
                        </div>

                        <!-- Copy this entire btn-group div for buttons. -->
                        <div class="btn-group" id="fixedbutton" style="z-index: 3">
                            <button type="button" class="btn-lg btn-primary" onClick="location.href='Default'">Log Out</button>
                            <button type="button" class="btn-lg btn-primary" onClick="location.href='tutor_profile'">Become a tutor</button>
                        </div>
                        
                    </div><!-- /scroller-inner -->

                </div><!-- /scroller -->

            </div><!-- /pusher -->

        </div><!-- /container -->


        <script src="Scripts/classie.js"></script>
        <script src="Scripts/mlpushmenu.js"></script>
        <script>
            new mlPushMenu(document.getElementById('mp-menu'), document.getElementById('trigger'), {
                type: 'cover'
            });
        </script>
        
    </body>
    </html>
</asp:content>

=======
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
    <link rel="stylesheet" type="text/css" href="Content/starRating/starability-basic.css" />
    <link rel="stylesheet" href="css/main_page.css">
    <script src="Scripts/daypilot-all.min.js?v=217" type="text/javascript"></script>
    <script src="Scripts/main_page.js"></script>
</head>

<body onload="onPageLoad()">
    <div id="mn-wrapper">
        <div class="mn-sidebar">
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
                        <p id="tutorName" style="float:left; font-size: 40px; font-weight: bold; padding-right: 100px;"></p>
                        <p id="tutorClass" style="float: left; font-size: 30px; font-weight: bold; top: 10px; left: 30px; margin-bottom: 5px; padding-top: 2px;"></p>
                    </div>

                    <div style="position: relative; clear:both; top:10px">
                        <p  style="position: relative; font-size: 20px; float: left; padding-right: 30px; padding-left: 5px;">
                            <a style="font-weight: bold; color:black;">Email: </a>
                            <a id="tutorEmail" href="mailto:" style="color:black;"></a>
                        </p>
                        <p style="position: relative; font-size: 20px; float: left; left:30px">
                            <a style="font-weight: bold; color:black;">Phone: </a>
                            <a id="tutorPhone" href="tel:">465-867-5309</a>
                        </p>
                    </div>
                    <br>
                    <hr size="100" style="position: relative; width: 100%; font-weight: bold; "/>
                    <div style="position: relative; height:10px">
                        <p style="position: relative; font-size: 20px; top: 5px; float: left;  height: 10px; left: 5px;">$$$/hr</p>
                        <br>
                        <br>
                        <form style="position: absolute; float: left;  left: 50px; height: 10px;">
                            <fieldset class="starability-basic">

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
                        <p id="tutorDescription"></p>
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

</body>
    </html>
</asp:Content>

>>>>>>> origin/coker
