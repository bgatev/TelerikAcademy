<?php
    $connection = mysqli_connect('localhost', 'gatakka', 'qwerty', 'books');
    if(!$connection){
    echo 'No Database';
    exit;
    }

    mysqli_set_charset($connection, 'utf8');
    $allDataArray = array();
    $allBookAuthors = array();
    $bookAuthorsID = array();
    $order = array(1=>'ASC', 2=>'DESC', 3=>'No Sort');
    
    function MakeSQLGetPost($selectAB, $whereClause){
        $selectAB = $selectAB.'WHERE books.book_title in (SELECT books.book_title FROM books
                                                      LEFT JOIN books_authors ON books.book_id = books_authors.book_id
                                                      LEFT JOIN authors ON authors.author_id = books_authors.author_id ';
        $selectAB = $selectAB.$whereClause;
        
        return $selectAB;
    }
?>
