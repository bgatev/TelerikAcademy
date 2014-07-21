/// <reference path="underscore.js" />
var Animal = (function () {
    function Animal(kind, numberOfLegs) {
        this.kind = kind;
        this.numberOfLegs = numberOfLegs;
    }
    return Animal;
})();

var monkey1 = new Animal("mammal", 6);
var monkey2 = new Animal("mammal", 2);
var monkey3 = new Animal("mammal", 8);
var monkey4 = new Animal("mammal", 6);
var cat = new Animal("mammal", 4);
var duck1 = new Animal("bird", 4);
var duck2 = new Animal("bird", 100);
var duck3 = new Animal("bird", 4);
var trout = new Animal("fish", 2);
var peacock = new Animal("mammal", 2);

var animals = [];

animals.push(monkey1);
animals.push(monkey2);
animals.push(monkey3);
animals.push(monkey4);
animals.push(cat);
animals.push(duck1);
animals.push(duck2);
animals.push(duck3);
animals.push(trout);
animals.push(peacock);

var groupedBySpeciesSortByNumberOfLegs = _.chain(animals)
                                        .groupBy('kind')
                                        .each(function (value, key, animals) {
                                            animals[key] = _.sortBy(value, 'numberOfLegs');
                                        })
                                        .value();

var totalNumberOfLegs = (function () {
    var totalLegs = 0;

    for (var i = 0, len = animals.length; i < len; i++) {
        totalLegs += parseInt(animals[i].numberOfLegs);
    }

    return totalLegs;
})();