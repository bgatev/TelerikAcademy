<?php
session_start();
$pageTitle='Users';
include 'templates\header.php';
?>

<a href="authorbooks.php">All Books </a>
 
<?php
if(!$_GET){
    header('Location: authorbooks.php');
    exit;
}

if(isset($_GET['user'])) {
    $user_id = paramVerify($connection, $_GET['user']);       
    $whereClause = 'WHERE users.user_id='.$user_id.' ';
}
else $whereClause ='';

$usersCommentsArray = getUsers($connection, $whereClause);

//print "<pre>";print_r($usersCommentsArray);print "</pre>";
//exit;

if($usersCommentsArray){
    echo '<table><tr><td>User</td><td>Comments</td><td>Comment Date</td><td>Book</td></tr>';
    foreach($usersCommentsArray as $singleUser){                  
        echo '<tr><td>'.$singleUser['username'].'</td>';
        $i = 0;
        foreach($singleUser['comment_name'] as $singleComment){            
                echo '<td>'.$singleComment.'</td>';
                echo '<td>'.$singleUser['comment_date'][$i++].'</td>';          
                echo '<td><a href="authorbooks.php?book=' . $singleUser['book_id'] . '" >'. $singleUser['book_title']. '</a></td></tr><tr><td></td>';       
        }
        echo '</tr>';
    }
    echo '</table>';
}
else echo 'No results';

?>


<?php include 'templates\footer.php'; ?>
