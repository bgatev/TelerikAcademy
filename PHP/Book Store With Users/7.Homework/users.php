<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Users';
include '..\includes\header.php';

if(!$_GET){
    header('Location: authorbooks.php');
    exit;
}
else{
    $selectUC = 'SELECT books.book_title, comments.comment_name, books.book_id, comments.comment_id, comments.comment_date, users.user_id, users.username
             FROM books
             JOIN comments_books ON books.book_id = comments_books.book_id
             JOIN comments ON comments.comment_id = comments_books.comment_id
             JOIN users ON comments_books.user_id = users.user_id ';
    
    if(isset($_GET['user'])) {
        $user_id = trim($_GET['user']);
        $user_id = mysqli_real_escape_string($connection,$user_id);
        $whereClause = 'WHERE users.user_id='.$user_id.' ';
    }
    else $whereClause ='';
    
    $selectUC = $selectUC . $whereClause . 'ORDER BY comments.comment_date DESC , books.book_title';
    
    $usersComments = mysqli_query($connection, $selectUC);
    if(!$usersComments){
        echo 'Error in Data Fetching';    
    }

    while($singleRecord = mysqli_fetch_assoc($usersComments)){
        $usersCommentsArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_name'][] = $singleRecord['comment_name'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_id'][] = $singleRecord['comment_id'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_date'][] = $singleRecord['comment_date'];
        $usersCommentsArray[$singleRecord['book_title']]['book_id'] = $singleRecord['book_id'];
        $usersCommentsArray[$singleRecord['book_title']]['user_id'] = $singleRecord['user_id'];
        $usersCommentsArray[$singleRecord['book_title']]['username'] = $singleRecord['username'];
    }

    //print "<pre>";print_r($usersCommentsArray);print "</pre>";
    //exit;
    
    if($usersComments->num_rows > 0){
        echo '<table><tr><td>User</td><td>Comments</td><td>Comment Date</td><td>Book</td></tr>';
        foreach($usersCommentsArray as $singleUser){                  
            echo '<tr><td>'.$singleUser['username'].'</td>';
            $i = 0;
            foreach($singleUser['comment_name'] as $singleComment){            
                    echo '<td>'.$singleComment.'</td>';
                    echo '<td>'.$singleUser['comment_date'][$i++].'</td>';
                    
                    $link = '<a href="authorbooks.php?book=' . $singleUser['book_id'] . '" >';          
                    echo '<td>'.$link. $singleUser['book_title']. '</a></td></tr>';
                    echo '<tr><td></td>';        
            }
            echo '</tr>';
        }
        echo '</table>';
    }
    else echo 'No results';
}


?>

<?php
include '..\includes\footer.php';
?>
