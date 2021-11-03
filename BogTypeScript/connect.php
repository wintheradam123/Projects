<?php
$conn = new mysqli("localhost", "root", "", "forfattereogboeger");

if($conn) {
    echo "Søgt!";
} else {
    echo "Error";
}
// mysql_connect('localhost','root','');
// mysql_select_db('forfattereogboeger');
?>