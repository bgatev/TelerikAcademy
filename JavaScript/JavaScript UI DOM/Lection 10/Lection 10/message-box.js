/// <reference path="E:\Downloads\Telerik\JavaScript\JavaScript UI DOM\Lection 10\Lection 10\scripts/jquery-1.11.1.js" />
$.fn.messageBox = function () {
    var $this = $(this);

    return {
        success: function (message) {
            $this.each(function () {
                $this.css('background-color', 'green');
                $this.animate({ 'opacity': 1 }, 1000);
                $(this).html(message);
                setTimeout(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
            });

            return $this;
        },
        error: function (message) {
            $this.each(function () {
                $this.css('background-color', 'red');
                $this.animate({ 'opacity': 1 }, 1000);
                $(this).html(message);
                setTimeout(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
            });

            return $this;
        }
    };
};

var onSuccessButton = $('#successBtn').on('click', function () {
    var msgBox = $('#message-box').messageBox();
    msgBox.success('Success message');
});

var onErrorButton = $('#errorBtn').on('click', function () {
    var msgBox = $('#message-box').messageBox();
    msgBox.error('Error message');
});