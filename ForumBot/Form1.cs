using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForumBot
{
    public partial class Form1 : Form
    {
        string uri = "http://forum.thedeathko.com/index.php?login/";
        string lastOp = "1";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.Navigate(uri);
            await  WaitNSeconds(2000);
            
            


        }
        private void login(string username,string pass) {
            if (webBrowser1.Url.AbsoluteUri == uri)
            {
                foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
                {
                    if (HtmlElement1.GetAttribute("id").Contains("_xfUid-1"))
                    {
                        HtmlElement1.InnerText = username;

                    }
                    else if (HtmlElement1.GetAttribute("id").Contains("_xfUid-2"))
                    {
                        HtmlElement1.InnerText = pass;

                    }
                    else if (HtmlElement1.OuterText == "Giriş yap")
                    {
                        HtmlElement1.InvokeMember("click");
                    }

                }
            }
        }

        private async Task WaitNSeconds(int millsec)
        {
           
              await Task.Delay(millsec);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text != "")
            login(textBox1.Text, textBox2.Text);
            
          
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Başlat")
            {
                if (textBox3.Text != "" && richTextBox1.Text != "")
                {
                    webBrowser1.Navigate(textBox3.Text);
                    await WaitNSeconds(2000);
                    timer1.Enabled = true;
                    button2.Text = "Durdur";

                }

            }
            else
            {
                timer1.Enabled = false;
                button2.Text = "Başlat";
            }
            
          

         
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            label1.Text = webBrowser1.Url.AbsoluteUri;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
                if( lastOp!= DateTime.Now.TimeOfDay.ToString("hh''mm"))
                {
                    lastOp = DateTime.Now.TimeOfDay.ToString("hh''mm");
                    foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
                    {

                        if (HtmlElement1.TagName == "TEXTAREA")//
                        {

                            HtmlElement1.SetAttribute("value", richTextBox1.Text);
                            
                        }

                        if (HtmlElement1.OuterText != null && HtmlElement1.OuterText.ToLower() == " Cevap yaz ".ToLower())//Bu alana bir cevap yazın...
                        {

                            HtmlElement1.InvokeMember("Click");
                            break;

                        }

                    }
                    await WaitNSeconds(5000);

                }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = Int32.Parse(comboBox1.SelectedItem.ToString()) *60000;
        }
    }
}
