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
    public partial class frmListStudentResult : Form
    {
        private DataTable _dtAllResults;
        private clsResults _result;
        public frmListStudentResult()
        {
            InitializeComponent();
        }

        private void frmListStudentResult_Load(object sender, EventArgs e)
        {
            _dtAllResults = clsResults.GetAllResults();
            dgvAllResults.DataSource = _dtAllResults;

            dgvAllResults.Columns[0].Width = 100;
        }

        private void dgvAllResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dgvAllResults.Columns[e.ColumnIndex];

                // Check if it's the "Edit" button column
                if (clickedColumn.Name == "btnShowResult") // Use the Name you gave the column
                {
                    // Get the UserId from the clicked row
                    //int examIdToEdit = Convert.ToInt32(dgvExams.Rows[e.RowIndex].Cells["ExamID"].Value);
                    int resultID = (int)dgvAllResults.CurrentRow.Cells["ResultID"].Value;
                    _result = clsResults.Find(resultID);

                    if(_result != null)
                    {
                        frmShowResult editForm = new frmShowResult(_result);
                        editForm.ShowDialog(); // Show as modal dialog
                        //FrmAdminMain frm = new FrmAdminMain();
                        //frm._OpenChildForm(new frmShowResult(_result));
                    }
                    else
                    {
                        MessageBox.Show("REsult not Found, null ", "Not found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    frmListStudentResult_Load(null, null);
                    //MessageBox.Show($"Edit button clicked for User ID: {examIdToEdit}");
                }
            }
        }
    }
}
