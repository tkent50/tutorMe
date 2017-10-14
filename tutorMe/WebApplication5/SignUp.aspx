<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication5.SignUp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>
<html lang="en">
	<style type="text/css">
		.shrink {
    -webkit-transform:scale(0.5);
    -moz-transform:scale(0.5);
    -ms-transform:scale(0.5);
    transform:scale(0.5);
}
            </style>

<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Sign Up</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="Content/starRating/starability-all.css"/>
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="Content/normalize.css" />
    <link rel="stylesheet" type="text/css" href="Content/demo.css" />
    <link rel="stylesheet" type="text/css" href="Content/icons.css" />
    <link rel="stylesheet" type="text/css" href="Content/component.css" />

    <!-- Bootstrap -->
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

</head>
<body>
    <div class="container">
        <form class="well form-horizontal" action=" " method="post" id="contact_form">
            <fieldset>
            <form id="regform" runat="server"> <!-- .net FORM -->

                <!-- Form Name -->
                <legend><center><h2><b>Sign Up</b></h2>
                        </center></legend><br>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">First Name</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <div>
                                 <asp:TextBox ID="first_name" placeholder="First Name" class="form-control"  type="text" runat="server"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Last Name</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <div>
                                 <asp:TextBox ID="last_name" placeholder="Last Name" class="form-control"  type="text" runat="server"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Password</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                 <div>
                                    <asp:TextBox ID="user_password" placeholder="Password" class="form-control"  type="password" runat="server"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">Confirm Password</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                              <div>
                                    <asp:TextBox ID="confirm_password" placeholder="Confirm Password" class="form-control"  type="password" runat="server"></asp:TextBox>
                              </div>
                        </div>
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label">E-Mail</label>
                    <div class="col-md-4 inputGroupContainer">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                              <div>
                                    <asp:TextBox ID="email"  placeholder="E-Mail Address" class="form-control"  type="text" runat="server"></asp:TextBox>
                              </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
					<label class="col-md-4 control-label"></label>
					 <div class="col-md-4"><br>
                    <div class="col-sm-offset-2 col-sm-8">
                        <asp:Button ID="SubmitRegistration" runat="server"  OnClick="SubmitRegistration_Click" class="btn bg-info" Text="Register"></asp:Button>
                    </div>
				</div>
                </div>
             </form>  <!-- .net FORM -->
            </fieldset>
        </form>
    
</div><!-- /.container -->
</body>
</html>

</asp:Content>

