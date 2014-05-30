//Write a function that formats a string using placeholders:
(function () {
    function stringFormat() {
        var stringToBeFormated = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var currentPlaceHolder = "{" + (i-1) + "}";
            if (stringToBeFormated.indexOf(currentPlaceHolder) !== -1) {
                stringToBeFormated = stringToBeFormated.split(currentPlaceHolder).join(arguments[i]);
            }
        }
        return stringToBeFormated;
    }

    var format = "{0}, {1}, {0} text {2}";
    var str = stringFormat(format, 1, "Pesho", "Gosho");
})();