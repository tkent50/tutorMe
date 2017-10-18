$( ".dropdown-submenu" ).click(function(event) {
    // stop bootstrap.js to hide the parents
    event.stopPropagation();
    // hide the open children
    $( this ).find(".dropdown-submenu").removeClass('open');
    // add 'open' class to all parents with class 'dropdown-submenu'
    $( this ).parents(".dropdown-submenu").addClass('open');
    // this is also open (or was)
    $( this ).toggleClass('open');
});

$('.child').hide(); //Hide children by default

$('.parent').children().click(function () {
	event.preventDefault();
	$(this).children('.child').slideToggle('slow');
	$(this).find('span').toggle();
});
