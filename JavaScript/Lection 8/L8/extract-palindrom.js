function CheckPalindrom(word){
    var counter = 0;
        wordLength = Math.floor(word.length / 2);

    for (var i = 0; i < wordLength; i++)
        if (word[i] == word[word.length - i - 1]) counter++;
        
    if (counter == wordLength && counter > 0) return true;
    else return false;
}
    var inputText = 'Write a program that extracts from a given text all 575 palindromes, e.g. ABBA , lamal , exe';
        words = [];

    words = inputText.split(' ');

    for (var i = 0; i < words.length; i++)
        if (CheckPalindrom(words[i])) console.log(words[i]);
