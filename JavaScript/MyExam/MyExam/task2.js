function Horsy(params) {
    var RC = params[0].split(' ');
    var R = RC[0];
    var C = RC[1];
    var field = [];
    var numbers = [];
    var allweeds = 0;
    var numberOfJumps = 0;

    for (var i = 0; i < R; i++) {
        field.push([]);
        for (var j = 0; j < C; j++) {
            var line = params[i + 1];
            field[i][j] = line[j];
            switch (field[i][j]) {
                case '1': field[i][j] = { x: -2, y: 1 }; break;
                case '2': field[i][j] = { x: -1, y: 2 }; break;
                case '3': field[i][j] = { x: 1, y: 2 }; break;
                case '4': field[i][j] = { x: 2, y: 1 }; break
                case '5': field[i][j] = { x: 2, y: -1 }; break;
                case '6': field[i][j] = { x: 1, y: -2 }; break;
                case '7': field[i][j] = { x: -1, y: -2 }; break;
                case '8': field[i][j] = { x: -2, y: -1 }; break
            }

        }
    }

    var numbers = makeNumberMatrix(R, C);

    var currentJump = { x: R-1, y: C-1 };

    while (true) {
        if ((currentJump.x < 0) || (currentJump.x > (R - 1)) || (currentJump.y < 0) || (currentJump.y > (C - 1))) return "Go go Horsy! Collected " + allweeds + " weeds";
        if (numbers[currentJump.x][currentJump.y] == "X") return "Sadly the horse is doomed in " + numberOfJumps + " jumps";

        allweeds += numbers[currentJump.x][currentJump.y];
        numbers[currentJump.x][currentJump.y] = "X";
        numberOfJumps++;

        var tempJump = DeepCopy(currentJump);

        currentJump.x += field[tempJump.x][tempJump.y].x;
        currentJump.y += field[tempJump.x][tempJump.y].y;
    }

    function DeepCopy(obj) {
        var result = {};

        if ((typeof (obj) === 'string') || (typeof (obj) === 'number') || (typeof (obj) === 'boolean')) return obj;

        for (var prop in obj) result[prop] = obj[prop];

        return result;
    }

    function makeNumberMatrix(mRows, mCols) {
        var resultMatrix = new Array(mRows);
        var inputNumber = 1;
        var powIndex = 1;

        for (var i = 0; i < mRows; i += 1) {
            resultMatrix[i] = new Array(mCols);

            if (i >= 1) {
                powIndex = i;
                inputNumber = Math.pow(2, powIndex);
            }

            for (var j = 0; j < mCols; j += 1) {
                resultMatrix[i][j] = inputNumber;
                inputNumber--;
            }

        }

        return resultMatrix;
    }
}



var args = [
  '3 5',
  '54561',
  '43328',
  '52388',
];

console.log(Horsy(args));