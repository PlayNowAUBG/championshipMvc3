$(document).ready(function() {
    $('#scheduleTableID tr').each(function () {
        var $tds = $(this).find("td").text();
     //   alert($tds);
        if ($tds == "False") {
            $(this).css('background-color', 'red');
        }
        else if ($tds == "True") {
            $(this).css('background-color', 'green')
        }

    });
});