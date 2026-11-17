
/* Exercise 10.5 - Inserting DOM Elements */

$(function () {
    // Create a new image element
    var img = $(
        '<img src="../images/art/thumbs/13030.jpg" alt="Artwork">'
    );

    // Select the panel
    var panel = $(".panel");

    // Insert the image before the panel
    img.insertBefore(panel);
});
