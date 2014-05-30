//Write a JavaScript function that finds how many times a substring is 
//contained in a given text (perform case insensitive search).
(function () {
    var input = prompt("Enter some text");
    var searchedText = prompt("Enter the searched substring");
    var start = 0;
    var textLower = input.toLowerCase();
    var searchedTextLower = searchedText.toLowerCase();
    var counter = 0;

    while (textLower.indexOf(searchedTextLower, start) !== -1) {
        counter++;
        start = textLower.indexOf(searchedTextLower, start) + searchedTextLower.length;
    }

    alert("The text has been found " + counter + " times.");
})();