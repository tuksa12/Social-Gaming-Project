<?php
require 'connectionsettings.php';

//variables submitted by user
$guildName = $_POST["guildName"];
$userID = $_POST["userID"];
// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
$sql = "SELECT name FROM guilds WHERE name =  '". $guildName ."'";
$result = $conn->query($sql);
//TO-DO : check if the username typed anything because empty names shouldnt be allowed
if($guildName == "")
{
    echo "Empty string can't be a name";
}
else if($result -> num_rows > 0)
{
 

//echo "Connected successfully, now we will show the users.<br><br>";
//$sql = "SELECT username FROM users WHERE username = '". $loginUser ."'";

//$result = $conn->query($sql);
  //insert the user and password into the database
  echo "joining Guild... <br>";

  $sql2 = "SELECT ID FROM guilds WHERE name = '". $guildName ."'";
  $result2 = $conn -> query($sql2);
  $resultID = $result2-> fetch_assoc()["ID"];
  $sql3= "UPDATE `users` SET `guildID` =  '". $resultID ."'  WHERE `id` = '". $userID ."'";
   $conn -> query($sql3);
    echo "You have successfully joined the Guild";  
    }
    else{
        echo "Guild Doesn't exist";
    }
  



$conn->close();