(function QuadraticEquation() {
    var a = 1;
        b = -5;
        c = 2;

    var D = b * b - 4 * a * c;
    if (D > 0) {
        var x1 = (-b + Math.sqrt(D)) / (2 * a);
        var x2 = (-b - Math.sqrt(D)) / (2 * a);
        console.log("The result of " + a + "*x^2 + " + b + "*x + " + c + " = 0 is:");
        console.log("x1 = " + x1);
        console.log("x2 = " + x2);
    }
    else if (D == 0) {
        x1 = -b / (2 * a);
        x2 = x1;
        console.log("The result of " + a + "*x^2 + " + b + "*x + " + c + " = 0 is:");
        console.log("x1 = " + x1);
        console.log("x2 = " + x2);
    }
    else console.log("No real Roots");
})();
