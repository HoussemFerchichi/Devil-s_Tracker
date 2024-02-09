using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace Devil_s_Tracker
{
    public partial class Form1 : Form
    {
        public bool Aa = true;
        public int n = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IP = textBox1.Text;
            WebClient request = new WebClient();
            string Geo = request.DownloadString("http://api.ipstack.com/"+ IP +"?access_key=3e6bdb1c8dd5409851c6914d1540aaa6&format=1"); 
            richTextBox1.Text = Geo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string IP = textBox2.Text;
            WebClient request = new WebClient();
            string proxychecker = request.DownloadString("https://ipqualityscore.com/api/json/ip/HgpJ4nBb5udm8o6zQG2uHbI6QJdHz0Lz/" + IP);
            richTextBox2.Text = proxychecker;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string IP = textBox3.Text;
            Ping ping = new Ping();
            PingReply reply = ping.Send(IP);
            while (reply.Status.ToString() == "Success")
            {
                label5.Text = "Online";
                label5.ForeColor = Color.Red;
                label3.Text = reply.RoundtripTime.ToString();
                DrawString();
            }
            while (reply.Status.ToString() != ("Success"))
            {
                label5.Text = "Offline";
                label5.ForeColor = Color.Red;
            }
        }
        public void DrawString()
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            string drawString = label3.Text;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 150.0F;
            float y = 50.0F;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Aa == true)
            {
                Aa = false;
            }
            else
            {
                Aa = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            n += 1;
            var a = n.ToString();
            label3.Text = a;
        }
    }
}
