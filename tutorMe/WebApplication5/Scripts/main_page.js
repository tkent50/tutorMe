
var calLoaded = false;

function onPageLoad() {
    loadClasses();
}


function loadClasses() {

    $.ajax({
        url: "TutorSearch.aspx/GetClasses",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            handleClasses(result);
        }
    });
}

function handleClasses(classList) {
    var numClasses = parseInt(classList.d[0]);
    for (var i = 1; i <= numClasses; i++) {

        var newClassName = document.createElement("a");
        newClassName.innerHTML = classList.d[i];
        newClassName.href = "#";

        var newTab = document.createElement("LI");
        newTab.id = classList.d[i];
        newTab.className = "dropdown-submenu";

        newTab.onclick = function (event) {
            loadClassTutors(this.id);
            event.stopPropagation();
            // hide the open children
            //$(this).find(".dropdown-submenu").removeClass('open');
            // add 'open' class to all parents with class 'dropdown-submenu'
            $(this).parents(".dropdown-submenu").addClass('open');
            // this is also open (or was)
            $(this).toggleClass('open');
            //tester(this.id);
        }


        newTab.appendChild(newClassName);
        //newTab.appendChild(testList);
        document.getElementById("classList").appendChild(newTab);
    }
}

function loadClassTutors(className) {
    //alert("Loading " + className + " tutors...");

    $.ajax({
        url: "TutorSearch.aspx/getClassTutors",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"className":"' + className + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            // Uncomment these to compare differences. result.d is the actual json object. Becuase f javascript
            // alert(result);
            // alert(result.d);
            handleClassTutors(result, className);
        }
    });
}

function handleClassTutors(tutorList, className) {
    var parsedTutors = JSON.parse(tutorList.d);
    //alert(className);

    var tutorNameList = document.createElement("ul");
    //tutorNameList.id = tutorNameList.parentNode.id;
    tutorNameList.className = "dropdown-menu";

    for (var i in parsedTutors) {
        //alert(parsedTutors[i].name);
        var newTutorLi = document.createElement("li");
        var newTutor = document.createElement("a");
        newTutor.href = "#";
        newTutor.id = parsedTutors[i].userId;
        newTutor.innerHTML = parsedTutors[i].firstname + ' ' + parsedTutors[i].lastname;

        newTutor.onclick = function () {
            showTutor(this.id, className);
        }

        newTutorLi.appendChild(newTutor);
        tutorNameList.appendChild(newTutorLi);
    }

    document.getElementById(className).appendChild(tutorNameList);
}

function firstTutorInfoLoad() {
    dp.init();
    document.getElementById("tutorInfo").style.visibility = 'visible';
    document.getElementById("landing").remove();
    calLoaded = true;
}

function showTutor(tutorId, className) {

    if (!calLoaded) {
        firstTutorInfoLoad();
    }

    //alert(className)
    $.ajax({
        url: "TutorSearch.aspx/getTutorDetails",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"tutorID":"' + tutorId + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            var parsedInfo = JSON.parse(result.d);

            document.getElementById("tutorName").innerHTML = parsedInfo[0].firstname + ' ' + parsedInfo[0].lastname;
            document.getElementById("tutorDescription").innerHTML = parsedInfo[0].bio;
            document.getElementById("tutorEmail").innerHTML = parsedInfo[0].email;
            document.getElementById("tutorPhone").innerHTML = parsedInfo[0].phone;
            document.getElementById("tutorClass").innerHTML = className;
            var rating = "rate" + parsedInfo[0].rating;
            document.getElementById("no-rate").checked = true;
            document.getElementById(rating).checked = true;
        }
    });
    dp = new DayPilot.Calendar("calendar");
    dp.startDate = "2013-03-25";
    dp.viewType = "Week";
    dp.timeRangeSelectedHandling = "Disabled";
    dp.eventMoveHandling = "Disabled";
    dp.eventResizeHandling = "Disabled";
    dp.init();
    dp.headerDateFormat = "dddd";
    getTutorSched(tutorId);
}

function saveRating(rating) {
    alert(rating);
}
function getTutorSched(userId) {
    $.ajax({
        url: "TutorSearch.aspx/getTutorSchedule",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"userId":"' + userId + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            loadSchedule(result);
        }
    });
}

function loadSchedule(tutorSched) {
    var parsedSched = JSON.parse(tutorSched.d);
    
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
