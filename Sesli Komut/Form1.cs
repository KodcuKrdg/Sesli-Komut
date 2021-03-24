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

namespace Sesli_Komut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            Ayarlar();
            recoEngine.RecognizeAsync();
        }

        private void Ayarlar()
        {
            string[] ihtimaller ={"Hello", "How are you"};
            Choices secenekler = new Choices(ihtimaller);
            Grammar gramner = new Grammar(new GrammarBuilder(secenekler));
            recoEngine.LoadGrammar(gramner);
            recoEngine.SetInputToDefaultAudioDevice();
            recoEngine.SpeechRecognized += ses_tanidiginda;
        }

        private void ses_tanidiginda(object sender, SpeechRecognizedEventArgs e)
        {
            /*if (e.Result.Text=="Hello")
            {

            }
            else if (e.Result.Text == "How are you")
            {
            
            }*/
            MessageBox.Show(e.Result.Text);
        }
    }
}
