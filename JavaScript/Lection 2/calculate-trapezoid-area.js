function CalculateTrapezoidArea(a, b, h) {
    return (a + b) * h / 2;
}

var sideA = 35;
    sideB = 2;
    heightH = 3;

    console.log("Area is: " + CalculateTrapezoidArea(sideA, sideB, heightH));