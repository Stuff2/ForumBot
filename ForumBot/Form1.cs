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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            webBrowser1.Navigate(uri);
            


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

        private void button1_Click(object sender, EventArgs e)
        {

            login(textBox1.Text, textBox2.Text);
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement HtmlElement1 in webBrowser1.Document.Body.All)
            {

                if (HtmlElement1.TagName=="TEXTAREA")//
                {
                   
                    HtmlElement1.SetAttribute("value", "yeni pc al kardeşim");
              


                }

                if (HtmlElement1.OuterText != null && HtmlElement1.OuterText.ToLower() == " Cevap yaz ".ToLower())//Bu alana bir cevap yazın...
                {

                    HtmlElement1.InvokeMember("Click");
                    break;

                }

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
            checkedListBox1.Items.Add(comboBox1.SelectedItem.ToString()+ comboBox2.SelectedItem.ToString(), true);//DateTime.Now.TimeOfDay.ToString("hh''mm")
        }
    }
}
