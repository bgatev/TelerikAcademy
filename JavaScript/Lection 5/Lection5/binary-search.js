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

function BinarySearch(inArray, numToFind)
{     
    var left = 0;
        right = inArray.length;

    while (left <= right)
    {
        var mid = Math.floor((left + right) / 2);

        if (numToFind == inArray[mid]) return mid;
        else if (numToFind > inArray[mid]) left = mid + 1;
        else if (numToFind < inArray[mid]) right = mid - 1;
    }
        
    return -1;
}

var numArray = [13, 11, 21, 13, 4, 3, 26, 2, 1, 5];
    numberToFind = 11;
    
    console.log(SelectionSort(numArray));
    console.log("Index of Number to find is: " + BinarySearch(numArray, numberToFind));