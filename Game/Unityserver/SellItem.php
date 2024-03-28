<?php

require 'connectionsettings.php';

//variables submitted by user
//$loginUser = $_POST["loginUser"];
//$loginPass = $_POST["loginPass"];
$ID = $_POST["ID"];
$itemID = $_POST["itemID"];
$userID = $_POST["userID"];
// Create connection


// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//get the price from the items table
$sql = "SELECT price FROM items WHERE ID = '". $itemID ."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    //store item price
    $itemPrice = $result -> fetch_assoc()["price"];
  // second sql (delete item)
  $sql2 = "DELETE FROM usersitems WHERE ID = '". $ID ."'" ;

  $result2 = $conn->query($sql2);
  //this means if the query was successful aka if we deleted the item
  if($result2)
  {
    $sql3= "UPDATE `users` SET `coins` = coins + '" . $itemPrice ."' WHERE `id` = '". $userID ."'";
    $conn -> query($sql3);
    echo "Item sold successfully, you have now received : '" . $itemPrice ."' ";

  }
  else {
echo "error: couldn't delete the item.";
  }
}
  else {
    echo '0';
  }

$conn -> close();
?>