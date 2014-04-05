$(document).ready(function () {
    var stringToBeReplaced;
    $('#scheduleTableID tr').each(function () {
        var $td = $(this).find("td");
        var $tds = $(this).find("td").text();
        var checkForFalse = RegExp(/false/i);

        if ($tds.match(checkForFalse)) {
            $(this).css('background-color', 'red');
            $(this).html($(this).html().replace(/False/gi, function (match, tag) {
                return (tag === "a") ? match : "";
            }));
            
        }
        else if (!$tds.match(checkForFalse)) {
            $(this).css('background-color', 'green')
            $(this).html($(this).html().replace(/True/gi, function (match, tag) {
                return (tag === "a") ? match : "";
            }));
        }

    });
});