function GetTitle(htmlStr)
{
    var title = '';
        startIndex = 0;
        endIndex = 0;

    htmlStr = String(htmlStr);
    startIndex = htmlStr.indexOf("<title>");
    endIndex = htmlStr.indexOf("</title>");

    if ((startIndex == -1) || (endIndex == -1)) return "-1";

    title = htmlStr.substring(startIndex + 7, endIndex);

    return title;
}

function GetBody(htmlStr)
{
    var body = '';
        startIndex = 0;
        endIndex = 0;
        bodyString = [];

        startIndex = htmlStr.indexOf("<body>");
        endIndex = htmlStr.indexOf("</body>");

    if ((startIndex == -1) || (endIndex == -1)) return "-1";
        
    body = htmlStr.substring(startIndex + 6, endIndex);// - startIndex - 6);

    bodyString = body.split('<');

    body = '';
    for (var i = 0; i < bodyString.length; i++)
    {
        endIndex = bodyString[i].indexOf(">");
        body += bodyString[i].substring(endIndex + 1); 
    }

    return body;
}
    
var inputHTML = '<html>\n <head><title>News</title></head>\n <body><p><a href= "http://academy.telerik.com">Telerik Academy</a> aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body>\n</html>';

    htmlTitle = GetTitle(inputHTML);
    htmlBody = GetBody(inputHTML);

console.log(htmlTitle + " -> " + htmlBody);