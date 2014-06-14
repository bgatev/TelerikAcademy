/// <reference path="scripts/jquery-1.11.1.js" />
function createTable(students) {
    var $container = $('#container');
    var $table = $('<table />');
    var $tr = $('<tr />');
    var $fNameTH = $('<th />');
    var $lNameTH = $('<th />');
    var $gradeTH = $('<th />');

    $fNameTH.html('First Name').appendTo($tr);
    $lNameTH.html('Last Name').appendTo($tr);
    $gradeTH.html('Grade').appendTo($tr);
    $tr.appendTo($table);

    for (var i = 0, len = students.length; i < len; i++) {
        var $currentTR = $('<tr />');
        var $fNameTD = $('<td />');
        var $lNameTD = $('<td />');
        var $gradeTD = $('<td />');

        $fNameTD.html(students[i].fName).appendTo($currentTR);
        $lNameTD.html(students[i].lName).appendTo($currentTR);
        $gradeTD.html(students[i].grade).appendTo($currentTR);

        $currentTR.appendTo($table);
    }

    $table.appendTo($container);
}