using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace QuizTool
{
    public partial class Form1 : Form
    {
        private bool CloseApplication = false;
        public static string QuizText;
        //It is important to change this key
        internal const string Salt = "3KDJS0K3JD932KE32JDL2";
        public string StudentName;
        private int _totalScore = 0;
        private int _currentQuestion = 0;
        private List<QuizQuestion> Questions;
        private List<string> StudentAnswers = new List<string>();
        private QuizQuestion Question
        {
            get { return Questions[_currentQuestion]; }
        }
        private bool Ready = false;
        private BackgroundWorker worker1 = new BackgroundWorker();
        private BackgroundWorker worker2 = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            ShowQuizComponents(false);
            EncryptFile();
        }
        private void ShowQuizComponents(bool hide)
        {
            //Show Quiz Elements
            submitanswer.Visible = hide;
            questionbox.Visible = hide;
            optionsbox.Visible = hide;
            groupBox1.Visible = hide;
            groupBox2.Visible = hide;

            //Hide Nameinput Elements
            groupBox3.Visible = !hide;
            nameinput.Visible = !hide;
            namesubmit.Visible = !hide;

        }
        private void EncryptFile()
        {
            if (!File.Exists("Quiz Template - READ ME.txt"))
            {
                //Generate new Template File.
                MessageBox.Show("Could not find Quiz Template, creating new");
                File.WriteAllText("Quiz Template - READ ME.txt", Properties.Resources.Quiz_Template___READ_ME);
            }
            if (File.Exists("Quiz.txt"))
            {
                //Encrypt the file.
                string encrypted = QuizEncryptorDecryptor.EncryptRijndael(File.ReadAllText("Quiz.txt"), Salt);
                File.WriteAllText("QuizEncrypted.txt", encrypted);
                File.Delete("Quiz.txt");
            }
            if (File.Exists("QuizEncrypted.txt"))
            {
                //Decrypt the file in memory.
                string decrypted = QuizEncryptorDecryptor.DecryptRijndael(File.ReadAllText("QuizEncrypted.txt"), Salt);
                QuizText = decrypted;
            }
            else
            {
                MessageBox.Show("No Quiz file is supplied! You need to write a Quiz file! Read QuizTemplate - READ ME.txt for information!");
                CloseApplication = true;
            }
        }
        private void SetupQuizForm()
        {
            ShowQuizComponents(true);
            SetUpWorkers();
            worker2.RunWorkerAsync();
            worker1.RunWorkerAsync();
        }
        private void SetUpWorkers()
        {
            //Set up worker events.

            //Worker1
            worker1.DoWork += Worker1_DoWork;
            worker1.RunWorkerCompleted += Worker1_RunWorkerCompleted;

            //Worker2
            worker2.DoWork += Worker2_DoWork;
        }

        private void Worker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!Ready)
            {
                questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Please wait.."; });
                if (Ready)
                {
                    questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Press Start Quiz when you are ready!"; });
                    break;
                }
                Thread.Sleep(1000);
                questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Please wait.."; });
                if (Ready)
                {
                    questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Press Start Quiz when you are ready!"; });
                    break;
                }
                Thread.Sleep(1000);
                questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Please wait.."; });
                if (Ready)
                {
                    questionbox.Invoke((MethodInvoker)delegate { questionbox.Text = "Press Start Quiz when you are ready!"; });
                    break;
                }
                Thread.Sleep(1000);
            }

        }

        private void Worker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Worker is done, ready to start Quiz.
            Ready = true;
            Questions = GetQuizFile.TheQuestions;
            questionbox.Text = "Press Start Quiz when you are ready!";
        }

        private void Worker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get the Quiz file.
            GetQuizFile.GetQuiz();
        }

        private void submitanswer_Click(object sender, EventArgs e)
        {
            if(_currentQuestion == Questions.Count) { return; }
            //Stop the user from starting the quiz if it is not done loading.
            if (!Ready) { MessageBox.Show("Please wait till Quiz is done loading!"); return; }
            //Change the questionbox text to Submit Answer.
            if(submitanswer.Text == "Start Quiz") { submitanswer.Text = "Submit Answer"; StartQuiz(); return; }

            //Handle submitting of answers.
            SubmitAnswer();
        }
        private void StartQuiz()
        {
            //Set Questionbox Text equal to Question.
            questionbox.Text = Question.Question;
            //Clear all Options.
            optionsbox.Items.Clear();
            foreach(string option in Question.Options)
            {
                //Populate all Options.
                optionsbox.Items.Add(option);
            }
        }
        private void SubmitAnswer()
        {
            if(optionsbox.CheckedItems.Count == 0) { MessageBox.Show("You must select an answer!"); return; }
            //Add the answer to the list of student answers.
            StudentAnswers.Add(optionsbox.CheckedItems[0].ToString());
            if(optionsbox.CheckedItems[0].ToString() == Question.Answer)
            {
                //Add 1 Point to Score.
                _totalScore++;
            }
            //Increment _currentQuestion.
            _currentQuestion++;
            if (_currentQuestion == Questions.Count)
            {
                //Display total Score
                var percentage = ((decimal)_totalScore / Questions.Count) * 100;
                percentage = Math.Round(percentage, 2);
                MessageBox.Show(string.Format("Score: {0}/{1}. \n {2}%.", _totalScore, Questions.Count, percentage));

                //Generate PDF Summary of Student's Performance.
                PDFGenerator.GenerateReport(GetQuizFile.Title, StudentName, StudentAnswers, _totalScore, percentage);
                Application.Exit();
            }
            else
            {
                //Display next question.
                StartQuiz();
            }
        }

        private void optionsbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //If there are multiple items checked, uncheck the ones not selected.
            if(optionsbox.CheckedItems.Count > 0)
            {
                for(int i = 0; i < optionsbox.Items.Count; i++)
                {
                    if(i != e.Index)
                    {
                        optionsbox.SetItemChecked(i, false);
                    }
                }
            }
            return;
        }
        private void namesubmit_Click_1(object sender, EventArgs e)
        {
            if (nameinput.Text.Length == 0) { MessageBox.Show("You must supply a valid name!"); return; }

            StudentName = nameinput.Text;
            SetupQuizForm();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Questions != null)
            {
                if (_currentQuestion < Questions.Count)
                {
                    if (MessageBox.Show("Are you sure you want to close the application? \n WARNING: You will lose ALL progress!", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Application exits.
                    }
                    else
                    {
                        //Application resumes.
                        e.Cancel = true;
                        this.Activate();
                    }
                }
            }
        }

        private void optionsbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                submitanswer_Click(null, null);
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CloseApplication)
            {
                Application.Exit();
            }
        }
    }
}
