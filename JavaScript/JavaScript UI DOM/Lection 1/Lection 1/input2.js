function getInput() {
    var input = document.getElementsByTagName('input');

    console.log(input[0].value);

    return input[0].value;
}

function setColor() {
    document.body.style.backgroundColor = getInput();
}