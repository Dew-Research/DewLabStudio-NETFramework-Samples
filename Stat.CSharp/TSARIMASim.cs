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
using Dew.Math.Editors;
using static Dew.Math.Tee.TeeChart;

namespace StatsMasterDemo
{
    public class TSARIMASim : StatsMasterDemo.BasicForm1
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
			this.line1 = new Steema.TeeChart.Styles.Line();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Name = "panel1";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Name = "richTextBox1";
			// 
			// tChart1
			// 
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
			this.tChart1.Header.Visible = false;
			// 
			// tChart1.Legend
			// 
			this.tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom;
			// 
			// tChart1.Legend.Font
			// 
			// 
			// tChart1.Legend.Font.Shadow
			// 
			this.tChart1.Legend.Font.Shadow.Visible = false;
			this.tChart1.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Series;
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
			this.tChart1.Location = new System.Drawing.Point(211, 100);
			this.tChart1.Name = "tChart1";
			// 
			// tChart1.Panel
			// 
			// 
			// tChart1.Panel.Brush
			// 
			// 
			// tChart1.Panel.Gradient
			// 
			this.tChart1.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.tChart1.Panel.Brush.Gradient.Visible = true;
			// 
			// tChart1.Panel.Gradient
			// 
			this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.tChart1.Panel.Gradient.Visible = true;
			// 
			// tChart1.Panel.ImageBevel
			// 
			this.tChart1.Panel.ImageBevel.Width = 1;
			// 
			// tChart1.Panel.Shadow
			// 
			this.tChart1.Panel.Shadow.Visible = false;
			this.tChart1.Series.Add(this.line1);
			this.tChart1.Size = new System.Drawing.Size(449, 325);
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
			this.tChart1.BeforeDrawSeries += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_BeforeDrawSeries);
			// 
			// line1
			// 
			// 
			// line1.Brush
			// 
			this.line1.Brush.Color = System.Drawing.Color.Red;
			// 
			// line1.LinePen
			// 
			this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((System.Byte)(153)), ((System.Byte)(0)), ((System.Byte)(0)));
			// 
			// line1.Marks
			// 
			// 
			// line1.Marks.Callout
			// 
			this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
			this.line1.Marks.Callout.ArrowHeadSize = 8;
			// 
			// line1.Marks.Callout.Brush
			// 
			this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
			this.line1.Marks.Callout.Distance = 0;
			this.line1.Marks.Callout.Draw3D = false;
			this.line1.Marks.Callout.Length = 10;
			this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			// 
			// line1.Marks.Font
			// 
			// 
			// line1.Marks.Font.Shadow
			// 
			this.line1.Marks.Font.Shadow.Visible = false;
			// 
			// line1.Pointer
			// 
			// 
			// line1.Pointer.Brush
			// 
			this.line1.Pointer.Brush.Color = System.Drawing.Color.Red;
			this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			this.line1.Title = "line1";
			// 
			// line1.XValues
			// 
			this.line1.XValues.DataMember = "X";
			this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
			// 
			// line1.YValues
			// 
			this.line1.YValues.DataMember = "Y";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 119);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "AR order";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(67, 117);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   30,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(49, 20);
			this.numericUpDown1.TabIndex = 5;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 2,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "MA order";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(67, 143);
			this.numericUpDown2.Maximum = new System.Decimal(new int[] {
																		   30,
																		   0,
																		   0,
																		   0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(49, 20);
			this.numericUpDown2.TabIndex = 7;
			this.numericUpDown2.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 171);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "# of diff.";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(67, 169);
			this.numericUpDown3.Maximum = new System.Decimal(new int[] {
																		   10,
																		   0,
																		   0,
																		   0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(49, 20);
			this.numericUpDown3.TabIndex = 9;
			this.numericUpDown3.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 197);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "# of sim.";
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Increment = new System.Decimal(new int[] {
																			 50,
																			 0,
																			 0,
																			 0});
			this.numericUpDown4.Location = new System.Drawing.Point(67, 195);
			this.numericUpDown4.Maximum = new System.Decimal(new int[] {
																		   1000,
																		   0,
																		   0,
																		   0});
			this.numericUpDown4.Minimum = new System.Decimal(new int[] {
																		   100,
																		   0,
																		   0,
																		   0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(49, 20);
			this.numericUpDown4.TabIndex = 11;
			this.numericUpDown4.Value = new System.Decimal(new int[] {
																		 100,
																		 0,
																		 0,
																		 0});
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(15, 232);
			this.button1.Name = "button1";
			this.button1.TabIndex = 12;
			this.button1.Text = "Simulate";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(122, 114);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(37, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "AR";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(122, 140);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(37, 23);
			this.button3.TabIndex = 14;
			this.button3.Text = "MA";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(122, 166);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(37, 23);
			this.button4.TabIndex = 15;
			this.button4.Text = "Init";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(15, 287);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 104);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Plot";
			// 
			// radioButton3
			// 
			this.radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton3.Location = new System.Drawing.Point(6, 75);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(114, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Time series PACF";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton2.Location = new System.Drawing.Point(6, 52);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(114, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Time series ACF";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButton1.Location = new System.Drawing.Point(6, 29);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(106, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Time series";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// TSARIMASim
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 437);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericUpDown4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.numericUpDown3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Name = "TSARIMASim";
			this.Load += new System.EventHandler(this.TSARIMASim_Load);
			this.Controls.SetChildIndex(this.numericUpDown1, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tChart1, 0);
			this.Controls.SetChildIndex(this.numericUpDown2, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.numericUpDown3, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.numericUpDown4, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.button2, 0);
			this.Controls.SetChildIndex(this.button3, 0);
			this.Controls.SetChildIndex(this.button4, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        #endregion

        private Steema.TeeChart.Styles.Line line1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;

        
        public TSARIMASim()
        {
            InitializeComponent();
            phi = new Vector(0);
            theta = new Vector(0);
            init = new Vector(0);
            timeseries = new Vector(0);
        }

        private int d=0;
        private Vector phi, theta, init, timeseries;

        private void Simulate()
        {
            int n = (int)numericUpDown4.Value;
            if (d==0) // ARMA process
            {
                StatTimeSerAnalysis.ARMASimulate(phi,theta,n,timeseries);
            }
            else
            {
                StatTimeSerAnalysis.ARIMASimulate(phi,theta,d,init,n,timeseries);
            }

            tChart1.Header.Text = "Simulating:";
            if (d==0) tChart1.Header.Text += "ARMA ("+phi.Length.ToString()+","+theta.Length.ToString()+") process";
            else tChart1.Header.Text += "ARIMA ("+phi.Length.ToString()+","+theta.Length.ToString()+","+d.ToString()+") process";

            if (radioButton2.Checked) PlotSeries(1);
            else if (radioButton3.Checked) PlotSeries(2);
            else PlotSeries(0);
        }

        private void PlotSeries(int index)
        {
            Vector vacf = new Vector(0);
            Vector vpacf = new Vector(0);

            tChart1.Axes.Bottom.Visible = false;
            tChart1.Axes.Left.Automatic = false;
            tChart1.Axes.Left.SetMinMax(-1.0, 1.0);

            switch (index)
            {
                case 0: // timeseries
                    {
                        tChart1.Axes.Bottom.Visible = true;
                        tChart1.Axes.Left.Automatic = true;
                        DrawValues(timeseries, tChart1.Series[0], 0, 1, false);
                        tChart1.Series[0].Title = "Time Series";
                    }; break;
                case 1: // ACF
                    {
                        StatTimeSerAnalysis.ACF(timeseries,vacf,timeseries.Length / 2);
                        tChart1.Series[0].Title = "Time Series ACF";
                        DrawValues(vacf, tChart1.Series[0], 0, 1, false);
                    }; break;
                case 2: // PACF
                    {
                        StatTimeSerAnalysis.ACF(timeseries, vacf, timeseries.Length / 2);
                        StatTimeSerAnalysis.PACF(vacf, vpacf);
                        tChart1.Series[0].Title = "Time Series PACF";
                        DrawValues(vpacf, tChart1.Series[0], 0, 1, false);
                    }; break;
            }
        }

        private void TSARIMASim_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("This example demonstrates usage of ARMA and ARIMA simulation and prediction routines. Change AR, MA and d parameters "
                + "to simulate different ARMA and ARIMA models.");
            Add("Press the \"Simulate\" button for random ARMA/ARIMA model time series.");
            // initial values
            phi.Length = 2;
            phi.SetZero();
            theta.Length = 1;
            theta.SetZero();
            init.Length = 1;
            init.SetZero();
            Simulate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            phi.Length = (int)numericUpDown1.Value;
            phi.SetZero();
            button2.Visible = phi.Length > 0;
            tChart1.Series[0].Clear();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            theta.Length = (int)numericUpDown2.Value;
            theta.SetZero();
            button3.Visible = theta.Length > 0;
            tChart1.Series[0].Clear();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            d = (int)numericUpDown3.Value;
            init.Length = d;
            // just an example 
            theta.SetZero();
            button4.Visible = init.Length > 0;
            tChart1.Series[0].Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simulate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) PlotSeries(1);
            else if (radioButton3.Checked) PlotSeries(2);
            else PlotSeries(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(phi, "AR coefficients", true, false, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(theta, "MA coefficients", true, false, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(init, "Initial derivatives", true, false, true);
        }

        private void tChart1_BeforeDrawSeries(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (!tChart1.Axes.Bottom.Visible)
            {
                int ypos = tChart1.Axes.Left.CalcYPosValue(0.0);
                tChart1.Axes.Bottom.Draw(ypos + 5, ypos + 15, ypos, true);
            }
        }

    }
}

