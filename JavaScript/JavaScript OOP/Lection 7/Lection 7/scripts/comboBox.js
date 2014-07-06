define(['jquery','handlebars'], function ($) {
    var ComboBox = function (people) {
        this.people = people || ["Empty Data Array"];
    };

    ComboBox.prototype = {
        render: function (template) {
            var handlebarsTemplate = Handlebars.compile(template);

            return handlebarsTemplate(this.people);
        },
        create: function (selector) {
            var parent = $(selector);
            var allElements = parent.children().hide();
            var selectedElement;

            var selectBtn = $('#selectBtn');
            selectBtn.on('click', function () {
                allElements.show();
                selectBtn.remove();
            });

            allElements.on('click', function () {
                selectedElement = $(this);
                var shownElement = selectedElement.clone().prependTo(parent);
                shownElement.on('click', function () {
                   allElements.show();
                   shownElement.remove();
                });
                allElements.hide();
            });
        }
    };

    return {
        ComboBox: function (data) {
            return new ComboBox(data);
        }
    };
});