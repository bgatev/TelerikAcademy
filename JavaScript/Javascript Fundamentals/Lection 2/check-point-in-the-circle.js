function CheckPointInCircle(x,y) {

    return (x * x  + y * y) < 25;
}

var pointX = 2;
    pointY = 3;

    console.log("Point (" + pointX + "," + pointY + ") is inside circle K(0,5):" + CheckPointInCircle(pointX, pointY));