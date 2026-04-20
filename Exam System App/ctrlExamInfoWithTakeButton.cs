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
    public partial class ctrlExamInfoWithTakeButton : UserControl
    {
        // 1. Define a delegate (optional, but good practice for custom event args)
        public delegate void ExamSelectedEventHandler(object sender, int examId);

        // 2. Define the event
        public event ExamSelectedEventHandler TakeExamClicked;

        // (Make sure you have a public property for ExamId in ExamInfoUserControl)


        private int _ExamID;
        private clsExam _Exam;
        public int ExamId
        { 
            get { return ctrlExamInfo1.ExamID; }
            set {  ctrlExamInfo1.ExamID = value;  }
        }

        public clsExam ExamSelected
        {
            get { return ctrlExamInfo1.SelectedExamID; }
        }

        public string btn
        {
            get
            {
                return btnTakeExam.Text;
            }

            set
            {
                btnTakeExam.Text = value;
            }
        }

        public ctrlExamInfoWithTakeButton()
        {
            InitializeComponent();
        }

        public void LoadExamInfo(int examID)
        {
            _ExamID = examID;
            ctrlExamInfo1.LoadExamInfo(_ExamID);
        }

        private void btnTakeExam_Click(object sender, EventArgs e)
        {
            TakeExamClicked?.Invoke(this, this.ExamId);

            //frmStudentMain frm = new frmStudentMain();
            //frm._OpenChildForm(new frmTakeExam(this.ExamId));
        }
    }
}
