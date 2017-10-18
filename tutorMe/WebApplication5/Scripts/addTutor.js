function onPageLoad() {
    loadClasses();
    loadClassTutors("testClass");
}


function loadClasses() {

    var test = "class1";

    $.ajax({
        url: "TutorSearch.aspx/getClassesTest",
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
        newTab.className = "dropdown-submenu";
        newTab.id = classList.d[i];

        newTab.appendChild(newClassName);
        document.getElementById("classList").appendChild(newTab);
    }
}

function loadClassTutors(className) {
    alert("Loading tutors...");

    $.ajax({
        url: "TutorSearch.aspx/getTutorsTest",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: '{"input":"' + className + '"}',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            alert(result.d);
        }
    });
}



function showTutor(name) {
    document.getElementById("tutorInfo").style.zIndex = "3";
    document.getElementById("tutorInfo").style.visibility = "visible";
    document.getElementById("tutorName").innerHTML = name;
    document.getElementById("tutorClass").innerHTML = name + "'s Class";
    document.getElementById("tutorEmail").innerHTML = "(" + name + ")@purdue.edu";


    var x = document.getElementById("dp").querySelectorAll("div");
    for (var i = 0; i < x.length; i++) {
        x[i].style.visibility = "visible";
    }
}

function closeTutorInfo() {
    document.getElementById("tutorInfo").style.zIndex = "-1";
    document.getElementById("tutorInfo").style.visibility = "hidden";

    var x = document.getElementById("dp").querySelectorAll("div");
    for (var i = 0; i < x.length; i++) {
        x[i].style.visibility = "hidden";
    }
}