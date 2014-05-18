function DeepCopy(obj) {
    var result = {};

    if ((typeof (obj) === 'string') || (typeof (obj) === 'number') || (typeof (obj) === 'boolean')) return obj;

    for (var prop in obj) result[prop] = obj[prop];

    return result;
}

function GenerateList(template, people) {
    var templateCopy = DeepCopy(template);
        liArray = [];

    for (var person in people) {
        var indexName = templateCopy.indexOf("{name}");
            indexAge = templateCopy.indexOf("{age}");

        template = templateCopy.replace("{name}", people[person].name);
        liArray.push(template.substr(indexName, people[person].name.length));

        template = templateCopy.replace("{age}", people[person].age);
        liArray.push(template.substr(indexAge, people[person].age.toString().length));
    }
    return liArray;
}

(function CreateUL()
{
    var people = [{ name: "gosho", age: 13 }, { name: "pesho", age: 29 }, { name: "bat sali", age: 30 }];
        template = document.getElementById("list-item").innerHTML;
        peopleList = GenerateList(template, people);

    for (var i = 0; i < peopleList.length; i += 2) {
        jsConsole.writeLine("<ul><li><strong>" + peopleList[i] + "</strong><span>" + peopleList[i + 1] + "</span></li><li>…</li>…</ul>")
    }
})()