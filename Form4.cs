using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        WMPLib.WindowsMediaPlayer wp;

        public Form4()
        {
            InitializeComponent();
            ss.SetOutputToDefaultAudioDevice();
            //ss.Speak("Welcome To application");
            clist.Add(new string[] {  "hello", "play song", "stop song", "play video", "pause song", "what is your name", "how are you", "what is the current time", "open chrome", "thank u", "close", "open mail" });
            Grammar gr = new Grammar(new GrammarBuilder(clist));
            sre.RequestRecognizerUpdate();
            sre.LoadGrammar(gr);
            sre.SpeechRecognized += sre_SpeechRecognized;
            sre.SetInputToDefaultAudioDevice();
            sre.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String s = e.Result.Text.ToString();
            string[] result = Regex.Split(s, "\n\\s*");
            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case "hello":
                        ss.SpeakAsync("welcome user");
                        break;
                    case "how are you":
                        ss.SpeakAsync("Im doing great how about u");
                        break;
                    case "what is the current time":
                        ss.SpeakAsync("current time is" + DateTime.Now.ToLongTimeString());
                        break;
                    case "what is your name":
                        ss.SpeakAsync("my name is AICBIT");
                        break;
                    case "thank you":
                        ss.SpeakAsync("Pleasure is mine yash");
                        break;
                    case "open chrome":
                        ss.SpeakAsync("opening chrome");
                        Process.Start("chrome", "https://www.google.com");
                        break;
                    case "open mail":
                        ss.SpeakAsync("opening mail login page");
                        Form2 f2 = new Form2();
                        f2.Show();
                        sre.RecognizeAsyncStop();
                        this.Hide();

                        //Process.Start("chrome", "https://www.gmail.com");
                        //login("yaswanthrayasam32","yashurayasam@32");
                        break;

                    case "play song":
                        wp = new WMPLib.WindowsMediaPlayer();
                        wp.URL = "C://Users//Yashu_r//Music//KUSHI//Ae meraa jahaan.mp3";
                        wp.controls.play();
                        break;
                    case "close":
                        Application.Exit();
                        break;
                    case "pause song":
                        // WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();
                        //wp.URL = "C://Users//Yashu_r//Music//KUSHI//Aduvaari maatalaku.mp3";
                        wp.controls.pause();
                        break;
                    case "stop song":
                        wp.controls.stop();
                        break;
                    default:
                        ss.SpeakAsync("sorry,i didnt get you");
                        break;
                        
                }
            }
         //
         textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
        }

    }
}
