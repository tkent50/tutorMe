﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication5.SignUp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">

    <style>
.form-group {
    padding: 16px;
}
.logo-font{
  font-style: oblique;
  color: #3b5998;
}
input[type=text], input[type=password] {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
}
body {
    background-color: #3b5998;
}
.form-horizontal {
    position: absolute;
    background-color: #dfe3ee;
    max-width: 380px;
    padding: 25px 35px 45px;
    margin: 0 auto;
    /*  top: 0;
    bottom: 0; */
    left: 0;
    right: 0;
    .form-horizontal{
        width:50%;
        margin:0 auto;
    }
}
.btn-block {
background-color: #8b9dc3;
font-color: #ffffff;  
font-size:20px;
font-style:bold;
padding: 14px 20px;
margin: 8px 0;
width: 100%;
                }
            </style>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sign Up</title>

</head>
<body>
    <div class="container">
        <form class="well form-horizontal" action=" " method="post" id="contact_form">
            <fieldset>
                <!-- Form Name -->
                <div class="text-center">
                    <h1 class="logo-font" align="center"><strong>Sign Up</strong></h1>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">First Name</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input name="first_name" placeholder="First Name" class="form-control" type="text">
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Last Name</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input name="last_name" placeholder="Last Name" class="form-control" type="text">
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Username</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input name="user_name" placeholder="Username" class="form-control" type="text">
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Password</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input name="user_password" placeholder="Password" class="form-control" type="password">
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Confirm Password</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input name="confirm_password" placeholder="Confirm Password" class="form-control" type="password">
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">E-Mail</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                            <input name="email" placeholder="E-Mail Address" class="form-control" type="text">
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-8">
                        <button type="button" class="btn-lg btn-primary btn-block" onClick="location.href='tutorSearch.html'">SIGN UP</button>
                    </div>
                </div>
            </fieldset>
        </form>
    </div>
</div><!-- /.container -->
</body>
</html>

</asp:Content>
