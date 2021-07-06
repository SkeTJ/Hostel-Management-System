<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "hostelmanagementsystem";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

//echo "Connected Succesfully.";

//Variables submitted by user
$roomID = $_POST["roomID"];

$path = "http://localhost/HostelManagementDatabase/RoomImages/" . $roomID . ".jpg";
$image = file_get_contents($path);

echo($image);

$conn->close();

?>