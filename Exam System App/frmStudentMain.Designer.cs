namespace Exam_System_App
{
    partial class frmStudentMain
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
            this.btnResult = new System.Windows.Forms.Button();
            this.btnTakeExam = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCover = new System.Windows.Forms.Panel();
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ctrlExamInfoWithTakeButton1 = new Exam_System_App.ctrlExamInfoWithTakeButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.panelSide.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCover.SuspendLayout();
            this.flPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.Black;
            this.panelSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSide.Controls.Add(this.btnExit);
            this.panelSide.Controls.Add(this.btnResult);
            this.panelSide.Controls.Add(this.btnTakeExam);
            this.panelSide.Controls.Add(this.btnHome);
            this.panelSide.Controls.Add(this.panel2);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSide.ForeColor = System.Drawing.Color.White;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(181, 613);
            this.panelSide.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(0, 562);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(177, 47);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResult
            // 
            this.btnResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResult.Location = new System.Drawing.Point(0, 194);
            this.btnResult.Name = "btnResult";
            this.btnResult.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnResult.Size = new System.Drawing.Size(177, 47);
            this.btnResult.TabIndex = 5;
            this.btnResult.Text = "RESULT";
            this.btnResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnTakeExam
            // 
            this.btnTakeExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTakeExam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTakeExam.Location = new System.Drawing.Point(0, 147);
            this.btnTakeExam.Name = "btnTakeExam";
            this.btnTakeExam.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTakeExam.Size = new System.Drawing.Size(177, 47);
            this.btnTakeExam.TabIndex = 2;
            this.btnTakeExam.Text = "TAKE EXAM";
            this.btnTakeExam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTakeExam.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHome.Location = new System.Drawing.Point(0, 100);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(177, 47);
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
            this.panel2.Size = new System.Drawing.Size(177, 100);
            this.panel2.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelCover);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(181, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(953, 613);
            this.panelMain.TabIndex = 2;
            // 
            // panelCover
            // 
            this.panelCover.Controls.Add(this.flPanel);
            this.panelCover.Controls.Add(this.panel1);
            this.panelCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCover.Location = new System.Drawing.Point(0, 0);
            this.panelCover.Name = "panelCover";
            this.panelCover.Size = new System.Drawing.Size(953, 613);
            this.panelCover.TabIndex = 0;
            // 
            // flPanel
            // 
            this.flPanel.AutoScroll = true;
            this.flPanel.Controls.Add(this.ctrlExamInfoWithTakeButton1);
            this.flPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanel.Location = new System.Drawing.Point(0, 87);
            this.flPanel.Margin = new System.Windows.Forms.Padding(5);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(953, 526);
            this.flPanel.TabIndex = 4;
            // 
            // ctrlExamInfoWithTakeButton1
            // 
            this.ctrlExamInfoWithTakeButton1.BackColor = System.Drawing.Color.Gray;
            this.ctrlExamInfoWithTakeButton1.ExamId = 0;
            this.ctrlExamInfoWithTakeButton1.Location = new System.Drawing.Point(3, 3);
            this.ctrlExamInfoWithTakeButton1.Name = "ctrlExamInfoWithTakeButton1";
            this.ctrlExamInfoWithTakeButton1.Size = new System.Drawing.Size(467, 328);
            this.ctrlExamInfoWithTakeButton1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.pbUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 87);
            this.panel1.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.White;
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
            this.pbUser.TabIndex = 0;
            this.pbUser.TabStop = false;
            // 
            // frmStudentMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1134, 613);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSide);
            this.Name = "frmStudentMain";
            this.Text = "frmStudentMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStudentMain_FormClosed);
            this.Load += new System.EventHandler(this.frmStudentMain_Load);
            this.panelSide.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCover.ResumeLayout(false);
            this.flPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnTakeExam;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelCover;
        private System.Windows.Forms.FlowLayoutPanel flPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pbUser;
        private ctrlExamInfoWithTakeButton ctrlExamInfoWithTakeButton1;
        private System.Windows.Forms.Button btnExit;
    }
}