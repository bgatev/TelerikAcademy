<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Authors\' Books';
include '..\includes\header.php';
?>

<a href="authorbooks.php">All Books </a>
<a href="newbook.php">New Book</a>
<a href="newauthor.php">New Author</a>

<form method="POST">
    <div>Book to find:<input type="text" name="book" /></div>   
    <select name="bookFilter">
            <?php
            foreach ($order as $key=>$value) {
                $selected = ' ';
                if (isset($_POST['bookFilter']) && $_POST['bookFilter'] == $key) $selected = ' selected ';
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
    <div><input type="submit" value="Намери" /></div>
</form>


<?php
$selectAB = 'SELECT books.book_title, authors.author_name, books.book_id, authors.author_id
             FROM books
             LEFT JOIN books_authors ON books.book_id = books_authors.book_id
             LEFT JOIN authors ON authors.author_id = books_authors.author_id ';

if($_GET){
    if(isset($_GET['book'])) {
        $foundedBook = $_GET['book'];
        $whereClause = 'WHERE books.book_id='.$foundedBook.')';
    }
    else if (isset($_GET['author'])) {
        $foundedAuthor = $_GET['author'];
        $whereClause = 'WHERE authors.author_id='.$foundedAuthor.')';
    }
    else $whereClause ='';
    
    $selectAB = MakeSQLGetPost($selectAB, $whereClause);  
}

if($_POST){
    if (!($_GET)) $selectAB = MakeSQLGetPost($selectAB, ')');

    if ($_POST['bookFilter'] == 1){
        $sortParamBook = ' ORDER BY books.book_title ASC';
    }
    else if ($_POST['bookFilter'] == 2) $sortParamBook = ' ORDER BY books.book_title DESC';
    else $sortParamBook='';
    
    if ($_POST['authors'] == 1){
        if ($sortParamBook){
            $sortParamAuthor = ',authors.author_name ASC';
        }
        else $sortParamAuthor = ' ORDER BY authors.author_name ASC';
    }
    else if ($_POST['authors'] == 2){
        if ($sortParamBook){
            $sortParamAuthor = ',authors.author_name DESC';
        }
        else $sortParamAuthor = ' ORDER BY authors.author_name DESC';
    }
    else $sortParamAuthor='';
    
    $bookName = trim($_POST['book']);
    $bookName = mysqli_real_escape_string($connection,$bookName);
    
    if($bookName != "") $selectAB = $selectAB.'AND books.book_title="'.$bookName.'"';
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
    $allDataArray[$singleRecord['book_title']]['book_id'][] = $singleRecord['book_id'];
}

$selectBC = 'SELECT books.book_title, comments.comment_name, books.book_id, comments.comment_id, comments.comment_date, users.user_id, users.username
             FROM books
             JOIN comments_books ON books.book_id = comments_books.book_id
             JOIN comments ON comments.comment_id = comments_books.comment_id
             JOIN users ON comments_books.user_id = users.user_id
             ORDER BY comments.comment_date DESC , books.book_title';

$commentsData = mysqli_query($connection, $selectBC);
if(!$commentsData){
    echo 'Error in Data Fetching';    
}

while($singleRecord = mysqli_fetch_assoc($commentsData)){
    $commentsDataArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
    $commentsDataArray[$singleRecord['book_title']]['comment_name'][] = $singleRecord['comment_name'];
    $commentsDataArray[$singleRecord['book_title']]['comment_id'][] = $singleRecord['comment_id'];
    $commentsDataArray[$singleRecord['book_title']]['comment_date'][] = $singleRecord['comment_date'];
    $commentsDataArray[$singleRecord['book_title']]['book_id'][] = $singleRecord['book_id'];
    $commentsDataArray[$singleRecord['book_title']]['user_id'][] = $singleRecord['user_id'];
    $commentsDataArray[$singleRecord['book_title']]['username'][] = $singleRecord['username'];
}

    //print "<pre>";print_r($usersDataArray);print "</pre>";
    //exit;
if($allData->num_rows > 0){
    echo '<table><tr><td>Book</td><td>Authors</td><td>Comments</td><td>Number Of Comments</td><td>Comment Date</td><td>Comment from User</td></tr>';
    foreach($allDataArray as $authorNames){       
        $linkBook = '<a href="authorbooks.php?book=' . $authorNames['book_id'][0] . '" >';          
        echo '<tr><td>'.$linkBook. $authorNames['book_title'].'</a></td><td>';
 
        $i=0;
        $tempArray=[];
        foreach($authorNames['author_name'] as $singleAuthorName){
            $link = '<a href="authorbooks.php?author=' . $authorNames['author_id'][$i++] . '" >';          
            $tempArray[] = $link . $singleAuthorName . '</a>';
        }
        echo implode(', ', $tempArray) . '</td>';
        
        foreach($commentsDataArray as $comments){          
            if ($authorNames['book_title'] == $comments['book_title']){
                $i = 0;
                $j = 0;
                $num = count($comments['comment_name']);
                foreach($comments['comment_name'] as $singleComment){
                    echo '<td>'.$singleComment.'</td>';
                    echo '<td>'.($i+1). ' / ' .$num. '</td>';
                    echo '<td>'.$comments['comment_date'][$i++].'</td>';
                    $link = '<a href="users.php?user=' . $comments['user_id'][$j] . '" >';          
                    echo '<td>'.$link. $comments['username'][$j++]. '</a></td></tr>';
                    echo '<tr><td></td><td></td>';
                }
            } 
        }
        
        if ($_SESSION['isLogged']){
            if (isset($_GET['book'])){
                $link = '<a href="newcomment.php?book=' . $_GET['book'] . '" >';          
                echo '<td>'.$link.'Add New Comment </a></td>';
            }
        }
    }
    echo '</table>';
}
else echo 'No results';

?>


<?php
include '..\includes\footer.php';
?>