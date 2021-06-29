namespace MtxVecDemo
{
    partial class clBenchmarkForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.platformListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TimingsLabel = new System.Windows.Forms.Label();
            this.deviceListLabel = new System.Windows.Forms.Label();
            this.deviceListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.functionBox = new System.Windows.Forms.ListBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(626, 104);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // platformListBox
            // 
            this.platformListBox.FormattingEnabled = true;
            this.platformListBox.Location = new System.Drawing.Point(12, 126);
            this.platformListBox.Name = "platformListBox";
            this.platformListBox.Size = new System.Drawing.Size(255, 69);
            this.platformListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Platform list:";
            // 
            // TimingsLabel
            // 
            this.TimingsLabel.AutoSize = true;
            this.TimingsLabel.Location = new System.Drawing.Point(285, 109);
            this.TimingsLabel.Name = "TimingsLabel";
            this.TimingsLabel.Size = new System.Drawing.Size(46, 13);
            this.TimingsLabel.TabIndex = 3;
            this.TimingsLabel.Text = "Timings:";
            // 
            // deviceListLabel
            // 
            this.deviceListLabel.AutoSize = true;
            this.deviceListLabel.Location = new System.Drawing.Point(12, 204);
            this.deviceListLabel.Name = "deviceListLabel";
            this.deviceListLabel.Size = new System.Drawing.Size(59, 13);
            this.deviceListLabel.TabIndex = 6;
            this.deviceListLabel.Text = "Device list:";
            // 
            // deviceListBox
            // 
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.Location = new System.Drawing.Point(12, 221);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(255, 69);
            this.deviceListBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Test function list:";
            // 
            // functionBox
            // 
            this.functionBox.FormattingEnabled = true;
            this.functionBox.Location = new System.Drawing.Point(12, 322);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(255, 134);
            this.functionBox.TabIndex = 7;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(288, 126);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(330, 330);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "";
            // 
            // clBenchmarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 473);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.functionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deviceListLabel);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.TimingsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.platformListBox);
            this.Controls.Add(this.richTextBox1);
            this.Name = "clBenchmarkForm";
            this.Text = "Benchmarks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox platformListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TimingsLabel;
        private System.Windows.Forms.Label deviceListLabel;
        private System.Windows.Forms.ListBox deviceListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox functionBox;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}