<?php
$usuario=$_GET["usuario"];
$contrasenia=$_GET["contrasenia"];
if ($usuario=='jorge' and $contrasenia=='123456')
{
	session_start();
	$_SESSION["usuario"]=$usuario;
	$_SESSION["rol"]='usuario';
	header("Location: bentrada.php");
	exit;
}
if ($usuario=='maria' and $contrasenia=='123456')
{
	session_start();
	$_SESSION["usuario"]=$usuario;
	$_SESSION["rol"]='usuario';
	header("Location: bentrada.php");
	exit;
}
if ($usuario=='Romina' and $contrasenia=='123456')
{
	session_start();
	$_SESSION["usuario"]=$usuario;
	$_SESSION["rol"]='kardex';
	header("Location: bentrada.php");
	exit;
}
header("Location: index.php");
?>