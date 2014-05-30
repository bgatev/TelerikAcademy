function checkEven(number){
    return ((number % 2 === 0) ? true : false);
};

var numberTocheck = 4;

console.log("Number: " + numberTocheck + " is even: " + checkEven(numberTocheck));