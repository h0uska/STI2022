<?php
    //parse data from web
    $tmp = explode('#', $html);
    $neededDate = trim($tmp[0]);
    $tmp = explode('|', $html);
    $neededAmmount = trim($tmp[26]);
    $neededCode = trim($tmp[27]);
    $neededExchangeWithF = trim($tmp[28]);
    $tmp = explode('F', $neededExchangeWithF);
    $neededExchange = trim($tmp[0]);
?>