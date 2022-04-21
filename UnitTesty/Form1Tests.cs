using Klient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace KlientNUnitTests
{
    public class Form1Tests
    {
        /*[Test]
        public void putHtmlInBoxTest()
        {
            // ARRANGE
            var theForm = new Form1();
            // ACT
            var results = theForm.putHtmlInBox("");
            // ASSERT

            //Assert
            NUnit.Framework.Assert.True(results == false, "Expected to be false.");
        }*/

        /*[Test]
        public void getQuestionUrlTest()
        {
            // ARRANGE
            var theForm = new Form1();
            // ACT
            //var results = theForm.getQuestionUrl(1);
            // ASSERT

            //Assert
            //NUnit.Framework.Assert.True(results.Equals("http://stiserver2.9e.cz/index.php?question1"), "Expected to be equal string");
            //NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question1", theForm.getQuestionUrl(1));
        }
        */
        [Test]
        public void getQuestionUrltTest()
        {
            // ARRANGE
            var c = new Converzation();
            // ACT
            // ASSERT
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question1", c.getQuestionUrl(1));
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question2", c.getQuestionUrl(2));
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question3", c.getQuestionUrl(3));
            NUnit.Framework.Assert.AreEqual("http://stiserver2.9e.cz/index.php?question4", c.getQuestionUrl(4));
            NUnit.Framework.Assert.AreEqual("wrong number", c.getQuestionUrl(5));
            NUnit.Framework.Assert.AreEqual("wrong number", c.getQuestionUrl(6));
            NUnit.Framework.Assert.AreEqual("wrong number", c.getQuestionUrl(0));
        }

    }
}
//Form1Tests
