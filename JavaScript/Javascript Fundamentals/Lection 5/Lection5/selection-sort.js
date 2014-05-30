function swap(nArray, firstIndex, secondIndex) {
    var temp = nArray[firstIndex];
        nArray[firstIndex] = nArray[secondIndex];
        nArray[secondIndex] = temp;
}

function SelectionSort(nArray) {
    var arrayLength = nArray.length,
        minElement;

    for (i = 0; i < arrayLength; i++) {
        minElement = i;

        for (j = i + 1; j < arrayLength; j++) {
            if (nArray[j] < nArray[minElement]) minElement = j;
        }

        if (i != minElement) swap(nArray, i, minElement);
    }

    return nArray;
}

var numArray = [13, 11, 21, 13, 4, 3, 26, 2, 1, 2];

console.log("Sorted Array: " + SelectionSort(numArray));