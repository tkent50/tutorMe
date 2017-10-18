function onPageLoad() {
    loadClasses();
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
            tester(this.id);
        }

        
        newTab.appendChild(newClassName);
        //newTab.appendChild(testList);
        document.getElementById("classList").appendChild(newTab);
    }
}

function loadClassTutors(className) {
    //alert("Loading tutors...");

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
        newTutor.id = parsedTutors[i].id;
        newTutor.innerHTML = parsedTutors[i].name;

        newTutor.onclick = function () {
            showTutor(this.innerHTML);
        }

        newTutorLi.appendChild(newTutor);
        tutorNameList.appendChild(newTutorLi);
    }

    document.getElementById(className).appendChild(tutorNameList);
}

function showTutor(tutorId) {

}

function handleTutorInfo(name) {
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


