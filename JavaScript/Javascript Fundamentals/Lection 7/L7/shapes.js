function createPoint(xCoordinate, yCoordinate) {
    return {
        x: xCoordinate,
        y: yCoordinate,
        toString: function () {
            return ("(" + this.x + ", " + this.y + ")");
        }
    }
}

function createLine(startPoint, endPoint) {
    return {
        begin: startPoint,
        end: endPoint,
        toString: function () {
            return ("-" + this.begin + "-" + this.end + "-");
        }
    }
}

function calculateDistance(point1, point2) {

    return Math.sqrt((point2.x - point1.x) * (point2.x - point1.x) + (point2.y - point1.y) * (point2.y - point1.y));
}

function canFormTriangle(a, b, c) {

    if ((a + b > c) && (b + c > a) && (c + a > b)) return true;

    return false;
}
var xCoord1 = 1;
    yCoord1 = 2;
    xCoord2 = 0;
    yCoord2 = 0;

    point1 = createPoint(xCoord1, yCoord1);
    point2 = createPoint(xCoord2, yCoord2);
    point3 = createPoint(0, 4);
    point4 = createPoint(0, 1);
    line1 = createLine(point1, point2);
    line2 = createLine(point2, point3);
    line3 = createLine(point3, point1);
    line4 = createLine(point2, point4);
    a = calculateDistance(point1, point2);
    b = calculateDistance(point2, point3);
    c = calculateDistance(point3, point1);
    d = calculateDistance(point2, point4);
    isTriangle = canFormTriangle(a, b, c);
    isTriangle1 = canFormTriangle(a, b, d);

console.log("Point1: " + point1.toString());
console.log("Point2: " + point2.toString());
console.log("Point3: " + point3.toString());
console.log("Line1: " + line1.toString());
console.log("Line2: " + line2.toString());
console.log("Line3: " + line3.toString());
console.log("Line4: " + line4.toString());
console.log("Side a= " + a);
console.log("Side b= " + b);
console.log("Side c= " + c);
console.log("Side d= " + d);
console.log("All sides can form triangle - a,b,c: " + isTriangle);
console.log("All sides can form triangle - a,b,d: " + isTriangle1);