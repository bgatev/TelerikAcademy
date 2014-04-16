<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Messages';
include '..\includes\header.php';

?>
<a href="NewMsg.php">New Message</a>

<form method="POST">
<select name="group">
            <?php
            $selectGrps = 'SELECT groupname FROM groups';
            $allGroups = mysqli_query($connection, $selectGrps);
            if(!$allGroups){
                echo 'Invalid Group';
                header('Location: index.php');
                exit;
            }

            while($currentGroup = $allGroups->fetch_assoc()){
                if (!in_array($currentGroup, $groups)) array_push($groups, $currentGroup);
            }

            foreach ($groups as $key=>$value) {
                $selected = ' ';
                if (isset($_POST['group']) && $_POST['group'] == $key) $selected = ' selected ';
                echo '<option'.$selected.'value="'.$key.'">' . $value['groupname'] . '</option>';
            }
            ?>
        </select>
<select name="date">
            <?php
            foreach ($dateOrder as $key=>$value) {
                $selected = ' ';
                if (isset($_POST['date']) && $_POST['date'] == $key) $selected = ' selected ';
                echo '<option'.$selected.'value="'.$key.'">' . $value . '</option>';
            }
            ?>
        </select>  
<input type="submit" value="Филтрирай" />
</form>

<?php
if($_SESSION['isLogged']){
    if($_POST){
        $selectAllData = 'SELECT messages.msg_date,users.username,messages.msg_title,messages.msg_text,groups.groupname,groups.group_id
                         FROM users,messages,groups,msgsgroups,usersmsgs
                         WHERE users.user_id = usersmsgs.user_id AND messages.msg_id = usersmsgs.msg_id
                         AND groups.group_id = msgsgroups.group_id AND messages.msg_id = msgsgroups.msg_id
                         ORDER BY messages.msg_date ';
        
        if ($_POST['date'] == 1){
            $sortParam = 'ASC';
        }
        else if ($_POST['date'] == 2) $sortParam = 'DESC';
        
        $selectAllData = $selectAllData.$sortParam;

        $allMsgs = mysqli_query($connection, $selectAllData);
        if(!$allMsgs){
            echo 'Error in Data Fetch';
            exit;
        }
        if($allMsgs->num_rows > 0){
            echo '<table><tr><td>Дата</td><td>Потребител</td><td>Заглавие</td><td>Текст</td><td>Група</td></tr>';
            while($currentMsg=$allMsgs->fetch_assoc()){
                if ($currentMsg['group_id'] == (int)$_POST['group'] + 1){
                    echo '<tr><td>'.$currentMsg['msg_date'].'</td>
                        <td>'.$currentMsg['username'].'</td>
                        <td>'.$currentMsg['msg_title'].'</td>
                        <td>'.$currentMsg['msg_text'].'</td>
                        <td>'.$currentMsg['groupname'].'</td></tr>';
                }
            }
            echo '</tr>';
        }
        else echo 'No results'; 
    }
}
else
{
    header('Location: index.php');
    exit;
}
?>

<?php
include '..\includes\footer.php';
?>