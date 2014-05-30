function DigitInEnglish(digit) {
    var singleDigitsStr;

    switch (digit) {
        case 0: singleDigitsStr = "Zero"; break;
        case 1: singleDigitsStr = "One"; break;
        case 2: singleDigitsStr = "Two"; break;
        case 3: singleDigitsStr = "Three"; break;
        case 4: singleDigitsStr = "Four"; break;
        case 5: singleDigitsStr = "Five"; break;
        case 6: singleDigitsStr = "Six"; break;
        case 7: singleDigitsStr = "Seven"; break;
        case 8: singleDigitsStr = "Eight"; break;
        case 9: singleDigitsStr = "Nine"; break;
        default: singleDigitsStr = "Invalid Digit"; break;
    }

    return singleDigitsStr;
}

var numberInEnglish = 3;

console.log(DigitInEnglish(numberInEnglish));
