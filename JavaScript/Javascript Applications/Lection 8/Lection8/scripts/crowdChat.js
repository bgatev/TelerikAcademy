(function () {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            sammy: "libs/sammy",
            reloadChat: "reload-chat",
            sendMessage: "send-message",
            controller: "controller"
        }
    });

    require(["jquery", "controller"], function ($, controller) {
        var url = 'http://crowd-chat.herokuapp.com/posts';

        var app = controller("#main-content", url);
        app.run("#/login");
    });
}());