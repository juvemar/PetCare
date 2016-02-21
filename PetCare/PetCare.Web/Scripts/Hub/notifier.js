$(document).ready(function () {
    var notifier = $.connection.notifierHub;

        $.connection.hub.start().done(function () {
            notifier.server.onConnectedCall();
        }).fail(function (error) {
            console.log('Invocation of start failed. Error: ' + error)
        });

        notifier.client.notify = function (obj) {
            console.log(obj);
            $('#roomPlace').text(obj[0]);
        };
})