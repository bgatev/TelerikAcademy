define(['jquery'], function () {
    var reloadChat = function (url) {
        return $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                var chatters = data;
                var chatlist = $('<ul/>').attr("id", "chat-list");
                for (var i = 0, len = chatters.length; i < len; i++) {
                    $('<li />')
                    .append($('<strong/>')
                    .html(chatters[i].by))
                    .append($('<br/>'))
                    .append($('<span/>')
                    .html(chatters[i].text))
                    .appendTo(chatlist);
                }

                $('#chat-div').html(chatlist);
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

    return reloadChat;
});