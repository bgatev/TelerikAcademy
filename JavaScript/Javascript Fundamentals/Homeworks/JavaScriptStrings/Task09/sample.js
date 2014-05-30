//Write a function for extracting all email addresses from given text. 
//All substrings that match the format <identifier>@<host>…<domain> 
//should be recognized as emails. Return the emails as array of strings.
(function () {
    function extractEmails(text) {
        return text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
    }

    var text = "lorem ipsum test nqh@gmail.com is there any blq blq blq21@co.in in this wordless@telerik.com";
    var allEmails = extractEmails(text);
    allEmails.forEach(function (item) {
        console.log(item);
    });
})();