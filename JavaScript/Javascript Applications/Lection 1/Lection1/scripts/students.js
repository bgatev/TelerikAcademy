/// <reference path="underscore.js" />

var Student = (function () {
    function Student(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    return Student;
})();

var pesho = new Student("Pesho", "Qkimov");
var gosho = new Student("Gosho", "Ivanov");
var minka = new Student("Minka", "Gaidarova");
var fi4kata = new Student("Ivan", "Cyncarov");
var geleto = new Student("Gele", "Angelov");

var students = [];

students.push(pesho);
students.push(gosho);
students.push(minka);
students.push(fi4kata);
students.push(geleto);

function isFNameBeforeLName(students) {   
    return students.firstName.localeCompare(students.lastName) < 1 ? true : false;
}

var sortedByFullName = _.chain(students).filter(isFNameBeforeLName)
                        .sortBy(function (currentStudent) {
                            var fullName = currentStudent.firstName + ' ' + currentStudent.lastName;

                            return -fullName;
                        })
                        .value();
