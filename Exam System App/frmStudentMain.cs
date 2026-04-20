using BusinessLogicLayer;
using Exam_System_App.Properties;
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
    public partial class frmStudentMain : Form
    {
        public delegate void DataBackEventHandler(object sender, int examID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        //private int _ExamID = ctrlExamInfoWithTakeButton1.ExamID;

        frmLogin _frmLogin;
        public frmStudentMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        public frmStudentMain()
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


        private void frmStudentMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            if (clsGlobal.CurrentUser.Gender == 1)
                pbUser.Image = Resources.Male_215;
            else
                pbUser.Image = Resources.female_215;
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

                    flPanel.Controls.Add(examInfo);
                    examInfo.LoadExamInfo(item.ExamID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private int _examID;
        private void DataBackEvent_TakeExamClick(object sender, int examId)
        {
            _examID = examId;
            _OpenChildForm(new frmTakeExam(examId));
        }


    
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm.Close();
            panelMain.Controls.Add(panelCover);
        }


        private bool _CloseAllApplication;
        private bool _isLoggingOut = false;
        private void frmStudentMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_CloseAllApplication = true;
            //if (_CloseAllApplication)
            //{
            //    _frmLogin.Show();
            //    return;
            //}

            if (!_isLoggingOut)
            {
                // Close the LoginForm to terminate the entire application.
                if (_frmLogin != null && !_frmLogin.IsDisposed)
                {
                    _frmLogin.Close(); // This is the line that causes the app to exit.
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                return; // User cancelled logout, do nothing
            }
            //clsGlobal.CurrentUser = null;
            //_frmLogin.Show();
            //this.Close();

            _isLoggingOut = true;

            // Show the LoginForm now, before closing this form.
            if (_frmLogin != null && !_frmLogin.IsDisposed)
            {
                _frmLogin.Show();
                // Optional: Clear fields on the LoginForm, if you have a method for it
                // _frmLogin.ClearLoginFormFields();
            }

            // Close the current frmStudentMain form. This will trigger frmStudentMain_FormClosed.
            this.Close();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmResults());
        }
    }
}
