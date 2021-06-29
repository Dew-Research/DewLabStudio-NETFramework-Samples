using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats.Units;
using static Dew.Math.Tee.TeeChart;

namespace StatsMasterDemo
{
    public class RandGen : StatsMasterDemo.BasicForm1
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandGen));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPar3 = new System.Windows.Forms.Label();
            this.lblPar2 = new System.Windows.Forms.Label();
            this.lblPar1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bar1 = new Steema.TeeChart.Styles.Bar();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.tChart1.Axes.Left.Title.Caption = "Count";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "Count"};
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
            this.tChart1.Axes.Right.Grid.Visible = false;
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
            this.tChart1.Axes.Right.Title.Caption = "PDF";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Right.Title.Lines = new string[] {
        "PDF"};
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
        "Random generator"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
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
            this.tChart1.Location = new System.Drawing.Point(291, 100);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tChart1.Panel.Gradient.Visible = true;
            // 
            // 
            // 
            this.tChart1.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.bar1);
            this.tChart1.Series.Add(this.line1);
            this.tChart1.Size = new System.Drawing.Size(381, 325);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Random generator";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Beta",
            "Binomial",
            "Cauchy",
            "Chi-Squared",
            "Erlang",
            "Exponential",
            "F (Fisher)",
            "Gamma",
            "Geometric",
            "Gumbel (min)",
            "Hypergeometric",
            "Laplace",
            "Logistic",
            "LogNormal",
            "Maxwell",
            "Negative Binomial",
            "Normal",
            "Poisson",
            "Rayleigh",
            "Student-T",
            "Triangular",
            "Uniform (continuous)",
            "Uniform (discrete)",
            "Weibull"});
            this.comboBox1.Location = new System.Drawing.Point(12, 131);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(15, 171);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "How many numbers?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "# of histogram bins";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(15, 210);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblPar3);
            this.groupBox1.Controls.Add(this.lblPar2);
            this.groupBox1.Controls.Add(this.lblPar1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(15, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 106);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distribution parameters";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(51, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(66, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblPar3
            // 
            this.lblPar3.AutoSize = true;
            this.lblPar3.Location = new System.Drawing.Point(6, 75);
            this.lblPar3.Name = "lblPar3";
            this.lblPar3.Size = new System.Drawing.Size(39, 13);
            this.lblPar3.TabIndex = 2;
            this.lblPar3.Text = "lblPar3";
            // 
            // lblPar2
            // 
            this.lblPar2.AutoSize = true;
            this.lblPar2.Location = new System.Drawing.Point(6, 52);
            this.lblPar2.Name = "lblPar2";
            this.lblPar2.Size = new System.Drawing.Size(39, 13);
            this.lblPar2.TabIndex = 1;
            this.lblPar2.Text = "lblPar2";
            // 
            // lblPar1
            // 
            this.lblPar1.AutoSize = true;
            this.lblPar1.Location = new System.Drawing.Point(6, 25);
            this.lblPar1.Name = "lblPar1";
            this.lblPar1.Size = new System.Drawing.Size(39, 13);
            this.lblPar1.TabIndex = 0;
            this.lblPar1.Text = "lblPar1";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(15, 372);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Estimate";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(94, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Generate";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bar1
            // 
            this.bar1.Marks.AutoPosition = false;
            this.bar1.BarWidthPercent = 100;
            // 
            // 
            // 
            this.bar1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.bar1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.bar1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.bar1.Marks.Callout.Distance = 0;
            this.bar1.Marks.Callout.Draw3D = false;
            this.bar1.Marks.Callout.Length = 20;
            this.bar1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar1.Marks.Font.Shadow.Visible = false;
            this.bar1.Marks.Visible = false;
            // 
            // 
            // 
            this.bar1.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(115)))), ((int)(((byte)(77)))));
            this.bar1.Pen.Visible = false;
            this.bar1.SideMargins = false;
            this.bar1.Title = "Generated";
            // 
            // 
            // 
            this.bar1.XValues.DataMember = "X";
            this.bar1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.bar1.YValues.DataMember = "Bar";
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.line1.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.line1.Pointer.Dark3D = false;
            this.line1.Pointer.Draw3D = false;
            this.line1.Pointer.InflateMargins = false;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "Estimated";
            this.line1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
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
            // RandGen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 437);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "RandGen";
            this.Load += new System.EventHandler(this.RandGen_Load);
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numericUpDown2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPar3;
        private System.Windows.Forms.Label lblPar2;
        private System.Windows.Forms.Label lblPar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private Steema.TeeChart.Styles.Bar bar1;
        private Steema.TeeChart.Styles.Line line1;

        public RandGen()
        {
            InitializeComponent();
            v1 = new Vector(0);
            v1int = new VectorInt(0);
            v2 = new Vector(0);
            vcount = new Vector(0);
            vbins = new Vector(0);
        }

        private Vector v1, v2, vcount, vbins;
        private VectorInt v1int; 

        private void UpdateControls(int index)
        {
            switch (index)
            {
                case 0: // Beta
                    {
                        lblPar1.Text = "a";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(1.5);
                        textBox2.Text = Convert.ToString(0.9);
                    }; break;
                case 1: // Binomial
                    {
                        lblPar1.Text = "N";
                        lblPar2.Text = "p";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = "10";
                        textBox2.Text = Convert.ToString(0.4);
                    }; break;
                case 2: // Cauchy
                    {
                        lblPar1.Text = "m";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(0.0);
                        textBox2.Text = Convert.ToString(0.5);
                    }; break;
                case 3: // Chi2
                    {
                        lblPar1.Text = "Nu";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = "4";
                    }; break;
                case 4: // Erlang
                    {
                        lblPar1.Text = "k";
                        lblPar2.Text = "lambda";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(2);
                        textBox2.Text = Convert.ToString(0.37);
                    }; break;
                case 5: // Exponential
                    {
                        lblPar1.Text = "Mu";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(1.8);
                    }; break;
                case 6: // F
                    {
                        lblPar1.Text = "Nu1";
                        lblPar2.Text = "Nu2";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = "3";
                        textBox2.Text = "8";
                    }; break;
                case 7: // Gamma
                    {
                        lblPar1.Text = "a";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(2.1);
                        textBox2.Text = Convert.ToString(0.3);
                    }; break;
                case 8: // Geometric
                    {
                        lblPar1.Text = "P";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(0.7);
                    }; break;
                case 9: // GUMBEL
                    {
                        lblPar1.Text = "m";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(2.1);
                        textBox2.Text = Convert.ToString(0.3);
                    }; break;
                case 10: //Hypergeometric
                    {
                        lblPar1.Text = "M";
                        lblPar2.Text = "K";
                        lblPar3.Text = "N";
                        lblPar2.Visible = true;
                        lblPar3.Visible = true;
                        textBox1.Text = "50";
                        textBox2.Text = "30";
                        textBox3.Text = "20";
                    };break;
                case 11: // Laplace
                    {
                        lblPar1.Text = "m";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(1.5);
                        textBox2.Text = Convert.ToString(0.8);
                    }; break;
                case 12: // Logistic
                    {
                        lblPar1.Text = "m";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(0.4);
                        textBox2.Text = Convert.ToString(2.1);
                    };  break;
                case 13: // Log-normal
                    {
                        lblPar1.Text = "mu";
                        lblPar2.Text = "sigma";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(5.0);
                        textBox2.Text = Convert.ToString(0.2);
                    }; break;
                case 14: // Maxwell
                    {
                        lblPar1.Text = "a";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(1.12);
                    }; break;
                case 15: // Negative binomial 
                    {
                        lblPar1.Text = "R";
                        lblPar2.Text = "p";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = "15";
                        textBox2.Text = Convert.ToString(0.65);
                    };  break;
                case 16: // Normal
                    {
                        lblPar1.Text = "mu";
                        lblPar2.Text = "sigma";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(0.0);
                        textBox2.Text = Convert.ToString(1.0);
                    };  break;
                case 17: // Poisson
                    {
                        lblPar1.Text = "Lambda";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(7.2);
                    }; break;
                case 18: // Rayleigh
                    {
                        lblPar1.Text = "b";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(0.2);
                    }; break;
                case 19: // Student-T
                    {
                        lblPar1.Text = "Nu";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = "4";
                    }; break;
                case 20: // Triangular
                    {
                        lblPar1.Text = "a";
                        lblPar2.Text = "b";
                        lblPar3.Text = "c";
                        lblPar2.Visible = true;
                        lblPar3.Visible = true;
                        textBox1.Text = Convert.ToString(2);
                        textBox2.Text = Convert.ToString(6.5);
                        textBox3.Text = Convert.ToString(4.2);
                    }; break;
                case 21: // Uniform
                    {
                        lblPar1.Text = "a";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(-2.5);
                        textBox2.Text = Convert.ToString(3.9);
                    };  break;
                case 22: // Discrete uniform
                    {
                        lblPar1.Text = "N";
                        lblPar2.Visible = false;
                        lblPar3.Visible = false;
                        textBox1.Text = "20";
                    }; break;
                case 23: // Weibull
                    {
                        lblPar1.Text = "a";
                        lblPar2.Text = "b";
                        lblPar2.Visible = true;
                        lblPar3.Visible = false;
                        textBox1.Text = Convert.ToString(1.5);
                        textBox2.Text = Convert.ToString(2.3);
                    };  break;
            }

            textBox2.Visible = lblPar2.Visible;
            textBox3.Visible = lblPar3.Visible;
        }

        
        private string Estimate(Dew.Math.TVec x, int index)
        {
            double par0, par1, par2;
            double[] CA = new double[2];
            double[] CB = new double[2];
            int int0, int1;
            string msgstr = "";
            line1.Active = true;
            VectorInt xInt = new VectorInt();
            xInt.Size(x);

            switch (index)
            {
                case 0: // Beta
                    {
                        Statistics.BetaFit(v1,out par0,out par1,ref CA, ref CB, 500,1.0E-8, 0.05);
                        Probabilities.BetaPDF(x,par0,par1,v2);
                        msgstr = "a = "+par0.ToString("0.00")+ " ; b = "+par1.ToString("0.00");
                    }; break;
                case 1: // Binomial
                    {
                        Statistics.BinomFit(v1, out int0, out par0);
                        x.CopyTo(xInt, TRounding.rnRound);
                        Probabilities.BinomPDF(xInt, int0, par0,v2);
                        msgstr = "N = " + int0.ToString()+ " ; p = " + par0.ToString("0.00");
                    } break;
                case 2: // Cauchy
                    {
                        Statistics.CauchyFit(v1, out par0, out par1, 500, 1.0E-8);
                        Probabilities.CauchyPDF(x, par0, par1, v2);
                        msgstr = "m = " + par0.ToString("0.00") + " ; b = " + par1.ToString("0.00");
                    }; break;
                case 3: // Chi-Squared
                    {
                        Statistics.ChiSquareFit(v1, out int0);
                        Probabilities.ChiSquarePDF(x, int0, v2);
                        msgstr = "Nu = " + int0.ToString();
                    }; break;
                case 4: // Erlang
                    {
                        Statistics.ErlangFit(v1, out int0, out par0);
                        Probabilities.ErlangPDF(x, int0, par0, v2);
                        msgstr = "k = " + int0.ToString() + " ; lambda = " + par0.ToString("0.00");
                    }; break;
                case 5: // Exponent
                    {
                        Statistics.ExponentFit(v1,out par0);
                        Probabilities.ExpPDF(x,par0,v2);
                        msgstr = "mu = "+par0.ToString("0.00");
                    }; break;
                case 6: // FISHER-F
                    {
                        Statistics.FFit(v1, out int0, out int1, 500, 1.0E-8);
                        Probabilities.FPDF(x, int0, int1,v2);
                        msgstr = "Nu1 = " + int0.ToString() + " ; Nu2 = "+int1.ToString();
                    }; break;
                case 7: // Gamma
                    {
                        Statistics.GammaFit(v1,out par0, out par1,500,1.0E-8);
                        Probabilities.GammaPDF(x,par0,par1,v2);
                        msgstr = "a = "+par0.ToString("0.00")+ " ; b = "+par1.ToString("0.00");
                    }; break;
                case 8: // Geometric
                    {
                        Statistics.GeometricFit(v1,out par0);
                        x.CopyTo(xInt, TRounding.rnRound);
                        Probabilities.GeometricPDF(xInt,par0,v2);
                        msgstr = "P = "+par0.ToString("0.00");
                    }; break;
                case 11: // Laplace
                    {
                        Statistics.LaplaceFit(v1, out par0, out par1);
                        Probabilities.LaplacePDF(x, par0, par1, v2);
                        msgstr = "mu = " + par0.ToString("0.00") + " ; b = " + par1.ToString("0.00");
                    }; break;
                case 12: // Logistic
                    {
                        Statistics.LogisticFit(v1, out par0, out par1);
                        Probabilities.LogisticPDF(x, par0, par1, v2);
                        msgstr = "m = " + par0.ToString("0.00") + " ; b = " + par1.ToString("0.00");
                    }; break;
                case 13: // Log-normal
                    {
                        Statistics.LogNormalFit(v1, out par0, out par1);
                        Probabilities.LogNormalPDF(x, par0, par1, v2);
                        msgstr = "mu = " + par0.ToString("0.00") + " ; sigma = " + par1.ToString("0.00");
                    }; break;
                case 14: // Maxwell
                    {
                        Statistics.MaxwellFit(v1, out par0);
                        Probabilities.MaxwellPDF(x, par0, v2);
                        msgstr = "a = " + par0.ToString("0.00");
                    }; break;
                case 15: // Neg-binomial fit
                    {
                        Statistics.NegBinomFit(v1, out par0, out par1);
                        x.CopyTo(xInt, TRounding.rnRound);
                        Probabilities.NegBinomPDF(xInt, par0, par1,v2);
                        msgstr = "r = " + par0.ToString("0.00") + " ; p = " + par1.ToString("0.00");
                    }; break;
                case 16: // Normal
                    {
                        Statistics.NormalFit(v1,out par0, out par1);
                        Probabilities.NormalPDF(x,par0,par1,v2);
                        msgstr = "mu = "+par0.ToString("0.00")+ " ; sigma = "+par1.ToString("0.00");
                    }; break;
                case 17: // Poisson
                    {
                        Statistics.PoissonFit(v1,out par0);
                        x.CopyTo(xInt, TRounding.rnRound);
                        Probabilities.PoissonPDF(xInt,par0,v2);
                        msgstr = "lambda = "+par0.ToString("0.00");
                    }; break;
                case 18: // Rayleigh
                    {
                        Statistics.RayleighFit(v1,out par0);
                        Probabilities.RayleighPDF(x,par0,v2);
                        msgstr = "b = "+par0.ToString("0.00");
                    }; break;
                case 19 : // Student-T
                    {
                        Statistics.StudentFit(v1, out int0,500,1.0E-8);
                        Probabilities.StudentPDF(x, int0, v2);
                        msgstr = "Nu = " + int0.ToString();
                    }; break;
                case 20: // Triangular
                    {
                        Statistics.TriangularFit(v1, out par0, out par1,out par2,500,1.0E-6);
                        Probabilities.TriangularPDF(x, par0, par1,par2, v2);
                        msgstr = "a = " + par0.ToString("0.00") + " ; b = " + par1.ToString("0.00") + " ; c = " + par2.ToString("0.00");
                    }; break;
                case 21: // Uniform
                    {
                        Statistics.UniformFit(v1,out par0, out par1);
                        Probabilities.UniformPDF(x,par0,par1,v2);
                        msgstr = "a = "+par0.ToString("0.00")+ " ; b = "+par1.ToString("0.00");
                    }; break;
                case 22: // Uniform discrete
                    {
                        Statistics.UniformDFit(v1,out int0);
                        x.CopyTo(xInt, TRounding.rnRound);
                        Probabilities.UniformDPDF(xInt,int0,v2);
                        msgstr = "Nu = "+int0.ToString();
                    }; break;
                case 23: // Weibull
                    {
                        Statistics.WeibullFit(v1,out par0, out par1,500,1.0E-8);
                        Probabilities.WeibullPDF(x,par0,par1,v2);
                        msgstr = "a = "+par0.ToString("0.00")+ " ; b = "+par1.ToString("0.00");
                    }; break;
                default:
                    {
                        msgstr = "Not supported!";
                        line1.Active = false;
                    } break;
            }
            return msgstr;
        }

        private void Generate(int index)
        {
            double s1,s2,s3;
            int i1,i2,i3;
            v1.Length = (int)numericUpDown1.Value;
            v1int.Length = v1.Length; 

            switch (index)
            {
                case 0: // Beta
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomBeta(s1, s2, v1,-1);
                    }; break;
                case 1: // Binomial
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        s1 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomBinom(i1, s1, v1int, -1);
                        v1.Copy(v1int);
                    };break;
                case 2: // Cauchy
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomCauchy(s1, s2, v1, -1);
                    };break;
                case 3: // Chi2
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        StatRandom.RandomChiSquare(i1, v1, -1);
                    };break;
                case 4: // Erlang
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        s1 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomErlang(i1, s1, v1, -1);
                    }; break;
                case 5: // Exponential
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        StatRandom.RandomExponent(s1, v1, -1);
                    };break;
                case 6: // F
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        i2 = Convert.ToInt16(textBox2.Text);
                        StatRandom.RandomF(i1, i2, v1, -1);
                    };break;
                case 7: // Gamma
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomGamma(s1, s2, v1, -1);
                    };break;
                case 8: // Geometric
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        StatRandom.RandomGeometric(s1, v1, -1);
                    };break;
                case 9: // Gumbel min
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomGumbel(s1, s2, v1, -1);
                    }; break;
                case 10: // Hypergeometric
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        i2 = Convert.ToInt16(textBox2.Text);
                        i3 = Convert.ToInt16(textBox3.Text);
                        StatRandom.RandomHypGeometric(i1, i2, i3, v1int, -1);
                        v1.Copy(v1int);
                    };break;
                case 11: // Laplace
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomLaplace(s1, s2, v1, -1);
                    };break;
                case 12: // Logistic
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomLogistic(s1, s2, v1, -1);
                    }; break;
                case 13: // Log-normal
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomLogNormal(s1, s2, v1, -1);
                    };break;
                case 14: // Maxwell
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        StatRandom.RandomMaxwell(s1, v1, -1);
                    }; break;
                case 15: // Negative binomial
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        s1 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomNegBinom(i1, s1, v1int, -1);
                        v1.Copy(v1int);
                    };break;
                case 16: // Normal
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomNormal(s1, s2, v1, -1);
                    };break;
                case 17: // Poisson
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        StatRandom.RandomPoisson(s1, v1int, -1);
                        v1.Copy(v1int);
                    };break;
                case 18: // Rayleigh
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        StatRandom.RandomRayleigh(s1, v1, -1);
                    };break;
                case 19: // Student-T
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        StatRandom.RandomStudent(i1, v1, -1);
                    };break;
                case 20: // Triangular
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        s3 = Convert.ToDouble(textBox3.Text);
                        StatRandom.RandomTriangular(s1, s2, s3, v1, -1);
                    }; break;
                case 21: // Uniform
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomUniform(s1, s2, v1, -1);
                    };break;
                case 22: // Discrete uniform
                    {
                        i1 = Convert.ToInt16(textBox1.Text);
                        StatRandom.RandomUniformD(i1, v1, -1);
                    };break;
                case 23: // Weibull
                    {
                        s1 = Convert.ToDouble(textBox1.Text);
                        s2 = Convert.ToDouble(textBox2.Text);
                        StatRandom.RandomWeibull(s1, s2, v1, -1);
                    };break;
            }

            // do centered histogram
            Statistics.Histogram(v1,(int)numericUpDown2.Value,vcount,vbins,true);
            DrawValues(vbins, vcount, bar1, false);

            if (checkBox1.Checked)
            {
                string st = Estimate(vbins, index);
                tChart1.SubHeader.Text = "Estimates: " + st;
                if (line1.Active)
                    DrawValues(vbins, v2, line1, false);
            }
            else line1.Active = false;

            tChart1.Legend.Visible = line1.Active;
        }


        private void RandGen_Load(object sender, EventArgs e)
        {

            richTextBox1.Clear();
            Add("The Statistics unit offers random generators for 28 different distributions.\n");
            Add("For some distributions you can also estimate parameter values. First check the \"Estimate\" "
                + "chechbox and then generate random numbers by clicking on the \"Generate\" button.");

            comboBox1.SelectedIndex = 5; // Exponential distribution
            Generate(comboBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            try
            {
                Generate(comboBox1.SelectedIndex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            try
            {
                bar1.Clear();
                line1.Clear();
                tChart1.SubHeader.Text = "";
                UpdateControls(comboBox1.SelectedIndex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}

