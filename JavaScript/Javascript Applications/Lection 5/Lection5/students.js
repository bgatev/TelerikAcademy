(function () {
    require.config({
        paths: {
            'requestModule': 'get_post',
            'q': 'q',
        }
    });

    require(['get_post', 'q'], function (get_post) {

        var url = 'http://localhost:3000/students';
        var headerOptions = {
            contentType: 'application/json',
            accept: 'application/json'
        };

        var notificationArea = document.getElementById('alerts');

        function removeChildNodes(parentNode) {
            while (parentNode.firstChild) {
                parentNode.removeChild(parentNode.firstChild);
            }
        }

        function addStudent() {
            var addStudentBtn = document.getElementById('addStudentBtn');

            addStudentBtn.addEventListener('click', function () {
                var student = {
                    name: "Pesho " + Math.floor((Math.random() * 10) + 1),
                    grade: Math.floor((Math.random() * 5) + 0.5)
                };

                notificationArea.innerHTML = '... processing request ...';
                get_post.postJSON(url, student, headerOptions)
                    .then(function () {
                        notificationArea.innerHTML = '<span style="color: green">Student Successfully added to the server database!</span>';
                    }, function () {
                        notificationArea.innerHTML = 'Error: Please start the nodeJS Server';
                    });
            })
        }

        function deleteStudent() {
            var deleteStudentBtn = document.getElementById('deleteStudentBtn');

            deleteStudentBtn.addEventListener('click', function () {
                var idToRemove = document.getElementById('idToRemove').value;

                notificationArea.innerHTML = '... processing request ...';
                get_post.deleteJSON(url, idToRemove)
                    .then(function (data) {
                        console.log(data);
                        notificationArea.innerHTML = data.message + ' <span style="color: green">Student Successfully removed from the server database!</span>';
                    }, function () {
                        notificationArea.innerHTML = 'Error: Please start the nodeJS Server';
                    });
                getAllStudents();
            })
        }

        function getAllStudents() {
            var getAllStudentsBtn = document.getElementById('getAllStudentsBtn');
            var studentsList = document.getElementById('studentsList');
            var fragment = document.createDocumentFragment();
            var studentLiElementTemplate = document.createElement('li');

            getAllStudentsBtn.addEventListener('click', function () {
                notificationArea.innerHTML = '... processing request ...';
                removeChildNodes(studentsList);
                get_post.getJSON(url, headerOptions)
                    .then(function (data) {
                        var parsedData = JSON.parse(data);
                        
                        for (var i = 0, len = parsedData.count; i < len; i++) {
                            var currentStudentElement = studentLiElementTemplate.cloneNode(true);

                            currentStudentElement.innerHTML =
                                parsedData.students[i].id + ': ' +
                                parsedData.students[i].name + ' - grade: ' +
                                parsedData.students[i].grade;
                            fragment.appendChild(currentStudentElement);
                        }
                        studentsList.appendChild(fragment);
                    })
                    .then(function () {
                        notificationArea.innerHTML = '';
                    }, function () {
                        notificationArea.innerHTML = 'Error: Please start the nodeJS Server';
                    })
            });
        }

        addStudent();
        deleteStudent();
        getAllStudents();

    })
}());