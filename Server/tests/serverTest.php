<?php
//      php vendor/bin/phpunit tests/serverTest.php --colors

use PHPUnit\Framework\TestCase;
include '.Server/functions.php'
// include 'functions.php';

class serverTest extends TestCase
{
    public function testGetTime()
    {
        $testfun = new functions();
        date_default_timezone_set('Europe/Prague');
        $this->assertEquals(date('H:i', time()) ,$testfun->getTime());
    }
    
    public function testGetData()
    {
        $testfun = new functions();
        $this->assertEquals("<!DOCTYPE html>\n<html>\n    <head>\n        <meta charset=\"utf-8\">\n        <title></title>\n    </head>\n    <body>\n            </body>\n</html>\n",$testfun->getData('http://stiserver2.9e.cz/'));
    }
    
    public function testParseDownloadedData()
    {
        $testfun = new functions();
        $this->assertEquals(array("string1","string2","string3","string4"),$testfun->parseDownloadedData("string1#|||||||||||F|F||||||||||||||string2|string3|string4Fsomestring|||#F"));
    }

    public function testGetLastLineInFile()
    {
        $testfun = new functions();
        $this->assertEquals("22.04.2022;1;EUR;24,320",$testfun->getLastLineInFile("tests/test_file.txt"));
    }

    public function testAppendDataInFile1()
    {
        $testfun = new functions();
        $this->assertEquals(false,$testfun->appendDataInFile(array("n","a","b","c"), "n;a;b;c", "tests/test_file_2.txt"));
    }

    public function testAppendDataInFile2()
    {
        date_default_timezone_set('Europe/Prague');
        $time = $date = date('m/d/Y h:i:s a', time());
        $testfun = new functions();
        $this->assertEquals(true,$testfun->appendDataInFile(array($time,"a","b","c"), "nothing", "tests/test_file_2.txt"));
        $this->assertEquals($time . ";a;b;c",$testfun->getLastLineInFile("tests/test_file_2.txt"));
    }

    public function testParseLine()
    {
        $testfun = new functions();
        $this->assertEquals(array("a","b","c","d"),$testfun->parseLine("a3b3c3d", '3'));
    }

    public function testCreateTable()
    {
        $testfun = new functions();
        $this->assertEquals("20.04.2022;24,415;21.04.2022;24,380;22.04.2022;24,320;",$testfun->createTable("tests/test_file.txt"));
    }
}

?>
