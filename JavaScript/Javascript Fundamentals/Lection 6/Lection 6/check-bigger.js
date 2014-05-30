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

(function testFunction() {
    var position = 10;
        numArray = [11, 2, 3, 5, 2, 45, 11, 89, 5, 7, 24];

    console.log("The element is bigger: " + CheckBigger(numArray, position));

})();