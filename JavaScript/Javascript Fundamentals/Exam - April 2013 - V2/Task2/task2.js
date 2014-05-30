function Solve(inputStr) {
    var numberOfJumps = 0;
        sumOfNumbers = 0;
        inputStrLength = inputStr.length;

    parsedLine = inputStr[0].split(" ");

    N = parseInt(parsedLine[0]);
    M = parseInt(parsedLine[1]);

    parsedLine = inputStr[1].split(" ");

    R = parseInt(parsedLine[0]);
    C = parseInt(parsedLine[1]);

    var field = [];
        allJumps = [];
        
    for (var i = 0, counter = 1; i < N; i++) {
        field.push([]);
        allJumps.push([]);
        parsedLine = inputStr[i + 2];
        for (var j = 0; j < M; j++) {
            field[i][j] = counter++;
            switch (parsedLine[j]) {
                case 'l': allJumps[i][j] = { x: 0, y: -1}; break;
                case 'r': allJumps[i][j] = { x: 0, y: 1 }; break;
                case 'u': allJumps[i][j] = { x: -1, y: 0 }; break;
                case 'd': allJumps[i][j] = { x: 1, y: 0 }; break
            }

        }
    }

    var currentJump = { x: R, y: C };

    while (true) {
        if ((currentJump.x < 0) || (currentJump.x > (N - 1)) || (currentJump.y < 0) || (currentJump.y > (M - 1))) return "out " + sumOfNumbers;
        if (field[currentJump.x][currentJump.y] == "X") return "lost " + numberOfJumps;

        sumOfNumbers += field[currentJump.x][currentJump.y];
        field[currentJump.x][currentJump.y] = "X";
        numberOfJumps++;

        var tempJump = DeepCopy(currentJump);

        currentJump.x += allJumps[tempJump.x][tempJump.y].x;
        currentJump.y += allJumps[tempJump.x][tempJump.y].y;

        
    }

    function DeepCopy(obj) {
        var result = {};

        if ((typeof (obj) === 'string') || (typeof (obj) === 'number') || (typeof (obj) === 'boolean')) return obj;

        for (var prop in obj) result[prop] = obj[prop];

        return result;
    }
}

console.log(Solve(['3 4',
                    '1 3',
                    'lrrd',
                    'dlll',
                    'rddd']));