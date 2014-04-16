<?php
mb_internal_encoding('UTF-8');
$db = mysqli_connect('localhost', 'gatakka', 'qwerty', 'books');
if(!$db){
    echo 'No Database';
}
mysqli_set_charset($db,'utf8');

function checkDBForError($db){
    return (bool) (mysqli_error($db));
}

function getAuthors($db){
    $q = mysqli_query($db, 'SELECT * FROM authors');
        if(checkDBForError($db)){
            echo 'Грешка';
        }
}

function searchArray($value, $key, $array) {
   foreach ($array as $k=>$singleRow) {
       if ($singleRow[$key] == $value) {
           return $k;
       }
   }
   return null;
}
?>