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
    public partial class frmListUser : Form
    {
        private static DataTable _dtUssers;
        private static DataTable _dtAllUssers;
        public frmListUser()
        {
            InitializeComponent();
        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            _dtUssers = clsUser.GetAllUsers();
            _dtAllUssers = _dtUssers.DefaultView.ToTable(false,"ID","FirstName","LastName","UserName","DateOfBirth","Genders","Email",
                "Address" ,"ImagePath","Roles");

            dgvUsers.DataSource = _dtAllUssers;

            if(dgvUsers.Rows.Count > 0 )
            {
                dgvUsers.Columns[0].HeaderText = "ID";
                dgvUsers.Columns[0].Width = 50;

                dgvUsers.Columns[1].HeaderText = "First Name";
                dgvUsers.Columns[1].Width = 100;

                dgvUsers.Columns[2].HeaderText = "Last Name";
                dgvUsers.Columns[2].Width = 100;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 100;

                dgvUsers.Columns[4].HeaderText = "DateOfBirth";
                dgvUsers.Columns[4].Width = 100;

                dgvUsers.Columns[5].HeaderText = "Genders";
                dgvUsers.Columns[5].Width = 50;

                dgvUsers.Columns[6].HeaderText = "Email";
                dgvUsers.Columns[6].Width = 100;

                dgvUsers.Columns[7].HeaderText = "Address";
                dgvUsers.Columns[7].Width = 100;

                dgvUsers.Columns[8].HeaderText = "Image Path";
                dgvUsers.Columns[8].Width = 100;

                dgvUsers.Columns[9].HeaderText = "Roles";
                dgvUsers.Columns[9].Width = 50;



            }
        }

        private void dgvUsers_Click(object sender, EventArgs e)
        {
        //    int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

        //    FrmAdminMain frm = new FrmAdminMain();
        //    frm._OpenChildForm(new frmAddUpdateUser(UserID));
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
         
            frmAddUpdateUser frm2 = new frmAddUpdateUser(UserID);
            frm2.Show();
           
        }

        private void dgvUsers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            //frmFindUser frm = new frmFindUser(UserID);
            //frm.Show();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            //frmFindUser frm = new frmFindUser(UserID);
            //frm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string ColumnFilter = "";

            switch(cbFilterBy.Text)
            {
                case "First Name":
                    ColumnFilter = "FirstName";
                    break;
                case "Role":
                    ColumnFilter = "Roles";
                    break;
                case "Gender":
                    ColumnFilter = "Genders";
                    break;
                
                default:
                    ColumnFilter = "None";
                    break;

            }

            if (txtSearch.Text.Trim() == "" || ColumnFilter == "None")
            {
                _dtAllUssers.DefaultView.RowFilter = "";
                return;
            }

           

            //if(ColumnFilter == "Genders" || ColumnFilter == "Roles")
            //    _dtAllUssers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnFilter, txtSearch.Text.Trim());

            _dtAllUssers.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnFilter, txtSearch.Text.Trim());
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            //int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            //frmShowUserInfo frm = new frmShowUserInfo(UserID);
            //frm.ShowDialog();
        }
    }
}
