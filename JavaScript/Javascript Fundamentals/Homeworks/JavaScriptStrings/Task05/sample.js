//Write a function that replaces non breaking white-spaces in a text with &nbsp;
(function () {
    var input = prompt("Enter some text");
    var newString = input.replace(/ /g, "&nbps;");
    alert("The new text is: " + newString);
})();