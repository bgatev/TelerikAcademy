function FindCaseInsensitive(textString, stringWanted) {
    var result = 0;
    lowerText = textString.toLowerCase();
    lowerStr = stringWanted.toLowerCase();

    do {
        var index = lowerText.indexOf(lowerStr);

        if (index > -1) {
            lowerText = lowerText.substr(index + lowerStr.length);
            result++;
        }
    }
    while (index > -1)

    return result;
}

//var subStringToFind = "test";
//textArray = "I am your mum.Test my visual effects, test your work or go home. The actual version is not tested yet.";
var subStringToFind = "in";
textArray = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."


console.log("The CaseInsensitive string is founded " + FindCaseInsensitive(textArray, subStringToFind) + " times");
