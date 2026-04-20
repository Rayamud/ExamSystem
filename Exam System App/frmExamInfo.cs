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
    public partial class frmExamInfo : Form
    {
        private clsExam _Exam;
        public frmExamInfo()
        {
            InitializeComponent();
        }

        public List<clsExam> GetAllExams()
        {

            List<clsExam> examList = new List<clsExam>();
            DataTable dtExam = clsExam.GetAllExams();

            foreach (DataRow row in dtExam.Rows)
            {
                // 4.For each DataRow, create a new Exam object
                clsExam exam = new clsExam();

                // 5. Populate the properties of the Exam object from the DataRow
                //    Make sure the column names match exactly what's in your DataTable
                //    Use Convert.ToXxx() for numeric, date, or other specific types
                exam.ExamID = Convert.ToInt32(row["ExamID"]);
                exam.Title = row["Title"].ToString();
                exam.Description = row["Description"].ToString();
                exam.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                // Add any other properties your Exam model has, e.g.:
                // exam.SomeOtherProperty = row["SomeOtherColumn"].ToString();

                // 6. Add the populated Exam object to your list
                examList.Add(exam);
            }
            return examList;
        }

        private void frmExamInfo_Load(object sender, EventArgs e)
        {
            try
            {
                List<clsExam> examList = GetAllExams();


                foreach (var item in examList)
                {
                    ctrlExamInfo examInfo = new ctrlExamInfo();

                    flPanel.Controls.Add(examInfo);
                    examInfo.LoadExamInfo(item.ExamID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
