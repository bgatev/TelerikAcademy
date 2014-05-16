function CheckBigger(inArray, currentPos) {
    var result = false;
        numbers = inArray.map(Number);

    if (currentPos === 0) {
        if (numbers[currentPos] > numbers[currentPos + 1]) return true;
    } else if (currentPos === numbers.length - 1) {
        if (numbers[currentPos] > numbers[currentPos - 1]) return true;
    } else if (numbers[currentPos] > numbers[currentPos - 1] && numbers[currentPos] > numbers[currentPos + 1]) return true;

    return result;
}

(function ReturnFirstBigger() {
    var numArray = [1, 2, 3, 5, 2, 45, 11, 89, 5, 7, 24];
        arrayLength = numArray.length;

    for (var i = 0; i < arrayLength; i++) {
        var index = CheckBigger(numArray, i);
        if (index) {
            console.log("The index of the first bigger element is: " + i);
            break;
        }
        if (i === (arrayLength - 1)) console.log("There is no such index");
    }

})();