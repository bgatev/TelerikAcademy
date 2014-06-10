var newItem = document.getElementById('newItem');
var addItemBtn = document.getElementById('addItem');
var showListBtn = document.getElementById('showList');
var hideListBtn = document.getElementById('hideList');
var allTasks = document.getElementById('allTasks');

addItemBtn.addEventListener('click', addItem);

hideListBtn.addEventListener('click', function () {
    allTasks.style.display = 'none';
});

showListBtn.addEventListener('click', function () {
    allTasks.style.display = 'block';
});

function addItem() {
    if (newItem.value) {
        var currentLI = document.createElement('li');
        var currentP = document.createElement('p');
        var removeItemBtn = document.createElement('button');

        removeItemBtn.innerHTML = 'X';
        removeItemBtn.id = 'removeItem';
        removeItemBtn.type = 'button';
        removeItemBtn.addEventListener('click', function () {
            allTasks.removeChild(this.parentNode);
        });

        var newItemText = document.createTextNode(newItem.value);

        currentP.appendChild(newItemText);
        currentLI.appendChild(currentP);
        currentLI.appendChild(removeItemBtn);
        allTasks.appendChild(currentLI);
    }
}

