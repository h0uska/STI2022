using Klient;
using KlientUnitTestsFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace KlientNUnitTests
{
    public class Form1Tests
    {
        // ARRANGE
        // ACT
        // ASSERT
        private Converzation2 c = new Converzation2();
        [Test]
        public void getQuestionUrltTest1()
        {
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question1", c.getQuestionUrl(1));
        }
        [Test]
        public void getQuestionUrltTest2()
        {
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question3", c.getQuestionUrl(3));
        }
        [Test]
        public void getQuestionUrltTest3()
        {
            NUnit.Framework.Assert.AreEqual("wrong number", c.getQuestionUrl(-1));
        }
        [Test]
        public void getQuestionUrltTest4()
        {
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question4", c.getQuestionUrl(4));
        }
        [Test]
        public void getQuestionUrltTest5()
        {
            NUnit.Framework.Assert.AreEqual("wrong number", c.getQuestionUrl(5));
        }



        [Test]
        public void getQuestionNumberTest1()
        {
            NUnit.Framework.Assert.AreEqual(1, c.getQuestionNumber("is whAT time name"));
        }
        [Test]
        public void getQuestionNumberTest2()
        {
            NUnit.Framework.Assert.AreEqual(2, c.getQuestionNumber("is whAT?name."));
        }
        [Test]
        public void getQuestionNumberTest3()
        {
            NUnit.Framework.Assert.AreEqual(3, c.getQuestionNumber("is EUR WHAT Current time name history"));
        }
        [Test]
        public void getQuestionNumberTest4()
        {
            NUnit.Framework.Assert.AreEqual(4, c.getQuestionNumber("tell me what is the history of eur "));
        }
        [Test]
        public void getQuestionNumberTest5()
        {
            NUnit.Framework.Assert.AreEqual(5, c.getQuestionNumber("inonsence time name current history nonsencesmgzdl zdl"));
        }



        [Test]
        public void getStringBeetweenStringsTest1()
        {
            NUnit.Framework.Assert.AreEqual("er",c.getStringBeetweenStrings("ksers rgesjkrg ks ks:","ks","s "));
        }
        [Test]
        public void getStringBeetweenStringsTest2()
        {
            NUnit.Framework.Assert.AreEqual("gesjkr", c.getStringBeetweenStrings("ksers rgesjkrg ks ks:", "rs r", "g ks k"));
        }



    }
}