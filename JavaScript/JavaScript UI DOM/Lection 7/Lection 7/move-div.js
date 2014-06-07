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

        currentDiv.style.position = 'absolute';

        docFragment.appendChild(currentDiv);
    }

    document.body.appendChild(docFragment);
};

function moveDiv(count, framesNumber) {
    //document.body.innerHTML = '';

    var dAngle = (2 + framesNumber / count) * Math.PI / 180;

    for (var i = 0; i < count; i++) {
        var currentDiv = document.getElementById('Div ' + (i + 1));
        console.log(currentDiv.innerHTML);
        var angle = i * dAngle;
        var x = startX + radius * Math.cos(angle);
        var y = startY + radius * Math.sin(angle);

        currentDiv.style.top = x + 'px';
        currentDiv.style.left = y + 'px';
    }
    frame++;
}

function animateDiv(count) {
    moveDiv(count, frame);
    setTimeout(animateDiv(count), 100);
    if (frame > 10) return;
}