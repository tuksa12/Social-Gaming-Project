<?php
require 'connectionsettings.php';

//variables submitted by user
//$loginUser = $_POST["loginUser"];
//$loginPass = $_POST["loginPass"];
$userID = $_POST["userID"];

// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

//echo "Connected successfully, now we will show the users.<br><br>";
$sql = "SELECT FriendID FROM friendship WHERE userID = '". $userID ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  
 $rows = array();
 while($row = $result->fetch_assoc()) {//$row will get every row that result got
    
    $rows[] = $row;
  } 
  echo json_encode($rows);//it will print each result because this time its an array not one result
}
   else {
  echo "0";//means friend doesnt exist
}       




$conn->close();
?>