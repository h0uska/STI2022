<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title></title>
    </head>
    <body>
        <?php
            session_start();
            include 'functions.php';
            $fun = new functions();
            
            
            if(isset($_GET['question1'])){
                $date = $fun->getTime();
                echo'the time is ';
                echo $date;
            }
            
            
            if(isset($_GET['question2']))
            {
                $serverName = $fun->getServerName();
                echo'my name is ';
                echo $serverName;
            }
            
            
            if(isset($_GET['question3']))
            {
                $html = $fun->getData('https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=51434B515C33C368A4D0DE79932EF99C?date=DD.MM.RRRR');
                $myarray = $fun->parseDownloadedData($html); //neededDate, neededAmmount, neededCode, neededExchange
                $line = $fun->getLastLineInFile("historie_meny.txt");
                $fun->appendDataInFile($myarray, $line,"historie_meny.txt");
                $line = $fun->getLastLineInFile("historie_meny.txt");
                $myarray2 = $fun->parseLine($line,';'); //neededDate, neededAmmount, neededCode, neededExchange
                // put echo data on page
                echo "exchange rate of " . $myarray2[1] . " " . $myarray2[2] . " to CZK is " . $myarray2[3] . " (" . $myarray2[0] . ")";
            }
            
            
            if(isset($_GET['question4']))
            {
                $html = $fun->getData('https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=51434B515C33C368A4D0DE79932EF99C?date=DD.MM.RRRR');
                $myarray = $fun->parseDownloadedData($html); //neededDate, neededAmmount, neededCode, neededExchange
                $line = $fun->getLastLineInFile("historie_meny.txt");
                $fun->appendDataInFile($myarray, $line,"historie_meny.txt");
                $fun->createTable("historie_meny.txt");
            }
            
            
            if(isset($_GET['updateData']))
            {
                $html = $fun->getData('https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt;jsessionid=51434B515C33C368A4D0DE79932EF99C?date=DD.MM.RRRR');
                $myarray = $fun->parseDownloadedData($html); //neededDate, neededAmmount, neededCode, neededExchange
                $line = $fun->getLastLineInFile("historie_meny.txt");
                $fun->appendDataInFile($myarray, $line,"historie_meny.txt");
                echo "Data updated";
            }
        ?>
    </body>
</html>
