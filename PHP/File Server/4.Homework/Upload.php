<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Качване на файл';
include '..\includes\header.php';
session_start();

$dir = DIRECTORY_SEPARATOR.$usernames[1].DIRECTORY_SEPARATOR;
if($_SESSION['isLogged']){
    if($_POST){
        if (count($_FILES) > 0){      
            if($_POST['filename']) $filename = trim($_POST['filename']);
            else $filename = $_FILES['uploadedFile']['name'];

            if(move_uploaded_file($_FILES['uploadedFile']['tmp_name'], ".".$dir.$filename)){
                echo 'File is uploaded successfully';
            }
            else echo 'File upload Error';

        }   
    }
}
?>
<a href="index.php">Начална страница</a>
<a href="Files.php">Списък файлове</a>
<form method="POST" enctype="multipart/form-data">
    
    <div>Име на файла:<input type="text" name="filename" /></div>
    <div>Качи файл:<input type="file" name="uploadedFile" /> </div>
          
    <div><input type="submit" value="Качи файл" /></div>
</form>
<?php
include '..\includes\footer.php';
?>