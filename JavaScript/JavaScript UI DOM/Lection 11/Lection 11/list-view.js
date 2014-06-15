/// <reference path="E:\Downloads\Telerik\JavaScript\JavaScript UI DOM\Lection 11\Lection 11\scripts/jquery-1.11.1.js" />
(function ($) {
    $.fn.listview = function (listViewItems) {
        var $this = $(this);

        var scriptID = $this.attr('data-template');

        var htmlTemplate;
        if (scriptID) htmlTemplate = document.getElementById(scriptID).innerHTML;
        else htmlTemplate = document.getElementById('students-table-body').innerHTML;

        console.log(htmlTemplate);

        var postTemplate = Handlebars.compile(htmlTemplate);

        $this.append(postTemplate(listViewItems));

        return $this;
    }
}(jQuery));

function createTable(insertIntoElement) {
    var $table = $('<table />');
    var $thead = $('<thead />');
    var $tbody = $('<tbody />');
    var $tr = $('<tr />');
    var $thNum = $('<th />');
    var $thName = $('<th />');
    var $thMark = $('<th />');
    var $trBody = $('<tr />');
    var $tdNum = $('<td />');
    var $tdName = $('<td />');
    var $tdMark = $('<td />');

    $tbody.attr('id','students-table-body');
    $trBody.addClass('student-row');

    $thNum.html('#');
    $thName.html('Name');
    $thMark.html('Mark');

    $tdNum.html('{{number}}');
    $tdName.html('{{name}}');
    $tdMark.html('{{mark}}');

    $thNum.appendTo($tr);
    $thName.appendTo($tr);
    $thMark.appendTo($tr);

    $tr.appendTo($thead);
    $thead.appendTo($table);

    $tbody.append('{{#each students}}');

    $tdNum.appendTo($trBody);
    $tdName.appendTo($trBody);
    $tdMark.appendTo($trBody);

    $trBody.appendTo($tbody);
    $tbody.append('{{/each}}');
  
    $tbody.appendTo($table);   
    $table.appendTo(document.getElementById(insertIntoElement));
}

var allBooks = {
    books: [
            {
                id: 1,
                title: 'JavaScript: The Good parts'
            },
            {
                id: 2,
                title: 'Secrets of the JavaScript Ninja'
            },
            {
                id: 3,
                title: 'Core HTML5 Canvas'
            },
            {
                id: 4,
                title: 'JavaScript Patterns'
            }
    ]
};

var allStudents = {
    students: [
            {
                number: 1,
                name: 'Peter Petrov',
                mark: 5.5
            },
            {
                number: 2,
                name: 'Stamat Georgiev',
                mark: 4.7
            },
            {
                number: 3,
                name: 'Maria Todorova',
                mark: 6
            },
            {
                number: 4,
                name: 'Georgi Geshov',
                mark: 3.7
            },
            {
                number: 5,
                name: 'Anna Hristova',
                mark: 4
            }
    ]
};
