<?php
session_start();
$pageTitle='Register';
include 'templates\header.php';

if($_POST){
    $username = paramVerify($connection, $_POST['username']);
    $password = paramVerify($connection, $_POST['pass']);
    
    $error = !validateString($username, 3, 20);
    if (!$error) $error = !validateString($password, 3, 30);
        
    if(!$error){
        if (!insertUser($connection, $username, $password)) exit;
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

<?php  include 'templates\footer.php'; ?>