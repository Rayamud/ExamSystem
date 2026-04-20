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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.Find(txtUserName.Text.Trim());
            //clsUser user = clsUser.Find(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null && clsSecurtyHash.VerifyPassword(txtPassword.Text.Trim(), user.Password))
            {
                if (chbRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                if(user.Role == 1)
                {
                    FrmAdminMain frmAdimn = new FrmAdminMain(this);
                    frmAdimn.ShowDialog();
                }
                else if(user.Role == 2)
                {
                    frmStudentMain frmStudent = new frmStudentMain(this);
                    frmStudent.ShowDialog();
                }
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string userName = ""; string password = "";

            if (clsGlobal.GetStoredCredential(ref userName, ref password))
            {
                txtUserName.Text = userName;
                txtPassword.Text = password;
                chbRememberMe.Checked = true;
            }
            else
                chbRememberMe.Checked = false;
        }
    }
}
