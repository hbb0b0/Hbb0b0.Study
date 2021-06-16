
namespace WinFormsTaskCancelSample
{
    partial class CalcWinform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.rbContent = new System.Windows.Forms.RichTextBox();
            this.btnGetUrlString = new System.Windows.Forms.Button();
            this.btnGetUrlStringCancel = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(68, 169);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "开始";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(68, 130);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(100, 23);
            this.tbNumber.TabIndex = 2;
            // 
            // rbContent
            // 
            this.rbContent.Location = new System.Drawing.Point(375, 29);
            this.rbContent.Name = "rbContent";
            this.rbContent.Size = new System.Drawing.Size(413, 326);
            this.rbContent.TabIndex = 3;
            this.rbContent.Text = "";
            // 
            // btnGetUrlString
            // 
            this.btnGetUrlString.Location = new System.Drawing.Point(372, 402);
            this.btnGetUrlString.Name = "btnGetUrlString";
            this.btnGetUrlString.Size = new System.Drawing.Size(75, 23);
            this.btnGetUrlString.TabIndex = 4;
            this.btnGetUrlString.Text = "开始";
            this.btnGetUrlString.UseVisualStyleBackColor = true;
            this.btnGetUrlString.Click += new System.EventHandler(this.btnGetUrlString_Click);
            // 
            // btnGetUrlStringCancel
            // 
            this.btnGetUrlStringCancel.Location = new System.Drawing.Point(453, 402);
            this.btnGetUrlStringCancel.Name = "btnGetUrlStringCancel";
            this.btnGetUrlStringCancel.Size = new System.Drawing.Size(75, 23);
            this.btnGetUrlStringCancel.TabIndex = 5;
            this.btnGetUrlStringCancel.Text = "取消";
            this.btnGetUrlStringCancel.UseVisualStyleBackColor = true;
            this.btnGetUrlStringCancel.Click += new System.EventHandler(this.btnGetUrlStringCancel_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(375, 373);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(413, 23);
            this.tbUrl.TabIndex = 6;
            this.tbUrl.Text = "https://www.oschina.net/";
            // 
            // CalcWinform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.btnGetUrlStringCancel);
            this.Controls.Add(this.btnGetUrlString);
            this.Controls.Add(this.rbContent);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRun);
            this.Name = "CalcWinform";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.RichTextBox rbContent;
        private System.Windows.Forms.Button btnGetUrlString;
        private System.Windows.Forms.Button btnGetUrlStringCancel;
        private System.Windows.Forms.TextBox tbUrl;
    }
}

