function Brackets(inputStr) {
    var inputStrLength = inputStr.length;
        leftBracket=[];
        rightBracket=[];

    for (var i = 0; i < inputStrLength; i++) {
        if (inputStr[i] == '(') leftBracket.push(i);
        else if (inputStr[i] == ')') rightBracket.push(i);
    }

    var leftBracketLength = leftBracket.length;
    if (leftBracket.length != rightBracket.length) return false;

    for (var i = 0; i < leftBracketLength; i++) {
        if (leftBracket[i] > rightBracket[i]) return false;
    }

    return true;
}

var str = "(a+3+(3-1)*6-7)";
console.log(Brackets(str));