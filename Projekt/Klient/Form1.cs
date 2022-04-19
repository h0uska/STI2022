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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private String getHtmlFromServer(string serverAdress)
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

                // You now have the HTML in the responseFromServer variable, use it :)
                return responseFromServer;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
