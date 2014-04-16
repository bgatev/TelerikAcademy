<?php

$allBookAuthors = array();
$bookAuthorsID = array();
$order = array(1=>'ASC', 2=>'DESC', 3=>'No Sort');

$selectAB = 'SELECT books.book_title, authors.author_name, books.book_id, authors.author_id
             FROM books
             LEFT JOIN books_authors ON books.book_id = books_authors.book_id
             LEFT JOIN authors ON authors.author_id = books_authors.author_id ';

?>
