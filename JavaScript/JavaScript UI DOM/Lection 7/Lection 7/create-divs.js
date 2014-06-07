function createDivs(count) {
    var docFragment = document.createDocumentFragment();
    var strongElement = document.createElement('strong');

    for (var i = 0; i < count; i++) {
        var currentDiv = document.createElement('div');
        currentDiv.style.width = random(20, 100) + 'px';
        currentDiv.style.height = random(20, 100) + 'px';
        currentDiv.style.backgroundColor = randomColor();
        currentDiv.style.color = randomColor();
        
		currentDiv.style.position = 'absolute';
		currentDiv.style.top = random(0, 620) + 'px';
		currentDiv.style.left = random(0, 924) + 'px';
		
        strongElement.innerHTML = 'Div ' + (i + 1);
        currentDiv.appendChild(strongElement.cloneNode(true));

        currentDiv.style.borderRadius = random(5, 20) + 'px';
		currentDiv.style.border = random(1, 20) + 'px solid ' + randomColor();

        docFragment.appendChild(currentDiv);
    }

    document.body.appendChild(docFragment);

    function random(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function randomColor() {
        var r = random(0, 255);
        var g = random(0, 255);
        var b = random(0, 255);

        return ("rgb(" + r + "," + g + "," + b + ")")
    }
};