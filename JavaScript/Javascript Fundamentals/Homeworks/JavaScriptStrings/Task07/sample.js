//Write a script that parses an URL address given in the format
(function () {
    var url = prompt("Enter some url");
    var protocol = url.substring(0, url.indexOf(":"));
    var serverResource = url.substring(url.indexOf("://") + 3);
    var server = serverResource.substring(0, serverResource.indexOf("/"));
    var resource = serverResource.substring(serverResource.indexOf("/"));
    var urlObj = {
        protocol: protocol,
        server: server,
        resource: resource
    };
    for (var i in urlObj) {
        console.log(i + " " + urlObj[i]);
    }
})();