<?php
    mb_internal_encoding('UTF-8');    
    include 'includes\functions.php';
    
    session_set_cookie_params(3600,'/','',false,true);
?>

<!DOCTYPE html>
<html>
    <head>
            <title><?= $pageTitle;?></title>

            <meta charset="UTF-8">

    </head>
    <body>
