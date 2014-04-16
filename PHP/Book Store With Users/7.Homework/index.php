<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Book Store User Login';
include '..\includes\header.php';

$selectUP = 'SELECT user_id 
             FROM users
             WHERE username=? AND password=?';

if(!isset($_SESSION['isLogged'])){
    if ($_POST){
        $username = trim($_POST['username']);
        $username = mysqli_real_escape_string($connection,$username);
        $password = trim($_POST['pass']);
        $password = mysqli_real_escape_string($connection,$password);
        
        $stmtUP = mysqli_prepare($connection, $selectUP);
        mysqli_stmt_bind_param($stmtUP, 'ss', $username,$password);
        mysqli_stmt_execute($stmtUP);
        mysqli_stmt_bind_result($stmtUP, $user_id);
        mysqli_stmt_fetch($stmtUP);
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

    
<?php
include '..\includes\footer.php';
?>