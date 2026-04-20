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
    public partial class ctrlExamInfo : UserControl
    {
        private int _ExamID;
        private clsExam _Exam;

        public int ExamID
        {
            get { return _ExamID; }
            set { _ExamID = value; }
        }

        public clsExam SelectedExamID
        {
            get { return _Exam; }
        }
        public ctrlExamInfo()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValue()
        {
            _ExamID = -1;
            lblExamID.Text = "";
            lblTitle.Text = "";
            lblDescription.Text = "";
            lblCreatedDate.Text = "";
            lblQuestionCount.Text = "";
        }

        private void _FillExamInfo()
        {
            _ExamID = _Exam.ExamID;
            lblExamID.Text = _ExamID.ToString();
            lblTitle.Text = _Exam.Title;
            lblDescription.Text = _Exam.Description;
            lblCreatedDate.Text = _Exam.CreatedDate.ToShortDateString();
            lblQuestionCount.Text = clsQuestions.GetQuestionCountByExamId(_ExamID).ToString();
        }

        public void LoadExamInfo(int examID)
        {
            _Exam = clsExam.Fine(examID);

            if( _Exam == null )
            {
                _ResetDefaultValue();
                MessageBox.Show("No Exam with ID : " + examID.ToString(), "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillExamInfo();
        }
    }
}
