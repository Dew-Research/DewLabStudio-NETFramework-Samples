using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Stats.Units;
using Dew.Math.Editors;
using static Dew.Math.Tee.MtxVecTee;

namespace StatsMasterDemo
{
	public class QCLevey : StatsMasterDemo.BasicForm1
	{
		private Steema.TeeChart.Styles.Line line1;
		private System.ComponentModel.IContainer components = null;
		
		private Vector data;
		private Vector outcont;
		private double m,s;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button1;

		private void Recalc()
		{
			m = data.Mean();
			s = data.StdDev();
			StatControlCharts.QCWestgardRules(data,outcont,m,s);
            DrawValues(data, tChart1.Series[0], 0, 1, false);
		}

		private string DecodeRules(int err)
		{
			string res = "";
			if (((err & 1) == 1)) res += "1S3\n";
			if (((err & 2) == 2)) res += "1S2\n";
			if (((err & 4) == 4)) res += "2S2\n";
			if (((err & 8) == 8)) res += "RS4\n";
			if (((err & 16) == 16)) res += "4S1\n";
			if (((err & 32) == 32)) res += "10X\n";
			return res;
		}

		public QCLevey()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            data = new Vector(0);
			outcont = new Vector(0);
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
			this.line1 = new Steema.TeeChart.Styles.Line();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
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
			this.tChart1.Location = new System.Drawing.Point(216, 100);
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
			this.tChart1.Panel.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.tChart1.Panel.Brush.Gradient.Visible = true;
			// 
			// tChart1.Panel.Gradient
			// 
			this.tChart1.Panel.Gradient.StartColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
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
			this.tChart1.Size = new System.Drawing.Size(440, 325);
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
			this.tChart1.AfterDraw += new Steema.TeeChart.PaintChartEventHandler(this.tChart1_AfterDraw);
			// 
			// line1
			// 
			// 
			// line1.Brush
			// 
			this.line1.Brush.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			// 
			// line1.LinePen
			// 
			this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(115)));
			this.line1.LinePen.Width = 2;
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
			this.line1.Marks.Visible = true;
			// 
			// line1.Pointer
			// 
			// 
			// line1.Pointer.Brush
			// 
			this.line1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.line1.Pointer.HorizSize = 3;
			this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
			this.line1.Pointer.VertSize = 3;
			this.line1.Pointer.Visible = true;
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
			this.line1.GetSeriesMark += new Steema.TeeChart.Styles.Series.GetSeriesMarkEventHandler(this.line1_GetSeriesMark);
			this.line1.GetPointerStyle += new Steema.TeeChart.Styles.CustomPoint.GetPointerStyleEventHandler(this.line1_GetPointerStyle);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(16, 120);
			this.button1.Name = "button1";
			this.button1.TabIndex = 4;
			this.button1.Text = "Edit data";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(16, 160);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Draw mean line";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(16, 192);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(144, 24);
			this.checkBox2.TabIndex = 6;
			this.checkBox2.Text = "Draw sigma lines";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// QCLevey
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(672, 437);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button1);
			this.Name = "QCLevey";
			this.Load += new System.EventHandler(this.QCLevey_Load);
			this.Controls.SetChildIndex(this.button1, 0);
			this.Controls.SetChildIndex(this.checkBox1, 0);
			this.Controls.SetChildIndex(this.checkBox2, 0);
			this.Controls.SetChildIndex(this.panel1, 0);
			this.Controls.SetChildIndex(this.tChart1, 0);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void QCLevey_Load(object sender, System.EventArgs e)
		{
			richTextBox1.Clear();
			Add("The Levey-Jennings control chart is a special case of the common X-bar (variables) chart in which "
				+ "there is only a single stream of data and sigma is estimated using the standard deviation of "
				+ "those data.");
			Add("Individual values are tested to determine if they are in, or out, of control using a set of five "
				+ "rules called the Westgard rules. They are specified in Westgard et al. (1981). These rules "
				+ "indicate which rows in a variable are out-of-control.\n");
			Add("Check http://www.westgard.com/mltirule.htm to learn more about Westgard rules and how to interpret them.");

			data.SetIt(new double[]{248, 250, 255, 243, 254, 260, 251, 261, 253, 244,
									   257 ,254, 239, 236, 250, 259, 260, 262, 263, 254, 241 ,255 ,250,
									   256, 247, 242, 256, 246});
            tChart1.Header.Text = "1S3: One value beyond three sigma from the mean.\n"
                + "1S2: One value beyond two sigma from the mean.\n"
                + "2S2: Two consecutive values either greater than, or less than, two sigma from the mean.\n"
                + "RS4: A difference between consecutive values greater than four sigma.\n"
                + "41S: Four consecutive values greater than, or less than, one sigma from the mean.\n"
                + "10X: Ten consecutive values all greater than, or less than, the mean. ";

			Recalc();

		}

		private void line1_GetPointerStyle(Steema.TeeChart.Styles.CustomPoint series, Steema.TeeChart.Styles.GetPointerStyleEventArgs e)
		{
			e.Style = outcont.Values[e.ValueIndex] > 0 ? Steema.TeeChart.Styles.PointerStyles.Star : Steema.TeeChart.Styles.PointerStyles.DownTriangle;

		}

		private void line1_GetSeriesMark(Steema.TeeChart.Styles.Series series, Steema.TeeChart.Styles.GetSeriesMarkEventArgs e)
		{
			e.MarkText = DecodeRules((int)Math.Round(outcont.Values[e.ValueIndex]));
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			MtxVecEdit.ViewValues(data,"Process data",true,false,true);
			Recalc();
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			tChart1.Invalidate();
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			tChart1.Invalidate();
		}

		private void tChart1_AfterDraw(object sender, Steema.TeeChart.Drawing.Graphics3D g)
		{
			int ypos;
			System.Drawing.Rectangle r = tChart1.Chart.ChartRect;
			g.ClipRectangle(tChart1.Chart.ChartRect);
			if (checkBox1.Checked)
			{
				ypos = tChart1.Axes.Left.CalcPosValue(m);
				g.Pen.Width = 1;
				g.Pen.Color = tChart1.Series[0].Color;
				g.Pen.Style = System.Drawing.Drawing2D.DashStyle.Dot;
				g.HorizontalLine(r.Left,r.Right,ypos);
				g.Font.Color = tChart1.Series[0].Color;
				g.TextOut(r.Left+10,ypos,"mean");

			}

			if (checkBox2.Checked)
			{
				// 1-sigma
				ypos = tChart1.Axes.Left.CalcPosValue(m+s);
				g.Pen.Width = 1;
				g.Pen.Color = Color.Green;
				g.Pen.Style = System.Drawing.Drawing2D.DashStyle.DashDot;
				g.HorizontalLine(r.Left,r.Right,ypos);
				g.Font.Color = Color.Green;
				g.TextOut(r.Left+10,ypos,"1-sigma");
				ypos = tChart1.Axes.Left.CalcPosValue(m-s);
				g.HorizontalLine(r.Left,r.Right,ypos);

				// 2-sigma
				ypos = tChart1.Axes.Left.CalcPosValue(m+2*s);
				g.Pen.Width = 1;
				g.Pen.Color = Color.Orange;
				g.Pen.Style = System.Drawing.Drawing2D.DashStyle.DashDot;
				g.HorizontalLine(r.Left,r.Right,ypos);
				g.Font.Color = Color.Orange;
				g.TextOut(r.Left+10,ypos,"2-sigma");
				ypos = tChart1.Axes.Left.CalcPosValue(m-2*s);
				g.HorizontalLine(r.Left,r.Right,ypos);
				
				// 3-sigma
				ypos = tChart1.Axes.Left.CalcPosValue(m+3*s);
				g.Pen.Width = 1;
				g.Pen.Color = Color.Red;
				g.Pen.Style = System.Drawing.Drawing2D.DashStyle.DashDot;
				g.HorizontalLine(r.Left,r.Right,ypos);
				g.Font.Color = Color.Red;
				g.TextOut(r.Left+10,ypos,"3-sigma");
				ypos = tChart1.Axes.Left.CalcPosValue(m-3*s);
				g.HorizontalLine(r.Left,r.Right,ypos);
			}

			g.UnClip();
		}
	}
}

