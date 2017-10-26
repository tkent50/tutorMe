<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="WebApplication5.UserSettings" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>User Settings</title>
    <link href="images/icon_settings.png" rel="icon" type="image/x-icon" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M"
        crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="Scripts/user_settings.js"></script>
    <script src="Scripts/daypilot-all.min.js?v=217" type="text/javascript"></script>

</head>

<body>
    <form id="regform" runat="server">
        <!-- .net FORM -->
        <div style="padding-top: 30px;" class="container">
            <h3 style="text-align: center;">Change Login Settings</h3>
            <form style="padding-top: 20px;">
                <div class="form-group row">
                    <label for="email" class="col-sm-2 col-form-label">Change Email Address</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="email" placeholder="Email Address" class="form-control" type="text" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="password" class="col-sm-2 col-form-label">Current Password</label>
                    <div class="col-sm-10">
                        <div class="input-group">
                            <asp:TextBox ID="password" placeholder="Enter current password" class="form-control" type="password" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn btn-secondary" type="button" id="showPassword1">Show Password</button>
                            </span>
                        </div>
                        <small id="emailHelp" class="form-text text-muted">Password should be between 8 and 32 characters long</small>
                    </div>

                </div>

                <div class="form-group row">
                    <label for="password" class="col-sm-2 col-form-label">Change Password</label>
                    <div class="col-sm-10">
                        <div class="input-group">
                            <asp:TextBox ID="newPassword" placeholder="Enter new password" class="form-control" type="password" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn btn-secondary" type="button" id="showPassword2">Show Password</button>
                            </span>
                        </div>

                    </div>

                </div>

                <div class="form-group row">
                    <label for="password" class="col-sm-2 col-form-label">Confirm New Password</label>
                    <div class="col-sm-10">
                        <div class="input-group">
                            <asp:TextBox ID="confirmPassword" placeholder="Confirm new password" class="form-control" type="password" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <button class="btn btn-secondary" type="button" id="showPassword3">Show Password</button>
                            </span>
                        </div>

                    </div>

                </div>
                <div class="container text-center">

                    <asp:Button ID="submit" runat="server" OnClick="SubmitChanges" class="btn btn-secondary btn-lg active" Text="Submit"></asp:Button>

                </div>

            </form>
        </div>

        
        <div style="padding-top: 20px;" class="container">
            <h3 style="text-align: center; padding-bottom:15px;">Add the Times you are free to get Tutored</h3>
            <button type="submit" class="btn btn-primary" id="showCalendar" onclick="getUserSched()">Show Calendar</button>
            <br />
            <br />
            <br />
            <div id="calendar" class="container" style="padding-left: 0px; border: 0px">
                <script>

                    //console.log(parsedSched);
                    // Initialize and Display Calendar
                    var dp = new DayPilot.Calendar("calendar");
                    dp.startDate = "2013-03-25";
                    dp.viewType = "Week";
                    //dp.timeRangeSelectedHandling = "Disabled";
                    dp.eventMoveHandling = "Disabled";
                    dp.eventResizeHandling = "Disabled";
                    dp.init();
                    dp.headerDateFormat = "dddd";

                    dp.onTimeRangeSelected = function (args) {
                        var name = prompt("New event name:", "Event");
                        if (!name) return;
                        start = args.start;
                        end = args.end;
                        id = DayPilot.guid();
                        text = name;
                        var e = new DayPilot.Event({
                            start: args.start,
                            end: args.end,
                            id: DayPilot.guid(),
                            text: name
                        });
                        setUserSched(start, end, id, text);
                        dp.events.add(e);
                        dp.clearSelection();
                    };

                    dp.onEventClick = function (args) {
                        if (confirm('Are you sure you want to delete this event?')) {

                        } else {

                        }
                    };

                </script>
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
