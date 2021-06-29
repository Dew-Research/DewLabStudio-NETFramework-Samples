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
	public class DirichletTestForm : MtxVecDemo.BasicForm2
	{
		private Steema.TeeChart.TChart tChart1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonRiemannZeta;
		private System.Windows.Forms.RadioButton radioButtonDirichletEta;
		private System.Windows.Forms.RadioButton radioButtonDirichletLambda;
		private System.Windows.Forms.RadioButton radioButtonDirichletBeta;
		private System.Windows.Forms.RadioButton radioButtonRe;
		private System.Windows.Forms.RadioButton radioButtonIm;
		private System.Windows.Forms.RadioButton radioButtonAbs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxXMin;
		private System.Windows.Forms.TextBox textBoxXMax;
		private System.Windows.Forms.TextBox textBoxYMax;
		private System.Windows.Forms.TextBox textBoxYMin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components = null;

		public DirichletTestForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            data = new Matrix(0, 0);
            tChart1.Series.Clear();
            tChart1.Series.Add(series = new MtxGridSeries());
            series.ColorPalette.MidColor = Color.Green;
            series.ColorPalette.Rainbow.BottomToMid = true;
            series.ColorPalette.Rainbow.MiddleColor = BaseColor.bcRed;
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
            this.tChart1 = new Steema.TeeChart.TChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDirichletBeta = new System.Windows.Forms.RadioButton();
            this.radioButtonDirichletLambda = new System.Windows.Forms.RadioButton();
            this.radioButtonDirichletEta = new System.Windows.Forms.RadioButton();
            this.radioButtonRiemannZeta = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonAbs = new System.Windows.Forms.RadioButton();
            this.radioButtonIm = new System.Windows.Forms.RadioButton();
            this.radioButtonRe = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxXMin = new System.Windows.Forms.TextBox();
            this.textBoxXMax = new System.Windows.Forms.TextBox();
            this.textBoxYMax = new System.Windows.Forms.TextBox();
            this.textBoxYMin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBoxYMax);
            this.panel2.Controls.Add(this.textBoxYMin);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxXMax);
            this.panel2.Controls.Add(this.textBoxXMin);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tChart1);
            this.panel2.Size = new System.Drawing.Size(656, 341);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 453);
            this.panel3.Size = new System.Drawing.Size(656, 48);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(656, 112);
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
            this.tChart1.Location = new System.Drawing.Point(8, 8);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Size = new System.Drawing.Size(472, 336);
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
            this.tChart1.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonDirichletBeta);
            this.groupBox1.Controls.Add(this.radioButtonDirichletLambda);
            this.groupBox1.Controls.Add(this.radioButtonDirichletEta);
            this.groupBox1.Controls.Add(this.radioButtonRiemannZeta);
            this.groupBox1.Location = new System.Drawing.Point(504, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // radioButtonDirichletBeta
            // 
            this.radioButtonDirichletBeta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonDirichletBeta.Location = new System.Drawing.Point(8, 64);
            this.radioButtonDirichletBeta.Name = "radioButtonDirichletBeta";
            this.radioButtonDirichletBeta.Size = new System.Drawing.Size(104, 16);
            this.radioButtonDirichletBeta.TabIndex = 3;
            this.radioButtonDirichletBeta.Text = "Dirichlet Beta";
            this.radioButtonDirichletBeta.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // radioButtonDirichletLambda
            // 
            this.radioButtonDirichletLambda.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonDirichletLambda.Location = new System.Drawing.Point(8, 48);
            this.radioButtonDirichletLambda.Name = "radioButtonDirichletLambda";
            this.radioButtonDirichletLambda.Size = new System.Drawing.Size(112, 16);
            this.radioButtonDirichletLambda.TabIndex = 2;
            this.radioButtonDirichletLambda.Text = "Dirichlet Lambda";
            this.radioButtonDirichletLambda.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // radioButtonDirichletEta
            // 
            this.radioButtonDirichletEta.Checked = true;
            this.radioButtonDirichletEta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonDirichletEta.Location = new System.Drawing.Point(8, 32);
            this.radioButtonDirichletEta.Name = "radioButtonDirichletEta";
            this.radioButtonDirichletEta.Size = new System.Drawing.Size(104, 16);
            this.radioButtonDirichletEta.TabIndex = 1;
            this.radioButtonDirichletEta.TabStop = true;
            this.radioButtonDirichletEta.Text = "Dirichlet Eta";
            this.radioButtonDirichletEta.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // radioButtonRiemannZeta
            // 
            this.radioButtonRiemannZeta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonRiemannZeta.Location = new System.Drawing.Point(8, 16);
            this.radioButtonRiemannZeta.Name = "radioButtonRiemannZeta";
            this.radioButtonRiemannZeta.Size = new System.Drawing.Size(104, 16);
            this.radioButtonRiemannZeta.TabIndex = 0;
            this.radioButtonRiemannZeta.Text = "Riemann Zeta";
            this.radioButtonRiemannZeta.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonAbs);
            this.groupBox2.Controls.Add(this.radioButtonIm);
            this.groupBox2.Controls.Add(this.radioButtonRe);
            this.groupBox2.Location = new System.Drawing.Point(504, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Draw";
            // 
            // radioButtonAbs
            // 
            this.radioButtonAbs.Checked = true;
            this.radioButtonAbs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonAbs.Location = new System.Drawing.Point(8, 48);
            this.radioButtonAbs.Name = "radioButtonAbs";
            this.radioButtonAbs.Size = new System.Drawing.Size(120, 16);
            this.radioButtonAbs.TabIndex = 2;
            this.radioButtonAbs.TabStop = true;
            this.radioButtonAbs.Text = "Abs";
            this.radioButtonAbs.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // radioButtonIm
            // 
            this.radioButtonIm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonIm.Location = new System.Drawing.Point(8, 32);
            this.radioButtonIm.Name = "radioButtonIm";
            this.radioButtonIm.Size = new System.Drawing.Size(120, 16);
            this.radioButtonIm.TabIndex = 1;
            this.radioButtonIm.Text = "Im";
            this.radioButtonIm.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // radioButtonRe
            // 
            this.radioButtonRe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonRe.Location = new System.Drawing.Point(8, 16);
            this.radioButtonRe.Name = "radioButtonRe";
            this.radioButtonRe.Size = new System.Drawing.Size(120, 16);
            this.radioButtonRe.TabIndex = 0;
            this.radioButtonRe.Text = "Re";
            this.radioButtonRe.CheckedChanged += new System.EventHandler(this.radioButtonDirichletLambda_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(504, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "X Range :";
            // 
            // textBoxXMin
            // 
            this.textBoxXMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXMin.Location = new System.Drawing.Point(504, 216);
            this.textBoxXMin.Name = "textBoxXMin";
            this.textBoxXMin.Size = new System.Drawing.Size(64, 20);
            this.textBoxXMin.TabIndex = 4;
            this.textBoxXMin.Text = "-2";
            // 
            // textBoxXMax
            // 
            this.textBoxXMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXMax.Location = new System.Drawing.Point(568, 216);
            this.textBoxXMax.Name = "textBoxXMax";
            this.textBoxXMax.Size = new System.Drawing.Size(64, 20);
            this.textBoxXMax.TabIndex = 5;
            this.textBoxXMax.Text = "2";
            // 
            // textBoxYMax
            // 
            this.textBoxYMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYMax.Location = new System.Drawing.Point(568, 264);
            this.textBoxYMax.Name = "textBoxYMax";
            this.textBoxYMax.Size = new System.Drawing.Size(64, 20);
            this.textBoxYMax.TabIndex = 8;
            this.textBoxYMax.Text = "2";
            // 
            // textBoxYMin
            // 
            this.textBoxYMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYMin.Location = new System.Drawing.Point(504, 264);
            this.textBoxYMin.Name = "textBoxYMin";
            this.textBoxYMin.Size = new System.Drawing.Size(64, 20);
            this.textBoxYMin.TabIndex = 7;
            this.textBoxYMin.Text = "-4";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(504, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y Range :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(520, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "Recreate";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DirichletTestForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 501);
            this.Name = "DirichletTestForm";
            this.Load += new System.EventHandler(this.DirichletTestForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


        private Matrix data;
        private MtxGridSeries series;
		private double xmin, xmax, ymin, ymax;
		private double xstep, ystep;

		private void Generate() {
			this.Cursor = Cursors.WaitCursor;
			try {
				xmin = Double.Parse(textBoxXMin.Text);
				xmax = Double.Parse(textBoxXMax.Text);
				ymin = Double.Parse(textBoxYMin.Text);
				ymax = Double.Parse(textBoxYMax.Text);
				xstep = (xmax-xmin)*0.02;
				ystep = (ymax-ymin)*0.02;
                // re = x axis - matrix columns
                // im = y axis - matrix rows
				data.Size(50,50,false);
                for (int y = 0; y < data.Rows; y++)
                    for (int x = 0; x < data.Cols; x++) 
                    {
						TCplx z, cVal;
						z.Re = xmin + x*xstep;
						z.Im = ymin + y*ystep;
						cVal.Re = 0;
						cVal.Im = 0;
						if (radioButtonRiemannZeta.Checked) cVal = Probabilities.RiemannZeta(z,1); 
						else if (radioButtonDirichletEta.Checked) cVal = Probabilities.DirichletEta(z,1);
						else if (radioButtonDirichletLambda.Checked) cVal = Probabilities.DirichletLambda(z,1);
						else if (radioButtonDirichletBeta.Checked) cVal = Probabilities.DirichletBeta(z);

						if (radioButtonRe.Checked) data.Values[y,x] = cVal.Re;
						else if (radioButtonIm.Checked) data.Values[y,x] = cVal.Im;
						else if (radioButtonAbs.Checked) data.Values[y,x] = Math387.CAbs(cVal);
					}
				series.XOffset = xmin;
				series.XStep = xstep;
				series.YOffset = ymin;
				series.YStep = ystep;
				series.GetVertAxis.Increment = (ymax-ymin)*0.01;
				series.GetHorizAxis.Increment = (xmax-xmin)*0.01;
                DrawValues(data, series);
			} finally {
				this.Cursor = Cursors.Default;
			}
		}

		private void DirichletTestForm_Load(object sender, System.EventArgs e) {
			Add("Several new special functions have been added to MtxVec "
				+ "Probabilities unit. MtxVec now supports Riemann Zeta, Dirichlet Eta "
				+ "and Dirichlet Lambda functions in complex plane.");

            Generate();
		}

		private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g) {
			g.Pen.Color = Color.Black;
			g.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dot;

			int pos = tChart1.Axes.Bottom.CalcPosValue(0.0) + 1;
			g.VerticalLine(pos,tChart1.Axes.Left.IStartPos,tChart1.Axes.Left.IEndPos);

			pos = tChart1.Axes.Left.CalcPosValue(0.0) + 1;
			g.HorizontalLine(tChart1.Axes.Bottom.IStartPos,tChart1.Axes.Bottom.IEndPos,pos);
		}

		private void button1_Click(object sender, System.EventArgs e) {

            TVec a;
            MtxVec.CreateIt(out a);
            double[] arr = new double[3];
            a.SetDouble(false,arr);

            MtxVec.FreeIt(ref a);

			Generate();
		}

        private void radioButtonDirichletLambda_CheckedChanged(object sender, EventArgs e)
        {
            Generate();
        }

	}
}

