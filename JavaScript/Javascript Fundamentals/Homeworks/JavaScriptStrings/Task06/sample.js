//Write a function that extracts the content of a html page given as text. 
//The function should return anything that is in a tag, without the tags:
(function () {
    var text = prompt("Some text:");
    var startExtract = false;
    var extractedText = "";
    for (var i = 0; i < text.length; i++) {
        if (text[i] === "<") {
            startExtract = false;
        }
        if (startExtract) {
            extractedText += text[i];
        }
        if (text[i] === ">") {
            startExtract = true;
        }
    }

    alert("Extracted text: " + extractedText);
})();