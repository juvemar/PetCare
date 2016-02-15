$(document).on('click', '#freeHours', function ()
{
    $.ajax({
        type: "GET",
        url: "/VetVisit/GetSomePartialView/",
        data: someArguments,
        success: function (jsReturnArgs) {

            if (jsReturnArgs.Status === 300) { //300 is an arbitrary value I just made up right now
                showPopup("You do not have access to that.");
            }

            $("#someDiv").html(jsReturnArgs.ViewString); //the HTML I returned from the controller
        },
        error: function (errorData) { onError(errorData); }
    });
});