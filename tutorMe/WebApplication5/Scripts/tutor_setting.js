function onTutorSettingPageLoad() {
    alert();
    tutorSettingLoadClasses();
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