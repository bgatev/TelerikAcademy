function CheckBit3(number) {

    return (number & (1 << 3)) !== 0;
}

var numberToCheck = 25;

console.log("Bit 3 of " + numberToCheck + " is 1: " + CheckBit3(numberToCheck));