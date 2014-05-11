(function ExchangeIfBigger() {
    var a = 8,
        b = 7;

    if (a > b) {
        var temp = a;
        a = b;
        b = temp;
    }

    console.log(a);
    console.log(b);
})();