/// <reference path="D:\BGatev\Personal\JavaScript\Javascript Applications\Lection 2\Lection 2\jquery-1.11.1.js" />

var numberToGuess = getRandomNumber();
var numberOfTries = 0;
var success = false;
console.log(numberToGuess);

function onBtnClick() {
    playBullsAndCows();

    if (success) {
        alert("Well Done - That's the Number");
        highScoreTableUpdate();
    }
}

function highScoreTableUpdate() {
    if ($('#inputName').length == 0) {
        var $body = $('body');
        var $inputNameTB = $('<input type="text" placeholder="Input Your Name" id="inputName" />');
        var $inputNameBtn = $('<button onclick="onSaveBtnClick()">Save</button>');
        
        $body.append($inputNameTB);
        $body.append($inputNameBtn);
    }    
}

function onSaveBtnClick() {
    var playerName = $('#inputName').val();
    var localStorageRecord = [];

    if (localStorage.getItem('players') !== null) localStorageRecord = JSON.parse(localStorage.getItem('players'));

    localStorageRecord.push({
        player: playerName,
        score: numberOfTries
    });

    savetoLocalStorage(JSON.stringify(localStorageRecord));
}

function onShowHighScoreBtnClick() {
    if ($('#highScore').length == 0) {
        var $body = $('body');
        var $highScore = $('<textarea id="highScore"></textarea>');
        var highScoreTable = loadFromLocalStorage();

        $highScore.text(highScoreTable);
        $body.append($highScore);
    }
}

function playBullsAndCows() {
    numberOfTries++;

    var guess = getGuess();
    if (guess == 0) return;

    var census = countBovine(guess);

    console.log('    Bulls: ' + census.bulls + ', cows: ' + census.cows);

    if (census.bulls == 4) success = true;
}

function getRandomNumber() {
    var nums = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    nums.sort(function () { return Math.random() - 0.5 });

    return nums.slice(0, 4);
}

function getGuess() {
    var guess = $('#inNumber').val();

    guess = String(parseInt(guess)).split('');

    if (guess.length != 4) {
        console.log('  You must enter a four digit number.');
        return 0;
    }

    if (hasDups(guess)) {
        console.log('  No digits can be duplicated.');
        return 0;
    }

    console.log('Your guess #' + numberOfTries + ': ');

    return guess;
}

function hasDups(array) {
    var t = array.concat().sort();

    for (var i = 1; i < t.length; i++) {
        if (t[i] == t[i - 1]) return true;
    }

    return false;
}

function countBovine(guess) {
    var count = { bulls: 0, cows: 0 };
    var g = guess.join('');

    for (var i = 0; i < 4; i++) {
        var digPresent = g.search(numberToGuess[i]) != -1;

        if (numberToGuess[i] == guess[i]) count.bulls++;
        else if (digPresent) count.cows++;
    }

    return count;
}

function savetoLocalStorage(data) {
    if (localStorage['players'] == undefined) localStorage['players'] = [];
    localStorage['players'] = data;
}

function loadFromLocalStorage() {
    var storagePlayers = JSON.parse(localStorage.getItem('players'));
    var result = '';

    storagePlayers.sort(dynamicSort("score"));

    for (var i = 0, len = storagePlayers.length; i < len; i++) {
        result += storagePlayers[i].player + ' -> ' + storagePlayers[i].score + ' tries\n';
    }

    return result;
}

function onClearLocalStorage() {
    localStorage.clear();
}

function dynamicSort(property) {
    var sortOrder = 1;

    if (property[0] === "-") {
        sortOrder = -1;
        property = property.substr(1);
    }

    return function (a, b) {
        var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
        return result * sortOrder;
    }
}