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
?>
