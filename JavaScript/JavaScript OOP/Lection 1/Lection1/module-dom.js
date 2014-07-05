var domModule = (function () {
    var elements = [];

    function appendChild(elementToAdd, selector) {
        var parent = document.querySelector(selector);

        parent.appendChild(elementToAdd);
    }

    function removeChild(parentElement, selector) {
        var parent = document.querySelector(parentElement);
        var child = document.querySelector(selector);

        parent.removeChild(child);
    }

    function addHandler(selector, eventType, eventHandler) {
        var element = document.querySelector(selector);

        element.addEventListener(eventType, eventHandler);
    }

    function appendToBuffer(selector, elementToAdd) {
        if (elements[selector] === undefined) {
            elements[selector] = new Array();
        }

        elements[selector].push(elementToAdd);
        
        if (elements[selector].length == 100) {
            var parent = document.querySelector(selector).parentNode;
            var allElementsToAdd = elements[selector];

            for (var i = 0; i < 100; i++) {
                allElementsToAdd[i].innerHTML += " " + (i + 1);
                parent.appendChild(allElementsToAdd[i]);
            }

            elements[selector] = undefined;
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };
})();
