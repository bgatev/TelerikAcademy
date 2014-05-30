function CharCompareArrays(arr1,arr2) {
    var arrLength = (arr1.length < arr2.length) ? arr1.length : arr2.length;

    for (var i = 0; i < arrLength; i++) {
        if (arr1[i] < arr2[i]) return true;
        else if (arr1[i] === arr2[i]) continue;
        else return false;
    }
}

var charArray1 = "Hello Telerik";
    charArray2 = "Hei Mum";

console.log("Array 1 is first lexicographically: " + CharCompareArrays(charArray1, charArray2));