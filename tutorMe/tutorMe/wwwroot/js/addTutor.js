function addTutor() {
	/*var newTutor = document.createElement("li");
	var tutorLink = document.createElement("a");
	tutorLink.innerHTML = newTutorName.value;
	tutorLink.href = "#";
	newTutor.appendChild(tutorLink);
	tutorAList.appendChild(newTutor);
	newTutorName.value="";*/
}

function onPageLoad() {
	document.getElementById("newTutorName")
	.addEventListener("keyup", function(event) {
		event.preventDefault();
		if (event.keyCode == 13) {
			document.getElementById("addButton").click();
		}
	});

	showTutor();

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