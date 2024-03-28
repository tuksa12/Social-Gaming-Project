<?php

require 'connectionsettings.php';

//variables submitted by user
//$loginUser = $_POST["loginUser"];
//$loginPass = $_POST["loginPass"];
$userID = $_POST["userID"];
$coins = $_POST["coins"];



// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
$sql = "UPDATE `users` SET `coins` = coins + '" . $coins ."' WHERE `id` = '". $userID ."'";
$result = $conn->query($sql);
    echo "Enemy slain, coins received : '" . $coins ."' ";


$conn -> close();
?>