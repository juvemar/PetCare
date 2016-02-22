$(document).ready(function () {
    var notifier = $.connection.notifierHub;

    $.connection.hub.start();

    var notifications;
    notifier.client.notify = function (data) {
        notifications = JSON.parse(data);
        if (notifications.length == 0) {
            $('#notifications-list').removeClass("dropdown-menu");
            return;
        }

        $('#caret').show();
        $('#notification-item').css('color', 'lightgreen');
        $('#notification-item').text(" " + notifications.length);
        notifications.forEach(appendNotificationItems);
        showOrUpdateSuccessMessage("You have " + notifications.length + " new comming events!", true);
    };

    var ids = [];
    $('#notification-item').on('click', function () {
        if (notifications.length == 0) {
            return;
        }

        $('#notification-item').css('color', 'white');
        $('#notification-item').text("");
        notifications.forEach(extractIds);
        console.log(ids);
        notifier.server.setNotificationsSeen(ids);
    })

    function appendNotificationItems(element, index, array) {
        $('#notifications-list').append('<li><a href="VetVisit/VetVisitDetails/' + element.VetVisitId + '">' + element.Message + '</a></li>');
    }

    function extractIds(element, index, array) {
        ids.push(element.VetVisitId);
    }

    var n;
    function showOrUpdateSuccessMessage(message, timeout) {
        if (n == null) {
            n = noty({ text: message, type: 'success', timeout: timeout, maxVisible: 1 });
        }
        else {
            n.setText(message);
        }
    }
})