<?php

    //download data
    $html = file_get_contents('https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=51434B515C33C368A4D0DE79932EF99C?date=DD.MM.RRRR');
    
    //parse data from web
    $tmp = explode('#', $html);
    $neededDate = trim($tmp[0]);
    $tmp = explode('|', $html);
    $neededAmmount = trim($tmp[26]);
    $neededCode = trim($tmp[27]);
    $neededExchangeWithF = trim($tmp[28]);
    $tmp = explode('F', $neededExchangeWithF);
    $neededExchange = trim($tmp[0]);
    
    // find last line in file
    $line = '';
    $f = fopen('historie_meny.txt', 'r');
    $cursor = -1;
    fseek($f, $cursor, SEEK_END);
    $char = fgetc($f);
    while ($char === "\n" || $char === "\r") {
        fseek($f, $cursor--, SEEK_END);
        $char = fgetc($f);
    }
    while ($char !== false && $char !== "\n" && $char !== "\r") {
        $line = $char . $line;
        fseek($f, $cursor--, SEEK_END);
        $char = fgetc($f);
    }
    fclose($f);
    $line = substr_replace($line ,"",-1);
    
    // append in file
    $stringToAppend = $neededDate . ";" . $neededAmmount . ";" . $neededCode . ";" . $neededExchange;
    if (strcmp($stringToAppend, $line) !== 0) 
    {
        $fp = fopen('historie_meny.txt', 'a');//opens file in append mode  
        fwrite($fp, "\n"); 
        fwrite($fp, $stringToAppend);  
        fclose($fp);
    }
    
    // find last line in file
    $line = '';
    $f = fopen('historie_meny.txt', 'r');
    $cursor = -1;
    fseek($f, $cursor, SEEK_END);
    $char = fgetc($f);
    while ($char === "\n" || $char === "\r") {
        fseek($f, $cursor--, SEEK_END);
        $char = fgetc($f);
    }
    while ($char !== false && $char !== "\n" && $char !== "\r") {
        $line = $char . $line;
        fseek($f, $cursor--, SEEK_END);
        $char = fgetc($f);
    }
    fclose($f);
    $line = substr_replace($line ,"",-1);
    
    // parse last line from file
    $tmp = explode(';', $line);
    $neededDate = trim($tmp[0]);
    $neededAmmount = trim($tmp[1]);
    $neededCode = trim($tmp[2]);
    $neededExchange = trim($tmp[3]);
    
    // count and put echo data on page
    echo "exchange rate of " . $neededAmmount . " " . $neededCode . " to CZK is " . $neededExchange . " (" . $neededDate . ")";
?>