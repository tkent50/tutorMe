function addTutor() {
	var newTutor = document.createElement("li");
	var tutorLink = document.createElement("a");
	tutorLink.innerHTML = newTutorName.value;
	tutorLink.href = "#";
	newTutor.appendChild(tutorLink);
	tutorAList.appendChild(newTutor);
	newTutorName.value="";
}

function onPageLoad() {
	document.getElementById("newTutorName")
	.addEventListener("keyup", function(event) {
		event.preventDefault();
		if (event.keyCode == 13) {
			document.getElementById("addButton").click();
		}
	});
}

function showTutor() {
	document.getElementById("tutorInfo").style.zIndex = "3";
	document.getElementById("tutorInfo").style.visibility = "visible";
}

function closeTutorInfo() {
	document.getElementById("tutorInfo").style.zIndex = "-1";
	document.getElementById("tutorInfo").style.visibility = "hidden";
}