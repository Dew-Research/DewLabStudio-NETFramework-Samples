using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MtxVecDemo
{
	public class BenchmarkXForm : MtxVecDemo.BasicForm2
	{
		private System.Windows.Forms.Panel panel4;
		private Steema.TeeChart.TChart tChart1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label3;
		private Steema.TeeChart.Styles.HorizBar bar1;
		private Steema.TeeChart.Styles.HorizBar bar2;
		private Steema.TeeChart.Styles.HorizBar bar3;
		private Steema.TeeChart.Styles.HorizBar bar4;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.ComponentModel.IContainer components = null;

		public BenchmarkXForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			benchmarkFramework = new BenchmarkFramework();
			benchmarkResults = new BenchmarkResults();
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
			benchmarkFramework.Dispose();
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenchmarkXForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.bar2 = new Steema.TeeChart.Styles.HorizBar();
            this.bar4 = new Steema.TeeChart.Styles.HorizBar();
            this.bar3 = new Steema.TeeChart.Styles.HorizBar();
            this.bar1 = new Steema.TeeChart.Styles.HorizBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tChart1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Size = new System.Drawing.Size(736, 373);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 485);
            this.panel3.Size = new System.Drawing.Size(736, 48);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Size = new System.Drawing.Size(736, 112);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkedListBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(136, 373);
            this.panel4.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Location = new System.Drawing.Point(8, 24);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 244);
            this.checkedListBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Functions";
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.ElevationFloat = 345;
            this.tChart1.Aspect.HorizOffset = -533;
            this.tChart1.Aspect.RotationFloat = 345;
            this.tChart1.Aspect.VertOffset = 37;
            this.tChart1.Aspect.View3D = false;
            this.tChart1.Aspect.Zoom = 38;
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
            this.tChart1.Axes.Bottom.Title.Caption = "Time needed [ms]";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            this.tChart1.Axes.Bottom.Title.Lines = new string[] {
        "Time needed [ms]"};
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
            this.tChart1.ContextMenu = this.contextMenu1;
            this.tChart1.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.tChart1.Location = new System.Drawing.Point(136, 0);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.bar2);
            this.tChart1.Series.Add(this.bar4);
            this.tChart1.Series.Add(this.bar3);
            this.tChart1.Series.Add(this.bar1);
            this.tChart1.Size = new System.Drawing.Size(600, 373);
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
            this.tChart1.TabIndex = 1;
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
            this.tChart1.Walls.Bottom.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Visible = false;
            this.tChart1.Walls.Left.Visible = false;
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
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Load from file";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Save to file";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // bar2
            // 
            // 
            // 
            // 
            this.bar2.Brush.Color = System.Drawing.Color.LightCoral;
            // 
            // 
            // 
            this.bar2.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar2.Gradient.Transparency = 100;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.bar2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.bar2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.bar2.Marks.Callout.Distance = 0;
            this.bar2.Marks.Callout.Draw3D = false;
            this.bar2.Marks.Callout.Length = 20;
            this.bar2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar2.Marks.Font.Shadow.Visible = false;
            this.bar2.Marks.Visible = false;
            this.bar2.Title = "Complex Math387";
            // 
            // 
            // 
            this.bar2.XValues.DataMember = "X";
            // 
            // 
            // 
            this.bar2.YValues.DataMember = "Bar";
            this.bar2.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // bar4
            // 
            // 
            // 
            // 
            this.bar4.Brush.Color = System.Drawing.Color.LightSteelBlue;
            // 
            // 
            // 
            this.bar4.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar4.Gradient.Transparency = 100;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.bar4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.bar4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.bar4.Marks.Callout.Distance = 0;
            this.bar4.Marks.Callout.Draw3D = false;
            this.bar4.Marks.Callout.Length = 20;
            this.bar4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar4.Marks.Font.Shadow.Visible = false;
            this.bar4.Marks.Visible = false;
            this.bar4.Title = "Complex MtxVec";
            // 
            // 
            // 
            this.bar4.XValues.DataMember = "X";
            // 
            // 
            // 
            this.bar4.YValues.DataMember = "Bar";
            this.bar4.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // bar3
            // 
            // 
            // 
            // 
            this.bar3.Brush.Color = System.Drawing.Color.Blue;
            // 
            // 
            // 
            this.bar3.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar3.Gradient.Transparency = 100;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.bar3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.bar3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.bar3.Marks.Callout.Distance = 0;
            this.bar3.Marks.Callout.Draw3D = false;
            this.bar3.Marks.Callout.Length = 20;
            this.bar3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.bar3.Marks.Font.Shadow.Visible = false;
            this.bar3.Marks.Visible = false;
            this.bar3.Title = "Sample Math387";
            // 
            // 
            // 
            this.bar3.XValues.DataMember = "X";
            // 
            // 
            // 
            this.bar3.YValues.DataMember = "Bar";
            this.bar3.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // bar1
            // 
            // 
            // 
            // 
            this.bar1.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.bar1.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.bar1.Gradient.Transparency = 100;
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
            this.bar1.Title = "Sample MtxVec";
            // 
            // 
            // 
            this.bar1.XValues.DataMember = "X";
            // 
            // 
            // 
            this.bar1.YValues.DataMember = "Bar";
            this.bar1.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(284, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vector length";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(360, 8);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(556, 8);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.DoubleClick += new System.EventHandler(this.numericUpDown2_DoubleClick);
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(438, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Iterations (DblClick)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.Filter = "Benchmark files(*.dat)|*.dat|All files(*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Save benchmark results";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dat";
            this.saveFileDialog1.Filter = "Benchmark files(*.dat)|*.dat|All files(*.*)|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save benchmark results";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(92, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Open";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(176, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Save";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BenchmarkXForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 533);
            this.Name = "BenchmarkXForm";
            this.Load += new System.EventHandler(this.BenchmarkXForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		BenchmarkFramework benchmarkFramework;
		BenchmarkResults benchmarkResults;

		private void BenchmarkXForm_Load(object sender, System.EventArgs e) {
			Add("These benchmarks compare vectorized and not vectorized " +
				"versions of real and complex versions of basic math functions. " +
				"The vectorized versions are labeled with MtxVec and the non-vectorized "+
				"versions are labeled with Math387.");
			Add("");
			Add("The non-vectorized real and complex versions " +
				"are written in assembler for maximum performance. "+
				"Despite this, the vectorized versions are substantially faster. "+
				"Before running the tests double click on the iterations combobox. " +
				"That will compute the number of iterations that have to be performed " +
				"to get sufficiently long timings. The resolution of the timings is " +
				"about 15ms.");

			loadFuncListBox();
			numericUpDown1_ValueChanged(null,null);
			numericUpDown2_ValueChanged(null,null);
		}

		private void loadFuncListBox() {
			checkedListBox1.BeginUpdate();
			try {
				checkedListBox1.Items.Clear();
				for (int i=0;i<benchmarkFramework.FuncCount;i++) {
					checkedListBox1.Items.Add(benchmarkFramework.GetFuncName(i),true);
				}
			} finally {
				checkedListBox1.EndUpdate();
			}
		}

		private void numericUpDown2_DoubleClick(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				numericUpDown2.Value = benchmarkFramework.RecalcIterationCount();
			} finally {
				this.Cursor = Cursors.Default;
			}
		}

		private void numericUpDown2_ValueChanged(object sender, System.EventArgs e) {
			benchmarkFramework.IterationCount = (int)numericUpDown2.Value;
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e) {
			benchmarkFramework.VectorLength = (int)numericUpDown1.Value;
		}

		private void button1_Click(object sender, System.EventArgs e) {
			this.Cursor = Cursors.WaitCursor;
			try {
				benchmarkResults.Clear();
				foreach (String s in checkedListBox1.CheckedItems) {
					benchmarkFramework.Run(s,benchmarkResults);
				}
				benchmarkResults.Title = String.Format(".NET: Length:{0} Count: {1}",
					benchmarkFramework.VectorLength,benchmarkFramework.IterationCount);
				showResults(benchmarkResults);
			} finally {
				this.Cursor = Cursors.Default;
			}
		}
		
		private void showResults(BenchmarkResults results) {
			bar1.Clear();
			bar2.Clear();
			bar3.Clear();
			bar4.Clear();
			tChart1.Header.Text = results.Title;
			tChart1.Header.Visible = true;
			for (int i=results.Count-1;i>=0;i--) {
				bar1.Add(results[i].SmplVecTicks,results[i].FuncName);
				bar4.Add(results[i].CplxVecTicks,results[i].FuncName);
				bar3.Add(results[i].SmplFuncTicks,results[i].FuncName);
				bar2.Add(results[i].CplxFuncTicks,results[i].FuncName);
			}
			tChart1.Update();

		}
		private void loadFile() {
			if (openFileDialog1.ShowDialog()==DialogResult.OK) {
				BenchmarkResults results = BenchmarkResults.LoadFromFile(openFileDialog1.FileName);
				showResults(results);
			}
		}

		private void saveFile()
		{
			if (saveFileDialog1.ShowDialog()==DialogResult.OK) 
			{
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e) {
			loadFile();
		}

		private void menuItem2_Click(object sender, System.EventArgs e) {
			if (saveFileDialog1.ShowDialog()==DialogResult.OK) {
				benchmarkResults.SaveToFile(saveFileDialog1.FileName);
			}
		}

		private void button2_Click(object sender, System.EventArgs e) {
			loadFile();
		}

		private void tChart1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
		
		}

	}
}

