function solve(params) {
    var N = Number(params[0]);
    var result = '';
    var keyValuePair = [];

    for (var i = 0; i < N; i++) {
        var line = params[i + 1].split('-');
        var subline = line[1].split(';');
        keyValuePair[i] = { key: line[0], value: subline};
    }

    var M = Number(params[N + 1]);
    var view = [];

    for (var i = 0; i < M; i++) {
        view[i] = params[N + 2 + i];
    }

    var viewLength = view.length;
    var keyValuePairLength = keyValuePair.length;

    for (var i = 0; i < viewLength; i++) {
        var currentLine = view[i];
       
        if (currentLine != undefined) {
            var indexOfNK = currentLine.indexOf('<nk-model>');
            var indexOfNKEnd = currentLine.indexOf('</nk-model>');

            if (indexOfNK != -1 && indexOfNKEnd != -1) {
                result += currentLine.substring(0, indexOfNK);
                var currentKey = currentLine.substring(indexOfNK + 10, indexOfNKEnd);

                for (var j = 0; j < keyValuePairLength; j++) {
                    if (currentKey == keyValuePair[j].key) {
                        result += keyValuePair[j].value;
                        break;
                    }
                }
                result += currentLine.substr(indexOfNKEnd + 11) + '\n';
            }
            else result += currentLine + '\n';
        }
    }
    //console.log(result);
    return result;
}

var fs = require('fs');

var testId = '003';

fs.readFile('test.' + testId + '.in.txt', 'utf8', function (err, data) {
    var input = data.split('\r\n');
    console.log(input);
    var result = solve(input);
    fs.writeFile('test.' + testId + '.out.txt', result);
    console.log(result);
})


var p3=['2',
'text-RandomText',
'anotherText-RandomTextAgain',
'10',
'<div>',
'    <div>',
'        <nk-model>text</nk-model>',
'    </div>',
'    <ul>',
'        <li>',
'             <span><nk-model>anotherText</nk-model></span>',
'        </li>',
'    </ul>',
'</div>']

//solve(p3);

var p=[6,
'title-Telerik Academy',
'showSubtitle-true',
'subTitle-Free training',
'showMarks-false',
'marks-3;4;5;6',
'students-Ivan;Gosho;Pesho',
'42',
'<nk-template name="menu">',
    '<ul id="menu">',
        '<li>Home</li>',
        '<li>About us</li>',
    '</ul>',
'</nk-template>',
'<nk-template name="footer">',
    '<footer>',
       'Copyright Telerik Academy 2014',
    '</footer>',
'</nk-template>',
'<!DOCTYPE html>',
'<html>',
'<head>',
    '<title>Telerik Academy</title>',
'</head>',
'<body>',
    '<nk-template render="menu" />',
    '<h1><nk-model>title</nk-model></h1>',
    '<nk-if condition="showSubtitle">',
        '<h2><nk-model>subTitle</nk-model></h2>',
        '<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',
    '<ul>',
        '<nk-repeat for="student in students">',
            '<li>',
              '<nk-model>student</nk-model>',
            '</li>',
           '<li>Multiline <nk-model>title</nk-model></li>',
        '</nk-repeat>',
   '</ul>',
    '<nk-if condition="showMarks">',
       '<div>',
           '<nk-model>marks</nk-model>' ,
       '</div>',
   '</nk-if>',
   '<nk-template render="footer" />',
'</body>',
'</html>']

//console.log(solve(p));
