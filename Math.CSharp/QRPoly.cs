using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Math.Editors;
using Dew.Math.Tee;

namespace MtxVecDemo
{
	public class QRPolyForm : MtxVecDemo.BasicForm1
	{
		private Steema.TeeChart.Styles.Points series1;
		private Steema.TeeChart.Styles.Line series2;
		private Steema.TeeChart.Styles.Line series3;
		private Steema.TeeChart.Styles.Line series4;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelTimeNeeded;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
		private System.ComponentModel.IContainer components = null;

		public QRPolyForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			

            r = new Matrix(0, 0);
            x = new Vector(0);
            y = new Vector(0);
            coeff = new Vector(0);
            intX = new Vector(0);
            intY = new Vector(0);
            delta = new Vector(0);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRPolyForm));
            this.series1 = new Steema.TeeChart.Styles.Points();
            this.series2 = new Steema.TeeChart.Styles.Line();
            this.series3 = new Steema.TeeChart.Styles.Line();
            this.series4 = new Steema.TeeChart.Styles.Line();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTimeNeeded = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDown2);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.labelTimeNeeded);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 350);
            this.panel2.Size = new System.Drawing.Size(672, 87);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.checkBoxDownsample, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.labelTimeNeeded, 0);
            this.panel2.Controls.SetChildIndex(this.button1, 0);
            this.panel2.Controls.SetChildIndex(this.button2, 0);
            this.panel2.Controls.SetChildIndex(this.button3, 0);
            this.panel2.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.panel2.Controls.SetChildIndex(this.numericUpDown2, 0);
            // 
            // checkBoxDownsample
            // 
            this.checkBoxDownsample.CheckedChanged += new System.EventHandler(this.checkBoxDownsample_CheckedChanged);
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
            this.tChart1.CausesValidation = false;
            this.tChart1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.tChart1.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            this.tChart1.Legend.TextStyle = Steema.TeeChart.LegendTextStyles.Plain;
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
            this.tChart1.Location = new System.Drawing.Point(0, 100);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.series1);
            this.tChart1.Series.Add(this.series2);
            this.tChart1.Series.Add(this.series3);
            this.tChart1.Series.Add(this.series4);
            this.tChart1.Size = new System.Drawing.Size(672, 250);
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
            // series1
            // 
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
            this.series1.Marks.Callout.Length = 0;
            this.series1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series1.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series1.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.series1.Pointer.Dark3D = false;
            this.series1.Pointer.Draw3D = false;
            this.series1.Pointer.HorizSize = 2;
            // 
            // 
            // 
            this.series1.Pointer.Pen.Visible = false;
            this.series1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.DownTriangle;
            this.series1.Pointer.VertSize = 2;
            this.series1.Pointer.Visible = true;
            this.series1.Title = "Original data";
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
            this.series2.Brush.Color = System.Drawing.Color.RoyalBlue;
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
            // 
            // 
            // 
            // 
            // 
            // 
            this.series2.Pointer.Brush.Color = System.Drawing.Color.RoyalBlue;
            this.series2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.series2.Title = "Fitted polynomial";
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
            // series3
            // 
            // 
            // 
            // 
            this.series3.Brush.Color = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.series3.LinePen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.series3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.series3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.series3.Marks.Callout.Distance = 0;
            this.series3.Marks.Callout.Draw3D = false;
            this.series3.Marks.Callout.Length = 10;
            this.series3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series3.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series3.Pointer.Brush.Color = System.Drawing.Color.Black;
            this.series3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.series3.Title = "YCalc + Delta";
            // 
            // 
            // 
            this.series3.XValues.DataMember = "X";
            this.series3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.series3.YValues.DataMember = "Y";
            // 
            // series4
            // 
            // 
            // 
            // 
            this.series4.Brush.Color = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.series4.LinePen.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.series4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.series4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.series4.Marks.Callout.Distance = 0;
            this.series4.Marks.Callout.Draw3D = false;
            this.series4.Marks.Callout.Length = 10;
            this.series4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series4.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.series4.Pointer.Brush.Color = System.Drawing.Color.Black;
            this.series4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.series4.Title = "YCalc - Delta";
            // 
            // 
            // 
            this.series4.XValues.DataMember = "X";
            this.series4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.series4.YValues.DataMember = "Y";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Polynomial order";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(46, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Factor";
            // 
            // labelTimeNeeded
            // 
            this.labelTimeNeeded.Location = new System.Drawing.Point(160, 8);
            this.labelTimeNeeded.Name = "labelTimeNeeded";
            this.labelTimeNeeded.Size = new System.Drawing.Size(200, 16);
            this.labelTimeNeeded.TabIndex = 5;
            this.labelTimeNeeded.Text = "Time needed :";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(192, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Fit";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(264, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "View coefficients";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(376, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Delta";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(105, 30);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(105, 56);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 11;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // QRPolyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 437);
            this.Name = "QRPolyForm";
            this.Load += new System.EventHandler(this.QRPoly_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private int polyOrder =6;
        private int factor = 5;
		private Vector  x,y,coeff, delta;
		private Matrix r;
		private Vector intX,intY;
		private double L2R;
		private int degF;


		private void QRPoly_Load(object sender, System.EventArgs e) {
			Add("Fitting a polynomial of high degree is a peace of "
				+ "cake. MtxVec offers you the ability to create "
				+ "Vandermonde matrix and then use it to find the desired "
				+ "polynomial coefficients via the LQR decomposition. ");

			x.Size(100);
			y.Size(x);
			Random rnd = new Random();
			double tmp = rnd.Next(100);
			x.Ramp();
			for (int i=0;i<y.Length;i++) {
				tmp += rnd.Next(100) - 50;
				y.Values[i] = tmp;
			}
            TeeChart.DrawValues(y, series1, 0, 1, false);
		}

		private void button1_Click(object sender, System.EventArgs e) {
			int timeCheck = Environment.TickCount;
			this.Cursor = Cursors.WaitCursor;
			try {
				Polynoms.PolyFit(x,y,polyOrder,coeff,r,out degF,out L2R, null);
				intX.Size(x.Length * factor);
                intX.Ramp(0, 1.0 / (double)factor);
				Polynoms.PolyEval(intX, coeff, r, degF, L2R, intY, delta);
				int timeElapsed = Environment.TickCount - timeCheck;
				labelTimeNeeded.Text = "Time needed : " + timeElapsed.ToString() + " ms";
                TeeChart.DrawValues(intY, series2, 0, 1.0 / (double)factor, DownSize);
				intY.Sub(delta);
                TeeChart.DrawValues(intY, series4, 0, 1.0 / (double)factor, DownSize);
				intY.AddScaled(delta, 2);
                TeeChart.DrawValues(intY, series3, 0, 1.0 / (double)factor, DownSize);
				
                button2.Enabled = true;
				button3.Enabled = true;
			} finally {
				this.Cursor = Cursors.Default;
			}
		}

		private void checkBoxDownsample_CheckedChanged(object sender, System.EventArgs e) {
			button2.Enabled = button3.Enabled = false;
		}

		private void button2_Click(object sender, System.EventArgs e) {
			MtxVecEdit.ViewValues(coeff, "Coefficients",true,false,false);
		}

		private void button3_Click(object sender, System.EventArgs e) {
			MtxVecEdit.ViewValues(delta, "Delta",true,false,false);
		}

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            polyOrder = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            factor = (int)numericUpDown2.Value;
        }
	}
}

