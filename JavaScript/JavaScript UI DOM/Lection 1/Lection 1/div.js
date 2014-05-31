function getDivs(){
    var query = document.querySelectorAll('div > div');
    for (var i = 0, len = query.length; i < len; i++) console.log(query[i].innerHTML);

    var allDivs = document.getElementsByTagName('div');
    var nestedDivs = [];
    for (var i = 0, len = allDivs.length; i < len; i++) {
        if (allDivs[i].parentNode instanceof HTMLDivElement) console.log(allDivs[i].innerHTML);
    }
}