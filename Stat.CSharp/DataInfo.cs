using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static Dew.Math.Tee.MtxVecTee;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats.Units;

namespace StatsMasterDemo
{
    public class DataInfo : UserControl
    {
        private TVec data = null;
        private TVec xdata = null;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainerCharts;
        public Steema.TeeChart.TChart tChartData;
        public Steema.TeeChart.TChart tChartHistogram;
        private RichTextBox richTextBoxReport;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.HorizBar horizBar1;
        private string stringformat = "0.0000";

        public string StringFormat
        {
            get { return stringformat; }
            set { stringformat = value; Update(); }
        }

        [DefaultValue(false)]
        public bool SettingsPanelVisible
        {
            get { return panelSettings.Visible; }
            set { panelSettings.Visible = value; }
        }

        public new void  Update()
        {
            if (data != null)
            {
                if (xdata != null && xdata.Length == data.Length) DrawValues(xdata, data, tChartData[0], false);
                else DrawValues(data, tChartData[0], 0, 1, false);

                // Histogram, need only Y values
                TVec hist, bins;
                MtxVec.CreateIt(out hist, out bins);
                try
                {
                    Statistics.Histogram(data, 20, hist, bins, true);
                    DrawValues(hist,bins, tChartHistogram[0], false);
                }
                finally
                {
                    MtxVec.FreeIt(ref hist, ref bins);
                }
                // Calculate Y values statistics
                double amean = Data.Mean();
                double astd = data.StdDev(amean);
                richTextBoxReport.Text = "Count:\t" + data.Length.ToString() + "\n"
                    + "Mean:\t" + amean.ToString(stringformat) + "\n"
                    + "Median:\t" + data.Median().ToString(stringformat) + "\n"
                    + "Std.dev:\t" + astd.ToString(stringformat) + "\n"
                    + "Skewness:\t" + data.Skewness(amean, astd).ToString(stringformat) + "\n"
                    + "Kurtosis:\t" + data.Kurtosis(amean, astd).ToString(stringformat) + "\n";
            }
        }

        private void SetupChart(Steema.TeeChart.TChart chart)
        {
            chart.Aspect.View3D = false;
            chart.Header.Visible = false;
        }
        
        public DataInfo()
        {
            InitializeComponent();
            panelSettings.Visible = false;
            SetupChart(tChartData);
            SetupChart(tChartHistogram);
            tChartHistogram.Axes.Bottom.Title.Text = "Count";
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSettings = new System.Windows.Forms.Panel();
            this.checkBoxStat = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxHistogram = new System.Windows.Forms.CheckBox();
            this.checkBoxData = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerCharts = new System.Windows.Forms.SplitContainer();
            this.tChartData = new Steema.TeeChart.TChart();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.tChartHistogram = new Steema.TeeChart.TChart();
            this.horizBar1 = new Steema.TeeChart.Styles.HorizBar();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.panelSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainerCharts.Panel1.SuspendLayout();
            this.splitContainerCharts.Panel2.SuspendLayout();
            this.splitContainerCharts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.checkBoxStat);
            this.panelSettings.Controls.Add(this.groupBox1);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(121, 251);
            this.panelSettings.TabIndex = 0;
            this.panelSettings.Visible = false;
            // 
            // checkBoxStat
            // 
            this.checkBoxStat.Checked = true;
            this.checkBoxStat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxStat.Location = new System.Drawing.Point(9, 94);
            this.checkBoxStat.Name = "checkBoxStat";
            this.checkBoxStat.Size = new System.Drawing.Size(101, 18);
            this.checkBoxStat.TabIndex = 1;
            this.checkBoxStat.Text = "Basic statistics";
            this.checkBoxStat.CheckedChanged += new System.EventHandler(this.checkBoxStat_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHistogram);
            this.groupBox1.Controls.Add(this.checkBoxData);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show";
            // 
            // checkBoxHistogram
            // 
            this.checkBoxHistogram.Checked = true;
            this.checkBoxHistogram.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxHistogram.Location = new System.Drawing.Point(6, 42);
            this.checkBoxHistogram.Name = "checkBoxHistogram";
            this.checkBoxHistogram.Size = new System.Drawing.Size(79, 18);
            this.checkBoxHistogram.TabIndex = 1;
            this.checkBoxHistogram.Text = "Histogram";
            this.checkBoxHistogram.CheckedChanged += new System.EventHandler(this.checkBoxHistogram_CheckedChanged);
            // 
            // checkBoxData
            // 
            this.checkBoxData.Checked = true;
            this.checkBoxData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxData.Location = new System.Drawing.Point(6, 19);
            this.checkBoxData.Name = "checkBoxData";
            this.checkBoxData.Size = new System.Drawing.Size(55, 18);
            this.checkBoxData.TabIndex = 0;
            this.checkBoxData.Text = "Data";
            this.checkBoxData.CheckedChanged += new System.EventHandler(this.checkBoxData_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(121, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerCharts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxReport);
            this.splitContainer1.Size = new System.Drawing.Size(277, 251);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainerCharts
            // 
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCharts.Name = "splitContainerCharts";
            // 
            // splitContainerCharts.Panel1
            // 
            this.splitContainerCharts.Panel1.Controls.Add(this.tChartData);
            // 
            // splitContainerCharts.Panel2
            // 
            this.splitContainerCharts.Panel2.Controls.Add(this.tChartHistogram);
            this.splitContainerCharts.Size = new System.Drawing.Size(277, 173);
            this.splitContainerCharts.SplitterDistance = 146;
            this.splitContainerCharts.SplitterWidth = 2;
            this.splitContainerCharts.TabIndex = 0;
            // 
            // tChartData
            // 
            // 
            // 
            // 
            this.tChartData.Aspect.ElevationFloat = 345;
            this.tChartData.Aspect.RotationFloat = 345;
            this.tChartData.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Axes.Top.Title.Shadow.Visible = false;
            this.tChartData.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Header.Font.Shadow.Visible = false;
            this.tChartData.Header.Lines = new string[] {
        "Data"};
            // 
            // 
            // 
            this.tChartData.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChartData.Legend.Title.Shadow.Visible = false;
            this.tChartData.Legend.Visible = false;
            this.tChartData.Location = new System.Drawing.Point(0, 0);
            this.tChartData.Name = "tChartData";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChartData.Panel.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.tChartData.Series.Add(this.line1);
            this.tChartData.Size = new System.Drawing.Size(146, 173);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.SubHeader.Shadow.Visible = false;
            this.tChartData.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartData.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartData.Walls.Right.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartData.Zoom.Animated = true;
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.Red;
            this.line1.ClickableLine = false;
            this.line1.ColorEachLine = false;
            this.line1.Dark3D = false;
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
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
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
            // tChartHistogram
            // 
            // 
            // 
            // 
            this.tChartHistogram.Aspect.ElevationFloat = 345;
            this.tChartHistogram.Aspect.RotationFloat = 345;
            this.tChartHistogram.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Left.Title.Shadow.Visible = false;
            this.tChartHistogram.Axes.Left.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Axes.Top.Title.Shadow.Visible = false;
            this.tChartHistogram.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Header.Font.Shadow.Visible = false;
            this.tChartHistogram.Header.Lines = new string[] {
        "Histogram"};
            // 
            // 
            // 
            this.tChartHistogram.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Legend.Font.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartHistogram.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Legend.Title.Shadow.Visible = false;
            this.tChartHistogram.Legend.Visible = false;
            this.tChartHistogram.Location = new System.Drawing.Point(0, 0);
            this.tChartHistogram.Name = "tChartHistogram";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChartHistogram.Panel.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Panning.Allow = Steema.TeeChart.ScrollModes.None;
            this.tChartHistogram.Series.Add(this.horizBar1);
            this.tChartHistogram.Size = new System.Drawing.Size(129, 173);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.SubHeader.Shadow.Visible = false;
            this.tChartHistogram.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartHistogram.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartHistogram.Walls.Right.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChartHistogram.Zoom.Animated = true;
            // 
            // horizBar1
            // 
            this.horizBar1.Marks.AutoPosition = false;
            this.horizBar1.BarHeightPercent = 100;
            // 
            // 
            // 
            this.horizBar1.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.horizBar1.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            // 
            // 
            // 
            // 
            // 
            // 
            this.horizBar1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.horizBar1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.horizBar1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.horizBar1.Marks.Callout.Distance = 0;
            this.horizBar1.Marks.Callout.Draw3D = false;
            this.horizBar1.Marks.Callout.Length = 20;
            this.horizBar1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.horizBar1.Marks.Font.Shadow.Visible = false;
            this.horizBar1.Marks.Visible = false;
            this.horizBar1.MultiBar = Steema.TeeChart.Styles.MultiBars.None;
            // 
            // 
            // 
            this.horizBar1.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.horizBar1.SideMargins = false;
            this.horizBar1.Title = "horizBar1";
            this.horizBar1.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
            // 
            // 
            // 
            this.horizBar1.XValues.DataMember = "X";
            // 
            // 
            // 
            this.horizBar1.YValues.DataMember = "Bar";
            this.horizBar1.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxReport.DetectUrls = false;
            this.richTextBoxReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReport.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.ReadOnly = true;
            this.richTextBoxReport.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxReport.Size = new System.Drawing.Size(277, 77);
            this.richTextBoxReport.TabIndex = 0;
            this.richTextBoxReport.Text = "";
            // 
            // DataInfo
            // 
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelSettings);
            this.Name = "DataInfo";
            this.Size = new System.Drawing.Size(398, 251);
            this.panelSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerCharts.Panel1.ResumeLayout(false);
            this.splitContainerCharts.Panel2.ResumeLayout(false);
            this.splitContainerCharts.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHistogram;
        private System.Windows.Forms.CheckBox checkBoxData;
        private System.Windows.Forms.CheckBox checkBoxStat;


        /// <summary>
        /// Y Values
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
		public TVec Data
        {
            get { return data; }
            set
            {
                data = value;
                Update();
            }
        }

		/// <summary>
		/// X values.
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public TVec xData
		{
			get { return xdata;}
			set
			{
				xdata = value;
				Update();
			}
		}

		public bool ShowStat
		{
			get { return this.checkBoxStat.Checked;}
			set { checkBoxStat.Checked = value;}
		}

		public bool ShowHistogram
		{
			get{ return checkBoxHistogram.Checked; }
			set { checkBoxHistogram.Checked = value; }
		}

		public bool ShowData
		{
			get { return checkBoxData.Checked;}
			set { checkBoxData.Checked = value;}

		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Update();
        }

        private void checkBoxData_CheckedChanged(object sender, EventArgs e)
        {
            splitContainerCharts.Panel1Collapsed = !checkBoxData.Checked;
        }

        private void checkBoxHistogram_CheckedChanged(object sender, EventArgs e)
        {
            splitContainerCharts.Panel2Collapsed = !checkBoxHistogram.Checked;
        }

        private void checkBoxStat_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !checkBoxStat.Checked;
        }
    }
}
