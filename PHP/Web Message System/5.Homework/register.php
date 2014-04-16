<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Register';
include '..\includes\header.php';

if($_POST){
    $username = trim($_POST['username']);
    $username = mysqli_real_escape_string($connection,$username);
    $password = trim($_POST['pass']);
    $password = mysqli_real_escape_string($connection,$password);
    $error = false;
    
    $updateUP = 'INSERT INTO users (username, password) 
                 VALUES ("'.$username.'","'.$password.'")';
    
    if(mb_strlen($username) < 5){
        echo '<p>Username is too short</p>';
        $error = true;
    }
    if(mb_strlen($password) < 5){
        echo '<p>Password is too short</p>';
        $error = true;
    }   
        
    if(!$error){
        if (!mysqli_query($connection, $updateUP)){
            echo 'Error ';
            echo mysqli_error($connection);
            exit;
        }
        
        header('Location: index.php');
        exit;
    } 
}

?>

<form method="POST" enctype="multipart/form-data">
    
    <div>Username:<input type="text" name="username" /></div>
    <div>Password:<input type="text" name="pass" /></div>     
    <div><input type="submit" value="Добави" /></div>
</form>

<?php
include '..\includes\footer.php';
?>