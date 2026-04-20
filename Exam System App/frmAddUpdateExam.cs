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
    public partial class frmAddUpdateExam : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        private int _ExamID;
        private clsExam _Exam;

        public frmAddUpdateExam()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddUpdateExam(int examID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _ExamID = examID;
        }

        private void _ResetDefaultValue()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Create Exam";
                _Exam = new clsExam();
            }
            else
                lblTitle.Text = "Edit Exam";

            txtTitle.Text = "";
            txtDescription.Text = "";
            dtpExam.Value = DateTime.Now;
        }

        private void _LoadData()
        {
            _Exam = clsExam.Fine(_ExamID);

            if (_Exam == null)
            {
                MessageBox.Show("No Exam with ID = " + _ExamID, "Exam Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblExamID.Text = _Exam.ExamID.ToString();
            txtTitle.Text = _Exam.Title;
            txtDescription.Text = _Exam.Description;
            dtpExam.Text = _Exam.CreatedDate.ToShortDateString();
        }

        private void frmAddUpdateExam_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if(Mode == enMode.Update) 
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Exam.Title = txtTitle.Text;
            _Exam.Description= txtDescription.Text;
            _Exam.CreatedDate = dtpExam.Value;

            if(_Exam.Save())
            {
                lblExamID.Text = _Exam.ExamID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Edit Exam";
                MessageBox.Show("Exam Created Successfully, with ID :"+_Exam.ExamID.ToString(),"Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Exam Failed to Create", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTitle.Text))
            {
                errorProvider1.SetError(txtTitle, "this Field is Required");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }
    }
}
