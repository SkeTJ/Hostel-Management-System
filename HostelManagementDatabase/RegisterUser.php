<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "hostelmanagementsystem";

//Variables submitted by User
$registerUser = $_POST["registerUser"];
$registerPassword = $_POST["registerPassword"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

echo "Connected Succesfully.";

$sql = "SELECT Username FROM user WHERE Username = '" . $registerUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "Username already exists.";
} 

else 
{
    echo "Creating user...";
    //Insert new user into the database.
    $sql2 = "INSERT INTO user (Username, Password, isStaff) VALUES ('" . $registerUser . "', '" . $registerPassword . "', 0)";
    if ($conn->query($sql2) === TRUE) 
    {
        echo "New record created successfully";
    } 

    else 
    {
        echo "Error: " . $sql2 . "<br>" . $conn->error;
    }
}

$conn->close();
?>