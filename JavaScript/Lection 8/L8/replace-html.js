function ReplaceHTML(line, startTag, endTag, closeTag, openTagReplaced, openTagEndReplaced, closeTagReplaced) {

    var fixedLine = '';
        startIndex = 0;
        endIndex = 0;
        closeTagIndex = 0;

    line = String(line);

    do {
        startIndex = line.indexOf(startTag);

        if (startIndex == -1) {
            fixedLine += line;
            break;
        }

        fixedLine += line.substring(0, startIndex) + openTagReplaced;
        line = line.substring(startIndex + startTag.length);

        endIndex = line.indexOf(endTag);

        fixedLine += (line.substring(0, endIndex)) + openTagEndReplaced;
        line = line.substring(endIndex + endTag.length);

        closeTagIndex = line.indexOf(closeTag);

        fixedLine += (line.substring(0, closeTagIndex)) + closeTagReplaced;
        line = line.substring(closeTagIndex + closeTag.length);
    }
    while (startIndex != -1);

    return fixedLine;
}

var openTag = '<a href="';
    openTagEnd = '">';
    closeTag = "</a>";
    openTagReplaced = '[URL=';
    openTagEndReplaced = '] ';
    closeTagReplaced = '[/URL]';
    textArray = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

    console.log(ReplaceHTML(textArray, openTag, openTagEnd, closeTag, openTagReplaced, openTagEndReplaced, closeTagReplaced));
