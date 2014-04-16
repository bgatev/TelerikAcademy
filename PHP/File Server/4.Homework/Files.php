<?php
mb_internal_encoding('UTF-8');
$pageTitle='Списък Файлове';
include '..\includes\header.php';
session_start();

function addSizeDimension($bytes){
    if ($bytes > 1048575) $bytes = number_format($bytes / 1048576, 2) . ' MB';
    elseif ($bytes > 1023) $bytes = number_format($bytes / 1024, 2) . ' KB';
    elseif ($bytes == 1) $bytes = $bytes . ' byte';
    else $bytes = $bytes . ' bytes';

    return $bytes;
}

$dir = DIRECTORY_SEPARATOR.$usernames[1].DIRECTORY_SEPARATOR;
$files = array_diff(scandir(".".$dir), array('..', '.'));

if($_SESSION['isLogged']){
    if(count($files) < 0) echo '<p>Няма качени файлове</p>';
    else {
        echo '<table border="1">
            <tr>
            <td>'."Име на файла".'</td>
            <td>'."Размер на файла".'</td>
            </tr>';

        for($i = 2; $i < count($files) + 2; $i++) {
            $size = filesize (".".$dir . $files[$i]);
            $size = addSizeDimension($size);
            
            $link = '<a href="download.php?file=' . $files[$i] . '" >';
            echo '<tr><td>'.$link. $files[$i] .'</a></td><td>'.$size.'</td></tr>';
        }
        echo '</table>';
    }
}

?>
<a href="index.php">Начална страница</a>
<a href="Upload.php">Качи файл</a>

<?php
include '..\includes\footer.php';
?>