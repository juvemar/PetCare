﻿$(document).ready(function () {
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
        $('#notifications-list').append('<li><a href="VetVisit/VetVisitDetails/' + element.Id + '">' + element.Message + '</a></li>');
    }

    function extractIds(element, index, array) {
        ids.push(element.Id);
    }
})