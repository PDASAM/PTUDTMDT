
/* Exercise 10.9 - GET Requests */

$(function () {

    $("#consume").click(function () {

        var url = "https://geocoding-api.open-meteo.com/v1/search";

        var params = {
            name: "London",
            count: 10,
            language: "en",
            format: "json"
        };

        $("#results").html("<ul></ul>");

        $.get(url, params, function (data, status) {

            if (status === "success") {

                $.each(data.results || [], function (index, value) {

                    var li = $("<li></li>");

                    li.text(
                        value.name + " - " + value.country
                    );

                    li.appendTo("#results ul");

                });

            }

        }, "json");

    });

});
