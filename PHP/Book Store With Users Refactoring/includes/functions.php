<?php
require 'constants.php';

$connection = mysqli_connect('localhost', 'gatakka', 'qwerty', 'books');
if(!$connection){
    echo 'No Database';
}
mysqli_set_charset($connection,'utf8');

function checkLogin($connection, $username, $password){
    $selectUP = 'SELECT user_id 
                 FROM users
                 WHERE username=? AND password=?';
    
    $stmtUP = mysqli_prepare($connection, $selectUP);
    mysqli_stmt_bind_param($stmtUP, 'ss', $username,$password);
    mysqli_stmt_execute($stmtUP);
    mysqli_stmt_bind_result($stmtUP, $user_id);
    mysqli_stmt_fetch($stmtUP);
    
    return $user_id;
}

function insertUser($connection, $username, $password){
    $updateUP = 'INSERT INTO users (username, password) 
                 VALUES ("'.$username.'","'.$password.'")';
    $result = mysqli_query($connection, $updateUP);
    if (!$result){
        echo 'Error while saving the user';
        echo mysqli_error($connection);
        return false;
    }
    return true;
}

function getAuthors($connection){
    $selectA = 'SELECT * FROM authors';
    $result = mysqli_query($connection, $selectA);
    
    return $result;
}

function insertAuthor($connection, $authorName){
    $updateA = 'INSERT INTO authors (author_name) VALUES ("'.$authorName.'")';
    $result = mysqli_query($connection, $updateA);
    if (!$result){
        echo 'Error while saving the authors';
        echo mysqli_error($connection);
        return false;
    }
    
    return true;
}

function insertBook($connection, $bookName, $bookAllAuthors, $bookAuthorsID){
    foreach ($bookAllAuthors as $currentAuthor){
            if (!in_array($currentAuthor, $bookAuthorsID)) array_push($bookAuthorsID, $currentAuthor);
    }
    
    $updateB = 'INSERT INTO books (book_title) VALUES ("'.$bookName.'")';
    $result = mysqli_query($connection, $updateB);
    if (!$result){
        echo 'Error while saving the book';
        echo mysqli_error($connection);
        return false;
    }
    
    $book_id = mysqli_insert_id($connection);
    $tempID = $bookAuthorsID[0] + 1;
    $updateBA = 'INSERT INTO books_authors (book_id, author_id) VALUES ("'.$book_id.'","'.$tempID.'")';

    for($i = 1; $i < sizeof($bookAuthorsID); $i++){
        $tempID = $bookAuthorsID[$i] + 1;
        $updateBA = $updateBA.',("'.$book_id.'","'.$tempID.'")';    
    }
    
    $result = mysqli_query($connection, $updateBA);
    if (!$result){
        echo 'Error while saving the book';
        echo mysqli_error($connection);
        return false;
    }
    
    return true;
}

function insertComment($connection, $book_id, $addNewComment, $username){
    $updateUC ='INSERT INTO comments (comment_name) VALUES ("'.$addNewComment.'")';
    $result = mysqli_query($connection, $updateUC);
    if (!$result){
        echo 'Error while saving the comment';
        echo mysqli_error($connection);
        return false;
    }
    
    $comment_id = mysqli_insert_id($connection);
    $updateCB = 'INSERT INTO comments_books (comment_id, book_id, user_id)
                 VALUES ("'.$comment_id.'","'.$book_id.'","'.$username.'")';
    $result = mysqli_query($connection, $updateCB);
    if (!$result){
        echo 'Error while saving the comment';
        echo mysqli_error($connection);
        return false;
    }
    
    return true;
}

function getUsers($connection, $whereClause){
    $selectUC = 'SELECT books.book_title, comments.comment_name, books.book_id, comments.comment_id, comments.comment_date, users.user_id, users.username
                 FROM books
                 JOIN comments_books ON books.book_id = comments_books.book_id
                 JOIN comments ON comments.comment_id = comments_books.comment_id
                 JOIN users ON comments_books.user_id = users.user_id ';
    $selectUC = $selectUC . $whereClause . 'ORDER BY comments.comment_date DESC , books.book_title';
    
    $usersComments = mysqli_query($connection, $selectUC);
    if(!$usersComments){
        echo 'Error in Data Fetching';
        echo mysqli_error($connection);
        return false;
    }
    if($usersComments->num_rows <= 0) return false;
    
    while($singleRecord = mysqli_fetch_assoc($usersComments)){
        $usersCommentsArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_name'][] = $singleRecord['comment_name'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_id'][] = $singleRecord['comment_id'];
        $usersCommentsArray[$singleRecord['book_title']]['comment_date'][] = $singleRecord['comment_date'];
        $usersCommentsArray[$singleRecord['book_title']]['book_id'] = $singleRecord['book_id'];
        $usersCommentsArray[$singleRecord['book_title']]['user_id'] = $singleRecord['user_id'];
        $usersCommentsArray[$singleRecord['book_title']]['username'] = $singleRecord['username'];
    }
    
    return $usersCommentsArray;
}

function makeSQLGet($getParam){
    require 'constants.php';
        
    $selectAB = $selectAB.'WHERE books.book_title in (SELECT books.book_title FROM books
                                                      LEFT JOIN books_authors ON books.book_id = books_authors.book_id
                                                      LEFT JOIN authors ON authors.author_id = books_authors.author_id ';
    
    if(isset($getParam['book'])) $whereClause = 'WHERE books.book_id='.$getParam['book'].')';
    else if (isset($getParam['author'])) $whereClause = 'WHERE authors.author_id='.$getParam['author'].')';
    else $whereClause ='';
    
    $selectAB = $selectAB.$whereClause;
    
    return $selectAB;
}

function makeSQLPost(){
    require 'constants.php';
        
    $selectAB = $selectAB.'WHERE books.book_title in (SELECT books.book_title FROM books
                                                      LEFT JOIN books_authors ON books.book_id = books_authors.book_id
                                                      LEFT JOIN authors ON authors.author_id = books_authors.author_id)';        
    return $selectAB;
}

function addFiltersToSQLPost($connection, $postParam, $selectAB){   
    $bookName = paramVerify($connection, $postParam['book']);
    if($bookName != "") $selectAB = $selectAB.'AND books.book_title="'.$bookName.'"';
    
    if ($postParam['bookFilter'] == 1) $sortParamBook = ' ORDER BY books.book_title ASC';
    else if ($postParam['bookFilter'] == 2) $sortParamBook = ' ORDER BY books.book_title DESC';
    else $sortParamBook='';
    
    if ($postParam['authors'] == 1){
        if ($sortParamBook) $sortParamAuthor = ',authors.author_name ASC';
        else $sortParamAuthor = ' ORDER BY authors.author_name ASC';
    }
    else if ($postParam['authors'] == 2){
        if ($sortParamBook) $sortParamAuthor = ',authors.author_name DESC';
        else $sortParamAuthor = ' ORDER BY authors.author_name DESC';
    }
    else $sortParamAuthor='';   
    
    $selectAB = $selectAB.$sortParamBook.$sortParamAuthor;
    
    return $selectAB;
}

function getBookAuthors($connection, $selectAB){       
    $allData = mysqli_query($connection, $selectAB);
    if(!$allData){
        echo 'Error in Data Fetching';
        echo mysqli_error($connection);
        return false;
    }
    if($allData->num_rows <= 0) return false;
    
    while($singleRecord = mysqli_fetch_assoc($allData)){
        $allDataArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
        $allDataArray[$singleRecord['book_title']]['author_name'][] = $singleRecord['author_name'];
        $allDataArray[$singleRecord['book_title']]['author_id'][] = $singleRecord['author_id'];
        $allDataArray[$singleRecord['book_title']]['book_id'][] = $singleRecord['book_id'];
    }
    
    return $allDataArray;
}

function getBookComments($connection){    
    $selectBC = 'SELECT books.book_title, comments.comment_name, comments.comment_date, users.user_id, users.username
                 FROM books
                 JOIN comments_books ON books.book_id = comments_books.book_id
                 JOIN comments ON comments.comment_id = comments_books.comment_id
                 JOIN users ON comments_books.user_id = users.user_id
                 ORDER BY comments.comment_date DESC , books.book_title';

    $commentsData = mysqli_query($connection, $selectBC);
    if(!$commentsData){
        echo 'Error in Data Fetching';
        echo mysqli_error($connection);
        return false;
    }

    while($singleRecord = mysqli_fetch_assoc($commentsData)){
        $commentsDataArray[$singleRecord['book_title']]['book_title'] = $singleRecord['book_title'];
        $commentsDataArray[$singleRecord['book_title']]['comment_name'][] = $singleRecord['comment_name'];
        $commentsDataArray[$singleRecord['book_title']]['comment_date'][] = $singleRecord['comment_date'];
        //$commentsDataArray[$singleRecord['book_title']]['book_id'][] = $singleRecord['book_id'];
        //$commentsDataArray[$singleRecord['book_title']]['comment_id'][] = $singleRecord['comment_id'];
        $commentsDataArray[$singleRecord['book_title']]['user_id'][] = $singleRecord['user_id'];
        $commentsDataArray[$singleRecord['book_title']]['username'][] = $singleRecord['username'];
    }
    
    return $commentsDataArray;
}

function paramVerify($connection, $param){ 
    $result = trim($param);
    $result = mysqli_real_escape_string($connection,$result);
    
    return $result;
}

function validateString($param, $minLength, $maxLength){
    if(mb_strlen($param) < $minLength){
            echo '<p>'.$param.' is too short</p>';
            return false;
    }
    else if (mb_strlen($param) > $maxLength){
            echo '<p>'.$param.' is too long</p>';
            return false;
    }
    
    return true;
}

?>