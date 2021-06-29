using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;


namespace MtxVecDemo {
	public class Multiply1Form : MtxVecDemo.BasicForm2 {
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelDimension;
		private System.Windows.Forms.GroupBox groupBox1;
		private Steema.TeeChart.TChart tChart1;
		private System.Windows.Forms.RadioButton largeRadioButton;
		private System.Windows.Forms.RadioButton mediumRadioButton;
		private System.Windows.Forms.RadioButton smallRadioButton;
		private System.Windows.Forms.Button button1;
		private Steema.TeeChart.Styles.Line MtxLine;
		private Steema.TeeChart.Styles.Line NetLine;
		private System.ComponentModel.IContainer components = null;

        private Matrix a, b, c;
		private double[,] da,db,dc;
		private int mtxDim;
		private int factor = 1;

		public Multiply1Form() {
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            a = new Matrix(0, 0);
            b = new Matrix(0, 0);
            c = new Matrix(0, 0);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
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
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Multiply1Form));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDimension = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.largeRadioButton = new System.Windows.Forms.RadioButton();
            this.mediumRadioButton = new System.Windows.Forms.RadioButton();
            this.smallRadioButton = new System.Windows.Forms.RadioButton();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.NetLine = new Steema.TeeChart.Styles.Line();
            this.MtxLine = new Steema.TeeChart.Styles.Line();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tChart1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.labelDimension);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Size = new System.Drawing.Size(576, 341);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(0, 453);
            this.panel3.Size = new System.Drawing.Size(576, 48);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(576, 112);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(32, 32);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(136, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 50;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 60;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrix dimension";
            // 
            // labelDimension
            // 
            this.labelDimension.Location = new System.Drawing.Point(136, 16);
            this.labelDimension.Name = "labelDimension";
            this.labelDimension.Size = new System.Drawing.Size(32, 16);
            this.labelDimension.TabIndex = 2;
            this.labelDimension.Text = "60";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.largeRadioButton);
            this.groupBox1.Controls.Add(this.mediumRadioButton);
            this.groupBox1.Controls.Add(this.smallRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matrix size";
            // 
            // largeRadioButton
            // 
            this.largeRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.largeRadioButton.Location = new System.Drawing.Point(8, 64);
            this.largeRadioButton.Name = "largeRadioButton";
            this.largeRadioButton.Size = new System.Drawing.Size(168, 24);
            this.largeRadioButton.TabIndex = 2;
            this.largeRadioButton.Text = "Large matrix (eval. 1 x)";
            this.largeRadioButton.Click += new System.EventHandler(this.SizeRadioClicked);
            // 
            // mediumRadioButton
            // 
            this.mediumRadioButton.Checked = true;
            this.mediumRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mediumRadioButton.Location = new System.Drawing.Point(8, 40);
            this.mediumRadioButton.Name = "mediumRadioButton";
            this.mediumRadioButton.Size = new System.Drawing.Size(168, 24);
            this.mediumRadioButton.TabIndex = 1;
            this.mediumRadioButton.TabStop = true;
            this.mediumRadioButton.Text = "Medium matrix (eval. 100 x)";
            this.mediumRadioButton.Click += new System.EventHandler(this.SizeRadioClicked);
            // 
            // smallRadioButton
            // 
            this.smallRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.smallRadioButton.Location = new System.Drawing.Point(8, 16);
            this.smallRadioButton.Name = "smallRadioButton";
            this.smallRadioButton.Size = new System.Drawing.Size(168, 24);
            this.smallRadioButton.TabIndex = 0;
            this.smallRadioButton.Text = "Small matrix (eval. 1000 x)";
            this.smallRadioButton.Click += new System.EventHandler(this.SizeRadioClicked);
            // 
            // tChart1
            // 
            this.tChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tChart1.Aspect.ElevationFloat = 345D;
            this.tChart1.Aspect.RotationFloat = 345D;
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
            this.tChart1.Axes.Bottom.Grid.ZPosition = 0D;
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
            this.tChart1.Axes.Bottom.Title.Caption = "Dim";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Title.Lines = new string[] {
        "Dim"};
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
            this.tChart1.Axes.Depth.Grid.ZPosition = 0D;
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
            this.tChart1.Axes.DepthTop.Grid.ZPosition = 0D;
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
            this.tChart1.Axes.Left.Grid.ZPosition = 0D;
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
            this.tChart1.Axes.Left.Title.Caption = "time [ms]";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "time [ms]"};
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
            this.tChart1.Axes.Right.Grid.ZPosition = 0D;
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
            this.tChart1.Axes.Top.Grid.ZPosition = 0D;
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
            this.tChart1.Header.Lines = new string[0];
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
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
            this.tChart1.Location = new System.Drawing.Point(200, 8);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.NetLine);
            this.tChart1.Series.Add(this.MtxLine);
            this.tChart1.Size = new System.Drawing.Size(368, 280);
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
            this.tChart1.TabIndex = 4;
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
            // NetLine
            // 
            // 
            // 
            // 
            this.NetLine.Brush.Color = System.Drawing.Color.DarkOrange;
            this.NetLine.Dark3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.NetLine.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.NetLine.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.NetLine.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.NetLine.Marks.Callout.Distance = 0;
            this.NetLine.Marks.Callout.Draw3D = false;
            this.NetLine.Marks.Callout.Length = 10;
            this.NetLine.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.NetLine.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.NetLine.Pointer.Brush.Color = System.Drawing.Color.DarkOrange;
            this.NetLine.Pointer.Dark3D = false;
            this.NetLine.Pointer.Draw3D = false;
            this.NetLine.Pointer.HorizSize = 1;
            this.NetLine.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.DiagCross;
            this.NetLine.Pointer.VertSize = 1;
            this.NetLine.Pointer.Visible = true;
            this.NetLine.Title = ".NET";
            // 
            // 
            // 
            this.NetLine.XValues.DataMember = "X";
            this.NetLine.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.NetLine.YValues.DataMember = "Y";
            // 
            // MtxLine
            // 
            // 
            // 
            // 
            this.MtxLine.Brush.Color = System.Drawing.Color.RoyalBlue;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MtxLine.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MtxLine.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MtxLine.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MtxLine.Marks.Callout.Distance = 0;
            this.MtxLine.Marks.Callout.Draw3D = false;
            this.MtxLine.Marks.Callout.Length = 10;
            this.MtxLine.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MtxLine.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MtxLine.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MtxLine.Pointer.Dark3D = false;
            this.MtxLine.Pointer.Draw3D = false;
            this.MtxLine.Pointer.HorizSize = 2;
            this.MtxLine.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.DownTriangle;
            this.MtxLine.Pointer.VertSize = 2;
            this.MtxLine.Pointer.Visible = true;
            this.MtxLine.Title = "MtxVec";
            // 
            // 
            // 
            this.MtxLine.XValues.DataMember = "X";
            this.MtxLine.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MtxLine.YValues.DataMember = "Y";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(16, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Do comparison";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Multiply1Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(576, 501);
            this.Name = "Multiply1Form";
            this.Text = "Multiply1Form";
            this.Load += new System.EventHandler(this.Multiply1Form_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void trackBar1_ValueChanged(object sender, System.EventArgs e) {
			mtxDim = (sender as TrackBar).Value;
			labelDimension.Text = mtxDim.ToString();
		}


		private void SizeRadioClicked(object sender, System.EventArgs e) {
			if (smallRadioButton.Checked) trackBar1.Value = 25; else
				if (mediumRadioButton.Checked) trackBar1.Value = 60; else
				if (largeRadioButton.Checked) trackBar1.Value = 400; 
		}

		private void multiply(int dim) {
			for (int i=0;i<dim;i++) {
				for (int k=0;k<dim;k++) {
					double ac = da[i,k];
					for (int j=0;j<dim;j++) {
						dc[i,j]+=ac*db[k,j];
					}
				}
			}
		}

		private void generateData(int dim) {
			a.Size(dim,dim,false);
			b.Size(a);
			da = new double[dim,dim];
			db = new double[dim,dim];
			dc = new double[dim,dim];
			Random rnd = new Random();
			for (int i=0;i<dim;i++) {
				for (int j=0;j<dim;j++) {
					da[i,j] = rnd.Next(10);
					db[i,j] = rnd.Next(10);
					a.Values[i,j] = da[i,j];
					b.Values[i,j] = db[i,j];
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				generateData(mtxDim);          

				int i = 2;
				NetLine.Clear();
				MtxLine.Clear();
				do {
					int aDim = i;
					generateData(aDim);
                    Math387.StartTimer();
					if (mtxDim <= 30) {
						for (int j=0;j<=99*factor*4;j++) multiply(aDim);
					} else if (mtxDim <=60) {
						for (int j=0;j<=9*factor;j++) multiply(aDim);
					} else multiply(aDim);
					NetLine.Add(i, Math387.StopTimer()*1000);

                    Math387.StartTimer();
                    if (mtxDim <= 30) {
                           for (int j=0;j<=99*factor*4;j++) c.Mul(a,b);
                    } else if (mtxDim <=60) {
                           for (int j = 0; j <= 9 * factor; j++) c.Mul(a, b);
                    }
                    else c.Mul(a, b);
                    MtxLine.Add(i, Math387.StopTimer()*1000);
                   
					if (i<50) i+=2; else i+=25;
				} while (i < mtxDim );
			} finally {
				this.Cursor = Cursors.Default;
			}
		}


		private void Multiply1Form_Load(object sender, System.EventArgs e) {
			trackBar1_ValueChanged(trackBar1,null);
			Add("Matrix multiplication performance gives you "
				+ "an impression of the performance of MtxVec. You "
				+ "will be able to experience these performance "
				+ "gains with all MtxVec packages, when dealing "
				+ "with vectors or matrices. If you have a multi-CPU "
				+ "machine you might even want to try enabling SMP "
				+ "(check the readme file for more info).");

		}
	}
}

