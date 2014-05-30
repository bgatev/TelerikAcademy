function Reverse(num) {
    var reversed = "";
        numLength = num.toString().length;

        for (var i = numLength - 1; i > -1; i--) reversed += num.toString()[i];
    
    return reversed;
}

var numberToReverse = 12437;

console.log(Reverse(numberToReverse));
