//Write a JavaScript function reverses string and returns itExample: "sample"  "elpmas".
(function () {
    var input = prompt("Enter some text:");
    var reversedString = "";
    for (var i = input.length - 1; i >= 0; i--) {
        reversedString += input[i];
    }
    alert("Reversed string is: " + reversedString);
})();