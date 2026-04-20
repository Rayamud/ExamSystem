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
    public partial class frmAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int UserID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew =0, Update =1}
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male =1, Female =2}
        public enum enRole { Admin = 1, Srudent = 2 }

        private clsUser _User;
        private int _UserID;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _UserID = userID;
        }

        private void _ResetDefaultValue()
        {
            if(Mode  == enMode.AddNew)
            {
                lblTitle.Text = "Create User"; 
                _User = new clsUser();
            }
            else
                lblTitle.Text = "Edit User";

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            dtpDateOfBirth.Text = DateTime.Now.ToString();
            txtEmail.Text = "";
            txtAddress.Text = "";

            rbMale.Checked = true;
            if (rbMale.Checked)
                pbNewUser.Image = Resources.Male_215;
            else
                pbNewUser.Image = Resources.female_215;

            rbStudent.Checked = true;

        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if( _User == null )
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            txtFirstName.Text = _User.FirstName;
            txtLastName.Text = _User.LastName;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            dtpDateOfBirth.Value = _User.DateOfBirth;
            txtEmail.Text = _User.Email;
            txtAddress.Text = _User.Address;

            if (_User.Gender == 1)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_User.ImagePath != "")
                pbNewUser.ImageLocation = _User.ImagePath;
            else
            {
                if (_User.Gender == 1)
                    pbNewUser.Image = Resources.Male_215;
                else
                    pbNewUser.Image = Resources.female_215;
            }

            if(_User.Role == 1)
                rbAdmin.Checked = true;
            else
                rbStudent.Checked = true;

        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

            if(Mode == enMode.Update)
                _LoadData();
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbNewUser.ImageLocation == null)
                pbNewUser.Image = Resources.Male_215;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbNewUser.ImageLocation == null)
                pbNewUser.Image = Resources.female_215;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.FirstName = txtFirstName.Text;
            _User.LastName = txtLastName.Text;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _User.Gender = (short)enGender.Male;
            else
                _User.Gender = (short)enGender.Female;

            _User.Email = txtEmail.Text;
            _User.Address = txtAddress.Text;
            if (pbNewUser.ImageLocation != null)
                _User.ImagePath = pbNewUser.ImageLocation;
            else
                _User.ImagePath = "";
            
            if(rbAdmin.Checked)
                _User.Role = (short)enRole.Admin;
            else
                _User.Role = (short) enRole.Srudent;

            if(_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                Mode = enMode.Update;
                lblTitle.Text = "Edit User";

                MessageBox.Show("User Created Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this , _User.UserID);
                btnSave.Enabled = false;
                //this.Close();

                //when change password the info that saved in windows registry not change so it does not allow you to enter
                //to delete the old username and password that saved in windows registry
                clsGlobal.DeleteUserNameAndPasswordValueSaved();
                //write the new username and password
                clsGlobal.RememberUsernameAndPassword(_User.UserName, _User.Password);
            }
            else
            {
                MessageBox.Show("Error: User Failed to Create", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
            

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if(!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            //Make sure the national number is not used by another person
           if(Mode == enMode.AddNew)
           {
                if (txtUserName.Text.Trim() != _User.UserName && clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "User Name is used for another User!");

                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
           }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {

        }
    }
}
