<?php
require 'connectionsettings.php';

//variables submitted by user
$itemID = $_POST["itemID"];
$userID = $_POST["userID"];
// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

//$result = $conn->query($sql);
  //insert the user and password into the database
  
  $sql2 = "INSERT INTO usersitems (userID, itemID) VALUES ('" . $userID ."' , '" . $itemID ."')";
  if ($conn->query($sql2) === TRUE) {
    echo "Ressource Gathered! <br>";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }


$conn->close();
?>