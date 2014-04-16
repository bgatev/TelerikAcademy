<?php
mb_internal_encoding('UTF-8');
$pageTitle='New Author';
include '..\includes\header.php';
?>


<?php
    $selectA = 'SELECT * FROM authors';
    $allAuthors = mysqli_query($connection, $selectA);
    if (!$allAuthors){
        echo 'Error while fetching the authors';
    }
    
    if($allAuthors->num_rows > 0){
        echo '<table><tr><td>Authors</td></tr>';
        while($currentAuthor=$allAuthors->fetch_assoc()){
            $link = '<a href="authorbooks.php?author=' . $currentAuthor['author_id'] . '" >';          
            echo '<tr><td>'.$link. $currentAuthor['author_name'].'</a></td></tr>';
        }
        echo '</tr>'; 
    }
    else echo 'No results'; 
    
    if($_GET){
        $authorName = trim($_GET['author']);
        $authorName = mysqli_real_escape_string($connection,$authorName);
        $error = false;
                      
        if(mb_strlen($authorName) < 3){
            echo '<p>Author Name is too short</p>';
            $error = true;
        }
                
        $updateA = 'INSERT INTO authors (author_name) VALUES ("'.$authorName.'")';
        
        if(!$error){
            if (!mysqli_query($connection, $updateA)){
                echo 'Error while saving the authors';
                echo mysqli_error($connection);
                exit;
            }
            $author_id = mysqli_insert_id($connection);
        }
        header('Location: newauthor.php');
        exit;
    }

?>

<form method="GET" enctype="multipart/form-data">
    <div>New Author:<input type="text" name="author" /></div>     
    <div><input type="submit" value="Добави" /></div>
</form>


<?php
include '..\includes\footer.php';
?>