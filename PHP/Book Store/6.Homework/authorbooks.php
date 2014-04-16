<?php
mb_internal_encoding('UTF-8');
$pageTitle='Authors\' Books';
include '..\includes\header.php';
?>

<a href="authorbooks.php">All Books </a>
<form method="POST">
    <div>Book to find:<input type="text" name="book" /></div>     
    <div><input type="submit" value="Намери" /></div>
</form>


<?php
$selectAB = 'SELECT books.book_title, authors.author_name, authors.author_id
             FROM books
             LEFT JOIN books_authors ON books.book_id = books_authors.book_id
             LEFT JOIN authors ON authors.author_id = books_authors.author_id ';

if($_GET){
    $foundedAuthor = $_GET['author'];
    $selectAB = $selectAB.'WHERE books.book_title in (SELECT books.book_title FROM books
                                                      LEFT JOIN books_authors ON books.book_id = books_authors.book_id
                                                      LEFT JOIN authors ON authors.author_id = books_authors.author_id 
                                                      WHERE authors.author_id='.$foundedAuthor.') ';
}

if($_POST){
    $bookName = trim($_POST['book']);
    $bookName = mysqli_real_escape_string($connection,$bookName);
    
    $selectAB = $selectAB.'AND books.book_title="'.$bookName.'"';
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