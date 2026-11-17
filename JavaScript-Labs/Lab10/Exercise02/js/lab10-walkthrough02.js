
/* Exercise 10.2 - Basic Selectors */

$(function () {
    // Select textarea and change value
    var msg = $("#msgArea");
    msg.val("here is some new text");

    // Change title without removing other elements
    $("#pageTitle").html("new Title");

    // Read an attribute
    msg.val("My class is " + msg.attr("class"));

    // Select all buttons
    var buttons = $("button");
    buttons.css("background-color", "red");

    // Change body background
    var temp = $("body");
    temp.css("background-color", "ivory");

    // Add class to icon containers
    $(".center-icons").addClass("selected");
});
