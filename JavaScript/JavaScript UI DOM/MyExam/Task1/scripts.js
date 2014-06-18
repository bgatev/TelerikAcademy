function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);

    var currentDiv = createImage(items[0],'500px', '30px');
    currentDiv.className = 'selected';
    currentDiv.style.position = 'absolute';
    currentDiv.style.top = '100px';
    currentDiv.style.left = '100px';

    container.appendChild(currentDiv);
    
    var sidebarDiv = createSideBar(items);
    sidebarDiv.style.position = 'absolute';
    sidebarDiv.style.top = '100px';
    sidebarDiv.style.left = '800px';

    container.appendChild(sidebarDiv);
}

function createSideBar(items) {
    var sideDiv = document.createElement('div');
    var sideScrollDiv = document.createElement('div');
    var inputBoxTitle = document.createElement('strong');
    var inputBox = document.createElement('input');

    inputBoxTitle.innerHTML = 'Filter';
    inputBoxTitle.style.width = '200px';
    inputBoxTitle.style.display = 'block';
    inputBoxTitle.style.textAlign = 'center';
    inputBoxTitle.style.fontSize = '18px';

    inputBox.setAttribute("type", "text");
    inputBox.style.width = '200px';
    
    sideScrollDiv.style.overflowY = 'scroll';
    sideScrollDiv.style.height = '500px';

    sideDiv.appendChild(inputBoxTitle);
    sideDiv.appendChild(inputBox);

    for (var i = 0, len = items.length; i < len; i++) {
        var currentSideDiv = createImage(items[i], '200px', '18px');

        currentSideDiv.addEventListener('click', onDivClick);
        currentSideDiv.addEventListener('mouseover', onDivMouseover);
        currentSideDiv.addEventListener('mouseout', onDivMouseout);

        sideScrollDiv.appendChild(currentSideDiv);
    }  

    inputBox.addEventListener('change', function () {
        var filter = this.value.toLowerCase();
        sideScrollDiv.innerHTML = '';

        for (var i = 0, len = items.length; i < len; i++) {
            var filteredTitle = items[i].title.toLowerCase();

            if (filteredTitle.contains(filter)) {
                var currentSideDiv = createImage(items[i], '200px', '18px');

                currentSideDiv.addEventListener('click', onDivClick);
                currentSideDiv.addEventListener('mouseover', onDivMouseover);
                currentSideDiv.addEventListener('mouseout', onDivMouseout);

                sideScrollDiv.appendChild(currentSideDiv);
            }
        }
    });

    sideDiv.appendChild(sideScrollDiv);


    return sideDiv;
}

function createImage(item, width, titleFontSize) {
    var divElement = document.createElement('div');
    var strongElement = document.createElement('strong');
    var imageElement = document.createElement('img');

    strongElement.innerHTML = item.title;
    imageElement.setAttribute("src", item.url);
    
    strongElement.style.display = 'block';
    strongElement.style.width = width;
    strongElement.style.textAlign = 'center';
    strongElement.style.fontSize = titleFontSize;
    imageElement.style.borderRadius = '20px';
    imageElement.style.width = width;

    divElement.appendChild(strongElement);
    divElement.appendChild(imageElement);

    return divElement;
}

function onDivMouseover(ev) {
    this.style.background = 'grey';
}

function onDivMouseout(ev) {
    this.style.background = '';
}

function onDivClick(ev) {
    var imageTitleToShow = this.children[0].innerHTML;
    var imageToShow = this.children[1].getAttribute("src");

    var selectedImage = document.querySelector('.selected');
    var destTitle = selectedImage.children[0];
    var destImg = selectedImage.children[1];

    destTitle.innerHTML = imageTitleToShow;
    destImg.setAttribute("src", imageToShow);
}
