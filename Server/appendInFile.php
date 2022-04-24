<?php
    // append in file
    $stringToAppend = $neededDate . ";" . $neededAmmount . ";" . $neededCode . ";" . $neededExchange;
    if (strcmp($stringToAppend, $line) !== 0) 
    {
        $fp = fopen('historie_meny.txt', 'a');//opens file in append mode  
        fwrite($fp, "\n"); 
        fwrite($fp, $stringToAppend);  
        fclose($fp);
    }
?>