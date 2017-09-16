$(function () {
    var hub = $.connection.notificationHub;

    hub.client.notify = function (obj) {
        var json = JSON.stringify(obj);
        console.log(json);
    };

    $.connection.hub.start().done(function () {
        console.log('connection established');
    });

});