
/* Exercise 10.10 - jqXHR Handling */

$(function () {

    // Hide loading animation initially
    $(".animLoading").hide();

    $("#consume").click(function () {

        // Show loading animation
        $(".animLoading").show();

        // Clear previous results
        $("#results ul").empty();

        var url = "https://geocoding-api.open-meteo.com/v1/search";

        var params = {
            name: "London",
            count: 10,
            language: "en",
            format: "json"
        };

        $.get(url, params)

            .done(function (data) {

                $.each(data.results || [], function (index, value) {

                    var li = $("<li></li>");

                    li.text(
                        value.name + " - " + value.country
                    );

                    li.appendTo("#results ul");

                });

            })

            .fail(function (xhr, status, error) {

                alert(
                    "failed loading data - status=" +
                    status + " error=" + error
                );

            })

            .always(function () {

                $(".animLoading").fadeOut("slow");

            });

    });

});
