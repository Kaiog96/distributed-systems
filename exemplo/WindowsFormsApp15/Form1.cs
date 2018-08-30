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

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new professor
            {
                id = textId.Text,
                nome = textNome.Text,
                idade = textIdade.Text,
                cidade = textCidade.Text,
            });
            var request = WebRequest.CreateHttp("https://sistemasdistribuidos-fef5c.firebaseio.com/professores/.json");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var request = WebRequest.CreateHttp("https://sistemasdistribuidos-fef5c.firebaseio.com/professores/.json");
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response1 = request.GetResponse() as HttpWebResponse;
            using (Stream responsestream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responsestream, Encoding.UTF8);
                string ret = Read.ReadToEnd();
            }


        }
    }
}
