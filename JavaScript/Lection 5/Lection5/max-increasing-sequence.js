function MaxIncreasingSequence(nArray) {
    var result = [];
        numArray = nArray.map(Number);
        numArrayLength = numArray.length;
        tempResult = [];

    for (var i = 0; i < numArrayLength - 1; i++) {
        if (numArray[i] < numArray[i + 1]) {
            tempResult.push(numArray[i]);
            if (i === numArrayLength - 2) {
                tempResult.push(numArray[i + 1]);
                if (tempResult.length > result.length) result = tempResult;
            }
        } else {
            tempResult.push(numArray[i]);
            if (tempResult.length > result.length) result = tempResult;
            tempResult = [];
        }
    }

    return result;
}

var numArray = [3, 2, 3, 4, 2, 2, 4, 5, 5];

console.log("Max Increasing Sequence is: " + MaxIncreasingSequence(numArray));