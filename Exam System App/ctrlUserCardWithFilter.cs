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
    public partial class ctrlUserCardWithFilter : UserControl
    {
        public event Action<int> OnUserSelected;

        protected virtual void UserSelected(int userID)
        {
            Action <int> handler = OnUserSelected;

            if (handler != null)
                handler(userID);
        }

        private int _UserID = -1;

        public int UserID
        {
            get { return ctrlUserCard1.UserID; }
        }
        public clsUser SelectedUserInfo
        {
            get { return ctrlUserCard1.SelectedUserInfo; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled;}
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        public ctrlUserCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlUserCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void _FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "User ID":
                    ctrlUserCard1.LoadUserInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "User Name":
                    ctrlUserCard1.LoadUserInfo(txtFilterValue.Text);
                    break;
                
                default:
                    break;
            }

            if (OnUserSelected != null && FilterEnabled)
                OnUserSelected(ctrlUserCard1.UserID);
        }

        public void LoadInfo(int userID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = userID.ToString();
            _FindNow();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void DataBackEvent (object sender, int UserID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = UserID.ToString();
            ctrlUserCard1.LoadUserInfo(UserID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }

            if (cbFilterBy.Text == "User ID")
            {
                e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
            }
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "this Feild is required");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
    }
}
