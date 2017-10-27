function onTutorSettingPageLoad() {

    tutorSettingLoadClasses();
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

function getTutorSched() {
    $.ajax({
        url: "TutorSettings.aspx/getTutorSchedule",
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

function setTutorSched(startTime, endTime, text) {
    $.ajax({
        url: "TutorSettings.aspx/setTutorSchedule",
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

function deleteSched(calId) {
    // Need to fix this
    // deleteTutorSchedule(int calId)
    $.ajax({
        url: "UserSettings.aspx/deleteTutorSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"calId":"' + calId + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            return;
        }
    });
}


function tutorSettingLoadClasses() {
    //alert("loading");
    $.ajax({
        url: "TutorSearch.aspx/GetClasses",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            //alert("success");
            console.log(result);
            tutorSettingHandleClasses(result);
        }
    });
}

function tutorSettingHandleClasses(classList) {
    document.getElementById("classList").innerHTML = "";
    var numClasses = parseInt(classList.d[0]);
    for (var i = 1; i <= numClasses; i++) {

        var newTab = document.createElement("LI");
        newTab.value = classList.d[i];
        newTab.onclick = function (event) {
            document.getElementById("search").placeholder = this.innerHTML;
        }
        newTab.appendChild(document.createTextNode(classList.d[i]));

        // newTab.appendChild(newClassName);
        //newTab.appendChild(testList);
        console.log(classList);
        document.getElementById("classList").appendChild(newTab);
    }
}


function AddClassChange() {
    //alert();

    var amount = document.getElementById("amount").value;
    var className = document.getElementById("search").placeholder;

    if (className === 'Add Class') {
        alert("Please insert class name.")
    } else if (amount === '') {
        alert("Please insert rate for class.")
    } else {
        //alert("Success");
        $.ajax({
            url: "TutorSettings.aspx/setTutorClass",
            method: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: '{"className":"' + className + '","rate":"' + amount + '"}',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                alert("Enter a class you're not already signed up for.")
            },
            success: function (result) {
                // Uncomment these to compare differences. result.d is the actual json object. Becuase f javascript
                // alert(result);
                // alert(result.d);
                alert("Class info added!");
                document.getElementById("amount").value = '';
                document.getElementById("search").placeholder = 'Add Class';
            }
        });
    }
}


function addNonExistingClass() {
    //alert();
    
    var className = document.getElementById("newClassName").value;
    alert(className);

    if (className === '') {
        alert("Please insert class name.")
    } else {
        //alert("Success");
        $.ajax({
            url: "TutorSettings.aspx/addClass",
            method: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: '{"className":"' + className + '"}',
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                alert("Enter a class that doesn't already exist.")
            },
            success: function (result) {
                // Uncomment these to compare differences. result.d is the actual json object. Becuase f javascript
                // alert(result);
                // alert(result.d);
                alert("Class info added!");
                document.getElementById("newClassName").value = '';
                tutorSettingLoadClasses();
            }
        });
    }
}