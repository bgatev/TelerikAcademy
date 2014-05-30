function createPerson(fname, lname, personAge) {
    return {
        fName: fname,
        lName: lname,
        age: personAge,
        toString: function () {
            return (this.fName + " " + this.lName + " - " + this.age);
        }
    }
}

function groupPersons(personsArray,criteria) {
    var result = {};

    personsArray.map(function (prop) {
        if (!result[prop[criteria]]) result[prop[criteria]] = new Array();
        result[prop[criteria]].push(prop);
    });

    return result;
}

var person1 = createPerson("Ivan", "Ivanov", 35);
    person2 = createPerson("Pesho", "Ivanov", 13);
    person3 = createPerson("Ivan", "Petrov", 22);
    person4 = createPerson("Ivan", "Kacov", 65);
    person5 = createPerson("Maria", "Kacarova", 43);
    person6 = createPerson("Koicho", "Ivanov", 58);
    person7 = createPerson("Slavenka", "Ivanova", 22);
    persons = [person1, person2, person3, person4, person5, person6, person7];

    groupedByFName = groupPersons(persons, "fName");
    groupedByLName = groupPersons(persons, "lName");
    groupedByAge = groupPersons(persons, "age");

    for (var singlePerson in groupedByFName) {
        console.log(singlePerson + ": " + groupedByFName[singlePerson]);
    }

    for (var singlePerson in groupedByLName) {
        console.log(singlePerson + ": " + groupedByLName[singlePerson]);
    }

    for (var singlePerson in groupedByAge) {
        console.log(singlePerson + ": " + groupedByAge[singlePerson]);
    }
