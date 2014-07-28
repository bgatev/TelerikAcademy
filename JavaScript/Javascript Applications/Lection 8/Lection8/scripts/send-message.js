define(["jquery", "reloadChat"], function ($, reloadChat) {
    var sendMessage = function (url, data) {
        return $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                reloadChat(url);
                $('#message').val('');
            },
            error: function (error) {
                console.log(error);
            }
        });
    };

    return sendMessage;
});