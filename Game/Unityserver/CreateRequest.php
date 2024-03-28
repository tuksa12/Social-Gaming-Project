<?php
require 'connectionsettings.php';

//variables submitted by user
$sellerID = $_POST["sellerID"];
$buyerID = $_POST["buyerID"];
$itemID = $_POST["itemID"];

// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
else{
//echo "Connected successfully, now we will show the users.<br><br>";
//$sql = "SELECT username FROM users WHERE username = '". $loginUser ."'";

//$result = $conn->query($sql);
  //insert the user and password into the database
  echo "Creating request.. <br>";
  $sql2 = "INSERT INTO tradingrequests (sellerID, buyerID, itemID) VALUES ('" . $sellerID ."' , '" . $buyerID ."', '" . $itemID ."')";
  if ($conn->query($sql2) === TRUE) {
    echo "request created";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}

$conn->close();
?>