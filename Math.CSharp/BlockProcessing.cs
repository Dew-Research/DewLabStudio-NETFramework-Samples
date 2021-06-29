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
   
    public class BlockProcessingForm : MtxVecDemo.BasicForm1
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
        private CheckBox GCBox;
        private bool GCTest = false;


		public BlockProcessingForm()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlockProcessingForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.line2 = new Steema.TeeChart.Styles.Line();
            this.line3 = new Steema.TeeChart.Styles.Line();
            this.line4 = new Steema.TeeChart.Styles.Line();
            this.GCBox = new System.Windows.Forms.CheckBox();
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
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.GCBox);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Size = new System.Drawing.Size(688, 40);
            this.panel2.Controls.SetChildIndex(this.button1, 0);
            this.panel2.Controls.SetChildIndex(this.GCBox, 0);
            this.panel2.Controls.SetChildIndex(this.label1, 0);
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
        "Block vectorization"};
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
            this.tChart1.Click += new System.EventHandler(this.tChart1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(136, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run test";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(224, 8);
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
            this.line2.Title = "Vectorized";
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
            this.line3.Title = "Block vectorized";
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
            this.line4.Title = "Expression";
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
            // GCBox
            // 
            this.GCBox.AutoSize = true;
            this.GCBox.Location = new System.Drawing.Point(413, 11);
            this.GCBox.Name = "GCBox";
            this.GCBox.Size = new System.Drawing.Size(130, 17);
            this.GCBox.TabIndex = 3;
            this.GCBox.Text = "Garbage collector test";
            this.GCBox.UseVisualStyleBackColor = true;
            this.GCBox.CheckedChanged += new System.EventHandler(this.GCBox_CheckedChanged);
            // 
            // BlockProcessingForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 485);
            this.Name = "BlockProcessingForm";
            this.Load += new System.EventHandler(this.BlockProcessingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void BlockProcessingForm_Load(object sender, System.EventArgs e) 
		{
			Add("Block processing enables you to adapt the length "
				+ "of the memory being accessed by your algorithm to "
				+ "approximately match the size of the CPU cache. If "
				+ "the memory at the same memory location is accessed "
				+ "more than once, the second access will about 3-6 "
				+ "times faster. The trick is to break long vectors "
				+ "down in to a series of short ones and process each "
				+ "block separately, thus always holding the entire memory "
				+ "block in the CPU cache and radically reducing the number"
				+ "of CPU cache misses. Block processing is demonstrated by "
				+ "timing three versions of the same function. The function "
				+ "being benchmarked is Maxwell PDF.");
			Add("");
			Add("Block length (size of the sub vector) is automatically set "
				+ "by MtxVec to match the CPU cache size and so is the number "
				+ "iterations required to process the entire vector length.");		
		}

		private double MaxwellFunction(int Iterations) 
		{
			double a = 1;
            double[] testArray;
            Math387.StartTimer();
            if (Iterations == 0) throw new Exception("Iterations == 0");
			for (int i=0;i<Iterations;i++) 
			{
				for (int j=0;j<x.Length; j++) resArray[j] = MaxwellPdf3(xArray[j],a);

                //because xArray is not pinned, we should see degradation in performance
                if (GCTest)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        testArray = new double[resArray.Length];
                        testArray[k] = resArray[1];
                    }
                }
			}
			double result = Math387.StopTimer()*1000;
            res.CopyFromArray(resArray);
            return result;
		}

        public double MaxwellPdf3(double x, double a) 
        { 
	        double xx;

	        xx = x*x;
	        return  Math.Sqrt(4*a*Math387.INVTWOPI)*a*xx*Math.Exp(-0.5*a*xx);
          }

private void MaxwellPdf2(TVec X, double a, TVec Res)
{
    TVec res1;
    MtxVec.CreateIt(out res1);
    try
    {
        Res.Size(X);
        X.BlockInit();
        res.BlockInit();
        while (!X.BlockEnd)
        {
            tmp.Sqr(X);
            res.Copy(tmp);
            res.Mul(-0.5 * a);
            res.Exp();
            res.Mul(tmp);
            res.Mul(Math.Sqrt(4 * a * Math387.INVTWOPI) * a);
            res.BlockNext();
            X.BlockNext();
        }
    }
    finally
    {
        MtxVec.FreeIt(ref res1);
    }
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
            Math387.StartTimer();
			for (int i=0;i<Iterations;i++) {
				tmp.Sqr(x);              
                res.Mul(tmp,-0.5*a);
                res.Exp();
                res.Mul(tmp);
                res.Mul(Math.Sqrt(4*Math387.INVTWOPI*a)*a);

          //xArray is not pinned, we should still not see degradation in performance
                if (GCTest)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        testArray = new double[res.Length];
                        testArray[k] = resArray[1];
                    }
                }
			}
            return Math387.StopTimer()*1000;
		}

        private double MaxwellArray(int Iterations)
        {
            double a = 1;
            double xx;
            Math387.StartTimer();

            for (int j = 0; j < Iterations; j++)
            {
                for (int i = 0; i < xArray.Length; i++)
                {
                    xx = xArray[i] * xArray[i];
                    resArray[i] = Math.Sqrt(4 * a * Math387.INVTWOPI) * a * xx * Math.Exp(-0.5 * a * xx);
                }
            }
            return Math387.StopTimer();
        }


        public Vector MaxwellPDFx(Vector x, Vector a)
        {
            Vector xx = x * x;
            Vector res = MtxExpr.Sqrt(4 * Math387.INVTWOPI * a) * a * xx * MtxExpr.Exp(-0.5 * a * xx);
            return res;
        }

        private double MaxwellExpression(int Iterations)
        {
            double a = 1;
            Vector xx;
            Math387.StartTimer();
            for (int i = 0; i < Iterations; i++)
            {
				xx = x*x;
                res = Math.Sqrt(4 * Math387.INVTWOPI * a) * a *  xx * MtxExpr.Exp(-0.5 * a * xx);
            }
            return Math387.StopTimer()*1000;
        }

        private double MaxwellBlock(int Iterations) { 
			double a = 1;

            Math387.StartTimer();

			for (int i=0;i<Iterations;i++) {
				res.BlockInit();
				x.BlockInit();
				while (!x.BlockEnd) {
					tmp.Sqr(x);
					res.Mul(tmp,-0.5*a);
					res.Exp();
					res.Mul(tmp);
					res.Mul(Math.Sqrt(4*Math387.INVTWOPI)*a);
					res.BlockNext();
					x.BlockNext();
				}
			}
			return Math387.StopTimer()*1000;

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
                int InitialIters = 200000/(InitialSize/10);
				int iters = InitialIters;
                int Range = 17;
				double[] a1 = new double[Range];
				double[] a2 = new double[Range];
				double[] a3 = new double[Range];
                double[] a4 = new double[Range];
                for (int i = 0; i < Range; i++)
                { 
                    for (int j = 0; j < x.Length; j++) refRes.Values[j] = Probabilities.MaxwellPDF(xArray[j], 1);
                    res.SetZero();
                    a1[i] = MaxwellFunction(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.2) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

                    System.GC.Collect();
                    //System.Threading.Thread.Sleep(200); //allow GC to catch up

                    res.SetZero();
                    a2[i] = MaxwellNoBlock(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.4) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

                    System.GC.Collect();
                    //System.Threading.Thread.Sleep(200); //allow GC to catch up

                    res.SetZero();
                    a3[i] = MaxwellBlock(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.6) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");
                    Refresh();

                    //System.Threading.Thread.Sleep(200); //allow GC to catch up
                    System.GC.Collect();

                    res.SetZero();
                    a4[i] = MaxwellExpression(iters);
                    label1.Text = "Progress : " + ((int)(((double)i + 0.8) / Range * 100)).ToString() + " %";
                    if (!(refRes.IsEqual(res, 1E-10, TCompare.cmpAbsolute))) throw new Exception("Not equal!");

                    //System.Threading.Thread.Sleep(200); //allow GC to catch up
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
//                    if (a4[i] == 0) tChart1.Series[3].Add();
                    //else 
                    tChart1.Series[3].Add(a4[i], (10 * Math.Pow(IterStep, i)).ToString());
                }
				tChart1.Axes.Left.SetMinMax(0,1.1*Math.Max(Math.Max(Math.Max(FindMax(a1),FindMax(a2)),FindMax(a3)),FindMax(a4)));
			} finally {
				this.Cursor = Cursors.Default;
			}
		}

        private void tChart1_Click(object sender, EventArgs e)
        {

        }

        private void GCBox_CheckedChanged(object sender, EventArgs e)
        {
            GCTest = GCBox.Checked;
        }
    }
}

