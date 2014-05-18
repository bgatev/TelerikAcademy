function buildStringBuilder() {
    return {
        strs: [],
        len: 0,
        append: function (str) {
            this.strs[this.len++] = str;
            return this;
        },
        toString: function () {
            return this.strs.join("");
        }
    };
}

function StringFormat() {
    var output = arguments[0];

    for (var i = 1; i < arguments.length; i++)
        output = output.replace(new RegExp('\\{' + (i - 1) + '\\}', "g"), arguments[i]);

    return output;
}

var format = "My string is like this: {0}, {1}, {0} then {2}";

console.log(StringFormat(format, 1, "Pesho", "Gosho"));
