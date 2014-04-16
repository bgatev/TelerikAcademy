<?php
mb_internal_encoding('UTF-8');
$pageTitle='New Book';
include '..\includes\header.php';
?>

<a href="authorbooks.php">All Books </a>
<a href="newauthor.php">New Author</a>
<?php
      
    if($_GET){
        $bookName = trim($_GET['book']);
        $bookName = mysqli_real_escape_string($connection,$bookName);
        foreach ($_GET['authors'] as $currentAuthor){
            if (!in_array($currentAuthor, $bookAuthorsID)) array_push($bookAuthorsID, $currentAuthor);
        }
 
        $error = false;
                      
        if(mb_strlen($bookName) < 3){
            echo '<p>Book Name is too short</p>';
            $error = true;
        }      
        
        $updateB = 'INSERT INTO books (book_title) VALUES ("'.$bookName.'")';

        if(!$error){
            if (!mysqli_query($connection, $updateB)){
                echo 'Error while saving the book';
                echo mysqli_error($connection);
                exit;
            }
            $book_id = mysqli_insert_id($connection);
            $tempID = $bookAuthorsID[0] + 1;
            $updateBA = 'INSERT INTO books_authors (book_id, author_id) VALUES ("'.$book_id.'","'.$tempID.'")';
            
            for($i=1;$i<sizeof($bookAuthorsID);$i++){
                $tempID = $bookAuthorsID[$i] + 1;
                $updateBA = $updateBA.',("'.$book_id.'","'.$tempID.'")';    
            }

            if (!mysqli_query($connection, $updateBA)){
                echo 'Error while saving connectons';
                echo mysqli_error($connection);
                exit;
            }
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
            $selectA = 'SELECT * FROM authors';
            $allBookAuthors = mysqli_query($connection, $selectA);
            if (!$allBookAuthors){
                echo 'Error while fetching the authors';
            }

            while($currentAuthor = $allBookAuthors->fetch_assoc()){
                print_r($allBookAuthors);
                if (!in_array($currentAuthor, $allBookAuthors)) array_push($allBookAuthors, $currentAuthor);
            }

            foreach ($allBookAuthors as $key=>$value) {
                echo '<option value="'.$key.'">' . $value['author_name'] . '</option>';
            }
            ?>
        </select>
    </div> 
    <div><input type="submit" value="Добави" /></div>
</form>


<?php
include '..\includes\footer.php';
?>