﻿$(document).on('change', '#pickDay', function (e) {
    console.log(e);

    e.preventDefault();

    var data = {
        date: $(this).val(),
        vetId: $('#vetId').val(),
        description: $('#description').val(),
        healthRecordId: $('#healthRecordId').val()
    };

    console.log(data);

    if ($('#vetId').val().trim() != '' && $('#description').val().trim() != '') {
        $("#LoadingImage").show();

        $.ajax({
            type: "GET",
            url: "/VetBusyHour/VetAvailableHours",
            data: data,
            success: function (view) {
                $("#LoadingImage").hide();
                $("#available-hours").html(view);
            },
            error: function (errorData) { onError(errorData); }
        });
    } else {
        console.log("Prazni sa ti dannite be");
    }
});