<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "hostelmanagementsystem";

//Variables submitted by User
$loginUser = $_POST["loginUser"];
$loginPassword = $_POST["loginPassword"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

//echo "Connected Succesfully.";

$sql = "SELECT Password, ID, isStaff FROM user WHERE Username = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) 
{
  // output data of each row
  while($row = $result->fetch_assoc()) 
  {
    if($row["Password"] == $loginPassword)
    {
        echo $row["ID"];
        echo "\n";
        echo $row["isStaff"];
    }

    else
    {
        echo "Wrong Username/Password.";
    }
  }
} 
else 
{
  echo "Username does not exists.";
}

$conn->close();
?>