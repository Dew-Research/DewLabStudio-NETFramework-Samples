using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;

namespace MtxVecDemo
{
	public class CopyCompareForm : MtxVecDemo.BasicForm2
	{
		private Matrix a,b;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelDimension;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button button1;
		private int dim;
		private Steema.TeeChart.TChart tChart1;
		private Steema.TeeChart.Styles.Bar seriesNet;
		private Steema.TeeChart.Styles.Bar seriesMtx;

		private System.ComponentModel.IContainer components = null;

		public CopyCompareForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyCompareForm));
            this.label1 = new System.Windows.Forms.Label();
            this.labelDimension = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.seriesNet = new Steema.TeeChart.Styles.Bar();
            this.seriesMtx = new Steema.TeeChart.Styles.Bar();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tChart1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.labelDimension);
            this.panel2.Controls.Add(this.label1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrix dimension:";
            // 
            // labelDimension
            // 
            this.labelDimension.Location = new System.Drawing.Point(104, 16);
            this.labelDimension.Name = "labelDimension";
            this.labelDimension.Size = new System.Drawing.Size(48, 16);
            this.labelDimension.TabIndex = 1;
            this.labelDimension.Text = "labelDimension";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(8, 32);
            this.trackBar1.Maximum = 1300;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(128, 45);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 30;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(16, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Do comparison";
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.tChart1.Axes.Bottom.Title.Lines = new string[] {
        ""};
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
            this.tChart1.Axes.Left.Title.Caption = "Normalized ratios";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "Normalized ratios"};
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
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.tChart1.Location = new System.Drawing.Point(152, 8);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.seriesNet);
            this.tChart1.Series.Add(this.seriesMtx);
            this.tChart1.Size = new System.Drawing.Size(312, 272);
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
            this.tChart1.TabIndex = 3;
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
            // seriesNet
            // 
            // 
            // 
            // 
            this.seriesNet.Brush.Color = System.Drawing.Color.DarkOrange;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesNet.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.seriesNet.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.seriesNet.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.seriesNet.Marks.Callout.Distance = 0;
            this.seriesNet.Marks.Callout.Draw3D = false;
            this.seriesNet.Marks.Callout.Length = 20;
            this.seriesNet.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesNet.Marks.Font.Shadow.Visible = false;
            this.seriesNet.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.seriesNet.Title = ".NET";
            // 
            // 
            // 
            this.seriesNet.XValues.DataMember = "X";
            this.seriesNet.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.seriesNet.YValues.DataMember = "Bar";
            // 
            // seriesMtx
            // 
            // 
            // 
            // 
            this.seriesMtx.Brush.Color = System.Drawing.Color.RoyalBlue;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesMtx.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.seriesMtx.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.seriesMtx.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.seriesMtx.Marks.Callout.Distance = 0;
            this.seriesMtx.Marks.Callout.Draw3D = false;
            this.seriesMtx.Marks.Callout.Length = 20;
            this.seriesMtx.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.seriesMtx.Marks.Font.Shadow.Visible = false;
            this.seriesMtx.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Value;
            this.seriesMtx.Title = "MtxVec";
            // 
            // 
            // 
            this.seriesMtx.XValues.DataMember = "X";
            this.seriesMtx.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.seriesMtx.YValues.DataMember = "Bar";
            // 
            // CopyCompareForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 445);
            this.Name = "CopyCompareForm";
            this.Load += new System.EventHandler(this.CopyCompareForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	

		private void CopyCompareForm_Load(object sender, System.EventArgs e) {
			richTextBox1.Clear();
			Add("This examle compares \"regular\" .NET code with highly optimized MtxVec code."
				+" The example compares TMtx.Copy and TMtx.Transp method with .NET equivalent"
				+" code. Here is the code used : ");
			Add("");
            richTextBox1.SelectionFont = new Font("Courier New", richTextBox1.SelectionFont.Size);
			Add("private void copyMtxVec(TMtx a, TMtx b) {\n"+
				"  b.Copy(a);\n"+
				"}");
			Add("");
            richTextBox1.SelectionFont = new Font("Courier New", richTextBox1.SelectionFont.Size);
			Add("private void copyDotNet(ref double[][] a, ref double[][] b) {\n" +
			"  for (int i=0;i<a.Length;i++)\n"+
			"    for (int j=0;j<a[i].Length;j++) \n"+
			"      b[i][j] = a[i][j];\n"+
		  "}");
			Add("");
            richTextBox1.SelectionFont = new Font("Courier New", richTextBox1.SelectionFont.Size);
			Add("private void transpMtxVec(TMtx a, TMtx b) {\n"+
				"  b.Transp(a);\n"+
			"}");
			Add("");
            richTextBox1.SelectionFont = new Font("Courier New", richTextBox1.SelectionFont.Size);
			Add("private void transpDotNet(ref double[][] a, ref double[][] b) {\n"+
			"  for (int i=0;i<a.Length;i++) \n"+
			"    for (int j=0;j<a[i].Length;j++) \n"+
			"      b[j][i] = a[i][j];\n"+
		  "}");
			Add("");
			Add("Try changing dimension of test matrix.");

            a = new Matrix(0, 0);
            b = new Matrix(0, 0);
			trackBar1_ValueChanged(trackBar1,null);
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e) {
			dim = (sender as TrackBar).Value;
			labelDimension.Text = dim.ToString();
		}

		private void copyMtxVec(TMtx a, TMtx b) {
			b.Copy(a);
		}

		private void copyDotNet(ref double[][] a, ref double[][] b) {
			for (int i=0;i<a.Length;i++) 
				for (int j=0;j<a[i].Length;j++) 
					b[i][j] = a[i][j];
		}

		private void transpMtxVec(TMtx a, TMtx b) {
			b.Transp(a);
		}

		private void transpDotNet(ref double[][] a, ref double[][] b) {
			for (int i=0;i<a.Length;i++) 
				for (int j=0;j<a[i].Length;j++) 
					b[j][i] = a[i][j];
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				seriesNet.Clear();
				seriesMtx.Clear();
				a.Size(dim,dim,false);
				b.Size(a);
				double[][] aa= new double[dim][];
				double[][] bb = new double[dim][];
				a.SizeToArray(ref aa);
				b.SizeToArray(ref bb);
				int maxIter;
				if (dim < 15) maxIter = 5000000; 
				else if (dim < 30) maxIter = 500000;
				else if (dim < 50) maxIter = 200000;
				else if (dim < 80) maxIter = 10000;
				else if (dim < 200) maxIter = 5000;
				else if (dim < 500) maxIter = 1000;
				else maxIter = 100;
				int timeCheck = Environment.TickCount;
				for (int i=0;i<maxIter;i++) copyDotNet(ref aa,ref bb);
				int timeElapsed = Environment.TickCount - timeCheck;
				seriesNet.Add(0,1,"Copy operation");

				timeCheck = Environment.TickCount;
				for (int i=0;i<maxIter;i++) copyMtxVec(a,b);
				int timeElapsed2 = Environment.TickCount - timeCheck;
				seriesMtx.Add(0,(double)timeElapsed2 / (double)timeElapsed);

				timeCheck = Environment.TickCount;
				for (int i=0;i<maxIter;i++) transpDotNet(ref aa,ref bb);
				timeElapsed2 = Environment.TickCount - timeCheck;
				seriesNet.Add(1,(double)timeElapsed2 / (double)timeElapsed, "Transp opertaion");

				timeCheck = Environment.TickCount;
				for (int i=0;i<maxIter;i++) transpMtxVec(a,b);
				timeElapsed2 = Environment.TickCount - timeCheck;
				seriesMtx.Add(1,(double)timeElapsed2 / (double)timeElapsed);

			} finally {
				this.Cursor = Cursors.Default;
			}
		}
	}
}

