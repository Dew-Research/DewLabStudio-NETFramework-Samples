using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Tee;

namespace MtxVecDemo
{
	public class PixelDownSampleForm : MtxVecDemo.BasicForm2
	{
		private System.ComponentModel.IContainer components = null;

		public PixelDownSampleForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            testVec = new Vector(0);
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
            this.buttonCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNormalTime = new System.Windows.Forms.Label();
            this.labelOptimizedTime = new System.Windows.Forms.Label();
            this.buttoDrawNormal = new System.Windows.Forms.Button();
            this.buttonDrawOptimized = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.labelNumber = new System.Windows.Forms.Label();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.seriesNormal = new Steema.TeeChart.Styles.FastLine();
            this.tChart2 = new Steema.TeeChart.TChart();
            this.seriesOptimized = new Steema.TeeChart.Styles.FastLine();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tChart2);
            this.panel2.Controls.Add(this.tChart1);
            this.panel2.Size = new System.Drawing.Size(704, 277);
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.labelNumber);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.buttonDrawOptimized);
            this.panel3.Controls.Add(this.buttoDrawNormal);
            this.panel3.Controls.Add(this.labelOptimizedTime);
            this.panel3.Controls.Add(this.labelNormalTime);
            this.panel3.Controls.Add(this.buttonCompare);
            this.panel3.Location = new System.Drawing.Point(0, 389);
            this.panel3.Size = new System.Drawing.Size(704, 80);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(704, 112);
            // 
            // buttonCompare
            // 
            this.buttonCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompare.Location = new System.Drawing.Point(8, 24);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Raw time for \"normal\" plotting : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Raw time for optimized plotting :";
            // 
            // labelNormalTime
            // 
            this.labelNormalTime.Location = new System.Drawing.Point(256, 8);
            this.labelNormalTime.Name = "labelNormalTime";
            this.labelNormalTime.Size = new System.Drawing.Size(56, 23);
            this.labelNormalTime.TabIndex = 3;
            this.labelNormalTime.Text = "0 ms";
            this.labelNormalTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelOptimizedTime
            // 
            this.labelOptimizedTime.Location = new System.Drawing.Point(256, 40);
            this.labelOptimizedTime.Name = "labelOptimizedTime";
            this.labelOptimizedTime.Size = new System.Drawing.Size(56, 23);
            this.labelOptimizedTime.TabIndex = 4;
            this.labelOptimizedTime.Text = "0 ms";
            this.labelOptimizedTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttoDrawNormal
            // 
            this.buttoDrawNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoDrawNormal.Location = new System.Drawing.Point(320, 8);
            this.buttoDrawNormal.Name = "buttoDrawNormal";
            this.buttoDrawNormal.Size = new System.Drawing.Size(48, 23);
            this.buttoDrawNormal.TabIndex = 5;
            this.buttoDrawNormal.Text = "Draw";
            this.buttoDrawNormal.Click += new System.EventHandler(this.buttoDrawNormal_Click);
            // 
            // buttonDrawOptimized
            // 
            this.buttonDrawOptimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawOptimized.Location = new System.Drawing.Point(320, 40);
            this.buttonDrawOptimized.Name = "buttonDrawOptimized";
            this.buttonDrawOptimized.Size = new System.Drawing.Size(48, 23);
            this.buttonDrawOptimized.TabIndex = 6;
            this.buttonDrawOptimized.Text = "Draw";
            this.buttonDrawOptimized.Click += new System.EventHandler(this.buttonDrawOptimized_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(392, 32);
            this.trackBar1.Maximum = 10000000;
            this.trackBar1.Minimum = 100000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(152, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 300000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 600000;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(392, 8);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(90, 13);
            this.labelNumber.TabIndex = 8;
            this.labelNumber.Text = "Number of points:";
            // 
            // tChart1
            // 
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
            this.tChart1.Dock = System.Windows.Forms.DockStyle.Top;
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
        "Normal"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            // 
            // 
            // 
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
            this.tChart1.Legend.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(0, 0);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.seriesNormal);
            this.tChart1.Size = new System.Drawing.Size(704, 144);
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
            this.tChart1.TabIndex = 0;
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
            // seriesNormal
            // 
            // 
            // 
            // 
            this.seriesNormal.LinePen.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesNormal.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.seriesNormal.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.seriesNormal.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.seriesNormal.Marks.Callout.Distance = 0;
            this.seriesNormal.Marks.Callout.Draw3D = false;
            this.seriesNormal.Marks.Callout.Length = 10;
            this.seriesNormal.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesNormal.Marks.Font.Shadow.Visible = false;
            this.seriesNormal.Title = "fastLine1";
            // 
            // 
            // 
            this.seriesNormal.XValues.DataMember = "X";
            this.seriesNormal.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.seriesNormal.YValues.DataMember = "Y";
            // 
            // tChart2
            // 
            // 
            // 
            // 
            this.tChart2.Aspect.ElevationFloat = 345;
            this.tChart2.Aspect.RotationFloat = 345;
            this.tChart2.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Title.Shadow.Visible = false;
            this.tChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Header.Font.Shadow.Visible = false;
            this.tChart2.Header.Lines = new string[] {
        "Using PixelDownSample"};
            // 
            // 
            // 
            this.tChart2.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Shadow.Visible = false;
            this.tChart2.Legend.Visible = false;
            this.tChart2.Location = new System.Drawing.Point(0, 144);
            this.tChart2.Name = "tChart2";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Panel.Shadow.Visible = false;
            this.tChart2.Series.Add(this.seriesOptimized);
            this.tChart2.Size = new System.Drawing.Size(704, 133);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.SubHeader.Shadow.Visible = false;
            this.tChart2.TabIndex = 1;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Right.Shadow.Visible = false;
            // 
            // seriesOptimized
            // 
            // 
            // 
            // 
            this.seriesOptimized.LinePen.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesOptimized.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.seriesOptimized.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.seriesOptimized.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.seriesOptimized.Marks.Callout.Distance = 0;
            this.seriesOptimized.Marks.Callout.Draw3D = false;
            this.seriesOptimized.Marks.Callout.Length = 10;
            this.seriesOptimized.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesOptimized.Marks.Font.Shadow.Visible = false;
            this.seriesOptimized.Title = "fastLine2";
            // 
            // 
            // 
            this.seriesOptimized.XValues.DataMember = "X";
            this.seriesOptimized.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.seriesOptimized.YValues.DataMember = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Important:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(423, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Raw time means time to add values to the series and not time needed to draw the s" +
                "eries.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Observe the times and CPU load needed to update each chart.";
            // 
            // PixelDownSampleForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(704, 469);
            this.Name = "PixelDownSampleForm";
            this.Load += new System.EventHandler(this.PixelDownSampleForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void PixelDownSampleForm_Load(object sender, System.EventArgs e) {
			Add("The PixelDownSample method can be used to speed "
				+ "up the drawing of huge amounts of data (>> 1 milion points) "
				+ "samples). The routine will reduce the number of "
				+ "points in vectors Y and X in such a way that there "
				+ "will be virtualy no visual difference between the original "
				+ "and downsampled data. That however will no longer be "
				+ "true, if you will zoom-in on the data.");
			Add("The performance gain can be as big as 500x depending "
				+ "on the charting tool that you use, CPU and number "
				+ "of points that will be drawn. You can easily "
				+ "draw data series from vectors with length of over 10 milion "
				+ "points in real time taking only a percent or so of your "
				+ "CPU. Try changing the \"Number of points\" "
				+ "and compare the visual appearance of both charts.");
			trackBar1_ValueChanged(trackBar1,null);
		}

		private System.Windows.Forms.Button buttonCompare;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelNormalTime;
		private System.Windows.Forms.Label labelOptimizedTime;
		private System.Windows.Forms.Button buttoDrawNormal;
		private System.Windows.Forms.Button buttonDrawOptimized;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label labelNumber;
		private Steema.TeeChart.TChart tChart1;
		private Steema.TeeChart.TChart tChart2;
		private Steema.TeeChart.Styles.FastLine seriesNormal;
		private Steema.TeeChart.Styles.FastLine seriesOptimized;

		private Vector testVec;
        private Label label4;
        private Label label3;
        private Label label5;
		private int numPoints;
		
		private void FillRandomPoints() {
			if (numPoints == testVec.Length) {
				testVec.Add(10000);
			} else {
				testVec.Size(numPoints);
				testVec.RandUniform(-500,500);
				testVec.CumSum();
			}
		}

		private void panel2_Resize(object sender, System.EventArgs e) {
			tChart1.Height = panel2.Height / 2;
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e) {
		  numPoints = (sender as TrackBar).Value;
			labelNumber.Text = "Number of points : " + numPoints.ToString();
		}

		private void buttonCompare_Click(object sender, System.EventArgs e) 
        {
            buttonDrawOptimized_Click(buttonDrawOptimized, e);
            buttoDrawNormal_Click(buttoDrawNormal, e);
        }

		private void buttoDrawNormal_Click(object sender, System.EventArgs e) {
			FillRandomPoints();
			this.Cursor = Cursors.WaitCursor;
            try
            {
                int timeCheck = Environment.TickCount;
                tChart1.Axes.Bottom.Automatic = false;
				tChart1.Axes.Bottom.SetMinMax(0, testVec.Length - 1);
                tChart1[0].Clear();
                TeeChart.DrawValues(testVec, tChart1[0], 0, 1.0, false);
                Application.DoEvents();

                labelNormalTime.Text = (Environment.TickCount - timeCheck).ToString() + " ms";
            } 
            finally 
            {
                this.Cursor = Cursors.Default;
            }
		}

		private void buttonDrawOptimized_Click(object sender, System.EventArgs e) {
			FillRandomPoints();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int timeCheck = Environment.TickCount;
                tChart2.Axes.Bottom.Automatic = false;
				tChart2.Axes.Bottom.SetMinMax( 0, testVec.Length - 1);
                tChart2[0].Clear();
                TeeChart.DrawValues(testVec, tChart2[0], 0, 1.0, true);
                Application.DoEvents();
                labelOptimizedTime.Text = (Environment.TickCount - timeCheck).ToString() + " ms";
            } 
            finally 
            {
                this.Cursor = Cursors.Default;
            }
		}
	}
}

