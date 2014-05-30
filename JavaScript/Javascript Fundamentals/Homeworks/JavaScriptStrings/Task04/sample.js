//You are given a text. Write a function that changes the text in all regions:
(function () {
    var mainText = "";
    var editedText = "";
    var upCase = "upcase";
    var lowCase = "lowcase";
    var mixCase = "mixcase";

    function toUpCase(val) {
        var text = val.text;
        editedText += text.toUpperCase();
    }

    function toLowCase(val) {
        var text = val.text;
        editedText += text.toLowerCase();
    }

    function toMixCase(val) {
        var text = val.text;
        var newText = "";
        for (var i = 0; i < text.length; i++) {
            if (i % 2 == 0) {
                newText += text[i].toLowerCase();
            } else {
                newText += text[i].toUpperCase();
            }
        }
        editedText += newText;
    }

    function getRegionText(type, index) {
        var text = "";
        var closingTag = "</" + type + ">";
        var indexOfClosingTag = mainText.indexOf(closingTag, index);
        if (!hasNested(index, indexOfClosingTag)) {
            while (true) {
                if (mainText[index] + mainText[index + 1] !== "</") {
                    text += mainText[index];
                    index++;
                } else {
                    break;
                }
            }
        }
        return {
            text: text,
            index: index
        };
    }

    function hasNested(startingIndex, closingIndex) {
        var substring = mainText.substring(startingIndex, closingIndex);
        var hasNested = false;
        if (substring.indexOf(upCase) !== -1) {
            hasNested = true;
        } else if (substring.indexOf(lowCase) !== -1) {
            hasNested = true;
        } else if (substring.indexOf(mixCase) !== -1) {
            hasNested = true;
        }

        return hasNested;
    }

    (function () {
        //var input = prompt("Enter some text");
        //mainText = input;
        mainText = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else."

        for (var i = 0; i < mainText.length; i++) {
            if (mainText[i] === "<") {
                var type = "";
                i++;
                while (mainText[i] !== ">") {
                    type += mainText[i];
                    i++;
                }

                var regionValues = getRegionText(type, i + 1);
                i = (regionValues.index + type.length+2);
                switch (type) {
                    case "upcase":
                        toUpCase(regionValues);
                        break;
                    case "lowcase":
                        toLowCase(regionValues);
                        break;
                    case "mixcase":
                        toMixCase(regionValues);
                        break;
                    default:
                        null;
                        break;
                }
            } else {
                editedText += mainText[i];
            }
        }
        console.log(editedText);
    })();
})();