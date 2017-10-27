
function deleteSched(startTime, endTime) {
    // Need to fix this
    $.ajax({
        url: "UserSettings.aspx/deleteUserSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({ startTime: startTime, endTime: endTime }),
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            return;
        }
    });
}

function getUserSched() {

    $.ajax({
        url: "UserSettings.aspx/getUserSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            loadSchedule(result);
        }
    });
}


function setUserSched(startTime,endTime,text) {
 
    $.ajax({
        url: "UserSettings.aspx/setUserSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({ startTime: startTime, endTime: endTime, text: text }),
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("ThisRequest: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            return;
        }
    });
}

function loadSchedule(userSched) {
    var parsedSched = JSON.parse(userSched.d);
    console.log(parsedSched);
    for (i in parsedSched) {
        var e = new DayPilot.Event({
            start: parsedSched[i].startTime,
            end: parsedSched[i].endTime,
            text: parsedSched[i].text,
        });
        dp.events.add(e);
    }
}

    /*
// Check javascript has loaded
$(document).ready(function(){
    // Click event of the showPassword button
    $('#showPassword1').on('click', function(){
      // Get the password field
      var passwordField = $('#password');
      // Get the current type of the password field will be password or text
      var passwordFieldType = passwordField.attr('type');
      // Check to see if the type is a password field
      if(passwordFieldType == 'password')
      {
          // Change the password field to text
          passwordField.attr('type', 'text');
          // Change the Text on the show password button to Hide
          $(this).text('Hide Password');
      } else {
          // If the password field type is not a password field then set it to password
          passwordField.attr('type', 'password');
          // Change the value of the show password button to Show
          $(this).text('Show Password');
      }
    });
    $('#showPassword2').on('click', function () {
        // Get the password field
        var passwordField = $('#newPassword');
        // Get the current type of the password field will be password or text
        var passwordFieldType = passwordField.attr('type');
        // Check to see if the type is a password field
        if (passwordFieldType == 'password') {
            // Change the password field to text
            passwordField.attr('type', 'text');
            // Change the Text on the show password button to Hide
            $(this).text('Hide Password');
        } else {
            // If the password field type is not a password field then set it to password
            passwordField.attr('type', 'password');
            // Change the value of the show password button to Show
            $(this).text('Show Password');
        }
    });
    $('#showPassword3').on('click', function () {
        // Get the password field
        var passwordField = $('#confirmPassword');
        // Get the current type of the password field will be password or text
        var passwordFieldType = passwordField.attr('type');
        // Check to see if the type is a password field
        if (passwordFieldType == 'password') {
            // Change the password field to text
            passwordField.attr('type', 'text');
            // Change the Text on the show password button to Hide
            $(this).text('Hide Password');
        } else {
            // If the password field type is not a password field then set it to password
            passwordField.attr('type', 'password');
            // Change the value of the show password button to Show
            $(this).text('Show Password');
        }
    });
  });
  */