function Solve(inputStr) {
    var result = 1;
    
    inputStr = inputStr.map(Number);
    var inputLength = inputStr[0];

    for (var i = 2; i < inputLength + 1; i++) {
        if (inputStr[i] < inputStr[i - 1]) result++;
    }

    return result;
}
