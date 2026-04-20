namespace Exam_System_App
{
    partial class ctrlTakeExam
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
            this.gbTitleExam = new System.Windows.Forms.GroupBox();
            this.lblQuestionCounter = new System.Windows.Forms.Label();
            this.rbOptionD = new System.Windows.Forms.RadioButton();
            this.rbOptionC = new System.Windows.Forms.RadioButton();
            this.rbOptionB = new System.Windows.Forms.RadioButton();
            this.rbOptionA = new System.Windows.Forms.RadioButton();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.gbTitleExam.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTitleExam
            // 
            this.gbTitleExam.Controls.Add(this.lblQuestionCounter);
            this.gbTitleExam.Controls.Add(this.rbOptionD);
            this.gbTitleExam.Controls.Add(this.rbOptionC);
            this.gbTitleExam.Controls.Add(this.rbOptionB);
            this.gbTitleExam.Controls.Add(this.rbOptionA);
            this.gbTitleExam.Controls.Add(this.lblQuestionText);
            this.gbTitleExam.ForeColor = System.Drawing.Color.White;
            this.gbTitleExam.Location = new System.Drawing.Point(12, 11);
            this.gbTitleExam.Name = "gbTitleExam";
            this.gbTitleExam.Size = new System.Drawing.Size(665, 258);
            this.gbTitleExam.TabIndex = 0;
            this.gbTitleExam.TabStop = false;
            this.gbTitleExam.Text = "Title";
            // 
            // lblQuestionCounter
            // 
            this.lblQuestionCounter.AutoSize = true;
            this.lblQuestionCounter.Location = new System.Drawing.Point(589, 22);
            this.lblQuestionCounter.Name = "lblQuestionCounter";
            this.lblQuestionCounter.Size = new System.Drawing.Size(31, 16);
            this.lblQuestionCounter.TabIndex = 5;
            this.lblQuestionCounter.Text = "0 / 0";
            // 
            // rbOptionD
            // 
            this.rbOptionD.AutoSize = true;
            this.rbOptionD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOptionD.Location = new System.Drawing.Point(68, 209);
            this.rbOptionD.Name = "rbOptionD";
            this.rbOptionD.Size = new System.Drawing.Size(88, 22);
            this.rbOptionD.TabIndex = 4;
            this.rbOptionD.TabStop = true;
            this.rbOptionD.Text = "Option D";
            this.rbOptionD.UseVisualStyleBackColor = true;
            this.rbOptionD.CheckedChanged += new System.EventHandler(this.rbOptionD_CheckedChanged);
            // 
            // rbOptionC
            // 
            this.rbOptionC.AutoSize = true;
            this.rbOptionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOptionC.Location = new System.Drawing.Point(68, 172);
            this.rbOptionC.Name = "rbOptionC";
            this.rbOptionC.Size = new System.Drawing.Size(88, 22);
            this.rbOptionC.TabIndex = 3;
            this.rbOptionC.TabStop = true;
            this.rbOptionC.Text = "Option C";
            this.rbOptionC.UseVisualStyleBackColor = true;
            this.rbOptionC.CheckedChanged += new System.EventHandler(this.rbOptionC_CheckedChanged);
            // 
            // rbOptionB
            // 
            this.rbOptionB.AutoSize = true;
            this.rbOptionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOptionB.Location = new System.Drawing.Point(68, 135);
            this.rbOptionB.Name = "rbOptionB";
            this.rbOptionB.Size = new System.Drawing.Size(87, 22);
            this.rbOptionB.TabIndex = 2;
            this.rbOptionB.TabStop = true;
            this.rbOptionB.Text = "Option B";
            this.rbOptionB.UseVisualStyleBackColor = true;
            this.rbOptionB.CheckedChanged += new System.EventHandler(this.rbOptionB_CheckedChanged);
            // 
            // rbOptionA
            // 
            this.rbOptionA.AutoSize = true;
            this.rbOptionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOptionA.Location = new System.Drawing.Point(68, 98);
            this.rbOptionA.Name = "rbOptionA";
            this.rbOptionA.Size = new System.Drawing.Size(86, 22);
            this.rbOptionA.TabIndex = 1;
            this.rbOptionA.TabStop = true;
            this.rbOptionA.Text = "Option A";
            this.rbOptionA.UseVisualStyleBackColor = true;
            this.rbOptionA.CheckedChanged += new System.EventHandler(this.rbOptionA_CheckedChanged);
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionText.Location = new System.Drawing.Point(38, 51);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(100, 18);
            this.lblQuestionText.TabIndex = 0;
            this.lblQuestionText.Text = "Question Text";
            // 
            // ctrlTakeExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.gbTitleExam);
            this.Name = "ctrlTakeExam";
            this.Size = new System.Drawing.Size(701, 295);
            this.gbTitleExam.ResumeLayout(false);
            this.gbTitleExam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitleExam;
        private System.Windows.Forms.RadioButton rbOptionD;
        private System.Windows.Forms.RadioButton rbOptionC;
        private System.Windows.Forms.RadioButton rbOptionB;
        private System.Windows.Forms.RadioButton rbOptionA;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.Label lblQuestionCounter;
    }
}
