function solve(params) {
    var s = params[0], c1 = params[1], c2 = params[2], c3 = params[3];
    var count = Math.max(s / c1, s / c2, s / c3);
    var answer = 0;
    var maxAnswer = 0;

    for (var i = 0; i < count; i++) {
        for (var j = 0; j < count; j++) {
            for (var k = 0; k < c3; k++) {
                answer = i * c1 + j * c2 + k * c3;
                if (answer > s) break;
                else if (answer > maxAnswer) maxAnswer = answer;
                if (maxAnswer == s) return maxAnswer;
            }
        }
    }

    return maxAnswer;
}

var params = [110, 13, 15, 17];
var p1 = [20, 11, 200, 300];
var p2 = [110, 19, 29, 39];
console.log(solve(params));
console.log(solve(p1));
console.log(solve(p2));