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
                            <small id="emailHelp" class="form-text text-muted">Password should be more than 8 characters and less than 32 character</small>
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
            <br />
            <br />
            <div style="padding-top: 20px;" class="container">
            <h3 style="text-align: center;">Add Class</h3>
            <div style="padding-top: 20px;" class="row">
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
                            <asp:Button ID="addButton" runat="server" OnClientClick="AddClassChange()" class="btn btn-secondary btn-lg" Text="Add"></asp:Button>
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
                            <asp:Button runat="server" class="btn btn-default" OnClientClick="addNonExistingClass()" text="Add"></asp:Button>
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

            <div class="container">
                <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Class</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Mark</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br />
            <br />
             <div style="padding-top: 20px;" class="container">
            <h3 style="text-align: center;">Add Class Schedule</h3>
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
                    getTutorSched();
                    initializeCal();
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
                        setTutorSched(start, end, id, text)
                        dp.events.add(e);
                        dp.clearSelection();
                    };

                    dp.onEventClick = function (args) {
                        if (confirm('Are you sure you want to delete this event?')) {
                            //deleteSched(DayPilot.guid());
                        } else {

                        }
                    };




                </script>

            </div>

            <div class="container-fluid" style="justify-content: space-between; flex-direction: display: flex; padding-bottom: 20px">
                <div class="btn-holder" style="justify-content: flex-end; display: flex;">
                    <a class="btn btn-info" href="/TutorSearch.aspx">Main Page</a>
                    <a class="btn btn-info" href="/UserSettings.aspx">User Settings</a>
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
