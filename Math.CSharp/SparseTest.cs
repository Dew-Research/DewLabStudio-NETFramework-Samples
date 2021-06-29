using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;

namespace MtxVecDemo
{
	public class SparseTestForm : MtxVecDemo.BasicForm2
	{
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private Steema.TeeChart.TChart tChart1;
		private Steema.TeeChart.Styles.Bar series1;
		private System.ComponentModel.IContainer components = null;

		public SparseTestForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            sparseA = new TSparseMtx();
            a = new Matrix(0,0);
            b = new Vector(0);
			x1 = new Vector(0);
			x2 = new Vector(0);
			x3 = new Vector(0);
			x4 = new Vector(0);
			
            comboBox1.SelectedIndex = 0;
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
			this.panel4 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tChart1 = new Steema.TeeChart.TChart();
			this.series1 = new Steema.TeeChart.Styles.Bar();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tChart1);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(616, 365);
			// 
			// panel3
			// 
			this.panel3.Location = new System.Drawing.Point(0, 477);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(616, 48);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(616, 112);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.textBox1);
			this.panel4.Controls.Add(this.comboBox1);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.button1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 365);
			this.panel4.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.textBox1.Location = new System.Drawing.Point(8, 88);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(184, 272);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "prlNone",
														   "prlErrorsOnly",
														   "prlBasic",
														   "prlExtensive",
														   "prlComplete",
														   "prlAll"});
			this.comboBox1.Location = new System.Drawing.Point(8, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Solver report level";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Do tests";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tChart1
			// 
			// 
			// tChart1.Aspect
			// 
			this.tChart1.Aspect.ElevationFloat = 345;
			this.tChart1.Aspect.RotationFloat = 345;
			// 
			// tChart1.Axes
			// 
			// 
			// tChart1.Axes.Bottom
			// 
			this.tChart1.Axes.Bottom.Automatic = true;
			// 
			// tChart1.Axes.Bottom.Grid
			// 
			this.tChart1.Axes.Bottom.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.Bottom.Labels
			// 
			// 
			// tChart1.Axes.Bottom.Labels.Font
			// 
			// 
			// tChart1.Axes.Bottom.Labels.Font.Shadow
			// 
			this.tChart1.Axes.Bottom.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Bottom.Labels.Shadow
			// 
			this.tChart1.Axes.Bottom.Labels.Shadow.Visible = false;
			this.tChart1.Axes.Bottom.Labels.Visible = false;
			// 
			// tChart1.Axes.Bottom.Title
			// 
			// 
			// tChart1.Axes.Bottom.Title.Font
			// 
			// 
			// tChart1.Axes.Bottom.Title.Font.Shadow
			// 
			this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Bottom.Title.Shadow
			// 
			this.tChart1.Axes.Bottom.Title.Shadow.Visible = false;
			// 
			// tChart1.Axes.Depth
			// 
			this.tChart1.Axes.Depth.Automatic = true;
			// 
			// tChart1.Axes.Depth.Grid
			// 
			this.tChart1.Axes.Depth.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.Depth.Labels
			// 
			// 
			// tChart1.Axes.Depth.Labels.Font
			// 
			// 
			// tChart1.Axes.Depth.Labels.Font.Shadow
			// 
			this.tChart1.Axes.Depth.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Depth.Labels.Shadow
			// 
			this.tChart1.Axes.Depth.Labels.Shadow.Visible = false;
			// 
			// tChart1.Axes.Depth.Title
			// 
			// 
			// tChart1.Axes.Depth.Title.Font
			// 
			// 
			// tChart1.Axes.Depth.Title.Font.Shadow
			// 
			this.tChart1.Axes.Depth.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Depth.Title.Shadow
			// 
			this.tChart1.Axes.Depth.Title.Shadow.Visible = false;
			// 
			// tChart1.Axes.DepthTop
			// 
			this.tChart1.Axes.DepthTop.Automatic = true;
			// 
			// tChart1.Axes.DepthTop.Grid
			// 
			this.tChart1.Axes.DepthTop.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.DepthTop.Labels
			// 
			// 
			// tChart1.Axes.DepthTop.Labels.Font
			// 
			// 
			// tChart1.Axes.DepthTop.Labels.Font.Shadow
			// 
			this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.DepthTop.Labels.Shadow
			// 
			this.tChart1.Axes.DepthTop.Labels.Shadow.Visible = false;
			// 
			// tChart1.Axes.DepthTop.Title
			// 
			// 
			// tChart1.Axes.DepthTop.Title.Font
			// 
			// 
			// tChart1.Axes.DepthTop.Title.Font.Shadow
			// 
			this.tChart1.Axes.DepthTop.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.DepthTop.Title.Shadow
			// 
			this.tChart1.Axes.DepthTop.Title.Shadow.Visible = false;
			// 
			// tChart1.Axes.Left
			// 
			this.tChart1.Axes.Left.Automatic = true;
			// 
			// tChart1.Axes.Left.Grid
			// 
			this.tChart1.Axes.Left.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.Left.Labels
			// 
			// 
			// tChart1.Axes.Left.Labels.Font
			// 
			// 
			// tChart1.Axes.Left.Labels.Font.Shadow
			// 
			this.tChart1.Axes.Left.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Left.Labels.Shadow
			// 
			this.tChart1.Axes.Left.Labels.Shadow.Visible = false;
			// 
			// tChart1.Axes.Left.Title
			// 
			this.tChart1.Axes.Left.Title.Caption = "Time for 100 evaluations [ms]";
			// 
			// tChart1.Axes.Left.Title.Font
			// 
			// 
			// tChart1.Axes.Left.Title.Font.Shadow
			// 
			this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
			this.tChart1.Axes.Left.Title.Lines = new string[] {
																  "Time for 100 evaluations [ms]"};
			// 
			// tChart1.Axes.Left.Title.Shadow
			// 
			this.tChart1.Axes.Left.Title.Shadow.Visible = false;
			// 
			// tChart1.Axes.Right
			// 
			this.tChart1.Axes.Right.Automatic = true;
			// 
			// tChart1.Axes.Right.Grid
			// 
			this.tChart1.Axes.Right.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.Right.Labels
			// 
			// 
			// tChart1.Axes.Right.Labels.Font
			// 
			// 
			// tChart1.Axes.Right.Labels.Font.Shadow
			// 
			this.tChart1.Axes.Right.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Right.Labels.Shadow
			// 
			this.tChart1.Axes.Right.Labels.Shadow.Visible = false;
			// 
			// tChart1.Axes.Right.Title
			// 
			// 
			// tChart1.Axes.Right.Title.Font
			// 
			// 
			// tChart1.Axes.Right.Title.Font.Shadow
			// 
			this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Right.Title.Shadow
			// 
			this.tChart1.Axes.Right.Title.Shadow.Visible = false;
			// 
			// tChart1.Axes.Top
			// 
			this.tChart1.Axes.Top.Automatic = true;
			// 
			// tChart1.Axes.Top.Grid
			// 
			this.tChart1.Axes.Top.Grid.ZPosition = 0;
			// 
			// tChart1.Axes.Top.Labels
			// 
			// 
			// tChart1.Axes.Top.Labels.Font
			// 
			// 
			// tChart1.Axes.Top.Labels.Font.Shadow
			// 
			this.tChart1.Axes.Top.Labels.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Top.Labels.Shadow
			// 
			this.tChart1.Axes.Top.Labels.Shadow.Visible = false;
			// 
			// tChart1.Axes.Top.Title
			// 
			// 
			// tChart1.Axes.Top.Title.Font
			// 
			// 
			// tChart1.Axes.Top.Title.Font.Shadow
			// 
			this.tChart1.Axes.Top.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Axes.Top.Title.Shadow
			// 
			this.tChart1.Axes.Top.Title.Shadow.Visible = false;
			this.tChart1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// tChart1.Footer
			// 
			// 
			// tChart1.Footer.Font
			// 
			// 
			// tChart1.Footer.Font.Shadow
			// 
			this.tChart1.Footer.Font.Shadow.Visible = false;
			// 
			// tChart1.Footer.Shadow
			// 
			this.tChart1.Footer.Shadow.Visible = false;
			// 
			// tChart1.Header
			// 
			// 
			// tChart1.Header.Font
			// 
			// 
			// tChart1.Header.Font.Shadow
			// 
			this.tChart1.Header.Font.Shadow.Visible = false;
			this.tChart1.Header.Lines = new string[] {
														 "TeeChart"};
			// 
			// tChart1.Header.Shadow
			// 
			this.tChart1.Header.Shadow.Visible = false;
			this.tChart1.Header.Visible = false;
			// 
			// tChart1.Legend
			// 
			// 
			// tChart1.Legend.Font
			// 
			// 
			// tChart1.Legend.Font.Shadow
			// 
			this.tChart1.Legend.Font.Shadow.Visible = false;
			// 
			// tChart1.Legend.Title
			// 
			// 
			// tChart1.Legend.Title.Font
			// 
			this.tChart1.Legend.Title.Font.Bold = true;
			// 
			// tChart1.Legend.Title.Font.Shadow
			// 
			this.tChart1.Legend.Title.Font.Shadow.Visible = false;
			// 
			// tChart1.Legend.Title.Pen
			// 
			this.tChart1.Legend.Title.Pen.Visible = false;
			// 
			// tChart1.Legend.Title.Shadow
			// 
			this.tChart1.Legend.Title.Shadow.Visible = false;
			this.tChart1.Legend.Visible = false;
			this.tChart1.Location = new System.Drawing.Point(200, 0);
			this.tChart1.Name = "tChart1";
			// 
			// tChart1.Panel
			// 
			// 
			// tChart1.Panel.Shadow
			// 
			this.tChart1.Panel.Shadow.Visible = false;
			this.tChart1.Series.Add(this.series1);
			this.tChart1.Size = new System.Drawing.Size(416, 365);
			// 
			// tChart1.SubFooter
			// 
			// 
			// tChart1.SubFooter.Font
			// 
			// 
			// tChart1.SubFooter.Font.Shadow
			// 
			this.tChart1.SubFooter.Font.Shadow.Visible = false;
			// 
			// tChart1.SubFooter.Shadow
			// 
			this.tChart1.SubFooter.Shadow.Visible = false;
			// 
			// tChart1.SubHeader
			// 
			// 
			// tChart1.SubHeader.Font
			// 
			// 
			// tChart1.SubHeader.Font.Shadow
			// 
			this.tChart1.SubHeader.Font.Shadow.Visible = false;
			// 
			// tChart1.SubHeader.Shadow
			// 
			this.tChart1.SubHeader.Shadow.Visible = false;
			this.tChart1.TabIndex = 1;
			// 
			// tChart1.Walls
			// 
			// 
			// tChart1.Walls.Back
			// 
			this.tChart1.Walls.Back.AutoHide = false;
			// 
			// tChart1.Walls.Back.Shadow
			// 
			this.tChart1.Walls.Back.Shadow.Visible = false;
			// 
			// tChart1.Walls.Bottom
			// 
			this.tChart1.Walls.Bottom.AutoHide = false;
			// 
			// tChart1.Walls.Bottom.Shadow
			// 
			this.tChart1.Walls.Bottom.Shadow.Visible = false;
			// 
			// tChart1.Walls.Left
			// 
			this.tChart1.Walls.Left.AutoHide = false;
			// 
			// tChart1.Walls.Left.Shadow
			// 
			this.tChart1.Walls.Left.Shadow.Visible = false;
			// 
			// tChart1.Walls.Right
			// 
			this.tChart1.Walls.Right.AutoHide = false;
			// 
			// tChart1.Walls.Right.Shadow
			// 
			this.tChart1.Walls.Right.Shadow.Visible = false;
			// 
			// series1
			// 
			// 
			// series1.Brush
			// 
			this.series1.Brush.Color = System.Drawing.Color.Red;
			this.series1.ColorEach = true;
			// 
			// series1.Marks
			// 
			// 
			// series1.Marks.Callout
			// 
			this.series1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
			this.series1.Marks.Callout.ArrowHeadSize = 8;
			// 
			// series1.Marks.Callout.Brush
			// 
			this.series1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
			this.series1.Marks.Callout.Distance = 0;
			this.series1.Marks.Callout.Draw3D = false;
			this.series1.Marks.Callout.Length = 20;
			this.series1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			// 
			// series1.Marks.Font
			// 
			// 
			// series1.Marks.Font.Shadow
			// 
			this.series1.Marks.Font.Shadow.Visible = false;
			// 
			// series1.Pen
			// 
			this.series1.Pen.Color = System.Drawing.Color.FromArgb(((System.Byte)(77)), ((System.Byte)(77)), ((System.Byte)(77)));
			this.series1.Title = "bar1";
			// 
			// series1.XValues
			// 
			this.series1.XValues.DataMember = "X";
			this.series1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
			// 
			// series1.YValues
			// 
			this.series1.YValues.DataMember = "Bar";
			// 
			// SparseTestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 525);
			this.Name = "SparseTestForm";
			this.Load += new System.EventHandler(this.SparseTestForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		internal TSparseMtx sparseA;
		internal Matrix a;
		internal Vector b;
		internal Vector x1,x2,x3,x4;
		

		private void SparseTestForm_Load(object sender, System.EventArgs e) {
			Add("The system of 256 linear equations (sparse) sytstem is solved with four methods:");
			Add("");
			Add("1) TMtx.LUSolve method is used to solve the system of equations");
			Add("2) TSparseMtx.Solve direct method (umfpack) is used to solve the system of equations");
			Add("3) TSparseMtx.Solve direct method (pardiso) is used to solve the system of equations");
			Add("4) TSparseMtx iterative method is used to solve the system of equations");
			Add("");
			Add("The test's should be ran at least twice because the pardiso solver "+
				"has a long initialization period! Umfpack can optionally report also " +
				"statistics about the solver!");


			sparseA.AutoClearReport = true;
            sparseA.LoadFromMatrixMarketFile(Utils.SourcePath() + @".\Data\pde225.mtx");
			b.Size(sparseA.Rows);
			b.RandGauss();
			comboBox1_SelectedIndexChanged(null,null);
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e) {
			switch (comboBox1.SelectedIndex) {
				case 0 : sparseA.ReportLevel = TReportLevel.prlNone; break;
				case 1 : sparseA.ReportLevel = TReportLevel.prlErrorsOnly; break;
				case 2 : sparseA.ReportLevel = TReportLevel.prlBasic; break;
				case 3 : sparseA.ReportLevel = TReportLevel.prlExtensive; break;
				case 4 : sparseA.ReportLevel = TReportLevel.prlComplete; break;
				case 5 : sparseA.ReportLevel = TReportLevel.prlAll; break;
			}
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				series1.Clear();
				sparseA.SparseToDense(a,10000000);
				int timeCheck = Environment.TickCount;
                for (int i = 0; i < 100; i++)  a.LUSolve(b, x1, TMtxType.mtGeneral, TMtxOperation.opNone);                
				series1.Add(Environment.TickCount - timeCheck, "LUSolve",Color.Red);

				sparseA.SparseSolver = TSparseSolver.ssUmfPack;
				MtxVec.Report.Clear();
				timeCheck = Environment.TickCount;
				for (int i=0;i<100;i++) sparseA.Solve(b,x2,TMtxType.mtGeneral);
				series1.Add(Environment.TickCount - timeCheck, "UMFPack\nSolve",Color.Blue);
				textBox1.Text = MtxVec.Report.DataString;

                sparseA.SparseSolver = TSparseSolver.ssPardiso;
				timeCheck = Environment.TickCount;
				for (int i=0;i<100;i++)
                    sparseA.Solve(b, x3,TMtxType.mtGeneral);  

                series1.Add(Environment.TickCount - timeCheck, "Pardiso\nSolve",Color.Green);
                
				x4.Size(b);
				sparseA.SparseSolver = TSparseSolver.ssIterative;
                sparseA.IterativeMethod = TIterativeMethod.itmLUGMRES;
				timeCheck = Environment.TickCount;
				for (int i=0;i<100;i++) { 
					x4.Ramp();
					sparseA.Solve(b,x4,TMtxType.mtGeneral); 
				}
				series1.Add(Environment.TickCount - timeCheck, "Sparse\nIterativeSolve",Color.Yellow);
				String tmpStr = "";

				if (x1.Equal(x2,1.0e-3)) tmpStr += "LU Solve solution equal to UMFPack solve solution";
				else tmpStr += "LU Solve solution NOT equal to UMFPack solve solution";
				if (x1.Equal(x3,1.0e-3)) tmpStr += "\nLU Solve solution equal to Pardiso solve solution";
				else tmpStr += "\nLU Solve solution NOT equal to Pardiso solve solution";
				if (x1.Equal(x4,1.0e-3)) tmpStr += "\nLU Solve solution equal to iterative solve solution";
				else tmpStr += "\nLU Solve solution NOT equal to iterative solve solution";
				MessageBox.Show(tmpStr);
				this.Cursor = Cursors.Default;
			} finally {
				this.Cursor = Cursors.Default;
			}
		} 

	}
}

