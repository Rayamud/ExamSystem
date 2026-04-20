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
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID;
        private clsUser _User;

        public int UserID
        {
            get { return _UserID; }
        }

        public clsUser SelectedUserInfo
        {
            get { return _User; }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserInfo()
        {
            _UserID = -1;
            lblUserID.Text = "";
            lblFullName.Text = "";
            lblUserName.Text = "";
            lblDateOfBirth.Text = "";
            lblGender.Text = "";
            lblEmail.Text = "";
            lblAddress.Text = "";
            lblRole.Text = "";
            pbNewUser.Image = Resources.Male_215;
        }

        private void _LoadUserImage()
        {
            if (_User.Gender == 1)
                pbNewUser.Image = Resources.Male_215;
            else
                pbNewUser.Image = Resources.female_215;
        }

        private void _FillUserInfo()
        {
            llEditUser.Enabled = true;

            _UserID = _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            lblFullName.Text = _User.FullName;
            lblUserName.Text = _User.UserName;
            lblDateOfBirth.Text = _User.DateOfBirth.ToShortDateString();
            lblGender.Text = (_User.Gender == 1) ? "Male" : "Female";
            lblEmail.Text = _User.Email;
            lblAddress.Text = _User.Address;
            lblRole.Text = (_User.Role == 1) ? "Admin" : "Student";

            _LoadUserImage();
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with ID : "+UserID.ToString() ,"Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        public void LoadUserInfo(string UserName)
        {
            _User = clsUser.Find(UserName);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserName : " + UserName, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void llEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(_UserID);
            frm.ShowDialog();

            LoadUserInfo(_UserID);
        }
    }
}
