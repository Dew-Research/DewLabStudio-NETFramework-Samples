using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Math.Tee;
using static Dew.Math.Tee.TeeChart;

namespace MtxVecDemo
{
	public class YuleLevinsonForm : MtxVecDemo.BasicForm1
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1x;
		private System.Windows.Forms.RadioButton radioButton2x;
		private System.Windows.Forms.RadioButton radioButton4x;
		private System.Windows.Forms.RadioButton radioButton8x;
		private System.Windows.Forms.RadioButton radioButton16x;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelCorrLength;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelLPCCoef;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label labelTimeLYW;
		private Steema.TeeChart.Styles.FastLine series1;
        private Steema.TeeChart.Styles.FastLine series2;
		private System.Windows.Forms.Label labelTimeFFT;
		private System.ComponentModel.IContainer components = null;

		public YuleLevinsonForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			x = new Vector(0);
			y = new Vector(0);
			spec = new Vector(0);
			corr = new Vector(0);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton16x = new System.Windows.Forms.RadioButton();
            this.radioButton8x = new System.Windows.Forms.RadioButton();
            this.radioButton4x = new System.Windows.Forms.RadioButton();
            this.radioButton2x = new System.Windows.Forms.RadioButton();
            this.radioButton1x = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCorrLength = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLPCCoef = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTimeLYW = new System.Windows.Forms.Label();
            this.labelTimeFFT = new System.Windows.Forms.Label();
            this.series1 = new Steema.TeeChart.Styles.FastLine();
            this.series2 = new Steema.TeeChart.Styles.FastLine();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(688, 100);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTimeFFT);
            this.panel2.Controls.Add(this.labelTimeLYW);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 421);
            this.panel2.Size = new System.Drawing.Size(688, 48);
            this.panel2.Controls.SetChildIndex(this.button1, 0);
            this.panel2.Controls.SetChildIndex(this.labelTimeLYW, 0);
            this.panel2.Controls.SetChildIndex(this.labelTimeFFT, 0);
            this.panel2.Controls.SetChildIndex(this.checkBoxDownsample, 0);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(688, 100);
            // 
            // checkBoxDownsample
            // 
            this.checkBoxDownsample.Location = new System.Drawing.Point(16, 16);
            // 
            // tChart1
            // 
            this.tChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tChart1.Aspect.ElevationFloat = 345;
            this.tChart1.Aspect.RotationFloat = 345;
            this.tChart1.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Font.Shadow.Visible = false;
            this.tChart1.Header.Lines = new string[] {
        "TeeChart"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            this.tChart1.Header.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Top;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Shadow.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(192, 104);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.series1);
            this.tChart1.Series.Add(this.series2);
            this.tChart1.Size = new System.Drawing.Size(488, 312);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubHeader.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.Shadow.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton16x);
            this.groupBox1.Controls.Add(this.radioButton8x);
            this.groupBox1.Controls.Add(this.radioButton4x);
            this.groupBox1.Controls.Add(this.radioButton2x);
            this.groupBox1.Controls.Add(this.radioButton1x);
            this.groupBox1.Location = new System.Drawing.Point(8, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zero padding";
            // 
            // radioButton16x
            // 
            this.radioButton16x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton16x.Location = new System.Drawing.Point(88, 40);
            this.radioButton16x.Name = "radioButton16x";
            this.radioButton16x.Size = new System.Drawing.Size(56, 24);
            this.radioButton16x.TabIndex = 4;
            this.radioButton16x.Text = "16x";
            this.radioButton16x.Click += new System.EventHandler(this.radioButton8x_Click);
            // 
            // radioButton8x
            // 
            this.radioButton8x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton8x.Location = new System.Drawing.Point(88, 16);
            this.radioButton8x.Name = "radioButton8x";
            this.radioButton8x.Size = new System.Drawing.Size(56, 24);
            this.radioButton8x.TabIndex = 3;
            this.radioButton8x.Text = "8x";
            this.radioButton8x.Click += new System.EventHandler(this.radioButton8x_Click);
            // 
            // radioButton4x
            // 
            this.radioButton4x.Checked = true;
            this.radioButton4x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton4x.Location = new System.Drawing.Point(8, 64);
            this.radioButton4x.Name = "radioButton4x";
            this.radioButton4x.Size = new System.Drawing.Size(56, 24);
            this.radioButton4x.TabIndex = 2;
            this.radioButton4x.TabStop = true;
            this.radioButton4x.Text = "4x";
            this.radioButton4x.Click += new System.EventHandler(this.radioButton8x_Click);
            // 
            // radioButton2x
            // 
            this.radioButton2x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2x.Location = new System.Drawing.Point(8, 40);
            this.radioButton2x.Name = "radioButton2x";
            this.radioButton2x.Size = new System.Drawing.Size(56, 24);
            this.radioButton2x.TabIndex = 1;
            this.radioButton2x.Text = "2x";
            this.radioButton2x.Click += new System.EventHandler(this.radioButton8x_Click);
            // 
            // radioButton1x
            // 
            this.radioButton1x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1x.Location = new System.Drawing.Point(8, 16);
            this.radioButton1x.Name = "radioButton1x";
            this.radioButton1x.Size = new System.Drawing.Size(56, 24);
            this.radioButton1x.TabIndex = 0;
            this.radioButton1x.Text = "1x";
            this.radioButton1x.Click += new System.EventHandler(this.radioButton8x_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(8, 224);
            this.trackBar1.Maximum = 8000;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(152, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 500;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 2000;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(8, 304);
            this.trackBar2.Maximum = 8000;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(152, 45);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.TickFrequency = 500;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar2.Value = 2000;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "CorrLength :";
            // 
            // labelCorrLength
            // 
            this.labelCorrLength.Location = new System.Drawing.Point(112, 208);
            this.labelCorrLength.Name = "labelCorrLength";
            this.labelCorrLength.Size = new System.Drawing.Size(56, 16);
            this.labelCorrLength.TabIndex = 7;
            this.labelCorrLength.Text = "labelCorrLength";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "LPCCoef :";
            // 
            // labelLPCCoef
            // 
            this.labelLPCCoef.Location = new System.Drawing.Point(112, 288);
            this.labelLPCCoef.Name = "labelLPCCoef";
            this.labelLPCCoef.Size = new System.Drawing.Size(56, 16);
            this.labelLPCCoef.TabIndex = 9;
            this.labelLPCCoef.Text = "labelLPCCoef";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(136, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calculate spectrum";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTimeLYW
            // 
            this.labelTimeLYW.AutoSize = true;
            this.labelTimeLYW.Location = new System.Drawing.Point(272, 8);
            this.labelTimeLYW.Name = "labelTimeLYW";
            this.labelTimeLYW.Size = new System.Drawing.Size(160, 13);
            this.labelTimeLYW.TabIndex = 2;
            this.labelTimeLYW.Text = "Time needed for Levinson YW : ";
            // 
            // labelTimeFFT
            // 
            this.labelTimeFFT.AutoSize = true;
            this.labelTimeFFT.Location = new System.Drawing.Point(272, 24);
            this.labelTimeFFT.Name = "labelTimeFFT";
            this.labelTimeFFT.Size = new System.Drawing.Size(112, 13);
            this.labelTimeFFT.TabIndex = 3;
            this.labelTimeFFT.Text = "Time needed to FFT : ";
            // 
            // series1
            // 
            // 
            // 
            // 
            this.series1.LinePen.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.series1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.series1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.series1.Marks.Callout.Distance = 0;
            this.series1.Marks.Callout.Draw3D = false;
            this.series1.Marks.Callout.Length = 10;
            this.series1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series1.Marks.Font.Shadow.Visible = false;
            this.series1.Title = "Yule Walker AR";
            // 
            // 
            // 
            this.series1.XValues.DataMember = "X";
            this.series1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.series1.YValues.DataMember = "Y";
            // 
            // series2
            // 
            // 
            // 
            // 
            this.series2.LinePen.Color = System.Drawing.Color.Green;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.series2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.series2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.series2.Marks.Callout.Distance = 0;
            this.series2.Marks.Callout.Draw3D = false;
            this.series2.Marks.Callout.Length = 10;
            this.series2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series2.Marks.Font.Shadow.Visible = false;
            this.series2.Title = "FFT";
            // 
            // 
            // 
            this.series2.XValues.DataMember = "X";
            this.series2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.series2.YValues.DataMember = "Y";
            // 
            // YuleLevinsonForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 469);
            this.Controls.Add(this.labelLPCCoef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCorrLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Name = "YuleLevinsonForm";
            this.Load += new System.EventHandler(this.YuleLevinsonForm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.trackBar1, 0);
            this.Controls.SetChildIndex(this.trackBar2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.labelCorrLength, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.labelLPCCoef, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	
		private int zeroPadding;
		private int corrLength, LPCCoef;
		private Vector x,y,spec,corr;

		private void radioButton8x_Click(object sender, System.EventArgs e) {
			if (radioButton1x.Checked) zeroPadding = 1;
			else if (radioButton2x.Checked) zeroPadding = 2;
			else if (radioButton4x.Checked) zeroPadding = 4;
			else if (radioButton8x.Checked) zeroPadding = 8;
			else if (radioButton16x.Checked) zeroPadding = 16;
		}

		private void YuleLevinsonForm_Load(object sender, System.EventArgs e) {
			Add("YuleWalker autoregressive spectra uses Levinson "
				+ "Durbin recursion to solve a toeplitz systems of "
				+ "linear equations taking only O(n2) operations "
				+ "instead of O(n3) as required by LUSolve. The chart "
				+ "compares FFT and YuleWalker AR. The corrLen defines "
				+ "the number of samples on which the Autocorrelation "
				+ "is performed and LPCCoef defines the number of "
				+ "computed autocorrelation coefficients. The method "
				+ "uses biased autocorrelation. FFT uses only LPCoef "
				+ "parameter to determine the number of sample to "
				+ "include. It then rounds LPCCoef to the nearest "
				+ "power of two. FFT uses no windowing.");
			Add("Zoom in on a chart (left-click and drag mouse "
				+ "over the chart) to see differences. Please note "
				+ "that it takes less then 10ms to compute a 32000 "
				+ "point FFT on P366.");

			radioButton8x_Click(null,null);
			trackBar1_ValueChanged(trackBar1,null);
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e) {
			corrLength = (sender as TrackBar).Value;
			labelCorrLength.Text = corrLength.ToString();
			trackBar2.Maximum = corrLength;
			trackBar2.TickFrequency = corrLength / 20;
			trackBar2.Value = corrLength / 2;
			trackBar2_ValueChanged(trackBar2, null);
		}

		private void trackBar2_ValueChanged(object sender, System.EventArgs e) {
			LPCCoef = (sender as TrackBar).Value;
			labelLPCCoef.Text = LPCCoef.ToString();
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				series1.Clear();
				series2.Clear();
                Math387.StartTimer();				
				y.LoadFromFile(Utils.SourcePath()+@".\Data\FFTData.vec");
				y.Resize(corrLength, true);
				corr.AutoCorrBiased(y,LPCCoef);
				Toeplitz.Levinson(corr, y);
				y.Resize(Math387.LargestExp2(y.Length*zeroPadding),true);
				x.FFT(y, false); // ???
				spec.Mag(x);
				spec.Inv(Math387.EPS);
				spec.Log10();
				double timeElapsed = Math387.StopTimer()*1000;
				labelTimeLYW.Text = "Time needed for Levinson YW : "+ timeElapsed.ToString("0.0")+" ms";
				if (DownSize) {
                    Vector downY = new Vector(0);
					downY.PixelDownSample(tChart1.Width, spec,null,null,TEquidistantSample.eqsXEquidistant); 
					double step = ((double)spec.Length / (double)downY.Length);
                    DrawValues(downY, series1, 0, step, false);
				} else {
                    DrawValues(spec, series1, 0, 1, false);
				}

                Math387.StartTimer();
                y.LoadFromFile(Utils.SourcePath() + @".\Data\FFTData.vec");
                y.Resize(LPCCoef, false);
				y.Resize(Math387.LargestExp2(LPCCoef)*zeroPadding, true);
				x.FFT(y,false); 
				spec.Mag(x);
				spec.ThreshBottom(0.00001); // -100dB
				spec.Log10();

                timeElapsed = Math387.StopTimer()*1000;
				labelTimeFFT.Text = "Time needed for FFT : "+ timeElapsed.ToString("0.0")+" ms";

				if (DownSize) {
                    Vector downY = new Vector(0);
    				downY.PixelDownSample(tChart1.Width, spec,null,null,TEquidistantSample.eqsXEquidistant); 
					double step = ((double)spec.Length / (double)downY.Length);
                    DrawValues(downY, series2, 0, step, false);
				} else {
                    DrawValues(spec, series2, 0, 1, false); // Default parameter values doesn"t work...
				}
				tChart1.Refresh();
			} finally {
				this.Cursor = Cursors.Default;
			}
		}
	
	}
}

