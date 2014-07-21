/// <reference path="underscore.js" />
for (var i = 0, len = students.length; i < len; i++) {
    _.extend(students[i], { age: i + 18 });
    _.extend(students[i], { mark: i + 2 });
}

function isAgeBetween18And24(students) {
    return (students.age >= 18 && students.age <= 24);
}

var studentsBetween18And24 = _.chain(students)
                            .filter(isAgeBetween18And24)
                            .map(function (currentStudent) {
                                return {
                                    firstName: currentStudent.firstName,
                                    lastName: currentStudent.lastName
                                };
                            })
                            .value();

var studentWithHighestMarks = _.max(students, function (currentStudent) {
    return currentStudent.mark;
});