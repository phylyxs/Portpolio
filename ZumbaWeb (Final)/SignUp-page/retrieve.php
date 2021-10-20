<?php
include_once 'database.php';
$result = mysqli_query($conn,"SELECT * FROM members");
?>

<?php
$i=0;
while($row = mysqli_fetch_array($result)) {
if($i%2==0)
$classname="even";
else
$classname="odd";
?>
<tr class="<?php if(isset($classname)) echo $classname;?>">
<td><?php echo $row["id"]; ?></td>
<td><?php echo $row["fname"]; ?></td>
<td><?php echo $row["lname"]; ?></td>
<td><?php echo $row["phone"]; ?></td>
<td><?php echo $row["email"]; ?></td>
<td><?php echo $row["DOB"]; ?></td>
<td><?php echo $row["conType"]; ?></td>
</tr>



<?php
$i++;
}
?>
<!DOCTYPE html>
<html>
<head>
<title> Retrive data</title>
</head>
<body>
<table>
<tr>
<td>Member ID</td>
<td>First Name</td>
<td>Last Name</td>
<td>Phone No</td>
<td>Email</td>
<td>Date of Birth</td>
<td>Concession Type</td>
</tr>

</table>
</body>
</html> 