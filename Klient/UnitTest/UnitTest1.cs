using System;
using Klient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
//using Klient;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {


        // ARRANGE
        // ACT
        // ASSERT
        /*[TestMethod]
        public void TestMethod1()
        {
        }*/

        [TestMethod]
        public void getQuestionUrltTest1()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("http://stiserver2.9e.cz/index.php?question1", c.getQuestionUrl(1));
        }
        [TestMethod]
        public void getQuestionUrltTest2()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("http://stiserver2.9e.cz/index.php?question2", c.getQuestionUrl(2));
        }
        [TestMethod]
        public void getQuestionUrltTest3()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("http://stiserver2.9e.cz/index.php?question3", c.getQuestionUrl(3));
        }
        [TestMethod]
        public void getQuestionUrltTest4()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("http://stiserver2.9e.cz/index.php?question4", c.getQuestionUrl(4));
        }
        [TestMethod]
        public void getQuestionUrltTest5()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("wrong number", c.getQuestionUrl(5));
        }



        [TestMethod]
        public void getQuestionNumberTest1()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(1, c.getQuestionNumber("is whAT time name"));
        }
        [TestMethod]
        public void getQuestionNumberTest2()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(2, c.getQuestionNumber("is whAT?name."));
        }
        [TestMethod]
        public void getQuestionNumberTest3()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(3, c.getQuestionNumber("is EUR WHAT Current time name history"));
        }
        [TestMethod]
        public void getQuestionNumberTest4()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(4, c.getQuestionNumber("tell me what is the history of eur "));
        }
        [TestMethod]
        public void getQuestionNumberTest5()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(5, c.getQuestionNumber("inonsence time name current history nonsencesmgzdl zdl"));
        }
        [TestMethod]
        public void getQuestionNumberTest6()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(1, c.getQuestionNumber("time what"));
        }
        [TestMethod]
        public void getQuestionNumberTest7()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(2, c.getQuestionNumber("name what"));
        }
        [TestMethod]
        public void getQuestionNumberTest8()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(3, c.getQuestionNumber("current_eur"));
        }
        [TestMethod]
        public void getQuestionNumberTest9()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(4, c.getQuestionNumber("eur_history"));
        }



        [TestMethod]
        public void getStringBeetweenStringsTest1()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("er", c.getStringBeetweenStrings("ksers rgesjkrg ks ks:", "ks", "s "));
        }
        [TestMethod]
        public void getStringBeetweenStringsTest2()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("gesjkr", c.getStringBeetweenStrings("ksers rgesjkrg ks ks:", "rs r", "g ks k"));
        }


        /*
        [TestMethod]
        public void addToTextMessagesHistoryTest1()
        {
            Converzation c = new Converzation();
            Assert.AreEqual(true, c.addToTextMessagesHistory("w"));
        }*/



        [TestMethod]
        public void createHtmlToDisplayTest1()
        {
            Converzation c = new Converzation();
            c.addToTextMessagesHistory("w");
            Assert.AreEqual("<!DOCTYPE html><html><head><meta charset=\"utf-8\">" +
                "<title></title></head><body><br>w</body></html>", c.createHtmlToDisplay());
        }



        [TestMethod]
        public void getHtmlFromServerTest1()
        {
            Converzation c = new Converzation();
            Assert.ThrowsException<UriFormatException>(() => c.getHtmlFromServer("w"));
        }
        [TestMethod]
        public void getHtmlFromServerTest2()
        {
            Converzation c = new Converzation();
            Assert.AreEqual("<!DOCTYPE html><html>    <head>        <meta charset=\"utf-8\">        <title>" +
                "</title>    </head>    <body>            </body></html>", c.getHtmlFromServer("http://stiserver2.9e.cz/index.php"));
        }


    }
}
