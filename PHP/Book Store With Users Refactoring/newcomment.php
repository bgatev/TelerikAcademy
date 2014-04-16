<?php
session_start();
$pageTitle='New Comment';
include 'templates\header.php';

if(!$_GET){
    header('Location: authorbooks.php');
    exit;
}

if($_POST){
    if ($_SESSION['isLogged']){
        $addNewComment = paramVerify($connection, $_POST['addcomment']);
        $book_id = paramVerify($connection, $_GET['book']);       

        $error = !validateString($addNewComment, 5, 255);
        if (!is_numeric($book_id)) $error = true;
               
        if(!$error){
            if (insertComment($connection, $book_id, $addNewComment, $_SESSION['username'])) echo 'Comment is added successfully';            
        }
    }
}

?>

<a href="authorbooks.php">All Books </a>
<form method="POST" enctype="multipart/form-data">
    
    <div>Comment:<input type="text" name="addcomment" /></div>   
    <div><input type="submit" value="Добави" /></div>
</form>

<?php include 'templates\footer.php'; ?>