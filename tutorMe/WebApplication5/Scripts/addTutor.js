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
    alert("Bef");

    //alert(PageMethods.MyMethod("Paul Hayman"));

    
    $.ajax({
        url: "TutorSearch.aspx/getClasses",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (result) {
            alert("We returned: " + result.d);
        }
    });

    alert("after");
}

function onPageLoad() {

	loadClasses();
}

function showTutor(name) {
	document.getElementById("tutorInfo").style.zIndex = "3";
	document.getElementById("tutorInfo").style.visibility = "visible";
	document.getElementById("tutorName").innerHTML = name;
	document.getElementById("tutorClass").innerHTML = name + "'s Class";
	document.getElementById("tutorEmail").innerHTML = "(" + name + ")@purduasdfasdfasdfe.edu";


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