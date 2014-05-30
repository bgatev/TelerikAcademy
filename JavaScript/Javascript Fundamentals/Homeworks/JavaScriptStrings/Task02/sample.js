//Write a JavaScript function to check if in a given expression the brackets are put correctly.
(function () {
    var input = prompt("Enter some expression:");
    var positiveBrackets = 0;
    for (var i = 0; i < input.length; i++) {
        if (input[i] === "(") {
            positiveBrackets++;
        } else if (input[i] === ")") {
            if (positiveBrackets === 0) {
                positiveBrackets = -1;
                break;
            } else {
                positiveBrackets--;
            }
        }
    }

    if (positiveBrackets === 0) {
        alert("Expression is correct");
    } else {
        alert("Wrong expression");
    }
})();