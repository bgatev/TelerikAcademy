<?php
session_start();
$pageTitle='Authors\' Books';
include 'templates\header.php';
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
if($_GET) $selectAB = makeSQLGet($_GET);  

if($_POST){
    if (!($_GET)) $selectAB = makeSQLPost();
    $selectAB = addFiltersToSQLPost($connection, $_POST, $selectAB);
}

$allDataArray = getBookAuthors($connection, $selectAB);
$commentsDataArray = getBookComments($connection);

    //print "<pre>";print_r($usersDataArray);print "</pre>";
    //exit;
if($allDataArray && $commentsDataArray){
    echo '<table><tr><td>Book</td><td>Authors</td><td>Comments</td><td>Number Of Comments</td><td>Comment Date</td><td>Comment from User</td></tr>';
    foreach($allDataArray as $authorNames){              
        echo '<tr><td><a href="authorbooks.php?book=' . $authorNames['book_id'][0] . '" >'. $authorNames['book_title'].'</a></td><td>';
 
        $i=0;
        $tempArray=[];
        foreach($authorNames['author_name'] as $singleAuthorName){        
            $tempArray[] = '<a href="authorbooks.php?author=' . $authorNames['author_id'][$i++] . '" >' . $singleAuthorName . '</a>';
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
                    echo '<td><a href="users.php?user=' . $comments['user_id'][$j] . '" >'. $comments['username'][$j++]. '</a></td></tr><tr><td></td><td></td>';
                }
            } 
        }
        
        if (isset($_SESSION['isLogged'])){
            if (isset($_GET['book'])) echo '<td><a href="newcomment.php?book=' . $_GET['book'] . '" >'.'Add New Comment </a></td>';
        }
    }
    echo '</table>';
}
else echo 'No results';

?>

<?php include 'templates\footer.php'; ?>