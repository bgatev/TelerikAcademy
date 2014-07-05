var movingShapes = (function () {
    var frame = 1;
    var startX = 100;
    var startY = 100;
    var radius = 100;
    var divCount = 0;

    function random(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function randomColor() {
        var r = random(0, 255);
        var g = random(0, 255);
        var b = random(0, 255);

        return ("rgb(" + r + "," + g + "," + b + ")")
    }

    function rectMove(frame, movedDiv, start) {
        frame += 0.5;

        var x = startX + radius * Math.cos(frame + start);
        var y = startY + radius * Math.sin(frame + start);

        movedDiv.style.top = y + 'px';
        movedDiv.style.left = x + 'px';

        setTimeout(function () { rectMove(frame, movedDiv, start); }, 100);
    }

    function elipseMove(frame, movedDiv, start) {
        frame += 0.5;

        var x = startX + radius * Math.cos(frame + start);
        var y = startY + radius * Math.sin(frame + start);

        movedDiv.style.top = y + 'px';
        movedDiv.style.left = x + 'px';

        setTimeout(function () { elipseMove(frame, movedDiv, start); }, 100);
    }

    function addMovingDiv(movingType) {
        var docFragment = document.createDocumentFragment();
        divCount++;

        for (var i = 0; i < divCount; i++) {
            var currentDiv = document.createElement('div');
            currentDiv.style.width = '40px';
            currentDiv.style.height = '40px';
            currentDiv.id = 'Div ' + (i + 1);
            currentDiv.innerHTML = 'Div ' + (i + 1);
            currentDiv.style.border = '2px solid ' + randomColor();
            currentDiv.style.backgroundColor = randomColor();

            var x = startX + radius * Math.cos(2 * Math.PI * i / divCount);
            var y = startY + radius * Math.sin(2 * Math.PI * i / divCount);

            currentDiv.style.left = x + 'px';
            currentDiv.style.top = y + 'px';
            currentDiv.style.position = 'absolute';

            docFragment.appendChild(currentDiv);
        }

        document.body.appendChild(docFragment);

        for (var i = 0; i < divCount; i++) {
            var div = document.getElementById('Div ' + (i + 1));

            if (movingType == "rect") rectMove(1, div, i);
            else elipseMove(1, div, i);
        }
    }

    return {
        add: addMovingDiv
    };
})();
