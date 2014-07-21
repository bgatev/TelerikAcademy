/// <reference path="underscore.js" />

var Human = (function () {
    function Human(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    return Human;
})();

var pesho = new Human("Pesho", "Qkimov");
var peshkata = new Human("Pesho", "Ivanov");
var petar = new Human("Pesho", "Golemiq");
var gosho = new Human("Gosho", "Ivanov");
var minka = new Human("Minka", "Gaidarova");
var fi4kata = new Human("Ivan", "Cyncarov");
var geleto = new Human("Gele", "Angelov");

var people = [];

people.push(pesho);
people.push(peshkata);
people.push(gosho);
people.push(minka);
people.push(fi4kata);
people.push(geleto);
people.push(petar);

function getMostCommonName(peoples, nameParam) {
    return _.chain(peoples)
            .groupBy(nameParam)
            .max(function (name) {
                return name.length;
            })
            .pluck(nameParam)
            .countBy()
            .value();
}

var mostCommonFirstName = getMostCommonName(people, 'firstName');
var mostCommonLastName = getMostCommonName(people, 'lastName');

function printKeyValuePair(object, description) {
    if (!(object instanceof Object)) {
        object = {};
        console.log(description + " -> EMPTY OBJECT");
    }
    else {
        Object.keys(object).forEach(function (key) {
            console.log(description + Object.keys(object)[0] + " -> " + object[key]);
        });
    }
}

printKeyValuePair(mostCommonFirstName, "Most Common First Name: ");
printKeyValuePair(mostCommonLastName, "Most Common Last Name: ");
