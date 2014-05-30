function FindNumInArray(inArray, numWanted) {
    var result = 0;
        numbers = inArray.map(Number);
        arrayLength = inArray.length;

    numbers.sort();
    for (var i = 0; i < arrayLength; i++) {
        if (numbers[i] === numWanted) result++;
    }

    return result;
}

(function testFunction() {
    var numToFind = 2;
    NumArray = [1, 2, 3, 5, 2, 45, 11, 89, 5, 7, 24];

    console.log("The number is founded " + FindNumInArray(NumArray, numToFind) + " times");

})();