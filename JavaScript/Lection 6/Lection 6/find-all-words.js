function FindAllWordsCaseSensitive(textString, wordWanted) {
    var result = 0;
        myTextString = textString;

    do {
        var index = myTextString.indexOf(wordWanted + " ");

        if (index > -1) {
            myTextString = myTextString.substr(index + wordWanted.length);
            result++;
        }
    }
    while (index > -1)

    return result;
}

function FindAllWordsCaseInsensitive(textString, wordWanted) {
    var result = 0;
        lowerText = textString.toLowerCase();
        lowerWord = wordWanted.toLowerCase();

        do {
            var index = lowerText.indexOf(lowerWord + " ");
            
            if (index > -1) {
                lowerText = lowerText.substr(index + lowerWord.length);
                result++;
            }
        }
        while (index > -1)
        
    return result;
}

var wordToFind = "test";
    textArray = "I am your mum.Test my visual effects, test your work or go home. The actual version is not tested yet.";

    console.log("The CaseInsensitive word is founded " + FindAllWordsCaseInsensitive(textArray, wordToFind) + " times");
    console.log("The CaseSensitive word is founded " + FindAllWordsCaseSensitive(textArray, wordToFind) + " times");
