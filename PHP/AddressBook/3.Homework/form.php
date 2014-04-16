<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Форма';
include '..\includes\header.php';

function IsDate($Str)
{
  $is_valid = date('d.m.Y', strtotime($Str)) == $Str;
  
  return $is_valid;
}


if($_POST){
    $data = trim($_POST['data']);
    $razhodName = trim($_POST['razhodName']);
    $razhodName =  str_replace('!', '', $razhodName);
    $amount = trim($_POST['amount']);
    $amount =  str_replace('!', '', $amount);
    $selectedGroup = (int)$_POST['group'];
    $error = false;
    
    if(!IsDate($data)){
        echo '<p>Невалидна дата</p>';
        $error = true;
    }
    if(mb_strlen($razhodName) < 4){
        echo '<p>Името е прекалено късо</p>';
        $error = true;
    }
    if($amount <= 0 || !is_numeric($amount)){
        echo '<p>Невалидна сума</p>';
        $error = true;
    }    
    if(!array_key_exists($selectedGroup, $groups)){
        echo '<p>Невалидна категория</p>';
        $error = true;
    }
    
    if(!$error){
        $result=$data.'!'.$razhodName.'!'.$amount.'!'.$selectedGroup."\n";
        if(file_put_contents('data.txt', $result,FILE_APPEND))
        {
            echo 'Записът е успешен';
        }
    }
 
}

?>
<a href="index.php">Разходи</a>
<form method="POST">
    <div>Дата (напр. 20.09.2013):<input type="text" name="data" /></div>
    <div>Име на разхода:<input type="text" name="razhodName" /></div>
    <div>Сума на разхода:<input type="text" name="amount" /></div>
    <div>
        <select name="group">
            <?php
            if (in_array("All", $groups)) array_pop($groups);
            
            foreach ($groups as $key=>$value) {
                echo '<option value="'.$key.'">' . $value .
                        '</option>';
            }
            ?>
        </select>           
    </div>        
    <div><input type="submit" value="Добави" /></div>
</form>
<?php
include '..\includes\footer.php';
?>