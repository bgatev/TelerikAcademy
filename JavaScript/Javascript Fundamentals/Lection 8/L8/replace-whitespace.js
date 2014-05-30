function ReplaceWhitespace(inputStr) {
    var str = '';
    inputStrLength = inputStr.length;

    for (var i = 0; i < inputStrLength; i++) {
        if (inputStr[i] == " ") str += '&nbsp';
        else str += inputStr[i];
    }

    return str;
}

var str = "come       on   go home    darling   ";
console.log(ReplaceWhitespace(str));
