<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='New Comment';
include '..\includes\header.php';

if(!$_GET){
    header('Location: authorbooks.php');
    exit;
}

if($_POST){
    if ($_SESSION['isLogged']){
        $addNewComment = trim($_POST['addcomment']);
        $addNewComment = mysqli_real_escape_string($connection,$addNewComment);
        $book_id = trim($_GET['book']);
        $book_id =  mysqli_real_escape_string($connection,$book_id);
        
        $error = false;

        $updateUC ='INSERT INTO comments (comment_name)
                    VALUES ("'.$addNewComment.'")';

        if(mb_strlen($addNewComment) < 5){
            echo '<p>Comment is too short</p>';
            $error = true;
        }
        
        if (!is_numeric($book_id)){
            $error = true;
        }
        
        if(!$error){
            if (!mysqli_query($connection, $updateUC)){
                echo 'Error ';
                echo mysqli_error($connection);
                exit;
            }
            else $comment_id = mysqli_insert_id($connection);

            $updateCB = 'INSERT INTO comments_books (comment_id, book_id, user_id)
                         VALUES ("'.$comment_id.'","'.$book_id.'","'.$_SESSION['username'].'")';
            
            
            if (!mysqli_query($connection, $updateCB)){
                echo 'Error ';
                echo mysqli_error($connection);
                exit;
            }
            else echo 'Comment is added successfully';
            
        }
        else echo 'Error';
    }
}

?>

<a href="authorbooks.php">All Books </a>
<form method="POST" enctype="multipart/form-data">
    
    <div>Comment:<input type="text" name="addcomment" /></div>   
    <div><input type="submit" value="Добави" /></div>
</form>

<?php
include '..\includes\footer.php';
?>