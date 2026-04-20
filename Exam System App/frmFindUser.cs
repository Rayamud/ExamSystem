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
    public partial class frmFindUser : Form
    {
        public delegate void DataBackEvent(object sender, int personID);
        public event DataBackEvent DataBack;

        private int _UserID;
        public frmFindUser()
        {
            InitializeComponent();
        }

        public frmFindUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlUserCardWithFilter1.UserID);
        }

        private void frmFindUser_Load(object sender, EventArgs e)
        {
            //ctrlUserCardWithFilter1.LoadInfo(_UserID);
        }
    }
}
