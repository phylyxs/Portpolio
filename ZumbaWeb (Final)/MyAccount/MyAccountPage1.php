<?php
include_once 'database.php';
$result = mysqli_query($conn,"SELECT * FROM members");
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MyAccount</title>
    <link rel="stylesheet" href="MyAccountStyle.css">
    <!--Call the Header and Footer-->
    <script src="../Header and Footer/main.js"></script>   
</head>
<body>
  <?php
  $i=0;
  while($row = mysqli_fetch_array($result)){
    $id = $row["id"];
    $fname = $row["fname"];
    $lname = $row["lname"];
    $phone = $row["phone"];
    $email = $row["email"];
    $DOB = $row["DOB"];
    $conType = $row["conType"];
  }
  ?>
  <div id="content"> 
    <div id="empty-space"></div>
    
  
    <div class="row">
      <div class="column left">
        <p class="p1"><img src=".\MyAccount pictures\user1.png">
          <h2>Membership Details</h2><br></p>

        <p><strong>Membership</strong>
          <br>Adult Dance</p><br>

        <p><strong>Member ID</strong>
          <br><?=$id?></p><br>

        <p><strong>Member Start Date</strong>
          <br>23/02/2020</p><br>

        <p><strong>Tutor</strong>
          <br>Davey</p><br>

        <p><strong>Class Time</strong>
          <br>Tuesday 5:30pm
          <br>Thursday 5:30pm
        </p> 
      </div>
    </div>
    
    
    <div class="row">
      <div class="column right">
        <p><h2>Name</h2><br></p>
        <p><h3><?=$fname?> <?=$lname?></h3><br></p>
        <br>
        <p><h2>Phone</h2><br></p>
        <p><h3><?=$phone?></h3><br></p>
        <br>
        <p><h2>Email</h2><br></p>
        <p><h3><?=$email?></h3><br></p>
        <br>
        <p><h2>DOB</h2><br></p>
        <p><h3><?=$DOB?></h3><br></p>
        <br>
        <p><h2>Concession</h2><br></p>
        <p><h3>Left: <?=$conType?></h3><br></p>
        <br>
    
      </div>
    </div>
  </div>
</body>
</html>