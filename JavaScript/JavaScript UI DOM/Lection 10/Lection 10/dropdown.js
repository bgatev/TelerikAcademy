/// <reference path="E:\Downloads\Telerik\JavaScript\JavaScript UI DOM\Lection 10\Lection 10\scripts/jquery-1.11.1.js" />
$.fn.dropdown = function () {
    var $this = this;
    var $container = $this;
    var $divContainer = $('<div />');
    var $ulContainer = $('<ul />');
    var $liTemplate = $('<li />');

    $divContainer.addClass('dropdown-list-container');
    $ulContainer.addClass('dropdown-list-options');
    $liTemplate.addClass('dropdown-list-option');
    $container.css('display', 'none');

    var $options = $this.find('option');
    console.log($options);

    for (var i = 0; i < $options.length; i++) {
        var $currentLI = $liTemplate.clone(true);
        var currentLIText = $options[i].innerHTML;

        $currentLI.attr('data-value', i);
        $currentLI.html(currentLIText);
        $currentLI.appendTo($ulContainer);
    }

    $ulContainer.appendTo($divContainer);
    $container.parent().append($divContainer);

    $(".dropdown-list-option").on("click", function () {
        if ($(this).attr('selected') == 'selected') {
            $(this).removeAttr('selected');
            $(this).css('background-color', '');
        }
        else {
            $(this).attr('selected', 'selected');
            $(this).css('background-color', 'red');
        }
    });

    return $this;
};