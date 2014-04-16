<?php
mb_internal_encoding('UTF-8');
$pageTitle='Файл сървър';
include '..\includes\header.php';
session_start();

if(!isset($_SESSION['isLogged'])){
    if ($_POST){
        $username = trim($_POST['username']);
        $pass = trim($_POST['pass']);

        if($username == $usernames[1] && $pass == $passes[1]){
            $_SESSION['isLogged'] = true;
            $_SESSION['username'] = $username;
            header('Location: Files.php');
            exit;
        }
        else echo 'Your username and password are not valid';
    }
}
else $_SESSION['isLogged'] = false;
?>

<a>За сега нямах време да добавя логване с няколко потребителя и качване на файлове в различни папки - 
   ще бъде направено и качено със следващото домашно !!!<br> </a><br>

<form method ="POST">
    <div>Username:<input type="text" name="username" /></div>
    <div>Password:<input type="password" name="pass" /></div>
    <div><input type="submit" value="Sign in" /></div>  
</form>


<?php
include '..\includes\footer.php';
?>