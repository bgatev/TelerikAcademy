function GetIdentifier(inEMail)
{
    var identifier = '';
    startIndex = 0;

    startIndex = inEMail.indexOf("@");
    if (startIndex == -1) return "-1";

    identifier = inEMail.substring(0, startIndex);

    return identifier;
}

function GetHost(inEMail)
{
    var host = '';
    startIndex = 0;
    endIndex = 0;
        
    startIndex = inEMail.indexOf("@");

    if (inEMail[inEMail.length - 1] == '.') inEMail = inEMail.substring(0, inEMail.length - 1);
    endIndex = inEMail.lastIndexOf('.');
    if ((startIndex == -1) || (endIndex == -1)) return "-1";
        
    host = inEMail.substring(startIndex + 1, endIndex);

    return host;
}

function GetDomain(inEMail)
{
    var domain = '';
        startIndex = 0;

    if (inEMail[inEMail.length - 1] == '.') inEMail = inEMail.substring(0, inEMail.length - 1);
    startIndex = inEMail.lastIndexOf(".");
    if (startIndex == -1) return "-1";

    domain = inEMail.substring(startIndex);

    return domain;
}

(function ExtractEmail() {
    var inputText = "I am a beautiful boy and my address is aman@ivan.telerik-students.org. My girlfriend address is hello@abv.bg, but is not full.";
        inputEmail = [];
        EMails = [];

    inputEmail = inputText.split(' ');

    for (var i = 0; i < inputEmail.length; i++) {
        var identifier = GetIdentifier(inputEmail[i]);
        if (identifier == "-1") continue;

        var host = GetHost(inputEmail[i]);
        if (host == "-1") continue;

        var domain = GetDomain(inputEmail[i]);
        if (domain == "-1") continue;
        
        var currentEmail = {
                Identifier: identifier,
                Host: host,
                Domain: domain
            };

        EMails.push(currentEmail);
    }

    console.log(EMails);
})();