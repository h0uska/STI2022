using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class Form1 : Form
    {

        private const string helpMessage = "your last question was not decoded" +
            "<br>HELP:" +
            "<br>1) if you want to ask what is the time, than use words 'what' and 'time'" +
            "<br>2) if you want to ask what is server name, than use words 'what' and 'name'" +
            "<br>3) if you want to ask what is the current euro exchange rate, than use words 'current' and 'EUR'" +
            "<br>4) if you want to ask what is the history of euro exchange rate, than use words 'history' and 'EUR'";
        private Converzation myConverzation = new Converzation();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendingQuestionAction();
            //moveDisplayOfHtml();
        }

        /*
        public void moveDisplayOfHtml()
        {
            if (webBrowser1.Document.Body != null)
            {
                webBrowser1.Document.Body.ScrollIntoView(false);// skoci na konec listu pockej az se to tam vykresli
            }
        }
        */


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendingQuestionAction()
        {
            int numberOfQuestion = myConverzation.getQuestionNumber(textBox2.Text);
            myConverzation.addToTextMessagesHistory("<b>question: </b>" + textBox2.Text);
            textBox2.Text = "";

            if (numberOfQuestion != 5)
            {
                try
                {
                    string url = myConverzation.getQuestionUrl(numberOfQuestion);
                    String responseFromServer = myConverzation.getHtmlFromServer(url);
                    string bodyHtml = myConverzation.getStringBeetweenStrings(responseFromServer, "<body>", "</body>");
                    myConverzation.addToTextMessagesHistory("<b>answer: </b>" + bodyHtml);
                }
                catch { }
            }
            else
            {
                myConverzation.addToTextMessagesHistory(helpMessage);
            }
            string htmlToDisplay = myConverzation.createHtmlToDisplay();
            webBrowser1.DocumentText = htmlToDisplay;
        }
    }
}
