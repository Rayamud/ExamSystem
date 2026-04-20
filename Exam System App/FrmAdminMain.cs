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
    public partial class FrmAdminMain : Form
    {
        frmLogin _frmLogin;
        public FrmAdminMain(frmLogin frmlogin)
        {
            InitializeComponent();
            _frmLogin = frmlogin;
            customizeDesign();
        }

        public FrmAdminMain()
        {
            InitializeComponent();
            
        }

        private void customizeDesign()
        {
            panelUserSubMenu.Visible = false;
            panelStudentSubMenu.Visible = false;
            panelExamSubMenu.Visible = false;

        }

        private void _HideSubMenu()
        {
            if(panelUserSubMenu.Visible == true)
                panelUserSubMenu.Visible = false;
            if (panelStudentSubMenu.Visible == true)
                panelStudentSubMenu.Visible = false;
            if (panelExamSubMenu.Visible == true)
                panelExamSubMenu.Visible = false;

        }

        private void _ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                _HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void btnUser_Click(object sender, EventArgs e)
        {
            _ShowSubMenu(panelUserSubMenu);
        }

        private void btnListUser_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmListUser());
            _HideSubMenu();
        }

        private void btnAddUpdateUser_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmAddUpdateUser());
            _HideSubMenu();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmFindUser());
            _HideSubMenu();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmChangePassword(clsGlobal.CurrentUser.UserID));
            _HideSubMenu();
        }

        

        private void btnStudent_Click(object sender, EventArgs e)
        {
            _ShowSubMenu(panelStudentSubMenu);
        }

        private void btnListStudent_Click(object sender, EventArgs e)
        {
            _HideSubMenu();
        }

        private void btnAddUpdateStudent_Click(object sender, EventArgs e)
        {
            //_OpenChildForm(new frmAddUpdateQuestion());
            _HideSubMenu();
        }

        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            _HideSubMenu();
        }

        private void btnStudentInfo_Click(object sender, EventArgs e)
        {
            _HideSubMenu();
        }

        private void btnStudentResult_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmListStudentResult());
            _HideSubMenu();
        }



        private void btnExam_Click(object sender, EventArgs e)
        {
            _ShowSubMenu(panelExamSubMenu);
        }

        private void btnListExam_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmListExam());
            _HideSubMenu();
        }

        private void btnAddUpdateExam_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmAddUpdateExam());
            _HideSubMenu();
        }

        private void btnFindExam_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmFindQuestionOfExam());
            _HideSubMenu();
        }

        private void btnExamInfo_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmExamInfo());
            _HideSubMenu();
        }

       
        private void FrmAdminMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
            if (clsGlobal.CurrentUser.Gender == 1)
                pbUser.Image = Resources.Male_215;
            else
                pbUser.Image = Resources.female_215;

            lblUserNameWelcom.Text = clsGlobal.CurrentUser.UserName;
        }

        //Action<Form> OpenChildForm = _OpenChildForm;

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm.Close();
            panelMain.Controls.Add(panelCover);
        }

        private bool _CloseAllApplication = true;
        private bool _isLoggingOut = false;
        private void FrmAdminMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (_CloseAllApplication)
            //{
            //    _frmLogin.Close();
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
    }
}
