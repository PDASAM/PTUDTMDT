
/* Exercise 9.8 - Form Validation */

function init() {
    document.getElementById("sampleForm")
        .addEventListener("submit", checkForEmptyFields);
}

window.addEventListener("load", init);

function checkForEmptyFields(e) {
    // Hide previous error message
    var errorArea = document.getElementById("errors");
    errorArea.className = "hidden";

    var cssSelector = "input[type=text],input[type=password]";
    var fields = document.querySelectorAll(cssSelector);

    // Find empty fields
    var fieldList = [];

    for (var i = 0; i < fields.length; i++) {
        if (fields[i].value == null || fields[i].value == "") {
            e.preventDefault();
            fieldList.push(fields[i]);
        }
    }

    // Display error messages
    var msg = "The following fields can't be empty: ";

    if (fieldList.length > 0) {
        for (var i = 0; i < fieldList.length; i++) {
            msg += fieldList[i].id + ",";
        }

        errorArea.innerHTML = "<p>" + msg + "</p>";
        errorArea.className = "visible";
    }
}
