function createPerson(fname,lname,personAge) {
    return {
        fName: fname,
        lName: lname,
        age: personAge,
        toString: function () {
            return (this.fName + " " + this.lName + " - " + this.age);
        }
    }
}

function findYoungestPerson(personsArray) {
    var minAge = 1000;
        personsCount = personsArray.length;
        result = personsArray[0];

    for (var i = 0; i < personsCount; i++) {
        var singlePerson = personsArray[i];
        
        if (singlePerson.age < minAge) {
            minAge = singlePerson.age;
            result = singlePerson;
        }
    }

    return result;
}

var person1 = createPerson("Ivan", "Ivanov", 35);
    person2 = createPerson("Pesho", "Ivanov", 13);
    person3 = createPerson("Mitko", "Petrov", 22);
    person4 = createPerson("Batkata", "Kacov", 65);
    person5 = createPerson("Maria", "Kacarova", 43);
    person6 = createPerson("Penka", "Petrova", 58);
    person7 = createPerson("Slavenka", "Ivanova", 21);
    persons = [person1, person2, person3, person4, person5, person6, person7];

    youngestPerson = findYoungestPerson(persons);
    console.log(youngestPerson.toString());
