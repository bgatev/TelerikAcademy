function Array5(n) {
    var arrayN = new Array(n);

    for (var i = 0; i < n; i++) {
        arrayN[i] = i * 5;
        console.log(arrayN[i]);
    }
}

var numberN = 20;
Array5(numberN);