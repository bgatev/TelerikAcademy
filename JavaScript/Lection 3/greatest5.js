(function Greatest5() {
    var Num1 = 8,
        Num2 = 7;
        Num3 = -9;
        Num4 = 4;
        Num5 = 15;

    if (Num1 > Num2) {
        if (Num3 < Num2) {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num1);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num1);
            }
        }
        else if (Num3 < Num1) {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num1);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num1);
            }
        }
        else {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num3);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num3);
            }
        }

    }
    else {
        if (Num3 < Num1) {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num2);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num2);
            }
        }
        else if (Num3 < Num2) {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num2);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num2);
            }
        }
        else {
            if (Num4 > Num5) {
                if (Num4 > Num1) console.log("The biggest number is " + Num4);
                else console.log("The biggest number is " + Num3);
            }
            else {
                if (Num5 > Num1) console.log("The biggest number is " + Num5);
                else console.log("The biggest number is " + Num3);
            }
        }
    }
})();