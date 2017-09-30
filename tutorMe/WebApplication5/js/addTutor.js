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
    alert("Before");
    $.ajax({
        url: "TutorSearch.aspx/getClasses",
        method: "POST",
        data: {},
        success: function() {alert("Success!")}
    })
    alert("after");
}


function onPageLoad() {


	//showTutor();
	alert("Loaded");
	loadClasses();

}
