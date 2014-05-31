﻿(function () {
    //Init canvas
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    var w = 450;
    var h = 450;
    var cellWidth = 10;
    var cellSpacing = 11;
    canvas.style.width = w + 'px';
    canvas.style.height = h + 'px';
    var direction;
    var isDead = false;
    var snakeArr = [];
    var mainColor = 'white';
    var foodElement = {};
    var scoreHolder = document.getElementById('score');
    var score = scoreHolder.innerHTML | 0;

    function createSnake() {
        var length = 5;
        snakeArr = [];
        for (var i = length - 1; i >= 0; i--) snakeArr.push({ x: i, y: 0 });
    }

    function createFood() {
        foodElement = {
            x: Math.floor(Math.random() * (w - w / cellWidth) / cellWidth),
            y: Math.floor(Math.random() * (h - w / cellWidth) / cellWidth),
            type: 'regular'
        }
    }

    function Draw() {

        ctx.fillStyle = 'black';
        ctx.fillRect(0, 0, w, h);
        ctx.strokeStyle = mainColor;
        ctx.strokeRect(0, 0, w, h);

        document.onkeydown = function () {
            switch (window.event.keyCode) {
                case 37: if (direction != 'right') direction = 'left';
                    break;
                case 38: if (direction != 'down') direction = 'up';
                    break;
                case 39: if (direction != 'left') direction = 'right';
                    break;
                case 40: if (direction != 'up') direction = 'down';
                    break;
            }
        }

        var newHeadX = snakeArr[0].x;
        var newHeadY = snakeArr[0].y;

        switch (direction) {
            case 'right': newHeadX++;
                break;
            case 'down': newHeadY++;
                break;
            case 'left': newHeadX--;
                break;
            case 'up': newHeadY--;
                break;
        }

        if (newHeadX > w / cellSpacing || newHeadX == -1 || newHeadY == -1 || newHeadY > h / cellSpacing) {
            init();
            return;
        }

        for (var i = 1; i < snakeArr.length; i++) {
            if (snakeArr[i].x == newHeadX && snakeArr[i].y == newHeadY) {
                init();
                return;
            }
        }

        if (newHeadX == foodElement.x && newHeadY == foodElement.y) {
            score++;
            scoreHolder.innerHTML = score;
            createFood();
            drawCell(foodElement.x, foodElement.y);

            snakeArr.push({ x: foodElement.x, y: foodElement.y });
        }

        var tail = snakeArr.pop();
        tail.x = newHeadX;
        tail.y = newHeadY;
        snakeArr.unshift(tail);

        for (var i = 0; i < snakeArr.length; i++) {
            var bodyElement = snakeArr[i];
            drawCell(bodyElement.x, bodyElement.y);
        }

        drawCell(foodElement.x, foodElement.y);

    }

    function drawCell(x, y) {
        ctx.fillStyle = mainColor;
        ctx.fillRect(x * cellSpacing, y * cellSpacing, cellWidth, cellWidth);
    }

    function init() {
        ctx.strokeStyle = 'white';
        ctx.strokeRect(0, 0, w, h);
        score = 0;
        scoreHolder.innerHTML = score;
        direction = 'right';
        createFood();
        createSnake();
        if (typeof gameLoop != 'undefined') clearInterval(gameLoop);
        gameLoop = setInterval(Draw, 80);
    }
    init();
}())