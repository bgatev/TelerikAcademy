var frame = 1;
var startX = 100;
var startY = 100;
var radius = 100;

function createDiv(count) {
    var docFragment = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var currentDiv = document.createElement('div');
        currentDiv.style.width = '40px';
        currentDiv.style.height = '40px';
        currentDiv.id = 'Div ' + (i + 1);
        currentDiv.innerHTML = 'Div ' + (i + 1);
        currentDiv.style.border = '1px solid black';

        var x = startX + radius * Math.cos(2 * Math.PI * i / count);
        var y = startY + radius * Math.sin(2 * Math.PI * i / count);

        currentDiv.style.left = x + 'px';
        currentDiv.style.top = y + 'px';
        currentDiv.style.position = 'absolute';

        docFragment.appendChild(currentDiv);
    }

    document.body.appendChild(docFragment);
};

function moveDiv(frame, movedDiv, start) {
    frame+=0.5;

    var x = startX + radius * Math.cos(frame + start);
    var y = startY + radius * Math.sin(frame + start);

    movedDiv.style.top = y + 'px';
    movedDiv.style.left = x + 'px';

    setTimeout(function () {moveDiv(frame, movedDiv, start); }, 100);
}

function animateDiv(count) {

    for (var i = 0; i < count; i++) {
        var div = document.getElementById('Div ' + (i + 1));
        moveDiv(1, div, i);
    }
}