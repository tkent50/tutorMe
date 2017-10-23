<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html>
<head>
	 <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Find My Tutor</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    
    <!-- Bootstrap -->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <link href="css/signin.css" rel="stylesheet">
</head>
<body>
    <div class="container">  
  <div class="row">
    <div class="Absolute-Center is-Responsive">   
               <h1 class="section-header text-center">
  <span>Find My Tutor</span>
</h1>
      <div class="col-sm-12 col-md-10 col-md-offset-1">
        <form action="" id="loginForm">
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
            <asp:TextBox ID="user_input" type="text" class="form-control" name="username" placeholder="Email Address" runat="server"></asp:TextBox>          
          </div>
          <div class="form-group input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
            <asp:TextBox ID="pass_input" type="text" class="form-control" name="password" placeholder="Password" runat="server"></asp:TextBox>     
          </div>
          
          <div class="row">
						<div class="col-sm-12">
							 <div class="text-center">
								 <asp:Button ID="login_button" OnClick="Login_Click" runat="server" class="btn btn-secondary btn-lg active" Text="Login" style="width: 100%">  							
								 </asp:Button> <br /><br />
							 </div>
						 </div>
					</div>
					<div class="row">
						<div class="col-sm-12">
							 <div class="text-center">
								 <asp:Button ID="signup_button" runat="server" OnClick="SignUp_Click" class="btn btn-secondary btn-lg active" Text="Signup" style="width: 100%"></asp:Button>  							
							 </div>
						 </div>
					</div>
 
        
        </form>        
      </div>  
    </div>    
  </div>
</div>
</body>
</html>
</asp:Content>
