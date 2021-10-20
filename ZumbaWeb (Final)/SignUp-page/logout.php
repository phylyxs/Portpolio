<?php
	session_start();
 	$_SESSION = array();
    session_destroy(); //this destroys the current session which is the login.php
	
	/*header("location: index.php");*/
	header("location: SignUp.php");
?>