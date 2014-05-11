(function Biggest3() {
    var fNum = 81,
        sNum = 17;
        tNum = -9;

    if (fNum > sNum) {
        if (tNum < sNum) {
            console.log("The biggest number is " + fNum);
        }
        else if (tNum < fNum) {
            console.log("The biggest number is " + fNum);
        }
        else {
            console.log("The biggest number is " + tNum);
        }

    }
    else {
        if (tNum < fNum) {
            console.log("The biggest number is " + sNum);
        }
        else if (tNum < sNum) {
            console.log("The biggest number is " + sNum);
        }
        else {
            console.log("The biggest number is " + tNum);;
        }
    }
})();