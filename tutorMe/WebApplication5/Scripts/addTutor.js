function addTutor() {
	/*var newTutor = document.createElement("li");
	var tutorLink = document.createElement("a");
	tutorLink.innerHTML = newTutorName.value;
	tutorLink.href = "#";
	newTutor.appendChild(tutorLink);
	tutorAList.appendChild(newTutor);
	newTutorName.value="";*/
}

function loadClasses() {

    var test = "class1";

    $.ajax({
        url: "TutorSearch.aspx/getClasses",
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
        var backButton = document.createElement("LI");
        backButton.className = "icon icon-arrow-left";

        var classLink = document.createElement("a");
        classLink.href = "#";
        classLink.innerHTML = classList.d[i];

        backButton.appendChild(classLink);

        document.getElementById("classList").appendChild(backButton);
    }
}

function onPageLoad() {

	loadClasses();
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