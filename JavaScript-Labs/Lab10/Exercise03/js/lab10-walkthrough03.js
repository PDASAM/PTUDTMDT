
/* Exercise 10.3 - Advanced Selectors */

$(function () {
    // Step 2: Tested password selector
    // $(':password').css('background-color', 'yellow');

    // Step 4: Select every fourth child
    $('form :nth-child(4n)').css(
        'background-color', 'yellow'
    );

    // Step 5: Select labels containing "word"
    $('label:contains("word")').css(
        'color', 'black'
    );
});
