function ConvertToEnglish(digit) {
    var singleDigits = digit % 10;
        tenthDigit = (Math.floor(digit / 10)) % 10;
        hundredsDigit = Math.floor(digit / 100);

    switch (hundredsDigit) {
        case 1: hundredsDigitStr = "One"; break;
        case 2: hundredsDigitStr = "Two"; break;
        case 3: hundredsDigitStr = "Three"; break;
        case 4: hundredsDigitStr = "Four"; break;
        case 5: hundredsDigitStr = "Five"; break;
        case 6: hundredsDigitStr = "Six"; break;
        case 7: hundredsDigitStr = "Seven"; break;
        case 8: hundredsDigitStr = "Eight"; break;
        case 9: hundredsDigitStr = "Nine"; break;
        default: hundredsDigitStr = "Invalid Hundred Digit"; break;
    }
    switch (tenthDigit) {
        case 2: tenthDigitStr = "Twen"; break;
        case 3: tenthDigitStr = "Thir"; break;
        case 4: tenthDigitStr = "Four"; break;
        case 5: tenthDigitStr = "Fif"; break;
        case 6: tenthDigitStr = "Six"; break;
        case 7: tenthDigitStr = "Seven"; break;
        case 8: tenthDigitStr = "Eight"; break;
        case 9: tenthDigitStr = "Nine"; break;
        default: tenthDigitStr = "Invalid Tenth Digit"; break;
    }
    switch (singleDigits) {
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

    if (hundredsDigit < 1) {
        if (tenthDigit < 1) console.log("You have entered: " + singleDigitsStr);
        else if (tenthDigit == 1) {
            if (singleDigits == 0) console.log("You have entered: Ten");
            else if (singleDigits == 1) console.log("You have entered: Eleven");
            else if (singleDigits == 2) console.log("You have entered: Twelve");
            else if (singleDigits == 3) console.log("You have entered: Thirteen");
            else if (singleDigits == 5) console.log("You have entered: Fifteen");
            else console.log("You have entered: " + singleDigitsStr + "teen");
        }
        else console.log("You have entered: " + tenthDigitStr + "ty" + singleDigitsStr);
    }
    else {
        if (tenthDigit < 1) {
            if (singleDigits == 0) console.log("You have entered: " + hundredsDigitStr  + " hundreds");
            else console.log("You have entered: " + hundredsDigitStr + "hundreds and " + singleDigitsStr);
        }
        else if (tenthDigit == 1) {
            if (singleDigits == 0) console.log("You have entered: " + hundredsDigitStr + " hundreds and ten");
            else if (singleDigits == 1) console.log("You have entered: " + hundredsDigitStr + " hundreds and eleven");
            else if (singleDigits == 2) console.log("You have entered: " + hundredsDigitStr + " hundreds and twelve");
            else if (singleDigits == 3) console.log("You have entered: " + hundredsDigitStr + " hundreds and thirteen");
            else if (singleDigits == 5) console.log("You have entered: " + hundredsDigitStr + " hundreds and fifteen");
            else console.log("You have entered: " + hundredsDigitStr + "hundreds and " + singleDigitsStr + "teen");
        }
        else if (singleDigits == 0) console.log("You have entered: " + hundredsDigitStr  + "hundreds and " + tenthDigitStr + "ty");
        else console.log("You have entered: " + hundredsDigitStr + "hundreds and " + tenthDigitStr + "ty" + singleDigitsStr);
    }
}

var numberInEnglish = 123;

ConvertToEnglish(numberInEnglish);
