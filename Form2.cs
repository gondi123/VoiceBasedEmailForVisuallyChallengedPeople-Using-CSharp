using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Sockets;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        /*SpeechRecognitionEngine sre1 = new SpeechRecognitionEngine();
        SpeechRecognitionEngine sre2 = new SpeechRecognitionEngine();*/
        Choices clist = new Choices();
        //Grammar gr;

        string s;
        string s1, s2, s3, s4;
       
        //string[] st;
        //int c = 0;
        public Form2()
        {
            InitializeComponent();
            ss.SetOutputToDefaultAudioDevice();
        
            /*string t=method1();
            string t1=method2();
            string t2=method3();*/
            //MessageBox.Show("success1");
          /*  public string method1()
            {*/
                clist.Add(new string[] {"yaswanthrayasam32","ngondi.reddy","yashurayasam","testfire","test mail","submit","thank u","close"  });
                Grammar gr;
                gr = new Grammar(new GrammarBuilder(clist));
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);  
                //return "suc";
            }
        /*public string method2()
        {
            clist.Add(new string[] { "hello", "how are you", "what is the current time", "open chrome", "thank u", "close", "open mail", "fuck u" });
            gr = new Grammar(new GrammarBuilder(clist));
            sre1.RequestRecognizerUpdate();
            sre1.LoadGrammar(gr);
            sre1.SpeechRecognized += sre1_SpeechRecognized1;
            //sre.SetInputToDefaultAudioDevice();
            //sre1.RecognizeAsync(RecognizeMode.Single);
            return "suc";
        }
        public string method3()
        {
            clist.Add(new string[] { "hello", "how are you", "what is the current time", "open chrome", "thank u", "close", "open mail", "fuck u" });
            gr = new Grammar(new GrammarBuilder(clist));
            sre2.RequestRecognizerUpdate();
            sre2.LoadGrammar(gr);
            sre2.SpeechRecognized += sre2_SpeechRecognized2;
            //sre.SetInputToDefaultAudioDevice();
            //sre2.RecognizeAsync(RecognizeMode.Single);
            return "suc";
        }*/
        private void Form2_Load(object sender, EventArgs e)
        {
            //sendEmail(s2,s3,s4);
            /*textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            */
        }
        private TextBox currentInput;
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            foreach (RecognizedWordUnit word in e.Result.Words)
            {
                //textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
                if (word.Text == "yaswanthrayasam32")
                {
                    //currentInput = textBox2;
                    //textBox1.Text = null;
                    textBox1.Text += e.Result.Text.ToString()+"@gmail.com";
                }
                else if (word.Text == "yashurayasam")
                {
                    //currentInput = textBox3;
                    textBox2.Text += e.Result.Text.ToString()+"@32";
                }
                else if (word.Text == "ngondi.reddy")
                {
                    //currentInput = textBox4;
                    textBox3.Text += e.Result.Text.ToString()+"@gmail.com";
                }
                else if (word.Text == "testfire")
                {
                    //currentInput = textBox4;
                    textBox4.Text += e.Result.Text.ToString();
                }
                else if (word.Text == "test mail")
                {
                    
                    textBox5.Text += e.Result.Text.ToString();
                }
                else if (word.Text == "close")
                {
                    Application.Exit();
                }
                else if(word.Text=="submit")
                {
                    button1_Click(sender, e);
                }
            }
        }
                //textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
        /*}
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {*/
            //textBox2.Text += e.Result.Text.ToString() + Environment.NewLine;
        /*}
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {*/
            //textBox3.Text += e.Result.Text.ToString() + Environment.NewLine;
            
       /* }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {*/
         /*   switch (e.Result.Text.ToString())
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
                case "thank u":
                    ss.SpeakAsync("Pleasure is mine yash");
                    break;
                case "open chrome":
                    ss.SpeakAsync("opening chrome");
                    Process.Start("chrome", "https://www.google.com");
                    break;
                //case "open mail":
                    //ss.SpeakAsync("opening mail login page");
                    //Form2 f2 = new Form2();
                    //f2.Show();
                    //Process.Start("chrome", "https://www.gmail.com");
                    //login("yaswanthrayasam32","yashurayasam@32");
                    //break;
                case "close":
                    Application.Exit();
                    break;
                case "tab":
                    SendKeys.Send("{TAB}");
                    break;
                /*case "enable one":
                    textBox1.Enabled = true;
                    sre_SpeechRecognized1(sender,e);
                   // textBox1.Text += e.Result.Text.ToString();
                    break;
                case "enable two":
                    textBox2.Enabled = true;
                    textBox1.Enabled = false;
                    break;

            }
        }*/
            /*textBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
            w = textBox1.Text;
            char[] splitchar = { '\n' };
            st = w.Split(splitchar);
            
            for(c=0;c<=st.Length-1;c++)
            {
                MessageBox.Show(st[c]);
            }
        }*/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s = textBox1.Text;
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            s1 = textBox2.Text;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            s2 = textBox3.Text;
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            s3 = textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendEmail(s2, s3, s4);
            ss.SpeakAsync("your mail has been sent successfully");
            MessageBox.Show("Your mail has been sent successfully");
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            s4 = textBox5.Text;
        }

        public string sendEmail(string toAddress, string sub, string body)
        {
            string result = "Message sent successfully";
            string senderId = s;
            string sendPassword = s1;
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderId, sendPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderId, toAddress, sub, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending mail";
            }
            //MessageBox.Show("success");
            return result;

        }

        private void sendmail_Click(object sender, EventArgs e)
        {

        }
    }
}