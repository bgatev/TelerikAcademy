function dividedBy5And7(number) {
    return ((number % 5 === 0 && number % 7 === 0) ? true : false);
}

var numberTocheck = 35;

console.log("Number: " + numberTocheck + " is divided by 5 and 7: " + dividedBy5And7(numberTocheck));