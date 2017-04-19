using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        WMPLib.WindowsMediaPlayer wp;
        //private object ListBox1;

        public Form1()
        {
            InitializeComponent();
            ss.SetOutputToDefaultAudioDevice();
            ss.Speak("Welcome To application");
            clist.Add(new string[] {"bot", "tab","hello","play song","stop song","play video","pause song", "what is your name","how are you", "what is the current time", "chrome", "thank u", "close", "open mail"});
            Grammar gr = new Grammar(new GrammarBuilder(clist));
            sre.RequestRecognizerUpdate();
            sre.LoadGrammar(gr);
            sre.SpeechRecognized += sre_SpeechRecognized;
            sre.SetInputToDefaultAudioDevice();
            sre.RecognizeAsync(RecognizeMode.Multiple);
            //ss.SpeakAsync("Welcome to the application");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToString())
            {
                /*case "hello":
                    ss.SpeakAsync("welcome user");
                    break;
                case "how are you":
                    ss.SpeakAsync("Im doing great how about u");
                    break;
                case "what is the current time":
                    ss.SpeakAsync("current time is" + DateTime.Now.ToLongTimeString());
                    break;
                case "what is your name":
                    ss.SpeakAsync("my name is srilok");
                    break;
                case "thank u":
                    ss.SpeakAsync("Pleasure is mine yash");
                    break;
                case "chrome":
                    ss.SpeakAsync("opening chrome");
                    Process.Start("chrome", "https://www.google.com");
                    break;*/
                case "open mail":
                    ss.SpeakAsync("opening mail login page");
                    Form2 f2= new Form2();
                    f2.Show();
                    sre.RecognizeAsyncStop();
                    this.Hide();
                    
                    //Process.Start("chrome", "https://www.gmail.com");
                    //login("yaswanthrayasam32","yashurayasam@32");
                    break;
                case "bot":
                    ss.SpeakAsync("Opening bot");
                    Form4 f3 = new Form4();
                    f3.Show();
                    sre.RecognizeAsyncStop();
                    this.Hide();
                    break;
                /*case "play song":
                    wp = new WMPLib.WindowsMediaPlayer();
                    wp.URL = "C://Users//Yashu_r//Music//KUSHI//Ae meraa jahaan.mp3";
                    wp.controls.play();
                    break;*/
                case "close":
                    Application.Exit();
                    break;
                /*case "pause song":
                   // WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();
                    //wp.URL = "C://Users//Yashu_r//Music//KUSHI//Aduvaari maatalaku.mp3";
                    wp.controls.pause();
                    break;
                case "stop song":
                    wp.controls.stop();
                    break;*/
            }
            textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(681, 288);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(770, 449);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();
            wp.URL = "C://Users//Yashu_r//Music//KUSHI//Aduvaari maatalaku.mp3";
            wp.controls.play();
        }*/
    }
}