function MostFrequentNumber(nArray) {
    var counter = 1;
        tempCounter = 1;
        arrayLength = nArray.length;
        nums = nArray.map(Number);
        nums.sort();
        result = [];

    for (var i = 0; i < arrayLength - 1; i++) {
        if (nums[i] === nums[i + 1]) {
            tempCounter++;
            if ((i === arrayLength - 2) && (tempCounter > counter)) {
                counter = tempCounter;
                result[0] = counter;
                result[1] = nums[i - 1];
            }
        } else {
            if (tempCounter > counter) {
                counter = tempCounter;
                result[0] = counter;
                result[1] = nums[i - 1];
            }
            tempCounter = 1;
        }
    }

    return result;
}

var numArray = [4, 1, 2, 1, 2, 4, 4, 4, 1, 2, 2, 9, 3];
    funcResult = MostFrequentNumber(numArray);
console.log("Most Frequent Number is: " + funcResult[1] + " - " + funcResult[0] + " times");