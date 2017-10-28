<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorSettings.aspx.cs" Inherits="WebApplication5.TutorSettings" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Tutor Settings</title>
    <link href="images/icon_settings.png" rel="icon" type="image/x-icon" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M"
        crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/tutor_setting.js"></script>
    <script src="Scripts/daypilot-all.min.js?v=217" type="text/javascript"></script>
    <link rel="stylesheet" href="css/tutor_setting.css">
</head>

<body onload="onTutorSettingPageLoad()">
    
        <form id="regform" runat="server">
            <!-- .net FORM -->
            <div class="container-fluid" style="background-color:lightgrey; padding-top: 30px; width: 1000px; margin-top: 20px; margin-bottom: 20px;">
                <h3 style="text-align: center;">Change Tutor Settings</h3>
                <br />
                <form style="padding-top: 20px;">

                    <div class="form-group row">
                        <label for="bio" class="col-sm-2 col-form-label">Add Bio</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="addBio" placeholder="Bio" class="form-control" type="text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group row">
                        <label for="phone" class="col-sm-2 col-form-label">Phone Number</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="addPhone" placeholder="Phone Number" class="form-control" type="text" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="container text-center">

                        <asp:Button ID="submit" runat="server" OnClick="SubmitChanges" class="btn btn-secondary btn-lg active" Text="Submit"></asp:Button>

                    </div>
                    <br />
                </form>
            </div>
            <br />
            <br />
            <div class="container-fluid" style="background-color:lightgrey; padding-top: 30px; width: 1000px; margin-top: 20px; margin-bottom: 20px;">

            <h3 style="text-align: center;">Add Class</h3>
            <div style="padding-top: 20px; margin-left: 40px;" class="row">
                <div align="center" class="col">
                    <div class="form-group row">
                        <div class="dropdown">
                            <button id="mydef" class="btn dropdown-toggle" type="button" data-toggle="dropdown">
                                <div class="col-10">
                                    <input type="text" id="search" class="form-control input-lg" placeholder="Add Class"></input>
                                </div>
                            </button>
                            <ul id="classList" class="dropdown-menu">
                            </ul>

                        </div>
                    </div>
                </div>
                <div align="center" class="col">
                    <div class="form-group row">
                        <div class="col-10">
                            <div class="input-group">
                                <span class="input-group-addon">$</span>
                                <input id="amount" type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                                <span class="input-group-addon">.00</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div align="center" class="col">
                    <div class="form-group row">
                        <div class="col-10">
                            <asp:Button ID="addButton" runat="server" OnClientClick="AddClassChange()" class="btn btn-secondary btn-lg active" Text="Add"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <div class="input-group">
                        <input id="newClassName" type="text" class="form-control" placeholder="Add non-existing class" />
                        <span class="input-group-btn">
                            <asp:Button runat="server" class="btn btn-secondary btn-lg active" OnClientClick="addNonExistingClass()" text="Add"></asp:Button>
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-4 -->
                <div class="col-lg-4"></div>
            </div>
            <!-- /.row -->
        </div>
        <br />
        <br />
            <br />
            <br />

            <div class="container" >
                <table id="tutoringClassess" class="table">
                    <thead>
                        <tr style="background-color:grey;">
                            <th style="text-align:center">Class</th>
                            <th style="text-align:center">Rate</th>
                            <th style="text-align:center">Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <br />
            
             <div style="padding-top: 20px;" class="container">
            <h3 style="text-align: center;">Add Class Schedule</h3>
                 <h6 style="text-align: center;">Drag to add & click to cancel</h6>
                 <br />
            <div id="calendar" class="container" style="padding-left: 0px; border: 0px">
                <script>

                    var dp;
                    function initializeCal() {
                        dp = new DayPilot.Calendar("calendar");
                        dp.startDate = "2013-03-25";
                        dp.viewType = "Week";
                        //dp.timeRangeSelectedHandling = "Disabled";
                        dp.eventMoveHandling = "Disabled";
                        dp.eventResizeHandling = "Disabled";
                        dp.init();
                        dp.headerDateFormat = "dddd";

                    }
                    dp = new DayPilot.Calendar("calendar");
                    dp.startDate = "2013-03-25";
                    dp.viewType = "Week";
                    //dp.timeRangeSelectedHandling = "Disabled";
                    dp.eventMoveHandling = "Disabled";
                    dp.eventResizeHandling = "Disabled";
                    dp.init();
                    dp.headerDateFormat = "dddd";

                    getTutorSched();
                    dp.onTimeRangeSelected = function (args) {
                        var name = prompt("New event name:", "Event");
                        if (!name) return;
                        start = args.start;
                        end = args.end;
                        //id = 0;
                        text = name;
                        setTutorSched(start, end, text);
                        var e = new DayPilot.Event({
                            start: args.start,
                            end: args.end,
                            text: name
                        });
                        dp.events.add(e);
                        dp.clearSelection();
                    };

                    dp.onEventClick = function (args) {
                        console.log(args);
                        if (confirm('Are you sure you want to delete this event?')) {
                            deleteSched(args.e.data.start.value, args.e.data.end.value);

                        } 
                    };




                </script>

            </div>
            <br />
            <br />

            <div class="container-fluid" style="justify-content: space-between; flex-direction: display: flex; padding-bottom: 20px">
                <div class="btn-holder" style="justify-content: flex-end; display: flex;">
                    <a class="btn btn-secondary btn-lg active" style="margin-right:15px;" href="/TutorSearch.aspx">Main Page</a>                   
                    <a class="btn btn-secondary btn-lg active" href="/UserSettings.aspx">User Settings</a>
                </div>
            </div>
           </div>

            <!-- Optional JavaScript -->
            <!-- jQuery first, then Popper.js, then Bootstrap JS -->
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4"
                crossorigin="anonymous"></script>
            <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1"
                crossorigin="anonymous"></script>
        </form>

    
</body>

</html>
