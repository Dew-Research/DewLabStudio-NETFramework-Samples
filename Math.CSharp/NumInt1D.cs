using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;

namespace MtxVecDemo
{
    public class NumInt1D : MtxVecDemo.BasicForm1
    {

        private TMtxExpression parser;
		private TRealFunction intfunctiondelegate;

        private bool ExtractFormula(string formula, out string varName)
        {
            TStringList list = new TStringList();
            varName = null;
            parser.ClearAll();
            parser.Expressions = formula;
            // Get a list of all variables, use only first variable
            parser.GetVarList(list);parser.GetVarList(list);
            bool result = (list.Count == 1);
            if (result)
            {
                parser.DefineDouble(list[0]);
                varName = list[0];
            }
            return result;
        }


        // A bit tricky, but ObjConsts hold all necessary objects, strings, etc..
        // needed for calculation of f(x)
        // obj[0] = TMtxExpression
        // obj[1] = x name
        // pars[0] = x value

        private double IntObjFun(TVec Parameters, TVec Constants, params object[] ObjConst)
        {
            TMtxExpression expr = (ObjConst[0] as TMtxExpression);
            string parname = ObjConst[1].ToString();
            expr.VarByName[parname].DoubleValue = Parameters.Values[0];            
            return expr.EvaluateDouble();
        }

        private void Evaluate()
        {
            Vector bp = new Vector(0);
            Vector w = new Vector(0);
            
            // Get function from edit text box
            string vname;
            if (ExtractFormula(textBox1.Text, out vname))
            {
                // Read bounds
                double lb = Math387.StrToSample(textBox2.Text);
                double ub = Math387.StrToSample(textBox3.Text);
                // Evaluate integral
                // Step 1 : calculate base points and weights
                int nquad = (int)numericUpDown1.Value;
                switch (comboBox1.SelectedIndex)
                {
                    case 0: MtxIntDiff.WeightsNewtonCotes(1, bp, w, bp.FloatPrecision); break;
                    case 1: MtxIntDiff.WeightsNewtonCotes(2, bp, w, bp.FloatPrecision); break;
                    case 2: MtxIntDiff.WeightsNewtonCotes(3, bp, w, bp.FloatPrecision); break;
                    case 3: MtxIntDiff.WeightsNewtonCotes(4, bp, w, bp.FloatPrecision); break;
                    case 4: MtxIntDiff.WeightsGauss(10, bp, w, bp.FloatPrecision); break;
                    case 5: MtxIntDiff.WeightsGauss(16, bp, w, bp.FloatPrecision); break;
                }
                int numpoints = Math.Max(100, nquad);
                double step = (ub - lb) / (double)numpoints;
                // plot function (100 points)
                double xv, yv;
                tChart1[0].Clear();
                for (int i = 0; i < numpoints; i++)
                {
                    xv = lb + i * step;
                    parser.VarByName[vname].DoubleValue = xv;
                    yv = parser.EvaluateDouble();
                    if (!Math387.IsNanInf(yv))
                        tChart1[0].Add(xv, yv);
                }

                // Step 2: evaluate integral
                double integral = MtxIntDiff.QuadGauss(intfunctiondelegate, lb, ub, null, new object[] { parser, vname }, bp, w, nquad);

                tChart1.Header.Text = "Integral of f(" + vname + ") from " + lb.ToString("0.00") + " to " + ub.ToString("0.00") + "\r\n" + integral.ToString();
                tChart1.Axes.Bottom.Title.Caption = vname;
                tChart1.Axes.Left.Title.Caption = "f(" + vname + ")";
            }
            else
            {
                MessageBox.Show("Use only one variable!");
                textBox1.Undo();
            }
        }

        public NumInt1D()
        {
            InitializeComponent();
            parser = new TMtxExpression();
			intfunctiondelegate = new TRealFunction(IntObjFun);
        }

        private Label label1;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Steema.TeeChart.Styles.Area area1;
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.area1 = new Steema.TeeChart.Styles.Area();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Name = "panel1";
			// 
			// panel2
			// 
			this.panel2.Name = "panel2";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Name = "richTextBox1";
			// 
			// checkBoxDownsample
			// 
			this.checkBoxDownsample.Name = "checkBoxDownsample";
			// 
			// tChart1
			// 
			this.tChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// tChart1.Aspect
			// 
			this.tChart1.Aspect.ElevationFloat = 345;
			this.tChart1.Aspect.RotationFloat = 345;
			this.tChart1.Aspect.View3D = false;
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
			// 
			// tChart1.Axes.Left.Title.Font
			// 
			// 
			// tChart1.Axes.Left.Title.Font.Shadow
			// 
			this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
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
			this.tChart1.Name = "tChart1";
			// 
			// tChart1.Panel
			// 
			// 
			// tChart1.Panel.Shadow
			// 
			this.tChart1.Panel.Shadow.Visible = false;
			this.tChart1.Series.Add(this.area1);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 117);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Function";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(67, 114);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(175, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "sin(x)/exp(-x)";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(16, 140);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 91);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bounds";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(51, 59);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(51, 26);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "-3";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Upper";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Lower";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 255);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Method";
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "Trapezoidal rule",
														   "Simpson rule",
														   "Simpson 3/8 rule",
														   "Boole\'s rule",
														   "10 point Gauss quadrature",
														   "16 point Gauss quadrature"});
			this.comboBox1.Location = new System.Drawing.Point(67, 252);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(175, 21);
			this.comboBox1.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 304);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "No. of subintervals";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(119, 302);
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 10,
																		 0,
																		 0,
																		 0});
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(21, 345);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(221, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Evaluate";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// area1
			// 
			// 
			// area1.AreaBrush
			// 
			this.area1.AreaBrush.Color = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			// 
			// area1.Gradient
			// 
			this.area1.AreaBrush.Gradient.Transparency = 50;
			// 
			// area1.AreaLines
			// 
			this.area1.AreaLines.Color = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(77)), ((System.Byte)(0)));
			// 
			// area1.Brush
			// 
			this.area1.Brush.Color = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0)));
			this.area1.Brush.ForegroundColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.area1.Brush.Visible = false;
			// 
			// area1.Gradient
			// 
			this.area1.Gradient.Transparency = 50;
			// 
			// area1.LinePen
			// 
			this.area1.LinePen.Color = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(77)), ((System.Byte)(0)));
			// 
			// area1.Marks
			// 
			// 
			// area1.Marks.Callout
			// 
			this.area1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
			this.area1.Marks.Callout.ArrowHeadSize = 8;
			// 
			// area1.Marks.Callout.Brush
			// 
			this.area1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
			this.area1.Marks.Callout.Distance = 0;
			this.area1.Marks.Callout.Draw3D = false;
			this.area1.Marks.Callout.Length = 10;
			this.area1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			// 
			// area1.Marks.Font
			// 
			// 
			// area1.Marks.Font.Shadow
			// 
			this.area1.Marks.Font.Shadow.Visible = false;
			// 
			// area1.Pointer
			// 
			// 
			// area1.Pointer.Brush
			// 
			this.area1.Pointer.Brush.Color = System.Drawing.Color.Red;
			this.area1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			this.area1.Title = "area1";
			// 
			// area1.XValues
			// 
			this.area1.XValues.DataMember = "X";
			this.area1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
			// 
			// area1.YValues
			// 
			this.area1.YValues.DataMember = "Y";
			// 
			// NumInt1D
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 437);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Name = "NumInt1D";
			this.Load += new System.EventHandler(this.NumInt1D_Load);
			this.Controls.SetChildIndex(this.comboBox1, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.numericUpDown1, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.textBox1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.panel2, 0);
			this.Controls.SetChildIndex(this.tChart1, 0);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}

        #endregion

        private void NumInt1D_Load(object sender, EventArgs e)
        {
            Add("You can use Gauss quadrature formula to evaluate single, double and "
                 + "n-dimensional integrals. This example demonstrates how to use numerical "
                 + "integration routines together with TMtxParser class to evaluate integral "
                 + "of f(x) on interval [a,b].\r\n");
            Add("1. Enter any function (using single variable) in \"Function\" edit box.");
            Add("2. Define integration lower and upper bounds.");
            Add("3. Select integration method.");
            Add("4. Press the \"Evaluate\" button.");

            comboBox1.SelectedIndex = 3; // Boole's rule
            Evaluate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Evaluate();
        }

    }
}

