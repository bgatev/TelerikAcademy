function CheckPrime(number) {

    for (var i = 2; i < Math.sqrt(number); i++) if (number % i == 0) return false;

    return true;
}

var numberToCheck = 41;

console.log("Number " + numberToCheck + " is prime:" + CheckPrime(numberToCheck));