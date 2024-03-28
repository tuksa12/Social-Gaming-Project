<?php
require 'connectionsettings.php';

//variables submitted by user
$guildName = $_POST["guildName"];
// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
$sql = "SELECT name FROM guilds WHERE name =  '". $guildName ."'";
$result = $conn->query($sql);
//TO-DO : check if the username typed anything because empty names shouldnt be allowed
if($result -> num_rows > 0)
{
    echo "Guild name not available";
}
else if($guildName == "")
{
    echo "Empty string can't be a name";
}
else{
//echo "Connected successfully, now we will show the users.<br><br>";
//$sql = "SELECT username FROM users WHERE username = '". $loginUser ."'";

//$result = $conn->query($sql);
  //insert the user and password into the database
  echo "Creating Guild... <br>";
  $sql2 = "INSERT INTO guilds (name, guildlevel) VALUES ('" . $guildName ."' , 1)";
  if ($conn->query($sql2) === TRUE) {
    echo "guild created successfully";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}

$conn->close();
?>