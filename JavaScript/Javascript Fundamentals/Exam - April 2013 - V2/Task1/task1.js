function Solve(inputStr) {
    var maxSum = -2000000000;

    inputStr = inputStr.map(Number);
    var inputLength = inputStr[0];
    var arr = [];

    for (var i = 0; i < inputLength; i++) {
        arr[i] = parseInt(inputStr[i + 1]);
    }

    for (var i = 0; i < inputLength; i++) {
        var currentSum = 0;

        for (var j = i; j < inputLength; j++) {
            currentSum += arr[j];
            if (currentSum > maxSum) maxSum = currentSum;
        }
        
    }

    return maxSum;
}
console.log(Solve(["8",
                    "1",
                    "6",
                    "-9",
                    "4",
                    "4",
                    "-2",
                    "10",
                    "-1"]));