<?php
mb_internal_encoding('UTF-8');
$pageTitle='Book Store';
include '..\includes\header.php';

?>

<a href="newbook.php">New Book </a><a href="newauthor.php">New Author</a>
<form method="POST">
    <select name="book">
            <?php
            foreach ($order as $key=>$value) {
                $selected = ' ';
                if (isset($_POST['book']) && $_POST['book'] == $key) $selected = ' selected ';
                echo '<option'.$selected.'value="'.$key.'">'."Book " . $value . '</option>';
            }
            ?>
    </select> 
    <select name ="authors">
            <?php
            foreach ($order as $key=>$value) {
                $selected = ' ';
                if (isset($_POST['authors']) && $_POST['authors'] == $key) $selected = ' selected ';
                echo '<option'.$selected.'value="'.$key.'">'."Authors " . $value . '</option>';
            }
            ?>
    </select>
<input type="submit" value="Филтрирай" />
</form>

<?php
$selectAB = 'SELECT books.book_title, authors.author_name, authors.author_id
             FROM books
             LEFT JOIN books_authors ON books.book_id = books_authors.book_id
             LEFT JOIN authors ON authors.author_id = books_authors.author_id ';

if($_POST){
    if ($_POST['book'] == 1){
        $sortParamBook = 'ORDER BY books.book_title ASC';
    }
    else if ($_POST['book'] == 2) $sortParamBook = 'ORDER BY books.book_title DESC';
    else $sortParamBook='';
    
    if ($_POST['authors'] == 1){
        if ($sortParamBook){
            $sortParamAuthor = ',authors.author_name ASC';
        }
        else $sortParamAuthor = 'ORDER BY authors.author_name ASC';
    }
    else if ($_POST['authors'] == 2){
        if ($sortParamBook){
            $sortParamAuthor = ',authors.author_name DESC';
        }
        else $sortParamAuthor = 'ORDER BY authors.author_name DESC';
    }
    else $sortParamAuthor='';
    
    $selectAB = $selectAB.$sortParamBook.$sortParamAuthor;
}

$allData = mysqli_query($connection, $selectAB);
if(!$allData){
    echo 'Error in Data Fetching';    
}

while($singleRecord = mysqli_fetch_assoc($allData)){
    $allDataArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
    $allDataArray[$singleRecord['book_title']]['author_name'][] = $singleRecord['author_name'];
    $allDataArray[$singleRecord['book_title']]['author_id'][] = $singleRecord['author_id'];
}
if($allData->num_rows > 0){
    echo '<table><tr><td>Book</td><td>Authors</td></tr>';
    foreach($allDataArray as $authorNames){
        echo '<tr><td>'.$authorNames['book_title'].'</td><td>';
        $i=0;
        foreach($authorNames['author_name'] as $singleAuthorName){
            $link = '<a href="authorbooks.php?author=' . $authorNames['author_id'][$i++] . '" >';          
            echo '<td>'.$link. $singleAuthorName.'</a></td>';
        }
        echo '</td></tr>';
    }
}
else echo 'No results';

?>

<?php
include '..\includes\footer.php';
?>