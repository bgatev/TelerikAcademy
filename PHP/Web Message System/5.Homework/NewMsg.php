<?php
session_start();
mb_internal_encoding('UTF-8');
$pageTitle='Input Message';
include '..\includes\header.php';

function IsDate($Str)
{
  $is_valid = date('d.m.Y', strtotime($Str)) == $Str;
  
  return $is_valid;
}

if($_SESSION['isLogged']){
    if($_POST){
        $date = trim($_POST['date']);
        $date = mysqli_real_escape_string($connection,$date);
        $msgtitle = trim($_POST['title']);
        $msgtitle = mysqli_real_escape_string($connection,$msgtitle);
        $msgtext = trim($_POST['text']);
        $msgtext = mysqli_real_escape_string($connection,$msgtext);
        $error = false;
       
        if(!IsDate($date)){
            echo '<p>Невалидна дата</p>';
            $error = true;
        }
        else $date = date("Y-m-d H:i:s",strtotime($date));
               
        if(mb_strlen($msgtitle) < 1){
            echo '<p>Message title is too short</p>';
            $error = true;
        }
        else if(mb_strlen($msgtitle) > 50){
            echo '<p>Message title is too long</p>';
            $error = true;
        }
        
        if(mb_strlen($msgtext) < 1){
            echo '<p>Message is too short</p>';
            $error = true;
        }   
        else if(mb_strlen($msgtext) > 250){
            echo '<p>Message is too long</p>';
            $error = true;
        } 
        
        $updateMsg = 'INSERT INTO messages (msg_date, msg_title,msg_text) 
                      VALUES ("'.$date.'","'.$msgtitle.'","'.$msgtext.'")';
        
        if(!$error){
            if (!mysqli_query($connection, $updateMsg)){
                echo 'Error while saving the message';
            }
            
            $msg_id = mysqli_insert_id($connection);
            $group_id = ($_POST['group'] + 1);
            $updateMsgsGroups = 'INSERT INTO msgsgroups (msg_id, group_id) 
                                 VALUES ("'.$msg_id.'","'.$group_id.'")';            
            if (!mysqli_query($connection, $updateMsgsGroups)){
                echo 'Error while saving the group';
                echo mysqli_error($connection);
            }
            
            $user_id = $_SESSION['username'];
            $updateUsersMsgs = 'INSERT INTO usersmsgs (user_id,msg_id) 
                                VALUES ("'.$user_id.'","'.$msg_id.'")';
            if (!mysqli_query($connection, $updateUsersMsgs)){
                echo 'Error while saving the user message property';
                echo mysqli_error($connection);
            }
            
            header('Location: messages.php');
            exit;
        } 
    }
}
else
{
    header('Location: index.php');
    exit;
}

?>

<form method="POST" enctype="multipart/form-data">
    <div>Дата (напр. 20.09.2013):<input type="text" name="date" /></div>
    <div>Message Title:<input type="text" name="title" /></div>
    <textarea id="text" name="text"></textarea>
    <div>
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
                echo '<option value="'.$key.'">' . $value['groupname'] . '</option>';
            }
            ?>
        </select>           
    </div>       
    <div><input type="submit" value="Добави" /></div>
</form>

<?php
include '..\includes\footer.php';
?>