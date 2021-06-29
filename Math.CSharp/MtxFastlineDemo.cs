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

namespace MtxVecDemo
{
    public class MtxFastlineDemo : BasicForm2
    {
        MtxFastLine mtxfl;
        Steema.TeeChart.Styles.FastLine fl;
        private Button buttonCompare;
        private Panel panel4;
        private NumericUpDown numericUpDown1;
        private Label label1;
        Vector data;
        
        public MtxFastlineDemo()
        {
            InitializeComponent();
            tChart1.Series.Clear();
            tChart2.Series.Clear();

            tChart1.Series.Add(mtxfl = new MtxFastLine());
            mtxfl.Chart = tChart1.Chart;
            mtxfl.PixelDownSample = true;

            tChart2.Series.Add(fl = new Steema.TeeChart.Styles.FastLine());
            fl.Chart = tChart2.Chart;

            data = new Vector();
        }

        private SplitContainer splitContainer1;
        private Steema.TeeChart.TChart tChart1;
        private Splitter splitter1;
        private Steema.TeeChart.TChart tChart2;
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.tChart2 = new Steema.TeeChart.TChart();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Size = new System.Drawing.Size(596, 285);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(596, 48);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(596, 112);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tChart2);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.tChart1);
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
            this.splitContainer1.Size = new System.Drawing.Size(596, 285);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.buttonCompare);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 73);
            this.panel4.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(83, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(73, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sample size";
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(3, 6);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(66, 23);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Populate";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // tChart2
            // 
            // 
            // 
            // 
            this.tChart2.Aspect.ElevationFloat = 345;
            this.tChart2.Aspect.RotationFloat = 345;
            this.tChart2.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.tChart2.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Axes.Top.Title.Shadow.Visible = false;
            this.tChart2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Header.Font.Shadow.Visible = false;
            this.tChart2.Header.Lines = new string[] {
        "Fastline"};
            // 
            // 
            // 
            this.tChart2.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart2.Legend.Title.Shadow.Visible = false;
            this.tChart2.Legend.Visible = false;
            this.tChart2.Location = new System.Drawing.Point(0, 129);
            this.tChart2.Name = "tChart2";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Panel.Shadow.Visible = false;
            this.tChart2.Size = new System.Drawing.Size(416, 156);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.SubHeader.Shadow.Visible = false;
            this.tChart2.TabIndex = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart2.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart2.Walls.Right.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart2.Zoom.Animated = true;
            this.tChart2.Scroll += new System.EventHandler(this.tChart2_Scroll);
            this.tChart2.UndoneZoom += new System.EventHandler(this.tChart2_UndoneZoom);
            this.tChart2.Zoomed += new System.EventHandler(this.tChart2_Zoomed);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 126);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(416, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
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
            this.tChart1.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dash;
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
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart1.Dock = System.Windows.Forms.DockStyle.Top;
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
        "MtxFastline"};
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
            this.tChart1.Legend.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(0, 0);
            this.tChart1.Name = "tChart1";
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
            this.tChart1.Size = new System.Drawing.Size(416, 126);
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
            // 
            // 
            // 
            this.tChart1.Zoom.Animated = true;
            // 
            // MtxFastlineDemo
            // 
            this.ClientSize = new System.Drawing.Size(596, 445);
            this.Name = "MtxFastlineDemo";
            this.Load += new System.EventHandler(this.MtxFastlineDemo_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            tChart1.Height = tChart1.Parent.Height / 2 - 5;
        }

        private void MtxFastlineDemo_Load(object sender, EventArgs e)
        {

            Add("New Dew.Math.Tee.MMtxFastLine draws many times faster than Steema.TeeChart.Styles.FastLine."
                + " It allows zoom-in and zoom-out with pixeldownsamle enabled. MtxFastLine can be used"
                + " with all TeeChart versions. Further optimization is applied, if X axis has equidistantly spaced samples.\n");
            Add("First press on the \"Populate\" button, then try different data sizes and zooming/panning bottom chart."
                + "Zoom by drawing a rectangle, zoom-out by drawing up and left, pan by dragging with right mouse button.");
        }

        private void Recreate()
        {
            data.Size((int)numericUpDown1.Value);
            data.RandGauss(5, 3.2);

            tChart1.Series[0].GetHorizAxis.Automatic = false;
            tChart1.Series[0].GetHorizAxis.SetMinMax(0, data.Length - 1);
            tChart2.Series[0].GetHorizAxis.Automatic = false;
            tChart2.Series[0].GetHorizAxis.SetMinMax(0, data.Length - 1);
            tChart1.Zoom.Animated = true;
            tChart2.Zoom.Animated = true;

            Math387.StartTimer();
            TeeChart.DrawValues(data, tChart1.Series[0], 0, 1, false);
            double timeElapsed = Math387.StopTimer()*1000;
            tChart1.Header.Text = "MtxFastLine\nDrawing " + data.Length.ToString() + " points:" + timeElapsed.ToString("0.0") + " ms\n";

            Math387.StartTimer();
            TeeChart.DrawValues(data, tChart2.Series[0], 0, 1, false);
            timeElapsed = Math387.StopTimer() * 1000;
            tChart2.Header.Text = "FastLine\nDrawing " + data.Length.ToString() + " points:" + timeElapsed.ToString("0.0") + " ms\n";
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Recreate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tChart1.Series[0].GetHorizAxis.Automatic = false;
            tChart1.Series[0].GetHorizAxis.SetMinMax(0, data.Length - 1);
            tChart1.Series[0].GetVertAxis.Automatic = true;
            tChart1.Zoom.Animated = true;
            
            tChart2.Series[0].GetHorizAxis.Automatic = false;
            tChart2.Series[0].GetHorizAxis.SetMinMax(0, data.Length - 1);
            tChart2.Series[0].GetVertAxis.Automatic = true;
            tChart2.Zoom.Animated = true;            
        }

        private void tChart2_UndoneZoom(object sender, EventArgs e)
        {
       //     tChart1.Series[0].GetVertAxis.Automatic = true;
       //     tChart1.Series[0].GetHorizAxis.SetMinMax(tChart2.Series[0].GetHorizAxis.Minimum, tChart2.Series[0].GetHorizAxis.Maximum);
       //     button1.Enabled = false;
        }

        private void tChart2_Zoomed(object sender, EventArgs e)
        {
       //     tChart1.Series[0].GetHorizAxis.SetMinMax(tChart2.Series[0].GetHorizAxis.Minimum, tChart2.Series[0].GetHorizAxis.Maximum);
       //     tChart1.Series[0].GetVertAxis.SetMinMax(tChart2.Series[0].GetVertAxis.Minimum, tChart2.Series[0].GetVertAxis.Maximum);
       //     button1.Enabled = true;
        }

        private void tChart2_Scroll(object sender, EventArgs e)
        {
        //    tChart1.Series[0].GetHorizAxis.SetMinMax(tChart2.Series[0].GetHorizAxis.Minimum, tChart2.Series[0].GetHorizAxis.Maximum);
        //    tChart1.Series[0].GetVertAxis.SetMinMax(tChart2.Series[0].GetVertAxis.Minimum, tChart2.Series[0].GetVertAxis.Maximum);
        //    button1.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Recreate();
        }
    }
}