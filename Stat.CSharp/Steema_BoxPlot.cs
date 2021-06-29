using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using Dew.Stats.Units;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats;
using Dew.Math.Editors;
using Dew.Stats.Tee;
using static Dew.Math.Tee.TeeChart;

namespace StatsMasterDemo
{
    public class Steema_BoxPlot : StatsMasterDemo.BasicForm1
    {
        private Matrix data;
        private Vector wrk1;

        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private BoxPlotStyle plotstyle = BoxPlotStyle.bpBox;
        
        public Steema_BoxPlot()
        {
            InitializeComponent();
            data = new Matrix(0, 0);
            wrk1 = new Vector(0);
        }

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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.Chart3DPercent = 25;
            this.tChart1.Aspect.Elevation = 336;
            this.tChart1.Aspect.ElevationFloat = 336;
            this.tChart1.Aspect.Orthogonal = false;
            this.tChart1.Aspect.Perspective = 0;
            this.tChart1.Aspect.Rotation = 24;
            this.tChart1.Aspect.RotationFloat = 24;
            this.tChart1.Aspect.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.tChart1.Aspect.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.tChart1.Aspect.View3D = false;
            this.tChart1.Aspect.Zoom = 62;
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
            this.tChart1.Axes.Left.Title.Caption = "Values";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Left.Title.Lines = new string[] {
        "Values"};
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
            this.tChart1.Header.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Header.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
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
            this.tChart1.Location = new System.Drawing.Point(235, 100);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tChart1.Panel.Gradient.Visible = true;
            // 
            // 
            // 
            this.tChart1.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Size = new System.Drawing.Size(425, 349);
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
            this.tChart1.Walls.Visible = false;
            this.tChart1.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Edit data";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 289);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Box plot settings";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox8.Location = new System.Drawing.Point(13, 73);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(70, 17);
            this.checkBox8.TabIndex = 11;
            this.checkBox8.Text = "Horizontal";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox7.Location = new System.Drawing.Point(13, 50);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(106, 17);
            this.checkBox7.TabIndex = 10;
            this.checkBox7.Text = "3D View";
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(69, 260);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Box width";
            // 
            // checkBox6
            // 
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox6.Location = new System.Drawing.Point(13, 232);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(126, 17);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "Show extreme outliers";
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.Location = new System.Drawing.Point(13, 209);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(126, 17);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Show mild outliers";
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Location = new System.Drawing.Point(13, 186);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(126, 17);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Show box";
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Location = new System.Drawing.Point(13, 163);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(126, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Show whiskers";
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Location = new System.Drawing.Point(13, 140);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Show mean lines";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(14, 117);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Show median line";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Items.AddRange(new object[] {
            "Box",
            "Diamond"});
            this.comboBox1.Location = new System.Drawing.Point(59, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Style";
            // 
            // Steema_BoxPlot
            // 
            this.ClientSize = new System.Drawing.Size(672, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Steema_BoxPlot";
            this.Load += new System.EventHandler(this.Steema_BoxPlot_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tChart1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;

        private void GeneratePlot()
        {
            tChart1.Series.Clear();
            tChart1.Header.Text = "Box plot showing " + data.Cols.ToString() + " columns";
            // setup bottom axis labels
            tChart1.Axes.Bottom.Labels.Items.Clear();
            for (int i = 0; i < data.Cols; i++)
            {
                BoxPlot boxplot = new BoxPlot(tChart1.Chart);
                boxplot.Title = "Column " + i.ToString();
                boxplot.Position = i;
                boxplot.Box.Gradient.Visible = true;
                boxplot.Box.Pen.Color = Color.Crimson;
                boxplot.MedianPen.Color = Color.Crimson;
                boxplot.MedianPen.Width = 2;
                wrk1.GetCol(data, i);
                wrk1.SortAscend();
                tChart1.Axes.Bottom.Labels.Items.Add(i, boxplot.Title);
                DrawValues(wrk1, boxplot, 0, 1, false);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MtxVecEdit.ViewValues(data, "Matrix values", true, false, true);
            GeneratePlot();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            plotstyle = (BoxPlotStyle)comboBox1.SelectedIndex;
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).PlotStyle = plotstyle;

        }

        private void Steema_BoxPlot_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Add("Box plots (Chambers 1983) are an excellent tool for conveying location and variation information in data "
                + "sets, particularly for detecting and illustrating location and variation changes between different groups" 
                + "of data.");
            Add("A single box plot can be drawn for one batch of data with no distinct groups. Alternatively, multiple box "
                + "plots can be drawn together to compare multiple data sets or to compare groups in a single data set. For "
                + "a single box plot, the width of the box is arbitrary.");
            Add("Check http://www.itl.nist.gov/div898/handbook/eda/section3/boxplot.htm to learn more about how box plots are"
                + "constructed.");
            comboBox1.SelectedIndex = 0;
            
            data.Size(30, 5);
            data.RandGauss();

            GeneratePlot();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).MedianPen.Visible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).MeanPen.Visible = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).WhiskerPen.Visible = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).Box.Visible = checkBox4.Checked;

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).MildOutlier.Visible = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).ExtremeOutlier.Visible = checkBox5.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < tChart1.Series.Count; i++)
                if (tChart1.Series[i] is CustomBoxPlot)
                    (tChart1.Series[i] as CustomBoxPlot).Box.HorizSize = (int)numericUpDown1.Value;
        }

        private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
        {
            if (tChart1.Series[0] is CustomBoxPlot)
            {
                int y = 50;
                CustomBoxPlot b = tChart1.Series[0] as CustomBoxPlot;
                g.Pen = b.MedianPen;
                g.HorizontalLine(80, 110, y);
                g.Font.Color = b.MedianPen.Color;
                g.TextOut(115, y - (int)g.TextHeight("W") / 2, "Median line");
                y += 16;
                g.Pen = b.MeanPen;
                g.HorizontalLine(80, 110, y);
                g.Font.Color = b.MeanPen.Color;
                g.TextOut(115, y - (int)g.TextHeight("W") / 2, "Mean line");

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            tChart1.Aspect.View3D = checkBox7.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            Type stype = checkBox8.Checked ? typeof(HorizBoxPlot) : typeof(BoxPlot);
            Series s;

            for (int i = 0; i < tChart1.Series.Count; i++)
            {
                s = tChart1.Series[i];
                Series.ChangeType(ref s, stype);
            }
        }
    }
}

