function Solve(args) {
    var wheels = parseInt(args);
    var counter = 0;

    for (var i = 0; i < wheels; i++) {
        for (var j = 0; j < wheels; j++) {
            for (var k = 0; k < wheels; k++) {
                var count = i * 10 + j * 4 + k * 3;
                if (count === wheels) {
                    counter++;
                }
            }
        }
    }

    return counter;
}
console.log(Solve(40));