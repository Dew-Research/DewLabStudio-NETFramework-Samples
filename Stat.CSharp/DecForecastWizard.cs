using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math.Units;
using Dew.Math;
using Dew.Stats.Units;
using static Dew.Math.Tee.TeeChart;

namespace StatsMasterDemo
{
    public class DecForecastWizard : StatsMasterDemo.BaseStatWizard
    {
        public DecForecastWizard()
        {
            InitializeComponent();
            // Initialize all necessary vectors
            timeseries = new Vector(0);
            data = new Vector(0);
            yv = new Vector(0);
            mv = new Vector(0);
            tv = new Vector(0);
            cv = new Vector(0);
            kv = new Vector(0);
            sv = new Vector(0);
            rv = new Vector(0);
            forecasts = new Vector(0);
            residuals = new Vector(0);

            openFileDialog1.Filter = "Vector files (*.vec)|*.vec";
            openFileDialog1.FilterIndex = 1;

            // Manually reposition Data wizard page after the Welcome page
            wizard.Pages.Remove(wizardPageData);
            wizard.Pages.Insert(1, wizardPageData);

        }

        private Steema.TeeChart.TChart tChartData;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.Line line2;
        private Steema.TeeChart.Styles.Line line3;
        private NumericUpDown numericUpDownForNum;
        private Label label5;
        private GroupBox groupBox3;
        private NumericUpDown numericUpDownSeasons;
        private Label label6;
        private TextBox textBoxForCycle;
        private Label labelForecastCycle;
        private CheckBox checkBoxCycle;
        private Button button1;
        private OpenFileDialog openFileDialog1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecForecastWizard));
            this.wizardPageData = new Dew.Math.Controls.WizardPage();
            this.tChartData = new Steema.TeeChart.TChart();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.line2 = new Steema.TeeChart.Styles.Line();
            this.line3 = new Steema.TeeChart.Styles.Line();
            this.numericUpDownForNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownSeasons = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxForCycle = new System.Windows.Forms.TextBox();
            this.labelForecastCycle = new System.Windows.Forms.Label();
            this.checkBoxCycle = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.wizard.SuspendLayout();
            this.wizardPageReport.SuspendLayout();
            this.wizardPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeasons)).BeginInit();
            this.SuspendLayout();
            // 
            // wizard
            // 
            this.wizard.Controls.Add(this.wizardPageData);
            this.wizard.Pages.AddRange(new Dew.Math.Controls.WizardPage[] {
            this.wizardPageData});
            this.wizard.Size = new System.Drawing.Size(591, 320);
            this.wizard.AfterSwitchPages += new Dew.Math.Controls.Wizard.AfterSwitchPagesEventHandler(this.wizard_AfterSwitchPages);
            this.wizard.Controls.SetChildIndex(this.wizardPageData, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageReport, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageFormat, 0);
            this.wizard.Controls.SetChildIndex(this.wizardPageWelcome, 0);
            // 
            // wizardPageReport
            // 
            this.wizardPageReport.Size = new System.Drawing.Size(591, 272);
            this.wizardPageReport.Title = "Decomposition Forecasting: Report";
            // 
            // richTextBox
            // 
            this.richTextBox.Size = new System.Drawing.Size(564, 133);
            // 
            // progressBar
            // 
            this.progressBar.Size = new System.Drawing.Size(510, 13);
            // 
            // wizardPageFormat
            // 
            this.wizardPageFormat.Size = new System.Drawing.Size(591, 272);
            this.wizardPageFormat.Title = "Step 2: Report options";
            // 
            // wizardPageWelcome
            // 
            this.wizardPageWelcome.Size = new System.Drawing.Size(591, 272);
            this.wizardPageWelcome.Title = "Decomposition Forecasting";
            // 
            // wizardPageData
            // 
            this.wizardPageData.Controls.Add(this.tChartData);
            this.wizardPageData.Controls.Add(this.numericUpDownForNum);
            this.wizardPageData.Controls.Add(this.label5);
            this.wizardPageData.Controls.Add(this.groupBox3);
            this.wizardPageData.Controls.Add(this.button1);
            this.wizardPageData.Description = "Define decomposition model parameters";
            this.wizardPageData.Location = new System.Drawing.Point(0, 0);
            this.wizardPageData.Name = "wizardPageData";
            this.wizardPageData.Size = new System.Drawing.Size(591, 272);
            this.wizardPageData.TabIndex = 13;
            this.wizardPageData.Title = "Step 1: Define model";
            // 
            // tChartData
            // 
            this.tChartData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tChartData.Aspect.ElevationFloat = 345;
            this.tChartData.Aspect.RotationFloat = 345;
            this.tChartData.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Shadow.Visible = false;
            this.tChartData.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.Font.Shadow.Visible = false;
            this.tChartData.Header.Lines = new string[] {
        "Transformations"};
            // 
            // 
            // 
            this.tChartData.Header.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Shadow.Visible = false;
            this.tChartData.Location = new System.Drawing.Point(248, 75);
            this.tChartData.Name = "tChartData";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.tChartData.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChartData.Panel.Shadow.Visible = false;
            this.tChartData.Series.Add(this.line1);
            this.tChartData.Series.Add(this.line2);
            this.tChartData.Series.Add(this.line3);
            this.tChartData.Size = new System.Drawing.Size(340, 184);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.SubHeader.Shadow.Visible = false;
            this.tChartData.TabIndex = 11;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Right.Shadow.Visible = false;
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line1.Marks.Callout.Distance = 0;
            this.line1.Marks.Callout.Draw3D = false;
            this.line1.Marks.Callout.Length = 10;
            this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "Zero";
            // 
            // 
            // 
            this.line1.XValues.DataMember = "X";
            this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line1.YValues.DataMember = "Y";
            // 
            // line2
            // 
            // 
            // 
            // 
            this.line2.Brush.Color = System.Drawing.Color.Green;
            // 
            // 
            // 
            this.line2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line2.Marks.Callout.Distance = 0;
            this.line2.Marks.Callout.Draw3D = false;
            this.line2.Marks.Callout.Length = 10;
            this.line2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line2.Title = "Mov. ave.";
            // 
            // 
            // 
            this.line2.XValues.DataMember = "X";
            this.line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line2.YValues.DataMember = "Y";
            // 
            // line3
            // 
            // 
            // 
            // 
            this.line3.Brush.Color = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.line3.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line3.Marks.Callout.Distance = 0;
            this.line3.Marks.Callout.Draw3D = false;
            this.line3.Marks.Callout.Length = 10;
            this.line3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line3.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line3.Pointer.Brush.Color = System.Drawing.Color.Yellow;
            this.line3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line3.Title = "Trend";
            // 
            // 
            // 
            this.line3.XValues.DataMember = "X";
            this.line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line3.YValues.DataMember = "Y";
            // 
            // numericUpDownForNum
            // 
            this.numericUpDownForNum.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownForNum.Location = new System.Drawing.Point(91, 239);
            this.numericUpDownForNum.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownForNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownForNum.Name = "numericUpDownForNum";
            this.numericUpDownForNum.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownForNum.TabIndex = 9;
            this.numericUpDownForNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "# of forecasts";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownSeasons);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxForCycle);
            this.groupBox3.Controls.Add(this.labelForecastCycle);
            this.groupBox3.Controls.Add(this.checkBoxCycle);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(13, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 93);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Decomposition parameters";
            // 
            // numericUpDownSeasons
            // 
            this.numericUpDownSeasons.Location = new System.Drawing.Point(88, 65);
            this.numericUpDownSeasons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSeasons.Name = "numericUpDownSeasons";
            this.numericUpDownSeasons.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownSeasons.TabIndex = 4;
            this.numericUpDownSeasons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSeasons.ValueChanged += new System.EventHandler(this.numericUpDownSeasons_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Seasons";
            // 
            // textBoxForCycle
            // 
            this.textBoxForCycle.Enabled = false;
            this.textBoxForCycle.Location = new System.Drawing.Point(88, 36);
            this.textBoxForCycle.Name = "textBoxForCycle";
            this.textBoxForCycle.Size = new System.Drawing.Size(62, 20);
            this.textBoxForCycle.TabIndex = 2;
            this.textBoxForCycle.Text = "1";
            // 
            // labelForecastCycle
            // 
            this.labelForecastCycle.AutoSize = true;
            this.labelForecastCycle.Enabled = false;
            this.labelForecastCycle.Location = new System.Drawing.Point(6, 39);
            this.labelForecastCycle.Name = "labelForecastCycle";
            this.labelForecastCycle.Size = new System.Drawing.Size(76, 13);
            this.labelForecastCycle.TabIndex = 1;
            this.labelForecastCycle.Text = "Forecast cycle";
            // 
            // checkBoxCycle
            // 
            this.checkBoxCycle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxCycle.Location = new System.Drawing.Point(9, 19);
            this.checkBoxCycle.Name = "checkBoxCycle";
            this.checkBoxCycle.Size = new System.Drawing.Size(70, 17);
            this.checkBoxCycle.TabIndex = 0;
            this.checkBoxCycle.Text = "Use cycle";
            this.checkBoxCycle.CheckedChanged += new System.EventHandler(this.checkBoxCycle_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(13, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Load data";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DecForecastWizard
            // 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(591, 320);
            this.Name = "DecForecastWizard";
            this.Load += new System.EventHandler(this.DecForecastWizard_Load);
            this.wizard.ResumeLayout(false);
            this.wizardPageReport.ResumeLayout(false);
            this.wizardPageReport.PerformLayout();
            this.wizardPageData.ResumeLayout(false);
            this.wizardPageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownForNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeasons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Dew.Math.Controls.WizardPage wizardPageData;
        private Vector timeseries;
        private Vector data, yv, mv, tv;
        private Vector cv, kv, sv, rv;
        private Vector forecasts, residuals;
        private double a, b, dmean; // trend parameters
        private int l, l2, fornum; // ma period

        public TVec TimeSeries
        {
            get { return (TVec)timeseries; }
        }


        #region Calculations

        /// <summary>
        /// Performs all necessary calculations and updates charts
        /// </summary>
        private void DoCalc()
        {
            if (timeseries.Length > 0)
            {
                // read parameters
                l = (int)numericUpDownSeasons.Value;
                l2 = (l - 1) / 2; //l/2 period end index
                fornum = (int)numericUpDownForNum.Value;
                // no transformation ...
                data.Copy(timeseries);

                // #1 : Remove mean
                dmean = data.Mean();
                yv.Copy(data);
                yv *= 1.0 / dmean;
                DrawValues(yv, tChartData.Series[0], 0, 1, false);

                // #2 : Moving average
                MovAve();
                DrawValues(mv, tChartData.Series[1], 0, 1, false);

                // #3 : Trend on M
                Trend();
                DrawValues(tv, tChartData.Series[2], 0, 1, false);

                // #4 : Cycle
                cv = mv / tv;

                // #5 :  Seasonality
                Seasonality();

                // #6 : Randomness
                Randomness();
            }
        }
        /// <summary>
        /// Forecasts values (must be called affter the DoCalc call).
        /// </summary>
        private void DoForecasts()
        {
            Vector xv = new Vector(0);
            forecasts.Size(data.Length + fornum);
            // Mean
            forecasts.SetVal(dmean);

            // Trend component
            xv.Size(forecasts);
            xv.Ramp();
            RegModels.LineEval(new double[] { a, b }, xv, tv);
            forecasts *= tv;

            // Seasonality
            sv.Resize(forecasts.Length, false);
            for (int i = l; i < sv.Length; i++)
                sv.Values[i] = sv.Values[i % l];
            forecasts *= sv;

            // add cycle factor, if specified
            if (checkBoxCycle.Checked)
            {
                cv.Resize(forecasts.Length, false);
                cv.SetVal(Convert.ToDouble(textBoxForCycle.Text), data.Length, fornum);
                forecasts *= tv;
            }
            // define R factor as 1.0 for forecasts
            rv.Resize(forecasts.Length, false);
            rv.SetVal(1.0, data.Length, fornum);

            // calculate residuals
            residuals.Size(data);
            residuals.Sub(data, forecasts, 0, 0, 0, data.Length);
        }
        
        /// <summary>
        /// Moving average on zero mean time series
        /// </summary>
        private void MovAve()
        {
            Vector v1 = new Vector(0);
            int mind;
            if (l <= 2) StatTimeSerAnalysis.MovingAverage(yv, l, mv, out mind, true);
            else
            {
                int eind = (yv.Length - 1) + l2 + 1;
                v1.Length = yv.Length + l2 * 2;
                v1.Copy(yv, 0, l2 + 1, yv.Length);
                for (int i = 0; i <= l2; i++)
                {
                    v1.Values[i] = v1.Values[i + l];
                    v1.Values[i + eind - 1] = v1.Values[eind - l + i];
                }
                StatTimeSerAnalysis.MovingAverage(v1, l, mv, out mind, true);
            }
        }

        /// <summary>
        /// Trend on moving average
        /// </summary>
        private void Trend()
        {
            Vector bv = new Vector(0);
            Vector x = new Vector(0);
            x.Size(mv);
            x.Ramp();
            // perform fit on truncated MA because first l2+1 and last l2+1  problem (see NIST pages)
            x.SetSubRange(l2, x.Length - 2 * l2);
            mv.SetSubRange(l2, mv.Length - 2 * l2);
            RegModels.LineFit(bv, x, mv, null);
            // but evaluate on whole interval
            x.SetSubRange();
            mv.SetSubRange();
            // trend parameters
            a = bv.Values[0];
            b = bv.Values[1];
            RegModels.LineEval(bv, x, tv);
        }

        private void Seasonality()
        {
            kv = yv / mv;
            sv.Size(l);
            double sum;
            int j, n;
            for (int i = 0; i < l; i++)
            {
                sum = 0.0;
                j = n = 0;
                while (j + i < kv.Length)
                {
                    sum += kv.Values[j + i];
                    j += l;
                    n++;
                }
                if (n > 1) sv.Values[i] = sum / (double)n; else sv.Values[i] = 0.0;
            }
        }

        private void Randomness()
        {
            int plen = sv.Length;
            rv.Size(kv);
            for (int i = 0; i < rv.Length; i++)
                rv.Values[i] = kv.Values[i] / sv.Values[i % plen];
        }

        #endregion

        /// <summary>
        /// Textual report
        /// </summary>
        private void TextReport()
        {
            richTextBox.SuspendLayout();
            wizard.BackEnabled = false;
            wizard.NextEnabled = false;
            try
            {
                richTextBox.Clear();
                progressBar.Value = 0; 
                DoCalc();
                progressBar.Value = 40;
                DoForecasts();
                progressBar.Value = 60;
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, 10, FontStyle.Underline);
                richTextBox.SelectedText = "Forecast summary\n\n";
                richTextBox.SelectedText = "Model:\tMean x Trend x ";
                if (checkBoxCycle.Checked) richTextBox.SelectedText += "Cycle x ";
                richTextBox.SelectedText += "Season\n";
                richTextBox.SelectedText += "Rows:\t" + data.Length.ToString() + "\n";
                richTextBox.SelectedText += "Mean:\t" + Math387.FormatSample(FmtString, timeseries.Mean()) + "\n";
                richTextBox.SelectedText += "Residuals RMS:\t" + Math387.FormatSample(FmtString, residuals.RMS()) + "\n";
                richTextBox.SelectedText += "Trend\t(" + Math387.FormatSample(FmtString, a) + ") + (" + Math387.FormatSample(FmtString, b) + ") x Time\n";
                richTextBox.SelectedText += "Seasons\t" + l.ToString() + "\n";
                richTextBox.SelectedText += "Seasonal component ratio:\n#\tratio\n";
                for (int i = 0; i < l; i++) richTextBox.SelectedText += (i + 1) + "\t" + Math387.FormatSample(FmtString, sv.Values[i]) + "\n";
                richTextBox.SelectedText = "\n";

                // forecasts section
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont.FontFamily, 10, FontStyle.Underline);
                richTextBox.SelectedText = "Forecast\n\n";
                richTextBox.SelectionColor = Color.Blue;
                SetupTabs(richTextBox, 7);
                richTextBox.SelectedText = "Time\tForecast\tActual\tResidual\tTrend factor\tCycle\tSeason\tRandomness\n";

                string st = "";
                for (int i = 0; i < forecasts.Length; i++)
                {
                    st += i + 1 + "\t" + Math387.FormatSample(FmtString, forecasts.Values[i]) + "\t";
                    if (i < timeseries.Length) st += Math387.FormatSample(FmtString, data.Values[i]) + "\t" + Math387.FormatSample(FmtString, residuals.Values[i]) + "\t";
                    else st += "\t\t";
                    st += Math387.FormatSample(FmtString, tv.Values[i]) + "\t";
                    if (checkBoxCycle.Checked) st += Math387.FormatSample(FmtString, cv.Values[i]) + "\t"; else st += "\t";
                    st += Math387.FormatSample(FmtString, sv.Values[i]) + "\t";
                    st += Math387.FormatSample(FmtString, rv.Values[i]) + "\t\n";
                }
                richTextBox.SelectedText = st;
                if (checkBoxCharts.Checked)
                {
                    // Charts
                    // #1: Forecasts
                    progressBar.Value = 70;
                    Chart.Aspect.View3D = false;
                    Chart.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
                    Chart.Legend.Visible = true;
                    Chart.Header.Text = "Forecasts";
                    Steema.TeeChart.Styles.Points pser;
                    Chart.Series.Add(pser = new Steema.TeeChart.Styles.Points());
                    Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                    pser.Title = "Time Series";
                    pser.Pointer.VertSize = 2;
                    pser.Pointer.HorizSize = 2;
                    Chart.Series[1].Title = "Forecasts";
                    DrawValues(timeseries, Chart.Series[0], 0, 1, false);
                    DrawValues(forecasts, Chart.Series[1], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";

                    // #2: Residuals
                    progressBar.Value = 75;
                    Chart.Legend.Visible = false;
                    Chart.Series.Clear();
                    Chart.Header.Text = "Residuals";
                    Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                    DrawValues(residuals, Chart.Series[0], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";

                    // #3: Trend factor
                    progressBar.Value = 80;
                    Chart.Legend.Visible = false;
                    Chart.Series.Clear();
                    Chart.Header.Text = "Trend factor";
                    Steema.TeeChart.Styles.Bar bseries;
                    Chart.Series.Add(bseries = new Steema.TeeChart.Styles.Bar());
                    bseries.Marks.Visible = false;
                    bseries.UseOrigin = true;
                    bseries.Origin = 1.0;
                    DrawValues(tv, Chart.Series[0], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";

                    // #4: Cycle
                    progressBar.Value = 85;
                    Chart.Series.Clear();
                    Chart.Legend.Visible = false;
                    Chart.Header.Text = "Cycle factor";
                    Chart.Series.Add(bseries = new Steema.TeeChart.Styles.Bar());
                    bseries.Marks.Visible = false;
                    bseries.UseOrigin = true;
                    bseries.Origin = 1.0;
                    DrawValues(cv, Chart.Series[0], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";

                    // #5: Seasonality
                    progressBar.Value = 90;
                    Chart.Series.Clear();
                    Chart.Legend.Visible = false;
                    Chart.Header.Text = "Season factor";
                    Chart.Series.Add(bseries = new Steema.TeeChart.Styles.Bar());
                    bseries.Marks.Visible = false;
                    bseries.UseOrigin = true;
                    bseries.Origin = 1.0;
                    DrawValues(sv, Chart.Series[0], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";

                    // #6: Randomness
                    progressBar.Value = 95;
                    Chart.Series.Clear();
                    Chart.Legend.Visible = false;
                    Chart.Header.Text = "Randomness";
                    Chart.Series.Add(new Steema.TeeChart.Styles.Line());
                    DrawValues(rv, Chart.Series[0], 0, 1, false);
                    CopyToRichBox(richTextBox);
                    richTextBox.SelectedText = "\n";
                }
                
                progressBar.Value = 100;
            }
            finally
            {
                richTextBox.SelectionStart = 0;
                richTextBox.ResumeLayout();
                wizard.BackEnabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                timeseries.LoadFromFile(openFileDialog1.FileName);
                numericUpDownSeasons.Maximum = timeseries.Length - 4;
                DoCalc();
                if (wizard.SelectedPage == wizardPageData) wizard.NextEnabled = timeseries.Length > 0;
            }
        }

        private void numericUpDownSeasons_ValueChanged(object sender, EventArgs e)
        {
            DoCalc();
        }

        private void checkBoxCycle_CheckedChanged(object sender, EventArgs e)
        {
            labelForecastCycle.Enabled = checkBoxCycle.Checked;
            textBoxForCycle.Enabled = checkBoxCycle.Checked;
        }

        private void wizard_AfterSwitchPages(object sender, Dew.Math.Controls.Wizard.AfterSwitchPagesEventArgs e)
        {
            Dew.Math.Controls.WizardPage newpage = wizard.Pages[e.NewIndex];
            if (newpage == wizardPageReport)
            {
                TextReport();
                wizard.CancelEnabled = false;
            }
            else if (newpage == wizardPageData)
            {
                wizard.NextEnabled = timeseries.Length > 0;
            }
            else wizard.CancelEnabled = true;

        }

        private void DecForecastWizard_Load(object sender, EventArgs e)
        {
            wizardPageWelcome.Description = "Classical time series decomposition separates a time series into "
                + "five components: mean, long-range trend, seasonality, cycle, and randomness. "
                + "The decomposition model is:\n\n"
                + "Value = (Mean) x (Trend) x (Seasonality) x (Cycle) x (Random).\n\n"
                + "Note that this model is multiplicative rather than additive. Although "
                + "additive models are more popular in other areas of statistics, forecasters "
                + "have found that the multiplicative model fits a wider range of forecasting "
                + "situations.\n"
                + "Decomposition is popular among forecasters because it is easy to understand (and explain to others). "
                + "While complex ARIMA models are often popular among statisticians, they are not as well accepted among "
                + "forecasting practitioners. For seasonal (monthly, weekly, or quarterly) data, decomposition methods "
                + "are often as accurate as the ARIMA methods and they provide additional information about the trend and "
                + "cycle which may not be available in ARIMA methods.\n"
                + "Decomposition has one disadvantage: the cycle component must be input by the forecaster since it is not "
                + "estimated by the algorithm. You can get around this by ignoring the cycle, or by assuming a constant value. "
                + "Some forecasters consider this a strength because it allows the forecaster to enter information "
                + "about the current business cycle into the forecast.";

            DoCalc();
        }


    }
}

