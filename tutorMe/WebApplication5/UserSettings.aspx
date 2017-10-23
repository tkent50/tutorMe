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
    <script src="js/user_settings.js"></script>
</head>

<body>
    <form id="regform" runat="server"> <!-- .net FORM -->
    <div style="padding-top:30px;" class="container">
        <h3 style="text-align:center;">Change Login Settings</h3>
        <form style="padding-top:20px;">
            <div class="form-group row">
                <label for="email" class="col-sm-2 col-form-label">Change Email Address</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="email" placeholder="Email Address" class="form-control"  type="text" runat="server"></asp:TextBox>
                </div>
            </div>
			
			<div class="form-group row">
                <label for="password" class="col-sm-2 col-form-label">Current Password</label>
                <div class="col-sm-10">
                    <div class="input-group">
                        <asp:TextBox ID="password" placeholder="Enter current password" class="form-control"  type="password" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="newPassword" placeholder="Enter new password" class="form-control"  type="password" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="confirmPassword" placeholder="Confirm new password" class="form-control"  type="password" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <button class="btn btn-secondary" type="button" id="showPassword3">Show Password</button>
                        </span>
                    </div>
                    
                </div>

            </div>
            <div class="container text-center"> 
                <button type="submit" class="btn btn-primary text-center">Submit</button> 
            </div>
            
        </form>
    </div>

    <div style="padding-top:20px;" class="container">
        <h3 style="text-align:center;">Add Free Times</h3>
        <div style="padding-top:20px;" class="row">
            <div align="center" class="col">
                <div class="form-group row">
                    <label for="example-time-input" class="col-2 col-form-label">Start Time: </label>
                    <div class="col-10">
                        <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                    </div>
                </div>

            </div>
            <div align="center" class="col">
                <div class="form-group row">
                    <label for="example-time-input" class="col-2 col-form-label">End Time: </label>
                    <div class="col-10">
                        <input class="form-control" type="time" value="13:45:00" id="example-time-input">
                    </div>
                </div>
            </div>
        </div>



        <div align="center" class="form-group">
            <label align="center" for="selectDay">Select Day</label>
            <select align="center" id="day">
                <option style="font-size:14px;" value="sunday">Sunday</option>
                <option style="font-size:14px;" value="monday">Monday</option>
                <option style="font-size:14px;" value="tuesday">Tuesday</option>
                <option style="font-size:14px;" value="wednesday">Wednesday</option>
                <option style="font-size:14px;" value="thursday">Thursday</option>
                <option style="font-size:14px;" value="friday">Friday</option>
                <option style="font-size:14px;" value="saturday">Saturday</option>
            </select>
        </div>

        <div align="center" class="col"></div>

    </div>

    <div class="container"> 
        <table class="table">
            <thead>
              <tr>
                <th>#</th>
                <th>Start Time</th>
                <th>End Time</th>
                <th>Day of the Week</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
              </tr>
            </tbody>
          </table>
   </div>

    



    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
        crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4"
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1"
        crossorigin="anonymous"></script>
        </form>
</body>

</html>
