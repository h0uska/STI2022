<?php
    class functions
    {
        
        public function getTime()
        {
            date_default_timezone_set('Europe/Prague');
            $date = date('H:i', time());
            return $date;
        }
        
        
        public function getServerName()
        {
            return $_SERVER['SERVER_NAME'];
        }
        
        
        public function getData($url)
        {
            $html = file_get_contents($url);
            return $html;
        }
        
        
        public function parseDownloadedData($html)
        {
            //parse data from web
            $myarray = array();
            $tmp = explode('#', $html);
            $myarray[0] = trim($tmp[0]); //neededDate
            $tmp = explode('|', $html);
            $myarray[1] = trim($tmp[26]); //neededAmmount
            $myarray[2] = trim($tmp[27]); //neededCode
            $neededExchangeWithF = trim($tmp[28]); //neededExchangeWithF
            $tmp = explode('F', $neededExchangeWithF);
            $myarray[3] = trim($tmp[0]); //neededExchange
            return $myarray; //neededDate, neededAmmount, neededCode, neededExchange
        }
        
        
        public function getLastLineInFile($soubor)
        {
            $line = '';
            $f = fopen($soubor, 'r');
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
            return $line;
        }
        
        
        public function appendDataInFile($myarray, $line, $soubor)
        {
            $stringToAppend = $myarray[0] . ";" . $myarray[1] . ";" . $myarray[2] . ";" . $myarray[3];
            if (strcmp($stringToAppend, $line) !== 0) 
            {
                $fp = fopen($soubor, 'a');//opens file in append mode  
                fwrite($fp, "\n"); 
                fwrite($fp, $stringToAppend);  
                fclose($fp);
                return true;
            }
            return false;
        }
        
        
        public function parseLine($line, $char)
        {
            //parse line ';'
            $myarray2 = array();
            $tmp = explode($char, $line);
            $myarray2[0] = trim($tmp[0]); //neededDate
            $myarray2[1] = trim($tmp[1]); //neededAmmount
            $myarray2[2] = trim($tmp[2]); //neededCode
            $myarray2[3] = trim($tmp[3]); //neededExchange
            return $myarray2; //neededDate, neededAmmount, neededCode, neededExchange
        }
        
        
        public function createTable($soubor)
        {
            $dataInTable = "";
            $fn = fopen($soubor,"r");
            echo '<table>';
            echo '<tr>';
            echo '  <th>Date </th>';
            echo '  <th>Exchange </th>';
            echo '</tr>';   
            while(! feof($fn))  
            {
                $line = fgets($fn);
                $myarray2 = array();
                $myarray2 = $this->parseLine($line,';'); //neededDate, neededAmmount, neededCode, neededExchange
                echo '<tr><td>' . $myarray2[0] . '</td><td>' . $myarray2[3] . '</td></tr>';
                $dataInTable = $dataInTable . $myarray2[0].';'. $myarray2[3] .';';
            }
            echo '</table>';
            fclose($fn);
            return $dataInTable;
        }
    }
?>