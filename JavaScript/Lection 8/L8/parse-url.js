function GetProtocol(inURL)
{
    var protocol = '';
        startIndex = 0;

    startIndex = inURL.indexOf("://");
    protocol = inURL.substring(0, startIndex);
        
    return protocol;
}

function GetServer(inURL)
{
    var server = '';
    startIndex = 0;

    startIndex = inURL.indexOf("://");
    inURL = inURL.substring(startIndex + 3);

    startIndex = inURL.indexOf('/');
    server = inURL.substring(0, startIndex);

    return server;
}

function GetResource(inURL)
{
    var resource = '';
        startIndex = 0;

    startIndex = inURL.indexOf("://");
    inURL = inURL.substring(startIndex + 3);

    startIndex = inURL.indexOf('/');
    resource = inURL.substring(startIndex);

    return resource;
}

    var inputUrl = "http://www.devbg.org/forum/index.php";

    var URL = {
        Protocol: GetProtocol(inputUrl),
        Server: GetServer(inputUrl),
        Resource: GetResource(inputUrl)
    };

    console.log(URL);