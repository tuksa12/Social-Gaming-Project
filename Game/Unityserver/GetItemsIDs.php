<?php

require 'connectionsettings.php';

//user submitted variable
$userID = $_POST["userID"];

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully, now we will show the users.<br><br>";
$sql = "SELECT ID, itemID FROM usersitems WHERE userID = '". $userID ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    //we create a new array
    $rows = array();
  // output data of each row
  while($row = $result->fetch_assoc()) {
    //echo "username: " . $row["username"]. " - level: " . $row["level"]. "<br>";
    //each row of result is going into the newly created array 
    $rows[] = $row;
  }
  //after the array is created
  echo json_encode($rows);
} else {
  echo "0";//means false
}
$conn->close();
?>