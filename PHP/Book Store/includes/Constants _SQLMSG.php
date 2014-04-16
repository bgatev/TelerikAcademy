<?php
    $connection = mysqli_connect('localhost', 'gatakka', 'qwerty', 'homework5');
    if(!$connection){
    echo 'No Database';
    exit;
    }

    mysqli_set_charset($connection, 'utf8');
    $groups = array();
    $dateOrder = array(1=>'ASC', 2=>'DESC');
?>
