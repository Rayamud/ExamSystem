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

namespace Exam_System_App
{
    public partial class frmAddUpdateQuestion : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        private int _QuestionID;
        private clsQuestions _Question;

        private int _ExamID;
        private clsExam _Exam;

        public frmAddUpdateQuestion(clsQuestions question)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _Question = question;
        }

        public frmAddUpdateQuestion(int examID)
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            _ExamID = examID;


        }

        public void Edit(int questionID)
        {
            Mode = enMode.Update;
            _QuestionID = questionID;
        }

        private void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Create Question";
                _Question = new clsQuestions();
            }
            else
                lblTitle.Text = "Edit Question";

            txtSubject.Text = "";
            txtQuestionText.Text = "";
            txtOptionA.Text = "";
            txtOptionB.Text = "";
            txtOptionC.Text = "";
            txtOptionD.Text = "";
            lblExamTitle.Text = clsExam.Fine(_ExamID).Title; // _Exam.Title
            rbA.Checked = true;
        }

        private void _LoadData()
        {
            _Question= clsQuestions.Find(_QuestionID);

            if ( _Question == null )
            {
                MessageBox.Show("No Question with ID = " + _QuestionID, "Question Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblQuestionID.Text = _Question.QuestionID.ToString();
            lblExamTitle.Text = _Question.ExamIDInfo.Title;
            txtSubject.Text = _Question.Subject;
            txtQuestionText.Text = _Question.QuestionText;
            txtOptionA.Text = _Question.OptionA;
            txtOptionB.Text = _Question.OptionB;
            txtOptionC.Text = _Question.OptionC;
            txtOptionD.Text = _Question.OptionD;

            if(_Question.CorrectOption == "A")
                rbA.Checked = true;
            else if(_Question.CorrectOption == "B")
                rbB.Checked = true;
            else if (_Question.CorrectOption == "C")
                rbC.Checked = true;
            else if (_Question.CorrectOption == "D")
                rbD.Checked = true;
            

        }

        private void frmAddUpdateQuestion_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if (Mode == enMode.Update)
                _LoadData();

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Question.Subject = txtSubject.Text;
            _Question.QuestionText = txtQuestionText.Text;
            _Question.OptionA = txtOptionA.Text;
            _Question.OptionB = txtOptionB.Text;
            _Question.OptionC = txtOptionC.Text;
            _Question.OptionD = txtOptionD.Text;
            _Question.ExamId = _ExamID;

            if (rbA.Checked)
                _Question.CorrectOption = "A";
            else if (rbB.Checked)
                _Question.CorrectOption = "B";
            else if (rbC.Checked)
                _Question.CorrectOption = "C";
            else if (rbD.Checked)
                _Question.CorrectOption = "D";

            if(_Question.Save())
            {
                lblQuestionID.Text = _Question.QuestionID.ToString();
                lblTitle.Text = "Edit Question";
                Mode = enMode.Update;
                MessageBox.Show("Question Created Successfully, with ID :" + _Question.QuestionID.ToString(), "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Question Failed to Create", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }
    }
}
