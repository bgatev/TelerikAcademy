function createTreeView(numberOfNodes) {
    var list = createList(numberOfNodes);

    addNestedList(list);
}

function createList(liCount, liText, isSubItem) {
    var container = document.getElementById('wrapper');
    var list = document.createElement('ul');

    liText = liText || "Item";

    for (var i = 0; i < liCount; i++) {
        var currentLI = createListItem(liText);

        list.appendChild(currentLI);
    }

    if (isSubItem) list.style.display = 'none';

    container.appendChild(list);

    return list;
}

function createListItem(liText) {
    var anchor = document.createElement('a');

    anchor.expanded = false;
    anchor.innerHTML = liText;

    anchor.onclick = function() {
        var children = anchor.nextElementSibling;

        if (children) children.style.display = this.expanded ? 'none' : 'block';

        this.expanded = !this.expanded;
    };

    var currentLI = document.createElement('li');
    currentLI.appendChild(anchor);

    return currentLI;
}

function addNestedList(list) {
    list.firstChild.appendChild(createList(1, "Sub item", true));
    list.firstChild.lastChild.lastChild.appendChild(createList(2, "Sub item", true));
    list.firstChild.lastChild.lastChild.lastChild.lastChild.appendChild(createList(3, "Sub item", true));
    list.firstChild.lastChild.lastChild.lastChild.lastChild.lastChild.lastChild.appendChild(createList(3, "Sub item", true));

    list.firstChild.nextElementSibling.appendChild(createList(2, "Sub item", true));
    list.firstChild.nextElementSibling.lastChild.firstChild.appendChild(createList(2, "Sub item", true));
    list.firstChild.nextElementSibling.lastChild.lastChild.appendChild(createList(2, "Sub item", true));
}