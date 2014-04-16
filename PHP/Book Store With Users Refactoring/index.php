<?php
session_start();
$pageTitle='Book Store User Login';
include 'templates\header.php';

if(!isset($_SESSION['isLogged'])){
    if ($_POST){      
        $username = paramVerify($connection, $_POST['username']);
        $password = paramVerify($connection, $_POST['pass']);
        
        $user_id = checkLogin($connection, $username, $password);
        if(!$user_id){
            echo 'Invalid Username or Password. Please <a href="index.php">check</a> input data or <a href="register.php">Register</a>';
            exit;
        }
 
        $_SESSION['isLogged'] = true;
        $_SESSION['username'] = $user_id;
        
        header('Location: authorbooks.php');
        exit;
    }
}
else $_SESSION['isLogged'] = false;
?>
   
<form method ="POST">
    <div>Username:<input type="text" name="username" /></div>
    <div>Password:<input type="password" name="pass" /></div>
    <div><input type="submit" value="Sign in" /> or <a href="register.php">Register</a></div>
</form>
    
<?php include 'templates\footer.php'; ?>