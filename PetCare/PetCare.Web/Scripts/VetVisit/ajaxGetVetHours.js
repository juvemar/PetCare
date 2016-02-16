$(document).on('change', '#pickDay', function ()
{
    var data = {
        date :  $(this).val(),
        vetId: $('#vetId').val(),
        description: $('#description').val(),
        healthRecordId: $('#healthRecordId').val()
    };
    console.log(data);
    $.ajax({
        type: "GET",
        url: "/VetBusyHour/VetAvailableHours",
        data: data,
        success: function (view) {
            $("#available-hours").html(view);
        },
        error: function (errorData) { onError(errorData); }
    });
});