<?php
// $sql = "SELECT boeger.Titel FROM boeger WHERE boeger.Titel =".$_POST['soegtitel']
// $result = mysqli_query($sql);    .$_POST['formData.soegtitel']
require 'connect.php';
$data = json_decode(file_get_contents("php://input"));
$titel = (!empty($data->soegtitel)) ?$data->soegtitel:"err";
$forfatter = (!empty($data->soegforfatter)) ?$data->soegforfatter:"err";
echo $titel;
if ($conn) {

    $sql = "SELECT Titel FROM boeger WHERE Titel LIKE '".$titel."'";
    $result = mysqli_query($conn, $sql);
    if(mysqli_num_rows($result) > 0){
        while ($row = mysqli_fetch_assoc($result)){
            echo $row['Titel'];
        }     
    }else {
        echo "Intet Resultat";
    }
}else {
    echo "Ingen forbindelse";
}

?>