function generateTagCloud(tags, minFontSize, maxFontSize){
    var hashTable = {};
    var containerWidth = 300;
    var containerHeight = 300;

    for (var i = 0, len = tags.length; i < len; i++) {
        var currentTag = tags[i];

        if (hashTable[currentTag]) {
            var currentCount = hashTable[currentTag];
            hashTable[currentTag] = currentCount + 1;
            currentCount = 1;
        }
        else hashTable[currentTag] = 1;  
    }

    var divContainer = document.getElementById('container');
    divContainer.style.width = containerWidth + 'px';
    divContainer.style.height = containerHeight + 'px';
    divContainer.style.position = 'absolute';
    divContainer.style.top = '0px';
    divContainer.style.left = '0px';

    var hashTableLength = Object.keys(hashTable).length;
    
    var docFragment = document.createDocumentFragment();
    var maxRepeatedCount = maxRepeated(hashTable);

    for (var currentTag in hashTable) {
        var currentDiv = document.createElement('div');
        currentDiv.style.width = random(20, 100) + 'px';
        currentDiv.style.height = random(20, 100) + 'px';

        currentDiv.style.position = 'absolute';
        currentDiv.style.top = random(0, containerHeight) + 'px';
        currentDiv.style.left = random(0, containerWidth) + 'px';

        var percentageFontSize = Math.floor(hashTable[currentTag] / maxRepeatedCount * (maxFontSize - minFontSize)) + minFontSize;
        currentDiv.style.fontSize = percentageFontSize + 'px';

        currentDiv.innerHTML = currentTag;

        docFragment.appendChild(currentDiv);
    }

    document.body.appendChild(docFragment);
}

function random(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function maxRepeated(divs) {
    var max = 1;

    for (var currentTag in divs) {
        if (divs[currentTag] > max) max = divs[currentTag];
    }

    return max;
}