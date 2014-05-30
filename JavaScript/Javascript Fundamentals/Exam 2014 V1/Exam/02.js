function Solve(args) {
    var result;
    var matrixRows = parseInt(args[0].split(' ')[0]);
    var matrixCols = parseInt(args[0].split(' ')[1]);

    var numberMatrix = makeNumberMatrix(matrixRows, matrixCols);
    var directionsMatrix = makeDirectionMatrix(args);

    var startRow = 0;
    var startCol = 0;
    var numberOfCells = 0;
    var currentResult = 0;

    function move(sRow, sCol) {
        if (sRow < 0 || sRow >= matrixRows || sCol < 0 || sCol >= matrixCols) {
            result = 'successed with ' + currentResult;
            return;
        }

        if (numberMatrix[sRow][sCol] === -1) {
            result = 'failed at (' + sRow + ', ' + sCol + ')';
            return;
        }

        numberOfCells++;
        currentResult += numberMatrix[sRow][sCol];
        numberMatrix[sRow][sCol] = -1;

        if (directionsMatrix[sRow][sCol] === 'dr') {
            move(sRow + 1, sCol + 1);
        } else if (directionsMatrix[sRow][sCol] === 'ur') {
            move(sRow - 1, sCol + 1);
        } else if (directionsMatrix[sRow][sCol] === 'ul') {
            move(sRow - 1, sCol - 1);
        } else if (directionsMatrix[sRow][sCol] === 'dl') {
            move(sRow + 1, sCol - 1);
        }
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
                inputNumber++;
            }

        }

        return resultMatrix;
    }

    function makeDirectionMatrix(params) {
        var resultMatrix = new Array(matrixRows);

        for (var i = 1; i < params.length; i += 1) {
            resultMatrix[i - 1] = params[i].split(' ');
        }

        return resultMatrix;
    }

    move(startRow, startCol);
    return result;
}

var args1 = [
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'   
];


var args2 = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'
]


console.log(Solve(args1));
console.log(Solve(args2));



//var powerSet = function (arr) {

//    // the power set of [] is [[]]
//    if (arr.length === 0) {
//        return [[]];
//    }

//    // remove and remember the last element of the array
//    var lastElement = arr.pop();

//    // take the powerset of the rest of the array
//    var restPowerset = powerSet(arr);


//    // for each set in the power set of arr minus its last element,
//    // include that set in the powerset of arr both with and without
//    // the last element of arr
//    var powerset = [];
//    for (var i = 0; i < restPowerset.length; i++) {

//        var set = restPowerset[i];

//        // without last element
//        powerset.push(set);

//        // with last element
//        set = set.slice(); // create a new array that's a copy of set
//        set.push(lastElement);
//        powerset.push(set);
//    }

//    return powerset;
//};

//var subsetsLessThan = function (arr, number) {

//    // all subsets of arr
//    var powerset = powerSet(arr);

//    // subsets summing less than or equal to number
//    var subsets = [];

//    for (var i = 0; i < powerset.length; i++) {

//        var subset = powerset[i];

//        var sum = 0;
//        for (var j = 0; j < subset.length; j++) {
//            sum += subset[j];
//        }

//        if (sum === number) {
//            subsets.push()
//            count++;
//        }
//    }

//    return;
//};

//subsetsLessThan(vehicles, S);
//return count;