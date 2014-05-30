//Write a function that creates a HTML UL using a template for every HTML LI. 
//The source of the list should an array of elements. Replace all placeholders 
//marked with –{…}–   with the value of the corresponding property of the object. 
(function () {
    function generateList(objects, temp) {
        var template = temp.trim();

        var nameTemplate = "-{name}-";
        var ageTemplate = "-{age}-";
        var ulOpenTag = "<ul>";
        var ulCloseTag = "</ul>";
        var liOpenTag = "<li>";
        var liCloseTag = "</li>";

        var generatedList = [ulOpenTag];

        for (var i = 0; i < objects.length; i++) {
            generatedList.push(liOpenTag);
            var currentObject = objects[i];

            if (currentObject.hasOwnProperty("name") && currentObject.hasOwnProperty("age")) {
                var element = template.replace(nameTemplate, currentObject.name)
                    .replace(ageTemplate, currentObject.age);
                generatedList.push(element);
            }

            generatedList.push(liCloseTag);
        }
        generatedList.push(ulCloseTag);

        return generatedList.join("");
    }


    var people = [{
        name: "Peter", age: 14
    }, {
        name: "Sasha", age: 22
    }, {
        name: "Galya", age: 19
    }];

    var tmpl = document.getElementById("list-item").innerHTML;
    var peopleList = generateList(people, tmpl);
    document.getElementById("list-item").innerHTML = peopleList;
})();