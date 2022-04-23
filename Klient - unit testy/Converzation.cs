using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Klient
{
    public class Converzation
    {
        
        private List<string> messagesHistory = new List<string>();

        public Converzation() { }


        public void addToTextMessagesHistory(string textToAdd)
        {
            messagesHistory.Add(textToAdd);
        }

        public string createHtmlToDisplay()
        {
            string htmlToDisplay = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title></title></head><body>";
            for (int i = 0; i < messagesHistory.Count; i++)
            {
                htmlToDisplay += "<br>" + messagesHistory[i];
            }
            htmlToDisplay += "</body></html>";
            return htmlToDisplay;
        }

        public string getStringBeetweenStrings(string stringToParse, string firstString, string lastString)
        {
            string finalString;
            int positionFirst = stringToParse.IndexOf(firstString) + firstString.Length;
            int positionLast = stringToParse.IndexOf(lastString);
            finalString = stringToParse.Substring(positionFirst, positionLast - positionFirst);
            return finalString;
        }

        public string getQuestionUrl(int numberOfQuestion)
        {
            if (numberOfQuestion == 1)
            {
                return "http://stiserver2.9e.cz/index.php?question1";
            }
            else if (numberOfQuestion == 2)
            {
                return "http://stiserver2.9e.cz/index.php?question2";
            }
            else if (numberOfQuestion == 3)
            {
                return "http://stiserver2.9e.cz/index.php?question3";
            }
            else if (numberOfQuestion == 4)
            {
                return "http://stiserver2.9e.cz/index.php?question4";
            }
            return "wrong number";
        }

        public int getQuestionNumber(string question)
        {
            question = question.ToLower();

            bool foundWordWhat = false, foundWordTime = false, foundWordName = false,
                foundWordCurrent = false, foundWordEUR = false, foundWordHistory = false;

            char[] separators = { ' ', '.', '?', '!', ',', ':', '_', '-', '§', '/', '(', ')', '=', '<', '>', ';'};

            string[] words = question.Split(separators);

            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].Equals("what"))
                {
                    foundWordWhat = true;
                    if (foundWordTime) { return 1; }
                    if (foundWordName) { return 2; }
                }

                else if (words[i].Equals("time"))
                {
                    foundWordTime = true;
                    if (foundWordWhat) { return 1; }
                }

                else if (words[i].Equals("name"))
                {
                    foundWordName = true;
                    if (foundWordWhat) { return 2; }
                }

                else if (words[i].Equals("current"))
                {
                    foundWordCurrent = true;
                    if (foundWordEUR) { return 3; }
                }

                else if (words[i].Equals("eur"))
                {
                    foundWordEUR = true;
                    if (foundWordCurrent) { return 3; }
                    if (foundWordHistory) { return 4; }
                }

                else if (words[i].Equals("history"))
                {
                    foundWordHistory = true;
                    if (foundWordEUR) { return 4; }
                }
            }

            return 5;
        }

        public String getHtmlFromServer(string serverAdress)
        {
            try
            {
                String queryString = "user=myUser&pwd=myPassword&tel=+123456798&msg=My message";
                byte[] requestByte = Encoding.Default.GetBytes(queryString);

                // build our request
                WebRequest webRequest = WebRequest.Create(serverAdress);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/xml";
                webRequest.ContentLength = requestByte.Length;

                // create our stream to send
                Stream webDataStream = webRequest.GetRequestStream();
                webDataStream.Write(requestByte, 0, requestByte.Length);

                // get the response from our stream
                WebResponse webResponse = webRequest.GetResponse();
                webDataStream = webResponse.GetResponseStream();

                // convert the result into a String
                StreamReader webResponseSReader = new StreamReader(webDataStream);
                String responseFromServer = webResponseSReader.ReadToEnd().Replace("\n", "").Replace("\t", "");

                // close everything
                webResponseSReader.Close();
                webResponse.Close();
                webDataStream.Close();

                // You now have the HTML in the responseFromServer variable, use it 
                return responseFromServer;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
