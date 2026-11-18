
/* Exercise 10.7 - More jQuery Animation */

$(function () {

    $("figure img").on("mouseover", function (e) {

        // Get image details
        var alt = $(this).attr("alt");
        var src = $(this).attr("src");

        // Change small image path to medium image
        var newsrc = src.replace("small", "medium");

        // Create preview elements
        var preview = $('<div id="preview"></div>');
        var image = $('<img src="' + newsrc + '">');
        var caption = $("<p>" + alt + "</p>");

        preview.append(image);
        preview.append(caption);

        $("body").append(preview);

        // Make original image grayscale
        $(this).addClass("gray");

        // Position and fade in preview
        movePreview(e);
        $("#preview").fadeIn(1000);
    });

    function removePreview() {
        $(this).removeClass("gray");
        $("#preview").remove();
    }

    function movePreview(e) {
        $("#preview")
            .css("top", (e.pageY - 10) + "px")
            .css("left", (e.pageX + 30) + "px");
    }

    // Mouse events
    $("figure img").on("mouseleave", removePreview);
    $("figure img").on("mousemove", movePreview);

});
