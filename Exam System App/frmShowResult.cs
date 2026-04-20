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
    public partial class frmShowResult : Form
    {
        private clsResults _result;
        public frmShowResult(clsResults Result)
        {
            InitializeComponent();
            _result = Result;
        }

        private void frmShowResult_Load(object sender, EventArgs e)
        {
            int totalQuestions = clsQuestions.GetQuestionCountByExamId(_result.ExamID);
            int correctAnswers = _result.Score;
            double percentage = (double)correctAnswers / totalQuestions * 100;

            lblStudent.Text = _result.StudentInfo.FullName;
            lblExamTitle.Text = _result.ExamInfo.Title;
            lblTotalQuestion.Text = totalQuestions.ToString();
            lblCorrectAnswer.Text = correctAnswers.ToString();
            lblPercentageScore.Text = percentage.ToString();
            lblDate.Text = _result.SubmissionDate.ToString();


        }
    }
}
