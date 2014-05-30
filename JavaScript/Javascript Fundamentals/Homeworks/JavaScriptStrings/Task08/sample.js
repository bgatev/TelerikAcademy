//Write a JavaScript function that replaces in a HTML document given as string 
//all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
(function () {
    var text = prompt("Enter some html text:");
    var newText = text.replace(/<a href="/g, "[URL=").replace(/">/g, "]")
        .replace(/<\/a>/g, "[/URL]");
    alert(newText);
})();