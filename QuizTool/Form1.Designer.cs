namespace QuizTool
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.questionbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optionsbox = new System.Windows.Forms.CheckedListBox();
            this.submitanswer = new System.Windows.Forms.Button();
            this.nameinput = new System.Windows.Forms.TextBox();
            this.namesubmit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.questionbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question:";
            // 
            // questionbox
            // 
            this.questionbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionbox.Location = new System.Drawing.Point(6, 19);
            this.questionbox.Multiline = true;
            this.questionbox.Name = "questionbox";
            this.questionbox.ReadOnly = true;
            this.questionbox.Size = new System.Drawing.Size(334, 107);
            this.questionbox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.optionsbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Answer";
            // 
            // optionsbox
            // 
            this.optionsbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsbox.CheckOnClick = true;
            this.optionsbox.FormattingEnabled = true;
            this.optionsbox.Location = new System.Drawing.Point(6, 19);
            this.optionsbox.Name = "optionsbox";
            this.optionsbox.Size = new System.Drawing.Size(334, 94);
            this.optionsbox.TabIndex = 0;
            this.optionsbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.optionsbox_ItemCheck);
            this.optionsbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.optionsbox_KeyDown);
            // 
            // submitanswer
            // 
            this.submitanswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitanswer.Location = new System.Drawing.Point(12, 271);
            this.submitanswer.Name = "submitanswer";
            this.submitanswer.Size = new System.Drawing.Size(340, 23);
            this.submitanswer.TabIndex = 2;
            this.submitanswer.Text = "Start Quiz";
            this.submitanswer.UseVisualStyleBackColor = true;
            this.submitanswer.Click += new System.EventHandler(this.submitanswer_Click);
            // 
            // nameinput
            // 
            this.nameinput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameinput.Location = new System.Drawing.Point(6, 19);
            this.nameinput.Name = "nameinput";
            this.nameinput.Size = new System.Drawing.Size(334, 20);
            this.nameinput.TabIndex = 0;
            // 
            // namesubmit
            // 
            this.namesubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namesubmit.Location = new System.Drawing.Point(6, 45);
            this.namesubmit.Name = "namesubmit";
            this.namesubmit.Size = new System.Drawing.Size(334, 27);
            this.namesubmit.TabIndex = 1;
            this.namesubmit.Text = "Submit Name";
            this.namesubmit.UseVisualStyleBackColor = true;
            this.namesubmit.Click += new System.EventHandler(this.namesubmit_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.nameinput);
            this.groupBox3.Controls.Add(this.namesubmit);
            this.groupBox3.Location = new System.Drawing.Point(12, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 79);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Enter your Name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 299);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.submitanswer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LarsQuiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox questionbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox optionsbox;
        private System.Windows.Forms.Button submitanswer;
        private System.Windows.Forms.TextBox nameinput;
        private System.Windows.Forms.Button namesubmit;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

