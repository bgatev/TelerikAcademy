function Reverse(inputStr) {
    var str = '';
        inputStrLength = inputStr.length;

    for (var i = inputStrLength - 1; i > -1; i--) str += inputStr[i];

    return str;
}

var str = "come on go home darling";
console.log(Reverse(str));
