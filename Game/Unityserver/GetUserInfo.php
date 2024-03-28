<?php

require 'connectionsettings.php';
//variables submitted by user
$loginUser = $_POST["userID"];
//$loginPass = "firstpassword";



// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully, now we will show the users.<br><br>";
$sql = "SELECT username, level,coins FROM users WHERE username = '". $loginUser ."'";
$result = $conn->query($sql);
$rows = array();
if ($result->num_rows > 0) {
  // output data of each row 
  while($row = $result->fetch_assoc()) {
    $rows[] = $row;
  }
  echo json_encode($rows);
}
  
 else {
  echo "Username does not exist";
}
$conn->close();
?>