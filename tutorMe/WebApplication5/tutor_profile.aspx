<!--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tutor_profile.aspx.cs" Inherits="WebApplication5.tutor_profile" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent">
<!DOCTYPE html>
-->
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
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Tutor Profile Page</title>
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

<body style="min-width: 1400">
    <div style="background-color:gray; width: 100%; height:190; padding-bottom: 30; position: absolute;">
        <div style="margin-left: 10%; float: left">
            <h1>Your Info</h1>
            <h3>First Last</h3>
            <h3>email</h3>
        </div>
        
        <textarea style="display: block; width: 50%; margin: 40 15% auto auto;" rows="5" placeholder="Tell us about yourself"></textarea>
    </div>

    <nav id="" style="left:400; height:86; top:220; position: absolute;" class="mp-menu">
    <div id="classList" class="mp-level">
            <h2>Classes</h2>
        </div>
    </nav>

    <nav id="" style="left:400; height:350; top:300; position: absolute;" class="mp-menu">
        
        <div id="classList" style="overflow-y:scroll" class="mp-level">
            <ul>
                <li>
                    <a href="#">Class 1</a>
                    <a href="#">Class 2</a>
                    <a href="#">Class 3</a>
                    <a href="#">Class 4</a>
                    <a href="#">Class 5</a>
                    <a href="#">Class 6</a>
                    <a href="#">Class 7</a>
                </li>
            </ul>
        </div>
    </nav>

    <nav id="" style="left:335; height:54.44; top:700; width: 170; position: absolute;" class="mp-menu">
        <div id="classList" style="overflow-y:scroll" class="mp-level">
            <ul>
                <li>
                    <a href="#">Add Class</a>
                </li>
            </ul>
        </div>
    </nav>

    <div class="btn-group" id="fixedbutton" style="z-index: 3">
        <button type="button" class="btn-lg btn-primary" onClick="location.href='Default.aspx'">Log Out</button>
        <button type="button" class="btn-lg btn-primary" onClick="location.href='TutorSearch.aspx'">Home</button>
    </div>

</body>

</html>
<!--
</asp:Content>
-->
