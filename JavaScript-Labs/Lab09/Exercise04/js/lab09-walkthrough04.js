
/* Exercise 9.4 - Simple Event Handling */

var btn = document.getElementById("testButton");
var img = document.getElementById("mainImage");

// Click button: Hide / Show content
function simpleHandler(event) {
    var content = document.getElementById("content");

    if (btn.innerHTML == "Hide") {
        btn.innerHTML = "Show";
        content.className = "makeItDisappear";

        setTimeout(function () {
            content.style.display = "none";
        }, 1000);
    } else {
        btn.innerHTML = "Hide";
        content.style.display = "block";

        setTimeout(function () {
            content.className = "makeItNormal";
        }, 500);
    }
}

btn.addEventListener("click", simpleHandler);

// Mouse over: make image gray
img.addEventListener("mouseover", function (event) {
    img.className = "makeItGray";
});

// Mouse out: restore original image
img.addEventListener("mouseout", function (event) {
    img.className = "makeItNormal";
});
