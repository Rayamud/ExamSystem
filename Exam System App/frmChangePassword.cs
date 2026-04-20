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
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void _ReseetDefaultValue()
        {
            txtCurrentPassword.Text = "";
            txtCurrentPassword.Focus();
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ReseetDefaultValue();

            _User = clsUser.Find(_UserID);

            if( _User == null )
            {
                MessageBox.Show("Could Not Find User With UserID = " + _UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo( _UserID );
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty( txtCurrentPassword.Text.Trim() ) )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password could not be Blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if (_User.Password != clsSecurtyHash.ComputeHash(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password could not be Blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim() )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password comfirmation does not match new password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Field are not Valid!", "Error Vslidation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = clsSecurtyHash.ComputeHash(txtNewPassword.Text);
            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ReseetDefaultValue();

                //when change password the info that saved in windows registry not change so it does not allow you to enter
                //to delete the old username and password that saved in windows registry
                clsGlobal.DeleteUserNameAndPasswordValueSaved();
                //write the new username and password
                clsGlobal.RememberUsernameAndPassword(_User.UserName, _User.Password);

                this.Close();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("An Error Occur , password not Save", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
