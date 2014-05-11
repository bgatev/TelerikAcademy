function CheckPointInCircleOutsideRectangle(x, y) {

    return ((((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 9) & ((x < 1 | x > 7) & (y < -1 | y > 1))) ? true : false;
}

var pointX = 0;
    pointY = 2;

console.log("Point (" + pointX + "," + pointY + ") is inside circle K((1,1),3), but outside Rectangle (1,-1) height=2, width=6:" + CheckPointInCircleOutsideRectangle(pointX, pointY));