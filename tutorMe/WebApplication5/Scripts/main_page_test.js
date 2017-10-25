function loadTutorSched() {

    $.ajax({
        url: "main_page.aspx/setTutorScheduleTest",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("MyRequest: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown + "\nThis one");
        },
        success: function (result) {
            handleTutorSched(result);
        }
    });
}

function handleTutorSched(tutorSched) {
    var parsedSched = JSON.parse(tutorSched);

    // Initialize and Display Calendar
    var dp = new DayPilot.Calendar("calendar");
    dp.startDate = "2013-03-25";  
    dp.viewType = "Week";
    dp.timeRangeSelectedHandling = "Disabled";
    dp.eventMoveHandling = "Disabled";
    dp.eventResizeHandling = "Disabled";
    dp.init();
    dp.headerDateFormat = "dddd";
    dp.onEventClick = function (args) {
        alert("Do you wanna request to book this time slot ?");
    };
    for (i in parsedSched) {
        var e = new DayPilot.Event({
            start: parsedSched[i].start,
            end: parsedSched[i].end,
            id: parsedSched[i].eventID,
            text: parsedSched[i].text,
        });
        dp.events.add(e);
    }
    
}