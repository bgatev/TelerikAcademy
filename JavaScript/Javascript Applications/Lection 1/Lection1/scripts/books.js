/// <reference path="underscore.js" />

var Book = (function () {
    function Book(author) {
        this.author = author;
    }
    return Book;
})();

var book1 = new Book("Ivan Vazov");
var book2 = new Book("Ivan Vazov");
var book3 = new Book("Pencho Slaveikov");
var book4 = new Book("Ivan Vazov");
var book5 = new Book("Hristo Botev");
var book6 = new Book("Hristo Botev");

var books = [];

books.push(book1);
books.push(book2);
books.push(book3);
books.push(book4);
books.push(book5);
books.push(book6);

var authorWithMaxBooks = (_.chain(books)
                        .groupBy('author')
                        .max(function (authorBooks) {
                            return authorBooks.length;
                        })
                        .pluck('author')
                        .value())[0];

console.log(authorWithMaxBooks);