<?php
    // parse last line from file
    $tmp = explode(';', $line);
    $neededDate = trim($tmp[0]);
    $neededAmmount = trim($tmp[1]);
    $neededCode = trim($tmp[2]);
    $neededExchange = trim($tmp[3]);
?>