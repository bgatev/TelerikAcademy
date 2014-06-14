/// <reference path="scripts/jquery-1.11.1.js" />
function changeColors() {
    var $container = $('body');
    var $colorPicker = $('#bodyBackgroundColor');
    
    $container.css('background-color', $colorPicker.val());

    $colorPicker.change(function () {
        $container.css('background-color', $colorPicker.val());
    });
}