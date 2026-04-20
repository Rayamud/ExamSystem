namespace Exam_System_App
{
    partial class ctrlExamInfoWithTakeButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTakeExam = new System.Windows.Forms.Button();
            this.ctrlExamInfo1 = new Exam_System_App.ctrlExamInfo();
            this.SuspendLayout();
            // 
            // btnTakeExam
            // 
            this.btnTakeExam.BackColor = System.Drawing.Color.White;
            this.btnTakeExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeExam.Location = new System.Drawing.Point(146, 294);
            this.btnTakeExam.Name = "btnTakeExam";
            this.btnTakeExam.Size = new System.Drawing.Size(163, 32);
            this.btnTakeExam.TabIndex = 1;
            this.btnTakeExam.Text = "Take Exam";
            this.btnTakeExam.UseVisualStyleBackColor = false;
            this.btnTakeExam.Click += new System.EventHandler(this.btnTakeExam_Click);
            // 
            // ctrlExamInfo1
            // 
            this.ctrlExamInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ctrlExamInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlExamInfo1.Name = "ctrlExamInfo1";
            this.ctrlExamInfo1.Size = new System.Drawing.Size(459, 323);
            this.ctrlExamInfo1.TabIndex = 0;
            // 
            // ctrlExamInfoWithTakeButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.btnTakeExam);
            this.Controls.Add(this.ctrlExamInfo1);
            this.Name = "ctrlExamInfoWithTakeButton";
            this.Size = new System.Drawing.Size(467, 328);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlExamInfo ctrlExamInfo1;
        private System.Windows.Forms.Button btnTakeExam;
    }
}
