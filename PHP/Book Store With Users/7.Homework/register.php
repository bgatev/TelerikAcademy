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
    
    if(mb_strlen($username) < 3){
        echo '<p>Username is too short</p>';
        $error = true;
    }
    if(mb_strlen($password) < 3){
        echo '<p>Password is too short</p>';
        $error = true;
    }   
        
    if(!$error){
        if (!mysqli_query($connection, $updateUP)){
            echo 'Error ';
            echo mysqli_error($connection);
            exit;
        }
        else echo 'Your registration is successfull ';
    } 
}

?>

<a href="index.php">Login</a>
<form method="POST" enctype="multipart/form-data">
    
    <div>Username:<input type="text" name="username" /></div>
    <div>Password:<input type="text" name="pass" /></div>     
    <div><input type="submit" value="Добави" /></div>
</form>

<?php
include '..\includes\footer.php';
?>