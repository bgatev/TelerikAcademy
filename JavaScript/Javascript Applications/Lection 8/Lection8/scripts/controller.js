define(['jquery', 'sammy', 'reloadChat', 'sendMessage'], function ($, sammy, reloadChat, sendMessage) {
    function savetoLocalStorage(data) {
        if (localStorage['username'] == undefined) localStorage['username'] = [];
        localStorage['username'] = data;
    }

    var app = function (div, url) {
        return sammy(div, function () {
            this.get("#/login", function () {
                $('#chat-div').remove();
                $('#send-div').remove();
                $('#about-div').remove();
                $(div)
                    .append($('<label />').html('Username')
                            .attr("id", "usernameLabel"))
                    .append($('<input /> ')
                            .attr("type", "text")
                            .attr("maxlength", "10")
                            .attr("id", "username"))
                    .append($('<button />').html('Login')
                            .attr("id", "loginBtn")
                            .on('click', function () {
                                var username = $('#username').val() || 'Anonymous';

                                savetoLocalStorage(JSON.stringify(username));
                            }));
            });

            this.get("#/chat", function () {
                var userName;

                if (localStorage.getItem('username') !== null) userName = JSON.parse(localStorage.getItem('username'))
                else userName = 'Anonymous';

                $('#username').remove();
                $('#usernameLabel').remove();
                $('#loginBtn').remove();
                $('#about-div').remove();
                $(div)
                    .append($('<div />')
                            .attr("id", "chat-div"))
                    .append($('<div />')
                            .attr("id", "send-div")
                            .append($('<input /> ')
                                .attr("type", "text")
                                .attr("maxlength", "70")
                                .attr("id", "message"))
                            .append($('<button />')
                                .attr("id", "sendBtn")
                                .html("Send")
                                .on('click', function () {
                                    var message = {
                                        user: userName,
                                        text: $('#message').val()
                                    };
                                    sendMessage(url, message);
                                })));
                reloadChat(url);
            });

            this.get("#/about", function () {
                $('#chat-div').remove();
                $('#send-div').remove();
                $('#username').remove();
                $('#usernameLabel').remove();
                $('#loginBtn').remove();
                $(div)
                    .append($('<div />')
                            .attr("id", "about-div")
                            .html("Good Luck guys"));
            });
        });
    };

    return app;
});