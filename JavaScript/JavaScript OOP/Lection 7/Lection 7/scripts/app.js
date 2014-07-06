define(['data', 'comboBox'], function (people, controls) {
    var start = function () {
        var container = document.getElementById('comboBox');
        var myComboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxHtml = myComboBox.render(template);

        container.innerHTML = comboBoxHtml;
        myComboBox.create('#comboBox');
    };

    return {
        start: start
    };
});