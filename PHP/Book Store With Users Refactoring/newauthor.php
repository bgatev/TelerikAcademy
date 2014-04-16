<?php
$pageTitle='New Author';
include 'templates\header.php';
?>

<a href="authorbooks.php">All Books </a>
<a href="newbook.php">New Book</a>

<?php
    $allAuthors = getAuthors($connection);
    if (!$allAuthors) echo 'Error while fetching the authors';    
    
    if($allAuthors->num_rows > 0){
        echo '<table><tr><td>Authors</td></tr>';
        while($currentAuthor = $allAuthors->fetch_assoc()){        
            echo '<tr><td><a href="authorbooks.php?author=' . $currentAuthor['author_id'] . '" >'. $currentAuthor['author_name'].'</a></td></tr>';
        }
        echo '</tr>'; 
    }
    else echo 'No results'; 
    
    if($_GET){
        $authorName = paramVerify($connection, $_GET['author']);
        $error = !validateString($authorName, 3, 100);
        
        if(!$error){
            if (!insertAuthor($connection, $authorName)) exit;
        }
        header('Location: newauthor.php');
        exit;
    }

?>

<form method="GET" enctype="multipart/form-data">
    <div>New Author:<input type="text" name="author" /></div>     
    <div><input type="submit" value="Добави" /></div>
</form>


<?php include 'templates\footer.php'; ?>