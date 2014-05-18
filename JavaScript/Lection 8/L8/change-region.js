function ExtractXML(line, startTag, endTag, param)
{
    var fixedLine = '';
        textForChange = '';
        startIndex = 0;
        endIndex = 0;

    line = String(line);
    do
    {
        startIndex = line.indexOf(startTag);

        if (startIndex == -1)
        {
            fixedLine += line;
            break;
        }

        fixedLine += line.substring(0, startIndex);
        line = line.substring(startIndex + startTag.length);
        endIndex = line.indexOf(endTag);
        switch (param) {
            case 'up': textForChange = (line.substring(0, endIndex)).toUpperCase(); break;
            case 'low': textForChange = (line.substring(0, endIndex)).toLowerCase(); break;
            case 'mix': textForChange = MixCase((line.substring(0, endIndex))); break;
        }
        
        fixedLine += textForChange;
        line = line.substring(endIndex + endTag.length);
    }
    while (startIndex != -1);

    return fixedLine;
}

function MixCase(inStr) {
    var result = '';
        inStrLength = inStr.length;

    for (var i = 0; i < inStrLength; i++) {
        if (i % 2 == 0) result += inStr[i].toUpperCase();
        else result += inStr[i].toLowerCase();
    }

    return result;
}

var upStartTag = "<upcase>";
    upEndTag = "</upcase>";
    lowStartTag = "<lowcase>";
    lowEndTag = "</lowcase>";
    mixedStartTag = "<mixcase>";
    mixedEndTag = "</mixcase>";

    xmlText = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYthing</lowcase> else.";

var result = ExtractXML(xmlText, upStartTag, upEndTag, 'up');

result = ExtractXML(result, lowStartTag, lowEndTag, 'low');
result = ExtractXML(result, mixedStartTag, mixedEndTag, 'mix');

console.log(result);
