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

$sql = "SELECT ID, Size, Description, Vacancy, Price FROM room";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    $rows = array();
    while($row = $result->fetch_assoc()) {
        $rows[] = $row;
    }
  
    echo json_encode($rows);
  
} else {
    echo "0";
}

$conn->close();
?>