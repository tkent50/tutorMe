<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tutor_profile.aspx.cs" Inherits="WebApplication5.tutor_profile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Tutor Profile Page</title>

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
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <!-- Logo -->
            <div class="navbar-header">
                <a class="navbar-brand">TUTOR MY CLASS</a>
            </div>
            <!-- Menu Items -->
            <div>
                <ul class="nav navbar-nav">
                    <li><a href="TutorSearch.aspx"><i class="fa fa-home" aria-hidden="true"></i> Home Page</a></li>
                    <li><a href="#">Student Profile Settings</a></li>
                    <li class="active"><a href="#">Tutor Profile Settings</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="Default.aspx">Log Out</a></li>
                </ul>
            </div>

        </div>
    </nav>
</body>

</html>
</asp:Content>

