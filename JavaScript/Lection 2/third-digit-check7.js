function ThirdDigitCheck7(number) {

    return (((Math.floor(number / 100)) % 10) === 7);
}

var numberToCheck = 2347835;

console.log("The third digit of " + numberToCheck + " is 7: " + ThirdDigitCheck7(numberToCheck));