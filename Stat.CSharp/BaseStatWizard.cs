using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart;

namespace StatsMasterDemo
{
    public class BaseStatWizard : Form
    {
        public BaseStatWizard()
        {
            InitializeComponent();
            double defalpha = 0.05;
            textBoxAlpha.Text = defalpha.ToString("0.00");
            textBoxFmt.Text = "0.0000";
        }

        protected internal Dew.Math.Controls.Wizard wizard;
        protected internal Dew.Math.Controls.WizardPage wizardPageReport;
        protected RichTextBox richTextBox;
        protected ProgressBar progressBar;
		private System.Windows.Forms.ContextMenu contextMenuRTB;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemSelectAll;
		private System.Windows.Forms.MenuItem menuItemCopyClpBrd;
		private System.Windows.Forms.MenuItem menuItemSaveRTF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        protected internal CheckBox checkBoxCharts;
        private TChart aChart = null;

        public TChart Chart
        {
            get
            {
                if (aChart == null)
                {
                    aChart = new TChart();
                    aChart.Width = 450;
                    aChart.Height = 250;
                    aChart.BackColor = Color.White;
                    aChart.AutoRepaint = false;
                    aChart.Panel.Transparent = true;
                }
                return aChart;
            }
            set
            {
                aChart = value;
            }
        }

        public void CopyToRichBox(RichTextBox rtb)
        {
            rtb.ReadOnly = false;
            Chart.Export.Image.Bitmap.CopyToClipboard();
            rtb.Paste();
            rtb.ReadOnly = true;
        }

		public string HypResult(Dew.Stats.THypothesisResult value)
		{
			switch(value)
			{
				case Dew.Stats.THypothesisResult.hrReject : return "Reject";
				case Dew.Stats.THypothesisResult.hrNotReject : return "Accept";
				default : return "NAN";
			}
		}

        public string OptimStopReason(Dew.Math.TOptStopReason value)
        {
            switch (value)
            {
                case Dew.Math.TOptStopReason.OptResBigLambda: return "Big lambda";
                case Dew.Math.TOptStopReason.OptResMaxIter: return "Maximum number of iterations reached.";
                case Dew.Math.TOptStopReason.OptResNotFound: return "Minimum not found.";
                case Dew.Math.TOptStopReason.OptResSingular: return "Hessian matrix singular.";
                case Dew.Math.TOptStopReason.OptResSmallGrad: return "Too small gradient.";
                case Dew.Math.TOptStopReason.optResSmallJacobian: return "Too small Jacobian.";
                case Dew.Math.TOptStopReason.OptResSmallStep: return "Small function increment step.";
                case Dew.Math.TOptStopReason.OptResZeroStep: return "Zero step.";
                default: return "Converged within given tolerance.";
            }
        }

        public string HTextBar(double val, double max, int len)
        {
            double pct = val / max;
            int barcount = (int)Math.Ceiling(pct * len);
            string result = "";
            for (int i = 1; i <= barcount; i++)
                result += "|";
            for (int i = barcount + 1; i <= len; i++)
                result += ".";
            return result;
        }


        public string FmtString
        {
            get { return textBoxFmt.Text; }
            set { textBoxFmt.Text = value; }
        }

        public double Alpha
        {
            get { return Convert.ToDouble(textBoxAlpha.Text); }
            set { textBoxAlpha.Text = value.ToString("0.00"); }
        }

        public void SetupTabs(RichTextBox rb, int numtabs)
        {
            numtabs = System.Math.Min(numtabs, 24);

            int[] tabs = new int[numtabs];
            int tabw = DefTabWidth;
            for (int i = 0; i < numtabs; i++)
            {
                tabs[i] = (i + 1) * tabw;
            }
            rb.SelectionTabs = tabs;
        }

        private int DefTabWidth
        {
            get
            {
                return 90;
            }
        }
           

        private Label label1;
        protected internal Dew.Math.Controls.WizardPage wizardPageFormat;
        protected internal Dew.Math.Controls.WizardPage wizardPageWelcome;
        private GroupBox groupBox1;
        protected internal TextBox textBoxAlpha;
        private TextBox textBoxFmt;
        private Label label3;
        private Label label2;
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
            this.wizard = new Dew.Math.Controls.Wizard();
            this.wizardPageReport = new Dew.Math.Controls.WizardPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuRTB = new System.Windows.Forms.ContextMenu();
            this.menuItemCopyClpBrd = new System.Windows.Forms.MenuItem();
            this.menuItemSaveRTF = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.MenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPageFormat = new Dew.Math.Controls.WizardPage();
            this.checkBoxCharts = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.textBoxFmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPageWelcome = new Dew.Math.Controls.WizardPage();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.wizard.SuspendLayout();
            this.wizardPageReport.SuspendLayout();
            this.wizardPageFormat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Controls.Add(this.wizardPageReport);
            this.wizard.Controls.Add(this.wizardPageFormat);
            this.wizard.Controls.Add(this.wizardPageWelcome);
            this.wizard.Location = new System.Drawing.Point(0, 0);
            this.wizard.Name = "wizard";
            this.wizard.Pages.AddRange(new Dew.Math.Controls.WizardPage[] {
            this.wizardPageWelcome,
            this.wizardPageFormat,
            this.wizardPageReport});
            this.wizard.Size = new System.Drawing.Size(468, 297);
            this.wizard.TabIndex = 0;
            // 
            // wizardPageReport
            // 
            this.wizardPageReport.Controls.Add(this.richTextBox);
            this.wizardPageReport.Controls.Add(this.progressBar);
            this.wizardPageReport.Controls.Add(this.label1);
            this.wizardPageReport.Location = new System.Drawing.Point(0, 0);
            this.wizardPageReport.Name = "wizardPageReport";
            this.wizardPageReport.Size = new System.Drawing.Size(468, 249);
            this.wizardPageReport.TabIndex = 12;
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox.CausesValidation = false;
            this.richTextBox.ContextMenu = this.contextMenuRTB;
            this.richTextBox.DetectUrls = false;
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox.HideSelection = false;
            this.richTextBox.Location = new System.Drawing.Point(15, 117);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.ShortcutsEnabled = false;
            this.richTextBox.Size = new System.Drawing.Size(441, 99);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            // 
            // contextMenuRTB
            // 
            this.contextMenuRTB.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCopyClpBrd,
            this.menuItemSaveRTF,
            this.menuItem1,
            this.menuItemSelectAll});
            // 
            // menuItemCopyClpBrd
            // 
            this.menuItemCopyClpBrd.Enabled = false;
            this.menuItemCopyClpBrd.Index = 0;
            this.menuItemCopyClpBrd.Text = "Copy to clipboard";
            this.menuItemCopyClpBrd.Click += new System.EventHandler(this.menuItemCopyClpBrd_Click);
            // 
            // menuItemSaveRTF
            // 
            this.menuItemSaveRTF.Index = 1;
            this.menuItemSaveRTF.Text = "Save to RTF file";
            this.menuItemSaveRTF.Click += new System.EventHandler(this.menuItemSaveRTF_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Index = 3;
            this.menuItemSelectAll.Text = "Select All";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(69, 77);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 13);
            this.progressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Progress:";
            // 
            // wizardPageFormat
            // 
            this.wizardPageFormat.Controls.Add(this.checkBoxCharts);
            this.wizardPageFormat.Controls.Add(this.groupBox1);
            this.wizardPageFormat.Location = new System.Drawing.Point(0, 0);
            this.wizardPageFormat.Name = "wizardPageFormat";
            this.wizardPageFormat.Size = new System.Drawing.Size(468, 249);
            this.wizardPageFormat.TabIndex = 11;
            // 
            // checkBoxCharts
            // 
            this.checkBoxCharts.AutoSize = true;
            this.checkBoxCharts.Checked = true;
            this.checkBoxCharts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCharts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCharts.Location = new System.Drawing.Point(53, 199);
            this.checkBoxCharts.Name = "checkBoxCharts";
            this.checkBoxCharts.Size = new System.Drawing.Size(140, 18);
            this.checkBoxCharts.TabIndex = 1;
            this.checkBoxCharts.Text = "Include charts in report";
            this.checkBoxCharts.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAlpha);
            this.groupBox1.Controls.Add(this.textBoxFmt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report format";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(82, 60);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(85, 20);
            this.textBoxAlpha.TabIndex = 3;
            // 
            // textBoxFmt
            // 
            this.textBoxFmt.Location = new System.Drawing.Point(82, 31);
            this.textBoxFmt.Name = "textBoxFmt";
            this.textBoxFmt.Size = new System.Drawing.Size(85, 20);
            this.textBoxFmt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Alpha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Format string:";
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Location = new System.Drawing.Point(0, 0);
            this.wizardPageWelcome.Name = "wizardPageWelcome";
            this.wizardPageWelcome.Size = new System.Drawing.Size(468, 249);
            this.wizardPageWelcome.Style = Dew.Math.Controls.WizardPageStyle.Welcome;
            this.wizardPageWelcome.TabIndex = 10;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "RTF";
            this.saveFileDialog1.Filter = "Rich Text Format|*.rtf";
            // 
            // BaseStatWizard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(468, 297);
            this.Controls.Add(this.wizard);
            this.Name = "BaseStatWizard";
            this.Text = "BaseStatWizard";
            this.wizard.ResumeLayout(false);
            this.wizardPageReport.ResumeLayout(false);
            this.wizardPageReport.PerformLayout();
            this.wizardPageFormat.ResumeLayout(false);
            this.wizardPageFormat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

		private void menuItemSaveRTF_Click(object sender, System.EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				richTextBox.SaveFile(saveFileDialog1.FileName);
			}
		}

		private void menuItemCopyClpBrd_Click(object sender, System.EventArgs e)
		{
			richTextBox.Copy();
		}

		private void richTextBox_SelectionChanged(object sender, System.EventArgs e)
		{
			menuItemSelectAll.Enabled = richTextBox.SelectionLength != richTextBox.Text.Length;
			menuItemCopyClpBrd.Enabled = richTextBox.SelectionLength > 0;
		}

		private void menuItemSelectAll_Click(object sender, System.EventArgs e)
		{
				richTextBox.SelectAll();
		}
    }
}