using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private Quiz quiz1, quiz2, quiz3, quiz4;

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupQuiz();
        }

        private int timeLeft = 60;
        public Form1()
        {
            InitializeComponent();
        }

        private void timerQuiz_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = string.Format("Pozostały czas: {0} sek.", timeLeft);

            if (timeLeft < 15)
            {
                lblTimer.ForeColor = Color.Red;
            }

            else if(timeLeft<30)
            {
                lblTimer.ForeColor = Color.Orange;
            }
            else
            {
                lblTimer.ForeColor = Color.Black;
            }

            if(timeLeft == 0)
            {
                timerQuiz.Enabled = false;
                CheckAnswers();
            }

        }

        private void CheckAnswers()
        {
            int correctAnswers = 0;

            if (quiz1.Result == numQ1.Value) correctAnswers++;
            if (quiz2.Result == numQ2.Value) correctAnswers++;
            if (quiz3.Result == numQ3.Value) correctAnswers++;
            if (quiz4.Result == numQ4.Value) correctAnswers++;

            MessageBox.Show(string.Format("Poprawne odpowiedzi: {0}", 
                correctAnswers));
            SetupQuiz();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(timerQuiz.Enabled)
            {
                //zakończ quiz
                timerQuiz.Enabled = false;
                CheckAnswers();
            }
            else
            {
                //uruchom quiz
                SetupQuiz();
                timerQuiz.Enabled = true;
                btnStart.Text = "Stop";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Czy na pewno chcesz wyjść z aplikacji?";
            string caption = "Pytanie";

            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            //else
            //{
            //    Close();
            //}
        }

        private Random random = new Random((int)DateTime.Now.Ticks);
        private int RandomNumber(int min, int max)
        {
            //Random random = new Random(42);
            return random.Next(min, max);
        }

        public void SetupQuiz()
        {
            numQ1.Value = 0; numQ1.Minimum = Int32.MinValue; numQ1.Maximum = Int32.MaxValue;
            numQ2.Value = 0; numQ2.Minimum = Int32.MinValue; numQ2.Maximum = Int32.MaxValue;
            numQ3.Value = 0; numQ3.Minimum = Int32.MinValue; numQ3.Maximum = Int32.MaxValue;
            numQ4.Value = 0; numQ4.Minimum = Int32.MinValue; numQ4.Maximum = Int32.MaxValue;

            quiz1 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "+");
            quiz2 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "-");
            quiz3 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "*");
            quiz4 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "/");

            lblQ1.Text = quiz1.ToString();
            lblQ2.Text = quiz2.ToString();
            lblQ3.Text = quiz3.ToString();
            lblQ4.Text = quiz4.ToString();

            timeLeft = 60;
            lblTimer.Text = string.Format("Pozostały czas: {0} sek.", timeLeft);
            lblTimer.ForeColor = Color.Black;

            btnStart.Text = "Start";
        }

    }
}
