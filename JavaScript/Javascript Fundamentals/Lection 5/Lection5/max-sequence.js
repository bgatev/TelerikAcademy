function MaxSequence(nArray) {
    var result = 1;
        numArray = nArray.map(Number);
        numArrayLength = numArray.length;
        tempResult = 1;

    for (var i = 0; i < numArrayLength - 1; i++) {
        if (numArray[i] === numArray[i + 1]) {
            tempResult++;
            if (i === numArrayLength - 2) result = tempResult;
        } else {
            if (tempResult > result) result = tempResult;
            tempResult = 1;
        }
    }

    return result;
}

var numArray = [1, 1, 1, 3, 3, 3, 2, 2, 1, 2];

console.log("Max Sequence is: " + MaxSequence(numArray));