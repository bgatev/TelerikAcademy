function Solve(inputStr) {
    var numberOfJumps = 0;
        sumOfNumbers = 0;

        parsedLine = inputStr[0].split(" ");

        N = parseInt(parsedLine[0]);
        M = parseInt(parsedLine[1]);
        J = parseInt(parsedLine[2]);

        parsedLine = inputStr[1].split(" ");

        R = parseInt(parsedLine[0]);
        C = parseInt(parsedLine[1]);

        var allJumps = [];

    for (var i = 2; i < 2 + J; i++) {
        parsedLine = inputStr[i].split(" ");
        var currentJump = {x:parseInt(parsedLine[0]), y:parseInt(parsedLine[1])}

        allJumps.push(currentJump);
    }

    var field = [];
    
    for (var i = 0,counter = 1; i < N; i++) {
        field.push([]);
        for (var j = 0; j < M; j++) {
            field[i][j] = counter++;
        }
    }

    currentJump = { x: R, y: C };
    var jumpIndex = 0;

    while (true) {
        if ((currentJump.x < 0) || (currentJump.x > (N - 1)) || (currentJump.y < 0) || (currentJump.y > (M - 1))) return "escaped " + sumOfNumbers;
        if (field[currentJump.x][currentJump.y] == "X") return "caught " + numberOfJumps;

        sumOfNumbers += field[currentJump.x][currentJump.y];
        field[currentJump.x][currentJump.y] = "X";
        numberOfJumps++;
        
        currentJump.x += allJumps[jumpIndex].x;
        currentJump.y += allJumps[jumpIndex++].y;
        if (jumpIndex > (J - 1)) jumpIndex = 0;  
    }
}

console.log(Solve(['6 7 3',
                    '0 0',
                    '2 2',
                    '-2 2',
                    '3 -1']));