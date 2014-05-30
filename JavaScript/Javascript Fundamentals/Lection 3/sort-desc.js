(function SortDescending() {
    var fNum = 81,
        sNum = 217;
        tNum = 966;

    if (fNum > sNum) {
        if (sNum > tNum) {
            console.log("Sort completed: " + fNum + ", " + sNum + ", " + tNum);
        }
        else {
            var tempNum = sNum;
            sNum = tNum;
            tNum = tempNum;
            console.log("Sort completed: " + fNum + ", " + sNum + ", " + tNum);
        }
    }
    else //fNum < sNum
    {
        tempNum = fNum;
        fNum = sNum;
        sNum = tempNum;
        if (tNum < sNum) {
            console.log("Sort completed: " + fNum + ", " + sNum + ", " + tNum);
        }
        else if (tNum < fNum) {
            tempNum = sNum;
            sNum = tNum;
            tNum = tempNum;
            console.log("Sort completed: " + fNum + ", " + sNum + ", " + tNum);
        }
        else {
            tempNum = tNum;
            tNum = sNum;
            sNum = fNum;
            fNum = tempNum;
            console.log("Sort completed: " + fNum + ", " + sNum + ", " + tNum);
        }
    }
})();