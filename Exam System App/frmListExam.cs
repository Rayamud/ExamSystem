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
    public partial class frmListExam : Form
    {
        private static DataTable _dtAllExams;
        public frmListExam()
        {
            InitializeComponent();
        }

        private void frmListExam_Load(object sender, EventArgs e)
        {
            _dtAllExams = clsExam.GetAllExams();
            dgvExams.DataSource = _dtAllExams;

            if (_dtAllExams.Rows.Count > 0)
            {
                dgvExams.Columns[0].HeaderText = "Edit";
                dgvExams.Columns[0].Width = 50;

                dgvExams.Columns[1].HeaderText = "Add Question";
                dgvExams.Columns[1].Width = 100;

                dgvExams.Columns[2].HeaderText = "Delete";
                dgvExams.Columns[2].Width = 50;

                dgvExams.Columns[3].HeaderText = "ID";
                dgvExams.Columns[3].Width = 50;

                dgvExams.Columns[4].HeaderText = "Title";
                dgvExams.Columns[4].Width = 100;

                dgvExams.Columns[5].HeaderText = "Description";
                dgvExams.Columns[5].Width = 100;

                dgvExams.Columns[6].HeaderText = "Date";
                dgvExams.Columns[6].Width = 100;
            }
        }

        private void dgvExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is actually a button column and not the header row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure a valid row and column was clicked
            {
                // Get the column that was clicked
                DataGridViewColumn clickedColumn = dgvExams.Columns[e.ColumnIndex];

                // Check if it's the "Edit" button column
                if (clickedColumn.Name == "btnEditColumn") // Use the Name you gave the column
                {
                    // Get the UserId from the clicked row
                    //int examIdToEdit = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["ExamID"].Value);
                    int examID = (int)dgvExams.CurrentRow.Cells["ExamID"].Value;

                    frmAddUpdateExam editForm = new frmAddUpdateExam(examID);
                    editForm.ShowDialog(); // Show as modal dialog

                    frmListExam_Load(null, null);
                    //MessageBox.Show($"Edit button clicked for User ID: {examIdToEdit}");
                }
                // Check if it's the "Delete" button column
                else if (clickedColumn.Name == "btnDeleteColumn") // Use the Name you gave the column
                {
                    int examIdToDelete = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["ExamID"].Value);
                    string TitleToDelete = dgvExams.Rows[e.RowIndex].Cells["Title"].Value.ToString();

                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to delete Exam  '{TitleToDelete}', (ID: {examIdToDelete})?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Call your BLL to delete the user
                         bool success = clsExam.Delete(examIdToDelete);
                        if (success)
                        {
                            MessageBox.Show("Exam deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmListExam_Load(null, null); // Refresh the list
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show($"Delete button clicked for User ID: {examIdToDelete}");
                    }
                }
                else if (clickedColumn.Name == "btnAddQuestion")
                {
                    int examID = (int)dgvExams.CurrentRow.Cells["ExamID"].Value;
                    frmAddUpdateQuestion frmQuestion = new frmAddUpdateQuestion(examID);
                    frmQuestion.ShowDialog();
                    frmListExam_Load(null, null); // Refresh the list
                }

             
                // Add more else if blocks for other button columns (e.g., "Manage Questions")


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _dtAllExams.DefaultView.RowFilter = string.Format("{0} Like '{1}%'","Title",txtSearch.Text.Trim());
           // FrmAdminMain frm = new FrmAdminMain();
           
        }

        private void dgvExams_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
