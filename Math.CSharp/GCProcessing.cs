using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using System.Runtime.InteropServices;

namespace MtxVecDemo
{
   
    public class GCProcessingForm : MtxVecDemo.BasicForm1
	{
		private System.ComponentModel.IContainer components = null;
		private Vector x,res,tmp, refRes;
		private double [] xArray, resArray;
		private System.Windows.Forms.Button button1;
		private Steema.TeeChart.Styles.Line line1;
		private Steema.TeeChart.Styles.Line line2;
		private Steema.TeeChart.Styles.Line line3;
        private Steema.TeeChart.Styles.Line line4;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private Dew.Math.Controls.FloatEdit GCLoadEdit;
        private int GCIterCount = 1;


		public GCProcessingForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            x = new Vector(0);
            res = new Vector(0);
            tmp = new Vector(0);
            refRes = new Vector(0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCProcessingForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.line2 = new Steema.TeeChart.Styles.Line();
            this.line3 = new Steema.TeeChart.Styles.Line();
            this.line4 = new Steema.TeeChart.Styles.Line();
            this.GCLoadEdit = new Dew.Math.Controls.FloatEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(688, 100);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.GCLoadEdit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Size = new System.Drawing.Size(688, 40);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
            this.panel2.Controls.SetChildIndex(this.GCLoadEdit, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.button1, 0);
            this.panel2.Controls.SetChildIndex(this.checkBoxDownsample, 0);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(688, 100);
            // 
            // checkBoxDownsample
            // 
            this.checkBoxDownsample.Visible = false;
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
            this.tChart1.Axes.Bottom.Title.Caption = "Vector length";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Title.Lines = new string[] {
        "Vector length"};
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
            this.tChart1.Axes.Left.Title.Caption = "Time [ms]";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "Time [ms]"};
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
        "Impact of memory allocation on performance"};
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
            this.tChart1.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
            this.tChart1.Legend.TextStyle = Steema.TeeChart.LegendTextStyles.Value;
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
            this.tChart1.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.line1);
            this.tChart1.Series.Add(this.line2);
            this.tChart1.Series.Add(this.line3);
            this.tChart1.Series.Add(this.line4);
            this.tChart1.Size = new System.Drawing.Size(688, 345);
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
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(260, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run test";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(341, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Progress : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.line1.Pointer.Dark3D = false;
            this.line1.Pointer.Draw3D = false;
            this.line1.Pointer.HorizSize = 3;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Triangle;
            this.line1.Pointer.VertSize = 3;
            this.line1.Pointer.Visible = true;
            this.line1.Title = "Plain function";
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
            this.line2.Brush.Color = System.Drawing.Color.RoyalBlue;
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
            this.line2.Pointer.Brush.Color = System.Drawing.Color.RoyalBlue;
            this.line2.Pointer.Dark3D = false;
            this.line2.Pointer.Draw3D = false;
            this.line2.Pointer.HorizSize = 3;
            this.line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.DownTriangle;
            this.line2.Pointer.VertSize = 3;
            this.line2.Pointer.Visible = true;
            this.line2.Title = "Plain function with GC";
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
            this.line3.Brush.Color = System.Drawing.Color.Magenta;
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
            this.line3.Pointer.Brush.Color = System.Drawing.Color.Magenta;
            this.line3.Pointer.Dark3D = false;
            this.line3.Pointer.Draw3D = false;
            this.line3.Pointer.HorizSize = 3;
            this.line3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Diamond;
            this.line3.Pointer.VertSize = 3;
            this.line3.Pointer.Visible = true;
            this.line3.Title = "Vectorized";
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
            // line4
            // 
            // 
            // 
            // 
            this.line4.Brush.Color = System.Drawing.Color.Green;
            // 
            // 
            // 
            this.line4.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line4.Marks.Callout.Distance = 0;
            this.line4.Marks.Callout.Draw3D = false;
            this.line4.Marks.Callout.Length = 10;
            this.line4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line4.Marks.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line4.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.line4.Pointer.HorizSize = 2;
            this.line4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line4.Pointer.VertSize = 2;
            this.line4.Pointer.Visible = true;
            this.line4.Title = "Vectorized with GC";
            // 
            // 
            // 
            this.line4.XValues.DataMember = "X";
            this.line4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line4.YValues.DataMember = "Y";
            // 
            // GCLoadEdit
            // 
            this.GCLoadEdit.Increment = "1";
            this.GCLoadEdit.IntegerIncrement = true;
            this.GCLoadEdit.Location = new System.Drawing.Point(179, 11);
            this.GCLoadEdit.MaxValue = "40";
            this.GCLoadEdit.Name = "GCLoadEdit";
            this.GCLoadEdit.ReFormat = "0.00#;-0.00#";
            this.GCLoadEdit.Size = new System.Drawing.Size(75, 20);
            this.GCLoadEdit.StoreInRegistry = false;
            this.GCLoadEdit.TabIndex = 3;
            this.GCLoadEdit.Text = "5";
            this.GCLoadEdit.Value = "5";
            this.GCLoadEdit.TextChanged += new System.EventHandler(this.GCLoadEdit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "GC Load:";
            // 
            // GCProcessingForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 485);
            this.Name = "GCProcessingForm";
            this.Load += new System.EventHandler(this.BlockProcessingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void BlockProcessingForm_Load(object sender, System.EventArgs e) 
		{
            Add("Garbage collector in .NET allows the programmer to "
                + "write code faster. However this also comes at a cost "
                + "and this benchmarks allows us to evaluate this cost. "
                + "Inside each timed loop is a computation part and  "
                + "memory allocation part. Both parts are independent "
                + "of each other. The size of the memory allocated by the GC is a multiple "
                + "of the memory required to store the result of the computational part. "
                + "The GC Load edit box, allows you to specify "
                + "that factor and thus the amount of memory allocated by "
                + "the GC during one iteration of the loop.");                
			Add("");
			Add("With GC Load 5, the vectorized math is slowed down by 2-3x. "                
                + "By allocating memory with GC, an existing algorithm which is otherwise "
                + "very fast, can be slowed down dramatically. Note that alrady slow code is not affected by much." 
                + "Therefore allocate only minimum or "
                + "no memory within performance sensitive loops, or use Mtxvec.CreateIt/FreeIt.");
		}

        public double MaxwellPdf3(double x, double a)
        {
            double xx;

            xx = x * x;
            return Math.Sqrt(4 * a * Math387.INVTWOPI) * a * xx * Math.Exp(-0.5 * a * xx);
        }

		private double MaxwellFunction(int Iterations) 
		{
			double a = 1;
            double[] testArray;
            double result;
            Math387.StartTimer(); 
            if (Iterations == 0) throw new Exception("Iterations == 0");
			for (int i=0;i<Iterations;i++) 
			{
				for (int j=0;j<x.Length; j++) resArray[j] = MaxwellPdf3(xArray[j],a);

                for (int k = 0; k < GCIterCount; k++)
                {
                    testArray = new double[resArray.Length];
                    testArray[2] = resArray[1];
                }
			}
            result = Math387.StopTimer()*1000; 
            res.CopyFromArray(resArray);
            return result;
		}

        private void MaxwellPdf1(TVec X, double a, TVec Res)
        {
            TVec res1;
            MtxVec.CreateIt(out res1);
            try
            {
                res1.Sqr(X);
                res.Mul(res1, -0.5 * a);
                res.Exp();
                res.Mul(res1);
                res.Mul(Math.Sqrt(4 * Math387.INVTWOPI * a) * a);
            }
            finally
            {
                MtxVec.FreeIt(ref res1);
            }
        }

        private double MaxwellNoBlock(int Iterations) { 
	        double a = 1;
            double[] testArray;
            res.Size(x);
            Math387.StartTimer(); 
	        for (int i=0;i<Iterations;i++) {

                MaxwellPdf1(x, a, res);
          
                for (int k = 0; k < GCIterCount; k++) //GC Loop
                 {
                     testArray = new double[res.Length];
                     testArray[1] = resArray[1];
                     //res.SetZero();
                 }
	        }
	        return Math387.StopTimer()*1000; //convert o ms
        }

		private double FindMax(double[] a) {
			double result = Math387.MINNUM;
			foreach(double val in a) {
				if (val > result) result = val;
			}
			return result;
		}

		private void button1_Click(object sender, System.EventArgs e) {

			this.Cursor = Cursors.WaitCursor;
			try {
                int InitialSize = 10;
				x.Size(InitialSize,false); 
				x.SetVal(2);
				res.Size(x);
                refRes.Size(x);
				x.CopyToArray(ref xArray);
				res.SizeToArray(ref resArray); 
                int IterStep = 2;
                int InitialIters = 300000/(InitialSize/10);
				int iters = InitialIters;
                int Range = 19;
				double[] a1 = new double[Range];
				double[] a2 = new double[Range];
				double[] a3 = new double[Range];
                double[] a4 = new double[Range];
                for (int i = 0; i < Range; i++)
                { 
                    for (int j = 0; j < x.Length; j++) refRes.Values[j] = Probabilities.MaxwellPDF(xArray[j], 1);
                    res.SetZero();
                    GCIterCount = 0;
                    a1[i] = MaxwellFunction(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.2) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

//                    System.Threading.Thread.Sleep(100); //allow GC to catch up
                    System.GC.Collect();

                    res.SetZero();
                    GCIterCount = GCLoadEdit.IntPosition;
                    a2[i] = MaxwellFunction(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.4) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

//                    System.Threading.Thread.Sleep(100); //allow GC to catch up
                    System.GC.Collect();

                    res.SetZero();
                    GCIterCount = 0;
                    a3[i] = MaxwellNoBlock(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.6) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

//                    System.Threading.Thread.Sleep(100); //allow GC to catch up
                    System.GC.Collect();

                    res.SetZero();
                    GCIterCount = GCLoadEdit.IntPosition;                       
                    a4[i] = MaxwellNoBlock(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.8) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");

//                    System.Threading.Thread.Sleep(200); //allow GC to catch up
                    System.GC.Collect();

                    Refresh();  
                    iters /= IterStep;
                    x.Length *= IterStep;
                    res.Size(x);
                    x.SetVal(2);
                    x.CopyToArray(ref xArray);                    
                    res.SizeToArray(ref resArray);
                    refRes.Size(x);
                }
				label1.Text = "Progress : 100 %";
				tChart1.Axes.Left.Automatic = false;
				foreach (Steema.TeeChart.Styles.Series s in tChart1.Series) s.Clear();
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] == 0) tChart1.Series[0].Add();
                    else tChart1.Series[0].Add(a1[i], (10 * Math.Pow(IterStep, i)).ToString());
                }
                for (int i = 0; i < a2.Length; i++)
                {
                    if (a2[i] == 0) tChart1.Series[1].Add();
                    else tChart1.Series[1].Add(a2[i], (10 * Math.Pow(IterStep, i)).ToString());
                }
                for (int i = 0; i < a3.Length; i++)
                {
                    if (a3[i] == 0) tChart1.Series[2].Add();
                    else tChart1.Series[2].Add(a3[i], (10 * Math.Pow(IterStep, i)).ToString());
                }                
                for (int i = 0; i < a4.Length; i++)
                {
                    if (a4[i] == 0) tChart1.Series[3].Add();
                    else tChart1.Series[3].Add(a4[i], (10 * Math.Pow(IterStep, i)).ToString());
                }
				tChart1.Axes.Left.SetMinMax(0,1.1*Math.Max(Math.Max(Math.Max(FindMax(a1),FindMax(a2)),FindMax(a3)),FindMax(a4)));
			} finally {
				this.Cursor = Cursors.Default;
			}
		}      

        private void GCLoadEdit_TextChanged(object sender, EventArgs e)
        {
            GCIterCount = GCLoadEdit.IntPosition;
        }
    }
}

