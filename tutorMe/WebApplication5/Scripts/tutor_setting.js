function onTutorSettingPageLoad() {
    //alert();
    tutorSettingLoadClasses();
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

function setTutorSched(startTime, endTime, calId, text) {
    // Need to fix this
    var res = "Not Updated";
    $.ajax({
        url: "TutorSettings.aspx/setTutorSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"startTime":"' + startTime + '","endTime":"' + endTime + '","calId":"' + calId + '","text":"' + text + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("ThisRequest: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            //alert(result);
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

function loadSchedule(userSched) {
    var parsedSched = JSON.parse(userSched.d);
    console.log(parsedSched);
    for (i in parsedSched) {
        var e = new DayPilot.Event({
            start: parsedSched[i].startTime,
            end: parsedSched[i].endTime,
            id: parsedSched[i].calID,
            text: parsedSched[i].text,
        });
        dp.events.add(e);
    }
}