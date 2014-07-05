var specialConsole = (function () {

    function toString() {
        var args = arguments;
        var text = args[0];
        var valuesArray = Array.prototype.slice.call(arguments, 1);
        return text.replace(/{(\d+)}/g, function (match, number) {
            return typeof valuesArray[number] != 'undefined' ? valuesArray[number] : match;
        });
    }

    function writeLine() {
        console.log(toString.apply(null, arguments));
    }
    function writeError() {
        console.error(toString.apply(null, arguments));
    }
    function writeWarning() {
        console.warn(toString.apply(null, arguments));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();
