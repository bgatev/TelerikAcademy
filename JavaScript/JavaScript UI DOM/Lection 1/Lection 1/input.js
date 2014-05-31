function getInput() {
    var input = document.getElementsByTagName('input');

    for (var i = 0, len = input.length; i < len; i++) console.log(input[i].value);
}