using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Math.Tee;
using static Dew.Math.Tee.TeeChart;


namespace MtxVecDemo
{
    public class ParserVectorized : MtxVecDemo.BasicForm1
    {
        public ParserVectorized()
        {
            InitializeComponent();
            x = new Vector(0);
            y = new Vector(0);
            yResult = new TVec();

            expr = new TMtxExpression();
            Updatex();


        }

        private Vector x, y;
        private TVec yResult;
        private TMtxExpression expr;
        private TValueRec x1;

        private Steema.TeeChart.Styles.Line line1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Dew.Math.Controls.FloatEdit floatEditxStep;
        private Dew.Math.Controls.FloatEdit floatEditxEnd;
        private Dew.Math.Controls.FloatEdit floatEditxStart;
        private Label label4;
        private TextBox textBoxFormula;
        private Button buttonBenchmark;
        private Label labelResult;
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

        private void Updatex()
        {
            x.Length = (int)Math.Round(Math.Abs(floatEditxEnd.Position- floatEditxStart.Position)/floatEditxStep.Position);
            x.Ramp(Math387.Min(floatEditxEnd.Position, floatEditxStart.Position), floatEditxStep.Position);
            y.Size(x);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParserVectorized));
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.floatEditxStep = new Dew.Math.Controls.FloatEdit();
            this.floatEditxEnd = new Dew.Math.Controls.FloatEdit();
            this.floatEditxStart = new Dew.Math.Controls.FloatEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFormula = new System.Windows.Forms.TextBox();
            this.buttonBenchmark = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 424);
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
            this.tChart1.Legend.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(220, 104);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.line1);
            this.tChart1.Size = new System.Drawing.Size(444, 315);
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
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.line1.Pointer.HorizSize = 2;
            this.line1.Pointer.InflateMargins = false;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Pointer.VertSize = 2;
            this.line1.Pointer.Visible = true;
            this.line1.Title = "line1";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.floatEditxStep);
            this.groupBox1.Controls.Add(this.floatEditxEnd);
            this.groupBox1.Controls.Add(this.floatEditxStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculation";
            // 
            // floatEditxStep
            // 
            this.floatEditxStep.EditorEnabled = false;
            this.floatEditxStep.Increment = "0.2";
            this.floatEditxStep.Location = new System.Drawing.Point(83, 71);
            this.floatEditxStep.Name = "floatEditxStep";
            this.floatEditxStep.RegistryPath = "\\Software\\Dew Research\\MtxVec";
            this.floatEditxStep.Scientific = false;
            this.floatEditxStep.Size = new System.Drawing.Size(65, 20);
            this.floatEditxStep.TabIndex = 5;
            this.floatEditxStep.Value = "1.00";
            this.floatEditxStep.TextChanged += new System.EventHandler(this.floatEditxStart_TextChanged);
            // 
            // floatEditxEnd
            // 
            this.floatEditxEnd.EditorEnabled = false;
            this.floatEditxEnd.Increment = "1";
            this.floatEditxEnd.IntegerIncrement = true;
            this.floatEditxEnd.Location = new System.Drawing.Point(83, 45);
            this.floatEditxEnd.Name = "floatEditxEnd";
            this.floatEditxEnd.RegistryPath = "\\Software\\Dew Research\\MtxVec";
            this.floatEditxEnd.Scientific = false;
            this.floatEditxEnd.Size = new System.Drawing.Size(65, 20);
            this.floatEditxEnd.TabIndex = 4;
            this.floatEditxEnd.Value = "50.00";
            this.floatEditxEnd.TextChanged += new System.EventHandler(this.floatEditxStart_TextChanged);
            // 
            // floatEditxStart
            // 
            this.floatEditxStart.EditorEnabled = false;
            this.floatEditxStart.Increment = "1";
            this.floatEditxStart.IntegerIncrement = true;
            this.floatEditxStart.Location = new System.Drawing.Point(83, 19);
            this.floatEditxStart.Name = "floatEditxStart";
            this.floatEditxStart.RegistryPath = "\\Software\\Dew Research\\MtxVec";
            this.floatEditxStart.Scientific = false;
            this.floatEditxStart.Size = new System.Drawing.Size(65, 20);
            this.floatEditxStart.TabIndex = 3;
            this.floatEditxStart.Value = "0.00";
            this.floatEditxStart.TextChanged += new System.EventHandler(this.floatEditxStart_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "x axis step ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End at x ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start at x ...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Formula: y = ";
            // 
            // textBoxFormula
            // 
            this.textBoxFormula.Location = new System.Drawing.Point(85, 248);
            this.textBoxFormula.Name = "textBoxFormula";
            this.textBoxFormula.Size = new System.Drawing.Size(94, 20);
            this.textBoxFormula.TabIndex = 5;
            this.textBoxFormula.Text = "x *. Sin( x / pi )";
            // 
            // buttonBenchmark
            // 
            this.buttonBenchmark.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBenchmark.Location = new System.Drawing.Point(12, 357);
            this.buttonBenchmark.Name = "buttonBenchmark";
            this.buttonBenchmark.Size = new System.Drawing.Size(75, 23);
            this.buttonBenchmark.TabIndex = 7;
            this.buttonBenchmark.Text = "Benchmark";
            this.buttonBenchmark.UseVisualStyleBackColor = true;
            this.buttonBenchmark.Click += new System.EventHandler(this.buttonBenchmark_Click);
            // 
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelResult.Location = new System.Drawing.Point(13, 281);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(166, 73);
            this.labelResult.TabIndex = 8;
            // 
            // ParserVectorized
            // 
            this.ClientSize = new System.Drawing.Size(672, 456);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonBenchmark);
            this.Controls.Add(this.textBoxFormula);
            this.Name = "ParserVectorized";
            this.Load += new System.EventHandler(this.ParserVectorized_Load);
            this.Controls.SetChildIndex(this.textBoxFormula, 0);
            this.Controls.SetChildIndex(this.buttonBenchmark, 0);
            this.Controls.SetChildIndex(this.labelResult, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void ParserVectorized_Load(object sender, EventArgs e)
        {
            Add("This example demonstrates performance benefits and usage differences when using a "
                + "classical single value (scalar) parser and a vectorized parser.\n Try changing "
                + "the math formula and measure the time needed with both approaches.");
        }

        private void floatEditxStart_TextChanged(object sender, EventArgs e)
        {
            Updatex();
        }

        private void buttonBenchmark_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                try
                {

                    int loops = 3000000 / y.Length;
                    double[] xvalues = new double[x.Length];
                    double[] yvalues = new double[x.Length];

                    expr.ClearAll();
                    x1 = expr.DefineDouble("x");
                    expr.Expressions = textBoxFormula.Text;

                    x.CopyToArray(ref xvalues);
                    y.SizeToArray(ref yvalues);

                    // Scalar
                    int tcs = Environment.TickCount;
                    for (int j = 0; j < loops; j++)
                    {
                        for (int i = 0; i < x.Length; i++)
                        {
                            x1.DoubleValue = xvalues[i];
                            yvalues[i] = expr.EvaluateDouble();
                        }
                    }
                    tcs = Environment.TickCount - tcs;
                    labelResult.Text = "Standard: " + tcs.ToString() + " ms\n";


                    // Vectorized
                    expr.ClearAll();
                    expr.DefineVector("x", x);
                    expr.Expressions = textBoxFormula.Text;

                    int tcv = Environment.TickCount;
                    for (int j = 0; j < loops; j++)
                        yResult = expr.EvaluateVector();

                    tcv = Environment.TickCount - tcv;
                    labelResult.Text += "Vectorized: " + tcv.ToString() + " ms\n\n";
                    labelResult.Text += "Ratio: " + Math387.SampleToStr((double)tcs / (double)tcv, 4, 4);

                    tChart1.Header.Text = "y = " + textBoxFormula.Text;
                    DrawValues(x, yResult, tChart1[0], checkBoxDownsample.Checked);

                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

            }
            catch (Exception e1)     {
                MessageBox.Show(e1.Message);
            }
        }

    }
}

