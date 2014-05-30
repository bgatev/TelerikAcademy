//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
(function () {
    function extractPolindromes(text) {
        var allWords = text.trim().split(" ");
        var results = [];
        allWords.forEach(function (item) {
            var isPolindrome = true;
            for (var i = 0; i < item.length/2; i++) {
                if (item[i] !== item[item.length - 1 - i]) {
                    isPolindrome = false;
                }
            }

            if (isPolindrome) {
                results.push(item);
            }
        });
        return results;
    }

    var text = " some word are not ABBA polindromes like lamal and exe";

    var getAllPolindromes = extractPolindromes(text);
    getAllPolindromes.forEach(function (item) {
        console.log(item);
    });
})();