<?php

require 'connectionsettings.php';
//variables submitted by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];



// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully, now we will show the users.<br><br>";
$sql = "SELECT password, id FROM users WHERE username = '". $loginUser ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row 
  while($row = $result->fetch_assoc()) {
    if($row["password"] == $loginPass)
    {
        echo $row["id"];
    }
    else {
echo "Wrong Password";
    }
  }
} else {
  echo "Username does not exist";
}
$conn->close();
?>