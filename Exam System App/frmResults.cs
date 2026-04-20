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
    public partial class frmResults : Form
    {
        //public delegate void DataBackEventHandler(object sender, int ExamID);

        //// Declare an event using the delegate
        //public event DataBackEventHandler DataBack;

        private clsResults _result;
        private int _examID;
        public frmResults()
        {
            InitializeComponent();
        }


        public List<clsExam> GetAllExams()
        {

            List<clsExam> examList = new List<clsExam>();
            DataTable dtExam = clsExam.GetAllExams();

            foreach (DataRow row in dtExam.Rows)
            {
                clsExam exam = new clsExam();

                exam.ExamID = Convert.ToInt32(row["ExamID"]);
                exam.Title = row["Title"].ToString();
                exam.Description = row["Description"].ToString();
                exam.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);

                examList.Add(exam);
            }
            return examList;
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            try
            {
                List<clsExam> examList = GetAllExams();
                // 1. Get all exams


                // Clear existing controls (if using FlowLayoutPanel or similar)
                flPanel.Controls.Clear();

                foreach (var item in examList)
                {
                    ctrlExamInfoWithTakeButton examInfo = new ctrlExamInfoWithTakeButton();
                    examInfo.ExamId = item.ExamID;

                    examInfo.TakeExamClicked += DataBackEvent_TakeExamClick;
                    _result = clsResults.FindByStudentIDAndExamID(clsGlobal.CurrentUser.UserID, item.ExamID);
                    
                    
                    if (_result != null && _result.Score != 0)
                    {
                        flPanel.Controls.Add(examInfo);
                        examInfo.LoadExamInfo(item.ExamID);
                        examInfo.btn = "See Result";
                    }
                    else
                    {
                        MessageBox.Show("you take Answer Question for Only these Exams ","Inform",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBackEvent_TakeExamClick(object sender, int examId)
        {
            //frmStudentMain frm = new frmStudentMain();
            //frm._OpenChildForm(new frmShowResult(clsResults.FindByStudentIDAndExamID(clsGlobal.CurrentUser.UserID, examId)));

            //frmShowResult frm2 = new frmShowResult(clsResults.FindByStudentIDAndExamID(clsGlobal.CurrentUser.UserID, examId));
            //frm2.ShowDialog();
            _examID = examId;
            _OpenChildForm(new frmShowResult(clsResults.FindByStudentIDAndExamID(clsGlobal.CurrentUser.UserID, examId)));
        }


        private Form _activeForm = null;
        public void _OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
                _activeForm.Close();

            _activeForm = childForm;

            _activeForm.TopLevel = false;
            _activeForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /*
            1-first we show controls of all exam that student take with button to show the result
            2-and we could do that when the student submit the question we show button to show the result of this exam
                that result take exam it as para

            3-or we just do what in first step to show all exam that student take 
            4-Result form show : Exam Name or title , number of question of this exam , student answer question count of total , score, 
                we could put student name (info) too
         */
    }
}
