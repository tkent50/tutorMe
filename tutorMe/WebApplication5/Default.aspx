<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    body {
        background-color: #3b5998;
    }
    .logo-font{
        font-style: oblique;
        color: #3b5998;
    }
    .spacer {
        margin-top: 2%;
        margin-bottom: 20%;
    }
    .block {
        height: 300px;
        padding-top: 15px;
    }
    .block2 {
        min-height: 260px;
        padding-top: 15px;
    }
    .center {
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
</style>

     <div class="container col-lg-12 spacer"></div>
     <div class="container col-lg-12 block">   
     <div class="row col-xs-6 block2 center">

        <div class="text-center">
            <h1 class="logo-font"><strong>Find My Tutor</strong></h1>
        </div>

               <div class="form-group">
                    <label class="control-label col-sm-3" for="username">Username<em></em></label>
                    <div class="col-sm-8 col-xs-12">
                        <input type="text" name="username" id="username" placeholder="Username" required="true" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-3" for="password">Password<em></em></label>
                    <div class="col-sm-8 col-xs-12">
                        <input type="password" name="password" id="password" placeholder="Password" required="true" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-8">    
                           </br>
                        <button class="btn btn-lg btn-primary btn-block" type="submit" onClick="location.href='TutorSearch.aspx'">Login</button>  
                        <button class="btn btn-lg btn-primary btn-block" type="submit" onClick="location.href='SignUp.aspx'">Sign up</button>
                    </div>
                </div>
        </div>
        </div>

</asp:Content>
