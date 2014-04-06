$(document).ready(function () {
    $("#regButton").on('click', function () {
        var url = $("#regPlayerModal").data('url');

        $.get(url, function (data) {
            $("#playerContainer").html(data);

            $("#regPlayerModal").show();
        });
    });
});