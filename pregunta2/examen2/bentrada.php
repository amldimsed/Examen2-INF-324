<?php
include "conexion.inc.php";
session_start();
$usuario=$_SESSION["usuario"];
$sql="select * from flujotramite ";
$sql.="where usuario='".$usuario."' and fecha_fin is not null";
$resultado=mysqli_query($con, $sql);
//$resultado=mysqli_query($sql, $con);

echo $usuario=$_SESSION["usuario"];
?>
<table>
<tr>
	<td>Flujo</td>
	<td>proceso</td>
	<td>No.tramite</td>
	<td>fecha inicial</td>
	<td>fecha final</td>
	<td>Ir</td>
</tr>
<?php 
while ($fila=mysqli_fetch_array($resultado))
{
  echo "<tr>";
  echo "<td>".$fila["flujo"]."</td>";
  echo "<td>".$fila["proceso"]."</td>";
  echo "<td>".$fila["nro_tramite"]."</td>";
  echo "<td>".$fila["fecah_ini"]."</td>";
  echo "<td>".$fila["fecha_fin"]."</td>";
  echo "<td><a href='flujo.php?flujo=".$fila["flujo"]."&proceso=".$fila["proceso"]."&nro_tramite=".$fila["nro_tramite"]."'>Ir</td>";
  echo "</tr>";
}
?>
</table>