<?php
$pageTitle='Разходи';
include '..\includes\header.php';

?>

<a>Филтърът по дата за сега не работи  - добавен е за бъдещи промени при нужда !!!<br>
Файлът е запълнен по време на тестовете и може да няма консистентни данни, но при добавяне 
на нов запис прави необходимите проверки !!!</a><br>

<a href="form.php">Добави нов разход</a>
<form method="POST">
<select name="group">
            <?php
            if (!in_array("All", $groups)) array_push($groups, "All");
            foreach ($groups as $key=>$value) {
                    echo '<option value="'.$key.'">' . $value .
                        '</option>';
            }
            ?>
        </select>
<select name="data">
            <?php
            $result =  file('data.txt');
            $temp = array(1=>'01.01.1900');
            foreach ($result as $value) {
                $columns = explode('!', $value);
                if (!in_array($columns[0], $temp)){
                    echo '<option value="'.$key.'">' . $columns[0] .
                            '</option>';
                    array_push($temp, $columns[0]);
                 }
            }
            ?>
        </select>       
<input type="submit" value="Филтрирай" />
</form>

<table border="1">
    <tr>
        <td>Дата</td>
        <td>Име</td>
        <td>Сума</td>
        <td>Вид</td>
    </tr>
    <?php
    if($_POST && file_exists('data.txt')){
        //$result =  file('data.txt');
        $sum = 0;
        //var_dump($result);
        foreach ($result as $value) {
            $columns = explode('!', $value);
            if (($columns[3] == (int)$_POST['group']) || (array_search('All', $groups) == (int)$_POST['group'])){
                $sum += $columns[2];
                echo '<tr>
                    <td>'.$columns[0].'</td>
                    <td>'.$columns[1].'</td>
                    <td>'.$columns[2].'</td>
                    <td>'.$groups[trim($columns[3])].'</td>
                    </tr>';
            }
        }
        echo '<tr>
                <td>'.$dashes.'</td>
                <td>'.$dashes.'</td>
                <td>'.$sum.'</td>
                <td>'.$dashes.'</td>
                </tr>';
    }

    ?>
 
</table>
<?php
include '..\includes\footer.php';
?>
