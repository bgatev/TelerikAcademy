<?php
$pageTitle='New Book';
include 'templates\header.php';
?>

<a href="authorbooks.php">All Books </a>
<a href="newauthor.php">New Author</a>
<?php
      
    if($_GET){
        $bookName = paramVerify($connection, $_GET['book']);
        $error = !validateString($bookName, 3, 100);

        if(!$error){
            if(!insertBook($connection, $bookName, $_GET['authors'], $bookAuthorsID)) exit;
        }
        
        header('Location: newbook.php');
        exit;
    }

?>

<form method="GET" enctype="multipart/form-data">
    <div>New Book:<input type="text" name="book" /></div>
    <div>
        <select name="authors[]" multiple style="height: 128pt">
            <?php
            $allBookAuthors = getAuthors($connection);
            if (!$allBookAuthors) echo 'Error while fetching the authors';

            foreach ($allBookAuthors as $key=>$value) {
                echo '<option value="'.$key.'">' . $value['author_name'] . '</option>';
            }
            ?>
        </select>
    </div> 
    <div><input type="submit" value="Добави" /></div>
</form>

<?php include 'templates\footer.php'; ?>