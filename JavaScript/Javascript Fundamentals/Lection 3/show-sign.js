(function ShowSign() {
    var fNum = 8,
        sNum = 7;
        tNum = -9;

    if (fNum > 0) {
        if (sNum > 0) {
            if (tNum > 0) console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is +");
            else console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is -");
        }
        else if (tNum > 0) console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is -");
        else console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is +");
    }
    else {
        if (sNum > 0) {
            if (tNum > 0) console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is -");
            else console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is +");
        }
        else if (tNum > 0) console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is +");
        else console.log("The sign of multiplication of " + fNum + ", " + sNum + ", " + tNum + " is -");
    }
})();