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
    public partial class frmFindQuestionOfExam : Form
    {
        private DataTable _dtAllQuestions;
        private clsQuestions _Question;
        public frmFindQuestionOfExam()
        {
            InitializeComponent();
        }

        private void frmFindQuestionOfExam_Load(object sender, EventArgs e)
        {
            _dtAllQuestions= clsQuestions.GetAllQuestions();
            dgvQuestions.DataSource= _dtAllQuestions;
            cbFilterBy.SelectedIndex = 0;

            if(dgvQuestions.Rows.Count > 0)
            {
                dgvQuestions.Columns[0].Width = 50;
                dgvQuestions.Columns[1].Width = 50;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnString = "";

            switch(cbFilterBy.Text)
            {
                case "Subject":
                    ColumnString = "Subject";
                    break;
                case "Title":
                    ColumnString = "Title";
                    break;
                default:
                    ColumnString = "Unkown";
                    break;

            }
            if (txtSearch.Text == "" || ColumnString == "Unknown")
                _dtAllQuestions.DefaultView.RowFilter = "";

            _dtAllQuestions.DefaultView.RowFilter = string.Format("{0} Like '{1}%'", ColumnString, txtSearch.Text.Trim());
            //_dtAllQuestions.DefaultView.RowFilter = string.Format("{0} Like '{1}%'", "Title", txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbFilterBy.SelectedIndex = 0;
            txtSearch.Text = "";
        }

        private void dgvQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Check if the clicked cell is actually a button column and not the header row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure a valid row and column was clicked
            {
                // Get the column that was clicked
                DataGridViewColumn clickedColumn = dgvQuestions.Columns[e.ColumnIndex];

                // Check if it's the "Edit" button column
                if (clickedColumn.Name == "btnEditColumn") // Use the Name you gave the column
                {
                    // Get the UserId from the clicked row
                    //int examIdToEdit = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["ExamID"].Value);
                    //int examID = (int)dgvQuestions.CurrentRow.Cells["Title"].Value;
                    int questionID = (int)dgvQuestions.CurrentRow.Cells["QuestionID"].Value;
                    _Question = clsQuestions.Find(questionID);
                    frmAddUpdateQuestion editForm = new frmAddUpdateQuestion(_Question);
                    editForm.Edit(questionID);
                    editForm.ShowDialog(); // Show as modal dialog

                    frmFindQuestionOfExam_Load(null, null);
                    //MessageBox.Show($"Edit button clicked for User ID: {examIdToEdit}");
                }
                // Check if it's the "Delete" button column
                else if (clickedColumn.Name == "btnDeleteColumn") // Use the Name you gave the column
                {
                    int questionIdToDelete = Convert.ToInt32(dgvQuestions.Rows[e.RowIndex].Cells["QuestionID"].Value);
                    //string TitleToDelete = dgvQuestions.Rows[e.RowIndex].Cells["Question Test"].Value.ToString();

                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to delete Question  '', (ID: {questionIdToDelete})?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Call your BLL to delete the user
                        bool success = clsQuestions.DeleteQuestion(questionIdToDelete);
                        if (success)
                        {
                            MessageBox.Show("Question deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmFindQuestionOfExam_Load(null, null); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show($"Delete button clicked for User ID: {questionIdToDelete}");
                    }
                }
            }
        }
    }
}
