namespace Exam_System_App
{
    partial class FrmAdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelExamSubMenu = new System.Windows.Forms.Panel();
            this.btnExamInfo = new System.Windows.Forms.Button();
            this.btnFindExam = new System.Windows.Forms.Button();
            this.btnAddUpdateExam = new System.Windows.Forms.Button();
            this.btnListExam = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.panelStudentSubMenu = new System.Windows.Forms.Panel();
            this.btnStudentResult = new System.Windows.Forms.Button();
            this.btnStudentInfo = new System.Windows.Forms.Button();
            this.btnFindStudent = new System.Windows.Forms.Button();
            this.btnAddUpdateQuestion = new System.Windows.Forms.Button();
            this.btnListStudent = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.panelUserSubMenu = new System.Windows.Forms.Panel();
            this.btnChangeUserPassword = new System.Windows.Forms.Button();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnAddUpdateUser = new System.Windows.Forms.Button();
            this.btnListUser = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCover = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblUserNameWelcom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.panelSide.SuspendLayout();
            this.panelExamSubMenu.SuspendLayout();
            this.panelStudentSubMenu.SuspendLayout();
            this.panelUserSubMenu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCover.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.AutoScroll = true;
            this.panelSide.BackColor = System.Drawing.Color.Black;
            this.panelSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSide.Controls.Add(this.btnExit);
            this.panelSide.Controls.Add(this.panelExamSubMenu);
            this.panelSide.Controls.Add(this.btnExam);
            this.panelSide.Controls.Add(this.panelStudentSubMenu);
            this.panelSide.Controls.Add(this.btnStudent);
            this.panelSide.Controls.Add(this.panelUserSubMenu);
            this.panelSide.Controls.Add(this.btnUser);
            this.panelSide.Controls.Add(this.btnHome);
            this.panelSide.Controls.Add(this.panel2);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(181, 613);
            this.panelSide.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(0, 968);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(156, 47);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelExamSubMenu
            // 
            this.panelExamSubMenu.Controls.Add(this.btnExamInfo);
            this.panelExamSubMenu.Controls.Add(this.btnFindExam);
            this.panelExamSubMenu.Controls.Add(this.btnAddUpdateExam);
            this.panelExamSubMenu.Controls.Add(this.btnListExam);
            this.panelExamSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExamSubMenu.Location = new System.Drawing.Point(0, 759);
            this.panelExamSubMenu.Name = "panelExamSubMenu";
            this.panelExamSubMenu.Size = new System.Drawing.Size(156, 209);
            this.panelExamSubMenu.TabIndex = 6;
            // 
            // btnExamInfo
            // 
            this.btnExamInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExamInfo.FlatAppearance.BorderSize = 0;
            this.btnExamInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamInfo.Location = new System.Drawing.Point(0, 141);
            this.btnExamInfo.Name = "btnExamInfo";
            this.btnExamInfo.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnExamInfo.Size = new System.Drawing.Size(156, 47);
            this.btnExamInfo.TabIndex = 3;
            this.btnExamInfo.Text = "Exam Info";
            this.btnExamInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamInfo.UseVisualStyleBackColor = true;
            this.btnExamInfo.Click += new System.EventHandler(this.btnExamInfo_Click);
            // 
            // btnFindExam
            // 
            this.btnFindExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFindExam.FlatAppearance.BorderSize = 0;
            this.btnFindExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindExam.Location = new System.Drawing.Point(0, 94);
            this.btnFindExam.Name = "btnFindExam";
            this.btnFindExam.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnFindExam.Size = new System.Drawing.Size(156, 47);
            this.btnFindExam.TabIndex = 2;
            this.btnFindExam.Text = "Find Exam";
            this.btnFindExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindExam.UseVisualStyleBackColor = true;
            this.btnFindExam.Click += new System.EventHandler(this.btnFindExam_Click);
            // 
            // btnAddUpdateExam
            // 
            this.btnAddUpdateExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddUpdateExam.FlatAppearance.BorderSize = 0;
            this.btnAddUpdateExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdateExam.Location = new System.Drawing.Point(0, 47);
            this.btnAddUpdateExam.Name = "btnAddUpdateExam";
            this.btnAddUpdateExam.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAddUpdateExam.Size = new System.Drawing.Size(156, 47);
            this.btnAddUpdateExam.TabIndex = 1;
            this.btnAddUpdateExam.Text = "Create / Edit Exam";
            this.btnAddUpdateExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUpdateExam.UseVisualStyleBackColor = true;
            this.btnAddUpdateExam.Click += new System.EventHandler(this.btnAddUpdateExam_Click);
            // 
            // btnListExam
            // 
            this.btnListExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListExam.FlatAppearance.BorderSize = 0;
            this.btnListExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListExam.Location = new System.Drawing.Point(0, 0);
            this.btnListExam.Name = "btnListExam";
            this.btnListExam.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListExam.Size = new System.Drawing.Size(156, 47);
            this.btnListExam.TabIndex = 0;
            this.btnListExam.Text = "List Exams";
            this.btnListExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListExam.UseVisualStyleBackColor = true;
            this.btnListExam.Click += new System.EventHandler(this.btnListExam_Click);
            // 
            // btnExam
            // 
            this.btnExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExam.Location = new System.Drawing.Point(0, 712);
            this.btnExam.Name = "btnExam";
            this.btnExam.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExam.Size = new System.Drawing.Size(156, 47);
            this.btnExam.TabIndex = 5;
            this.btnExam.Text = "EXAM SUBJECT";
            this.btnExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // panelStudentSubMenu
            // 
            this.panelStudentSubMenu.Controls.Add(this.btnStudentResult);
            this.panelStudentSubMenu.Controls.Add(this.btnStudentInfo);
            this.panelStudentSubMenu.Controls.Add(this.btnFindStudent);
            this.panelStudentSubMenu.Controls.Add(this.btnAddUpdateQuestion);
            this.panelStudentSubMenu.Controls.Add(this.btnListStudent);
            this.panelStudentSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudentSubMenu.Location = new System.Drawing.Point(0, 450);
            this.panelStudentSubMenu.Name = "panelStudentSubMenu";
            this.panelStudentSubMenu.Size = new System.Drawing.Size(156, 262);
            this.panelStudentSubMenu.TabIndex = 4;
            // 
            // btnStudentResult
            // 
            this.btnStudentResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudentResult.FlatAppearance.BorderSize = 0;
            this.btnStudentResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentResult.Location = new System.Drawing.Point(0, 188);
            this.btnStudentResult.Name = "btnStudentResult";
            this.btnStudentResult.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStudentResult.Size = new System.Drawing.Size(156, 47);
            this.btnStudentResult.TabIndex = 4;
            this.btnStudentResult.Text = "Student Result";
            this.btnStudentResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentResult.UseVisualStyleBackColor = true;
            this.btnStudentResult.Click += new System.EventHandler(this.btnStudentResult_Click);
            // 
            // btnStudentInfo
            // 
            this.btnStudentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudentInfo.Enabled = false;
            this.btnStudentInfo.FlatAppearance.BorderSize = 0;
            this.btnStudentInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentInfo.Location = new System.Drawing.Point(0, 141);
            this.btnStudentInfo.Name = "btnStudentInfo";
            this.btnStudentInfo.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnStudentInfo.Size = new System.Drawing.Size(156, 47);
            this.btnStudentInfo.TabIndex = 3;
            this.btnStudentInfo.Text = "Student Info";
            this.btnStudentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudentInfo.UseVisualStyleBackColor = true;
            this.btnStudentInfo.Click += new System.EventHandler(this.btnStudentInfo_Click);
            // 
            // btnFindStudent
            // 
            this.btnFindStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFindStudent.Enabled = false;
            this.btnFindStudent.FlatAppearance.BorderSize = 0;
            this.btnFindStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindStudent.Location = new System.Drawing.Point(0, 94);
            this.btnFindStudent.Name = "btnFindStudent";
            this.btnFindStudent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnFindStudent.Size = new System.Drawing.Size(156, 47);
            this.btnFindStudent.TabIndex = 2;
            this.btnFindStudent.Text = "Find Student";
            this.btnFindStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindStudent.UseVisualStyleBackColor = true;
            this.btnFindStudent.Click += new System.EventHandler(this.btnFindStudent_Click);
            // 
            // btnAddUpdateQuestion
            // 
            this.btnAddUpdateQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddUpdateQuestion.Enabled = false;
            this.btnAddUpdateQuestion.FlatAppearance.BorderSize = 0;
            this.btnAddUpdateQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdateQuestion.Location = new System.Drawing.Point(0, 47);
            this.btnAddUpdateQuestion.Name = "btnAddUpdateQuestion";
            this.btnAddUpdateQuestion.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAddUpdateQuestion.Size = new System.Drawing.Size(156, 47);
            this.btnAddUpdateQuestion.TabIndex = 1;
            this.btnAddUpdateQuestion.Text = "Create / Edit Student";
            this.btnAddUpdateQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUpdateQuestion.UseVisualStyleBackColor = true;
            this.btnAddUpdateQuestion.Click += new System.EventHandler(this.btnAddUpdateStudent_Click);
            // 
            // btnListStudent
            // 
            this.btnListStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListStudent.Enabled = false;
            this.btnListStudent.FlatAppearance.BorderSize = 0;
            this.btnListStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListStudent.Location = new System.Drawing.Point(0, 0);
            this.btnListStudent.Name = "btnListStudent";
            this.btnListStudent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListStudent.Size = new System.Drawing.Size(156, 47);
            this.btnListStudent.TabIndex = 0;
            this.btnListStudent.Text = "List Students";
            this.btnListStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListStudent.UseVisualStyleBackColor = true;
            this.btnListStudent.Click += new System.EventHandler(this.btnListStudent_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudent.Location = new System.Drawing.Point(0, 403);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStudent.Size = new System.Drawing.Size(156, 47);
            this.btnStudent.TabIndex = 3;
            this.btnStudent.Text = "STUDENT";
            this.btnStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // panelUserSubMenu
            // 
            this.panelUserSubMenu.Controls.Add(this.btnChangeUserPassword);
            this.panelUserSubMenu.Controls.Add(this.btnFindUser);
            this.panelUserSubMenu.Controls.Add(this.btnAddUpdateUser);
            this.panelUserSubMenu.Controls.Add(this.btnListUser);
            this.panelUserSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserSubMenu.Location = new System.Drawing.Point(0, 194);
            this.panelUserSubMenu.Name = "panelUserSubMenu";
            this.panelUserSubMenu.Size = new System.Drawing.Size(156, 209);
            this.panelUserSubMenu.TabIndex = 1;
            // 
            // btnChangeUserPassword
            // 
            this.btnChangeUserPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeUserPassword.FlatAppearance.BorderSize = 0;
            this.btnChangeUserPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUserPassword.Location = new System.Drawing.Point(0, 141);
            this.btnChangeUserPassword.Name = "btnChangeUserPassword";
            this.btnChangeUserPassword.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnChangeUserPassword.Size = new System.Drawing.Size(156, 47);
            this.btnChangeUserPassword.TabIndex = 3;
            this.btnChangeUserPassword.Text = "Change Current User Password";
            this.btnChangeUserPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeUserPassword.UseVisualStyleBackColor = true;
            this.btnChangeUserPassword.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFindUser.FlatAppearance.BorderSize = 0;
            this.btnFindUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindUser.Location = new System.Drawing.Point(0, 94);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnFindUser.Size = new System.Drawing.Size(156, 47);
            this.btnFindUser.TabIndex = 2;
            this.btnFindUser.Text = "Find User";
            this.btnFindUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // btnAddUpdateUser
            // 
            this.btnAddUpdateUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnAddUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdateUser.Location = new System.Drawing.Point(0, 47);
            this.btnAddUpdateUser.Name = "btnAddUpdateUser";
            this.btnAddUpdateUser.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAddUpdateUser.Size = new System.Drawing.Size(156, 47);
            this.btnAddUpdateUser.TabIndex = 1;
            this.btnAddUpdateUser.Text = "Create / Edit User";
            this.btnAddUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUpdateUser.UseVisualStyleBackColor = true;
            this.btnAddUpdateUser.Click += new System.EventHandler(this.btnAddUpdateUser_Click);
            // 
            // btnListUser
            // 
            this.btnListUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListUser.FlatAppearance.BorderSize = 0;
            this.btnListUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListUser.Location = new System.Drawing.Point(0, 0);
            this.btnListUser.Name = "btnListUser";
            this.btnListUser.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListUser.Size = new System.Drawing.Size(156, 47);
            this.btnListUser.TabIndex = 0;
            this.btnListUser.Text = "List Users";
            this.btnListUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListUser.UseVisualStyleBackColor = true;
            this.btnListUser.Click += new System.EventHandler(this.btnListUser_Click);
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUser.Location = new System.Drawing.Point(0, 147);
            this.btnUser.Name = "btnUser";
            this.btnUser.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUser.Size = new System.Drawing.Size(156, 47);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "USER";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Location = new System.Drawing.Point(0, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(156, 47);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "HOME";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 100);
            this.panel2.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelCover);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(181, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(953, 613);
            this.panelMain.TabIndex = 1;
            // 
            // panelCover
            // 
            this.panelCover.Controls.Add(this.groupBox3);
            this.panelCover.Controls.Add(this.lblUserNameWelcom);
            this.panelCover.Controls.Add(this.label1);
            this.panelCover.Controls.Add(this.panel1);
            this.panelCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCover.Location = new System.Drawing.Point(0, 0);
            this.panelCover.Name = "panelCover";
            this.panelCover.Size = new System.Drawing.Size(953, 613);
            this.panelCover.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Location = new System.Drawing.Point(69, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(763, 424);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(296, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Manage Students";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Exam_System_App.Properties.Resources.group_students_posing_table;
            this.pictureBox3.Location = new System.Drawing.Point(36, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(695, 338);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // lblUserNameWelcom
            // 
            this.lblUserNameWelcom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameWelcom.AutoSize = true;
            this.lblUserNameWelcom.Font = new System.Drawing.Font("MV Boli", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameWelcom.ForeColor = System.Drawing.Color.Honeydew;
            this.lblUserNameWelcom.Location = new System.Drawing.Point(440, 107);
            this.lblUserNameWelcom.Name = "lblUserNameWelcom";
            this.lblUserNameWelcom.Size = new System.Drawing.Size(263, 44);
            this.lblUserNameWelcom.TabIndex = 21;
            this.lblUserNameWelcom.Text = "\" User Name \"";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(271, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 38);
            this.label1.TabIndex = 20;
            this.label1.Text = "Welcom ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.pbUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 87);
            this.panel1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(840, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(44, 16);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Name";
            // 
            // pbUser
            // 
            this.pbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbUser.Location = new System.Drawing.Point(760, 15);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(62, 53);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.TabIndex = 0;
            this.pbUser.TabStop = false;
            // 
            // FrmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1134, 613);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSide);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1152, 660);
            this.Name = "FrmAdminMain";
            this.Text = "Main Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAdminMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmAdminMain_Load);
            this.panelSide.ResumeLayout(false);
            this.panelExamSubMenu.ResumeLayout(false);
            this.panelStudentSubMenu.ResumeLayout(false);
            this.panelUserSubMenu.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCover.ResumeLayout(false);
            this.panelCover.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelUserSubMenu;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnAddUpdateUser;
        private System.Windows.Forms.Button btnListUser;
        private System.Windows.Forms.Button btnChangeUserPassword;
        private System.Windows.Forms.Panel panelStudentSubMenu;
        private System.Windows.Forms.Button btnStudentInfo;
        private System.Windows.Forms.Button btnFindStudent;
        private System.Windows.Forms.Button btnAddUpdateQuestion;
        private System.Windows.Forms.Button btnListStudent;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Panel panelExamSubMenu;
        private System.Windows.Forms.Button btnExamInfo;
        private System.Windows.Forms.Button btnFindExam;
        private System.Windows.Forms.Button btnAddUpdateExam;
        private System.Windows.Forms.Button btnListExam;
        private System.Windows.Forms.Button btnStudentResult;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelCover;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblUserNameWelcom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Button btnExit;
    }
}

