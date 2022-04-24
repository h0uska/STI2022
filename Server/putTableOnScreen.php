<?php
    $fn = fopen("historie_meny.txt","r");
    echo '<table>';
        echo '<tr>';
        echo '  <th>Date </th>';
        echo '  <th>Exchange </th>';
        echo '</tr>';   
    while(! feof($fn))  
    {
        $line = fgets($fn);
        
        $tmp = explode(';', $line);
        $neededDate = trim($tmp[0]);
        $neededAmmount = trim($tmp[1]);
        $neededCode = trim($tmp[2]);
        $neededExchange = trim($tmp[3]);
        // put echo data on page in table
        echo '<tr><td>' . $neededDate . '</td><td>' . $neededExchange . '</td></tr>';
    }
    echo '</table>';
    fclose($fn);
?>