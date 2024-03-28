<?php

require 'connectionsettings.php';
//variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully, now we will show the users.<br><br>";
$sql = "SELECT username FROM users WHERE username = '". $loginUser ."'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
 //tell the user the username alrdy exists
 echo "Userame already exists";
  }
 else {
  echo "Creating user... <br>";
  //insert the user and password into the database
  $sql2 = "INSERT INTO users (username, password, level, coins) VALUES ('" . $loginUser ."', '" . $loginPass ."', 1, 0 )";
  if ($conn->query($sql2) === TRUE) {
    echo "User created successfully";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}
$conn->close();
?>