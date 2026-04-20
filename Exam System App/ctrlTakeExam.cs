using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Exam_System_App
{
    public partial class ctrlTakeExam : UserControl
    {
        // 1. Define a delegate for your custom event (can be simple EventArgs if no data is passed)
        public delegate void AnswerSelectionChangedEventHandler(object sender, EventArgs e);
        // 2. Declare the event
        public event AnswerSelectionChangedEventHandler AnswerSelectionChanged;


        private int _QuestionID;

        private clsQuestions _Questions;

        public int QuestionID
        {
            get { return _QuestionID; }
            set { _QuestionID = value; }
        }

        public clsQuestions Questions
        { 
            get { return _Questions; }
        }

        private string _selectedOption ="U";
        public string SelectedOption
        {
            get
            {
                //if (rbOptionA.Checked) return "A";
                //if (rbOptionB.Checked) return "B";
                //if (rbOptionC.Checked) return "C";
                //if (rbOptionD.Checked) return "D";

                return _selectedOption;
            }
        }

        private int _AllQuestionCount;
        public int _currentQuestionIndex = 0;

        private bool _controlEnable = true;
        public bool ControlEnable
        {
            get { return _controlEnable; }
            set 
            {
                _controlEnable = value;
                gbTitleExam.Enabled = _controlEnable;
            }
        }


        public ctrlTakeExam()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValue()
        {
            _QuestionID = -1;
            lblQuestionText.Text = "";

            rbOptionA.Checked = false;
            rbOptionB.Checked = false;
            rbOptionC.Checked = false;
            rbOptionD.Checked = false;

        }

        public void SetSelectedOption(string option)
        {
            if (option == "A")
            {
                rbOptionA.Checked = true;
                rbOptionA.BackColor = Color.AliceBlue;
            }
            else if (option == "B")
            {
                rbOptionB.Checked = true;
                rbOptionB.BackColor = Color.AliceBlue;
            }
            else if (option == "C")
            {
                rbOptionC.Checked = true;
                rbOptionC.BackColor = Color.AliceBlue;
            }
            else if (option == "D")
            {
                rbOptionD.Checked = true;
                rbOptionD.BackColor = Color.AliceBlue;
            }
           
        }

        private void _FillData()
        {
            _QuestionID = _Questions.QuestionID;
            gbTitleExam.Text = _Questions.ExamIDInfo.Title;
            lblQuestionText.Text = _Questions.QuestionText;
            rbOptionA.Text = _Questions.OptionA;
            rbOptionB.Text = _Questions.OptionB;
            rbOptionC.Text = _Questions.OptionC;
            rbOptionD.Text = _Questions.OptionD;

        

            //if(_Questions.)



            _AllQuestionCount = clsQuestions.GetQuestionCountByExamId(_Questions.ExamId);

            lblQuestionCounter.Text = $"{_currentQuestionIndex + 1} / {_AllQuestionCount}";
        }

        public void LoadQuestions(int quesID, int Index)
        {
            _Questions = clsQuestions.Find(quesID);
            _currentQuestionIndex = Index;

            if (_Questions == null)
            {
                _ResetDefaultValue();
                MessageBox.Show("No Question with quesID : " + quesID.ToString(), "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillData();
        }

        private void RadioButton_CheckCheange(object sender)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                // Raise the event to notify the parent form
                AnswerSelectionChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void rbOptionA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOptionA.Checked)
                _selectedOption = "A";
            //RadioButton rb = sender as RadioButton;
            RadioButton_CheckCheange(rbOptionA);
        }

        private void rbOptionB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOptionB.Checked)
                _selectedOption = "B";

            RadioButton_CheckCheange(rbOptionB);
        }

        private void rbOptionC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOptionC.Checked)
                _selectedOption = "C";
            RadioButton_CheckCheange(rbOptionC);
        }

        private void rbOptionD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOptionD.Checked)
                _selectedOption = "D";
            RadioButton_CheckCheange(rbOptionD);
        }
    }
}
