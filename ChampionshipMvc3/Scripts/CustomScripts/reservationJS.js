$(document).ready(function(){

    var selectedHourId;
    var selectedHourInterval;
    
    $(".reservationAnchor").on('click', StoreHourCell);

    function StoreHourCell(hourInterval) {
        selectedHourInterval = hourInterval;
        selectedHourId = $(this).data('assigned-id');

    }

});