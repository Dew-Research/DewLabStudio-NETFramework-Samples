using System;
using System.Globalization;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dew.Math;
using Dew.Math.Units;
using Dew.Controls;
using Dew.Controls.Units;

namespace MtxVecDemo
{
	public class ProbabilitiesForm : MtxVecDemo.BasicForm2
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Panel panel4;
		private Steema.TeeChart.TChart tChart1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton9;
		private System.Windows.Forms.RadioButton radioButton10;
		private System.Windows.Forms.RadioButton radioButton11;
		private System.Windows.Forms.RadioButton radioButton12;
		private System.Windows.Forms.RadioButton radioButton13;
		private System.Windows.Forms.RadioButton radioButton14;
		private System.Windows.Forms.RadioButton radioButton15;
		private System.Windows.Forms.RadioButton radioButton16;
		private System.Windows.Forms.RadioButton radioButton17;
		private System.Windows.Forms.RadioButton radioButton18;
		private System.Windows.Forms.RadioButton radioButton19;
		private System.Windows.Forms.RadioButton radioButton20;
		private System.Windows.Forms.RadioButton radioButton21;
		private System.Windows.Forms.RadioButton radioButton22;
		private System.Windows.Forms.RadioButton radioButton23;
		private System.Windows.Forms.RadioButton radioButton24;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label labelDecimals;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label labelx;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private Steema.TeeChart.Styles.Line series1;
		private Steema.TeeChart.Styles.Line series2;
		private System.ComponentModel.IContainer components = null;

		public ProbabilitiesForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			xVec = new TVec();
			pdfVec = new TVec();
			cdfVec = new TVec();
			format = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
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
			xVec.Free();
			pdfVec.Free();
			cdfVec.Free();
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.radioButton13 = new System.Windows.Forms.RadioButton();
			this.radioButton14 = new System.Windows.Forms.RadioButton();
			this.radioButton15 = new System.Windows.Forms.RadioButton();
			this.radioButton16 = new System.Windows.Forms.RadioButton();
			this.radioButton17 = new System.Windows.Forms.RadioButton();
			this.radioButton18 = new System.Windows.Forms.RadioButton();
			this.radioButton19 = new System.Windows.Forms.RadioButton();
			this.radioButton20 = new System.Windows.Forms.RadioButton();
			this.radioButton21 = new System.Windows.Forms.RadioButton();
			this.radioButton22 = new System.Windows.Forms.RadioButton();
			this.radioButton23 = new System.Windows.Forms.RadioButton();
			this.radioButton24 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.labelx = new System.Windows.Forms.Label();
			this.labelDecimals = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tChart1 = new Steema.TeeChart.TChart();
			this.series1 = new Steema.TeeChart.Styles.Line();
			this.series2 = new Steema.TeeChart.Styles.Line();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox1.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tChart1);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(616, 349);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Location = new System.Drawing.Point(0, 461);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(616, 48);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(616, 112);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Calc probability";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(120, 8);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Calc x";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.trackBar1);
			this.panel4.Controls.Add(this.checkBox1);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.textBox1);
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.textBox2);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.textBox3);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.textBox6);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Controls.Add(this.textBox5);
			this.panel4.Controls.Add(this.labelx);
			this.panel4.Controls.Add(this.labelDecimals);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.textBox4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(616, 272);
			this.panel4.TabIndex = 0;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(272, 128);
			this.trackBar1.Maximum = 16;
			this.trackBar1.Minimum = 2;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(160, 42);
			this.trackBar1.TabIndex = 4;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			this.trackBar1.Value = 8;
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(128, 208);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Show PDF(x)";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "a; a > 0";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 128);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton7);
			this.groupBox1.Controls.Add(this.radioButton8);
			this.groupBox1.Controls.Add(this.radioButton9);
			this.groupBox1.Controls.Add(this.radioButton10);
			this.groupBox1.Controls.Add(this.radioButton11);
			this.groupBox1.Controls.Add(this.radioButton12);
			this.groupBox1.Controls.Add(this.radioButton13);
			this.groupBox1.Controls.Add(this.radioButton14);
			this.groupBox1.Controls.Add(this.radioButton15);
			this.groupBox1.Controls.Add(this.radioButton16);
			this.groupBox1.Controls.Add(this.radioButton17);
			this.groupBox1.Controls.Add(this.radioButton18);
			this.groupBox1.Controls.Add(this.radioButton19);
			this.groupBox1.Controls.Add(this.radioButton20);
			this.groupBox1.Controls.Add(this.radioButton21);
			this.groupBox1.Controls.Add(this.radioButton22);
			this.groupBox1.Controls.Add(this.radioButton23);
			this.groupBox1.Controls.Add(this.radioButton24);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(608, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Distribution";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Beta";
			this.radioButton1.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 32);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 16);
			this.radioButton2.TabIndex = 0;
			this.radioButton2.Text = "Binomial";
			this.radioButton2.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(8, 48);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(104, 16);
			this.radioButton3.TabIndex = 0;
			this.radioButton3.Text = "Cauchy";
			this.radioButton3.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(8, 64);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(104, 16);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.Text = "Chi2";
			this.radioButton4.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(8, 80);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(104, 16);
			this.radioButton5.TabIndex = 0;
			this.radioButton5.Text = "Exponential";
			this.radioButton5.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(128, 16);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(104, 16);
			this.radioButton6.TabIndex = 0;
			this.radioButton6.Text = "F (Fischer)";
			this.radioButton6.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(128, 32);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(104, 16);
			this.radioButton7.TabIndex = 0;
			this.radioButton7.Text = "Gamma";
			this.radioButton7.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton8
			// 
			this.radioButton8.Checked = true;
			this.radioButton8.Location = new System.Drawing.Point(128, 48);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(104, 16);
			this.radioButton8.TabIndex = 0;
			this.radioButton8.TabStop = true;
			this.radioButton8.Text = "Geometric";
			this.radioButton8.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton9
			// 
			this.radioButton9.Location = new System.Drawing.Point(128, 64);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(104, 16);
			this.radioButton9.TabIndex = 0;
			this.radioButton9.Text = "Hypergeometric";
			this.radioButton9.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton10
			// 
			this.radioButton10.Location = new System.Drawing.Point(128, 80);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(104, 16);
			this.radioButton10.TabIndex = 0;
			this.radioButton10.Text = "Laplace";
			this.radioButton10.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton11
			// 
			this.radioButton11.Location = new System.Drawing.Point(248, 16);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(104, 16);
			this.radioButton11.TabIndex = 0;
			this.radioButton11.Text = "Logistic";
			this.radioButton11.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton12
			// 
			this.radioButton12.Location = new System.Drawing.Point(248, 32);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.Size = new System.Drawing.Size(104, 16);
			this.radioButton12.TabIndex = 0;
			this.radioButton12.Text = "LogNormal";
			this.radioButton12.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton13
			// 
			this.radioButton13.Location = new System.Drawing.Point(248, 48);
			this.radioButton13.Name = "radioButton13";
			this.radioButton13.Size = new System.Drawing.Size(104, 16);
			this.radioButton13.TabIndex = 0;
			this.radioButton13.Text = "LogWeibull";
			this.radioButton13.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton14
			// 
			this.radioButton14.Location = new System.Drawing.Point(248, 64);
			this.radioButton14.Name = "radioButton14";
			this.radioButton14.Size = new System.Drawing.Size(104, 16);
			this.radioButton14.TabIndex = 0;
			this.radioButton14.Text = "Maxwell";
			this.radioButton14.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton15
			// 
			this.radioButton15.Location = new System.Drawing.Point(248, 80);
			this.radioButton15.Name = "radioButton15";
			this.radioButton15.Size = new System.Drawing.Size(112, 16);
			this.radioButton15.TabIndex = 0;
			this.radioButton15.Text = "Negative binomial";
			this.radioButton15.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton16
			// 
			this.radioButton16.Location = new System.Drawing.Point(368, 16);
			this.radioButton16.Name = "radioButton16";
			this.radioButton16.Size = new System.Drawing.Size(104, 16);
			this.radioButton16.TabIndex = 0;
			this.radioButton16.Text = "Normal";
			this.radioButton16.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton17
			// 
			this.radioButton17.Location = new System.Drawing.Point(368, 32);
			this.radioButton17.Name = "radioButton17";
			this.radioButton17.Size = new System.Drawing.Size(104, 16);
			this.radioButton17.TabIndex = 0;
			this.radioButton17.Text = "Pareto";
			this.radioButton17.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton18
			// 
			this.radioButton18.Location = new System.Drawing.Point(368, 48);
			this.radioButton18.Name = "radioButton18";
			this.radioButton18.Size = new System.Drawing.Size(104, 16);
			this.radioButton18.TabIndex = 0;
			this.radioButton18.Text = "Poisson";
			this.radioButton18.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton19
			// 
			this.radioButton19.Location = new System.Drawing.Point(368, 64);
			this.radioButton19.Name = "radioButton19";
			this.radioButton19.Size = new System.Drawing.Size(104, 16);
			this.radioButton19.TabIndex = 0;
			this.radioButton19.Text = "Student (t)";
			this.radioButton19.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton20
			// 
			this.radioButton20.Location = new System.Drawing.Point(368, 80);
			this.radioButton20.Name = "radioButton20";
			this.radioButton20.Size = new System.Drawing.Size(104, 16);
			this.radioButton20.TabIndex = 0;
			this.radioButton20.Text = "Rayleigh";
			this.radioButton20.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton21
			// 
			this.radioButton21.Location = new System.Drawing.Point(488, 16);
			this.radioButton21.Name = "radioButton21";
			this.radioButton21.Size = new System.Drawing.Size(104, 16);
			this.radioButton21.TabIndex = 0;
			this.radioButton21.Text = "Triangular";
			this.radioButton21.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton22
			// 
			this.radioButton22.Location = new System.Drawing.Point(488, 32);
			this.radioButton22.Name = "radioButton22";
			this.radioButton22.Size = new System.Drawing.Size(120, 16);
			this.radioButton22.TabIndex = 0;
			this.radioButton22.Text = "Uniform continuous";
			this.radioButton22.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton23
			// 
			this.radioButton23.Location = new System.Drawing.Point(488, 48);
			this.radioButton23.Name = "radioButton23";
			this.radioButton23.Size = new System.Drawing.Size(112, 16);
			this.radioButton23.TabIndex = 0;
			this.radioButton23.Text = "Uniform discrete";
			this.radioButton23.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// radioButton24
			// 
			this.radioButton24.Location = new System.Drawing.Point(488, 64);
			this.radioButton24.Name = "radioButton24";
			this.radioButton24.Size = new System.Drawing.Size(104, 16);
			this.radioButton24.TabIndex = 0;
			this.radioButton24.Text = "Weibull";
			this.radioButton24.Click += new System.EventHandler(this.radioButton20_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 152);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "b; b > 0";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 168);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "x";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 208);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 1;
			this.textBox3.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(128, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "CDF ( <= x)";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(128, 168);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 1;
			this.textBox6.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(128, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "PDF ( = x)";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 128);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.TabIndex = 1;
			this.textBox5.Text = "";
			// 
			// labelx
			// 
			this.labelx.Location = new System.Drawing.Point(272, 112);
			this.labelx.Name = "labelx";
			this.labelx.Size = new System.Drawing.Size(104, 16);
			this.labelx.TabIndex = 2;
			this.labelx.Text = "Decimals";
			// 
			// labelDecimals
			// 
			this.labelDecimals.Location = new System.Drawing.Point(440, 144);
			this.labelDecimals.Name = "labelDecimals";
			this.labelDecimals.Size = new System.Drawing.Size(64, 16);
			this.labelDecimals.TabIndex = 2;
			this.labelDecimals.Text = "0";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 232);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "x";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 248);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 1;
			this.textBox4.Text = "";
			// 
			// tChart1
			// 
			// 
			// tChart1.Aspect
			// 
			this.tChart1.Aspect.View3D = false;
			this.tChart1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// tChart1.Header
			// 
			this.tChart1.Header.Lines = new string[] {
																								 "TeeChart"};
			this.tChart1.Header.Visible = false;
			this.tChart1.Location = new System.Drawing.Point(0, 272);
			this.tChart1.Name = "tChart1";
			this.tChart1.Series.Add(this.series1);
			this.tChart1.Series.Add(this.series2);
			this.tChart1.Size = new System.Drawing.Size(616, 77);
			this.tChart1.TabIndex = 1;
			// 
			// series1
			// 
			// 
			// series1.Brush
			// 
			this.series1.Brush.Color = System.Drawing.Color.RoyalBlue;
			// 
			// series1.LinePen
			// 
			this.series1.LinePen.Width = 2;
			// 
			// series1.Pointer
			// 
			this.series1.Pointer.Dark3D = false;
			this.series1.Pointer.Draw3D = false;
			this.series1.Pointer.HorizSize = 2;
			this.series1.Pointer.InflateMargins = false;
			this.series1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
			this.series1.Pointer.VertSize = 2;
			this.series1.Pointer.Visible = true;
			this.series1.Title = "PDF";
			// 
			// series2
			// 
			// 
			// series2.Brush
			// 
			this.series2.Brush.Color = System.Drawing.Color.DarkOrange;
			// 
			// series2.Pointer
			// 
			this.series2.Pointer.Dark3D = false;
			this.series2.Pointer.Draw3D = false;
			this.series2.Pointer.HorizSize = 2;
			this.series2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Diamond;
			this.series2.Pointer.VertSize = 2;
			this.series2.Pointer.Visible = true;
			this.series2.Title = "CDF";
			this.series2.VertAxis = Steema.TeeChart.Styles.VerticalAxis.Right;
			// 
			// ProbabilitiesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 509);
			this.Name = "ProbabilitiesForm";
			this.Load += new System.EventHandler(this.ProbabilitiesForm_Load);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox1.ResumeLayout(false);

		}
		#endregion

		private int decimals;
		private NumberFormatInfo format;
		TVec xVec,pdfVec,cdfVec;

		private void trackBar1_ValueChanged(object sender, System.EventArgs e) {
			decimals = trackBar1.Value;
			format.NumberDecimalDigits = decimals;
			labelDecimals.Text = decimals.ToString();

		}

		private void ProbabilitiesForm_Load(object sender, System.EventArgs e) {
			Add("The Probabilities unit introduces 24 most commonly "
				+ "used distributions. You can calculate \"Probability "
				+ "density function\" (PDF), \"Cumulative distribution function\" "
				+ "(CDF) and inverse \"Cumulative distribution function\" "
				+ "(InvCDF) for 7 discrete and 17 continuous distributions. "
				+ "Try changing distribution, distribution parameters and/or resulting CDF.");
			Add("");
			richTextBox1.SelectionFont = new Font (
				richTextBox1.SelectionFont.Name,
				richTextBox1.SelectionFont.Size,
				FontStyle.Underline);
			Add("NOTE :");
			Add("\"Calc  probability\" button will use distribution parameters "
				+ "to calculate PDF and CDF. The \"Calc x\" button will use CDF "
				+ "(must lie in the interval [0,1]) to calculate the x value of a "
				+ "given distribution. ");

			xVec.Size(100);
			trackBar1_ValueChanged(null,null);
			radioButton20_Click(null,null);
		}

		private void radioButton20_Click(object sender, System.EventArgs e) {
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			#region radioBut
			if (radioButton1.Checked) { //BETA distribution
				label1.Text = "a; a > 0";
				label2.Text = "b; b > 0";
				label3.Text = "x";
				textBox1.Text = 0.25.ToString("F",format);
				textBox2.Text = 0.75.ToString("F",format);
				textBox3.Text = 0.5.ToString("F",format);
				label1.Visible = true;
				textBox1.Visible = true;
				label2.Visible = true;
				textBox2.Visible = true;
				label3.Visible = true;
				textBox3.Visible = true;
				label4.Visible = false;
				textBox4.Visible = false;
			} else if (radioButton2.Checked) { // BINOMIAL distribution
           label1.Text = "n; n > 0";
           label2.Text = "p; p = [0,1]";
           label3.Text = "x";
           textBox1.Text = "4";
           textBox2.Text = 0.75.ToString("F",format);
           textBox3.Text = "3";
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton3.Checked) { // Cauchy distribution
           label1.Text = "m; m <> x";
           label2.Text = "b; b <> 0";
           label3.Text = "x";
           textBox1.Text = 1.5.ToString("F",format);
           textBox2.Text = 2.12.ToString("F",format);
           textBox3.Text = 3.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton4.Checked) { // Chi-squared distribution
           label1.Text = "Nu; Nu > 0";
           label2.Text = "x";
           textBox1.Text = "5";
           textBox2.Text = 1.2.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton5.Checked) { // Exponential distribution
           label1.Text = "Mu; Mu > 0";
           label2.Text = "x";
           textBox1.Text = 0.95.ToString("F",format);
           textBox2.Text = 3.25.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton6.Checked) { // F distribution
           label1.Text = "Nu1; Nu1 > 0";
           label2.Text = "Nu2; Nu2 > 0";
           label3.Text = "x";
           textBox1.Text = "7";
           textBox2.Text = "3";
           textBox3.Text = 0.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton7.Checked) { // Gamma distribution
           label1.Text = "a; a > 0";
           label2.Text = "b; b > 0";
           label3.Text = "x";
           textBox1.Text = 1.95.ToString("F",format);
           textBox2.Text = 5.ToString("F",format);
           textBox3.Text = 0.32.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton8.Checked) { // Geometric distribution
           label1.Text = "p; p =[0,1]";
           label2.Text = "x";
           textBox1.Text = 0.15.ToString("F",format);
           textBox2.Text = 2.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton9.Checked) { // Hypergeometric distribution
           label1.Text = "M; M >= K,N";
           label2.Text = "K;K >= x";
           label3.Text = "N; N >= x";
           label4.Text = "x";
           textBox1.Text = "10";
           textBox2.Text = "6";
           textBox3.Text = "5";
           textBox4.Text = 2.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = true;
           textBox4.Visible = true;
			} else if (radioButton10.Checked) { // Laplace
           label1.Text = "m";
           label2.Text = "b";
           label3.Text = "x";
           textBox1.Text = 3.ToString("F",format);
           textBox2.Text = 1.ToString("F",format);
           textBox3.Text = 0.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton11.Checked) { // Logistic
           label1.Text = "m";
           label2.Text = "b";
           label3.Text = "x";
           textBox1.Text = 3.ToString("F",format);
           textBox2.Text = 1.ToString("F",format);
           textBox3.Text = 0.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton12.Checked) { // Log-Normal distribution
           label1.Text = "Mu";
           label2.Text = "Sigma; Sigma > 0";
           label3.Text = "x";
           textBox1.Text = 3.ToString("F",format);
           textBox2.Text = 1.ToString("F",format);
           textBox3.Text = 0.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton13.Checked) { // Log-Weibull distribution
           label1.Text = "a; a>0";
           label2.Text = "b; b>0";
           label3.Text = "x";
           textBox1.Text = 3.ToString("F",format);
           textBox2.Text = 1.ToString("F",format);
           textBox3.Text = 0.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton14.Checked) { // Maxwell distribution
           label1.Text = "a; a > 0";
           label2.Text = "x";
           textBox1.Text = 0.95.ToString("F",format);
           textBox2.Text = 1.2.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton15.Checked) { // Negative binomial distribution
           label1.Text = "R; R > 1";
           label2.Text = "p; P =[0,1]";
           label3.Text = "x";
           textBox1.Text = "5";
           textBox2.Text = 0.75.ToString("F",format);
           textBox3.Text = 2.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton16.Checked) { // Normal distribution
           label1.Text = "Mu";
           label2.Text = "Sigma; Sigma > 0";
           label3.Text = "x";
           textBox1.Text = 0.ToString("F",format);
           textBox2.Text = 1.ToString("F",format);
           textBox3.Text = 1.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton17.Checked) { // Pareto distribution
           label1.Text = "a";
           label2.Text = "b; b < x";
           label3.Text = "x";
           textBox1.Text = 1.1.ToString("F",format);
           textBox2.Text = 0.3.ToString("F",format);
           textBox3.Text = 2.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton18.Checked) { // Poisson distribution
           label1.Text = "Lambda; Lambda > 0";
           label2.Text = "x";
           label1.Visible = true;
           textBox1.Text = 13.2.ToString("F",format);
           textBox2.Text = 7.ToString("F",format);
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton19.Checked) { // Student distribution
           label1.Text = "Nu; Nu > 1";
           label2.Text = "x";
           textBox1.Text = "3";
           textBox2.Text = 5.5.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton20.Checked) { // Rayleigh distribution
           label1.Text = "b; b > 0";
           label2.Text = "x; x >= 0";
           label1.Visible = true;
           textBox1.Text = 1.0.ToString("F",format);
           textBox2.Text = 3.2.ToString("F",format);
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton21.Checked) { // Triangular
           label1.Text = "a; a<=x<=b";
           label2.Text = "b;";
           label3.Text = "c; a<=c<=b";
           label4.Text = "x";
           textBox1.Text = 1.3.ToString("F",format);
           textBox2.Text = 5.4.ToString("F",format);
           textBox3.Text = 3.3.ToString("F",format);
           textBox4.Text = 4.2.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = true;
           textBox4.Visible = true;
			} else if (radioButton22.Checked) { // Uniform distribution
           label1.Text = "a; a < b";
           label2.Text = "b; b > a";
           label3.Text = "x";
           textBox1.Text = (-3).ToString("F",format);
           textBox2.Text = 5.ToString("F",format);
           textBox3.Text = 1.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton23.Checked) { // Discrete uniform distribution
           label1.Text = "N; N > 1";
           label2.Text = "x";
           textBox1.Text = "5";
           textBox2.Text = 3.1.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = false;
           textBox3.Visible = false;
           label4.Visible = false;
           textBox4.Visible = false;
			} else if (radioButton24.Checked) { // Weibull distribution 
           label1.Text = "a; a > 0";
           label2.Text = "b; b > 0";
           label3.Text = "x";
           textBox1.Text = 0.75.ToString("F",format);
           textBox2.Text = 2.5.ToString("F",format);
           textBox3.Text = 1.25.ToString("F",format);
           label1.Visible = true;
           textBox1.Visible = true;
           label2.Visible = true;
           textBox2.Visible = true;
           label3.Visible = true;
           textBox3.Visible = true;
           label4.Visible = false;
           textBox4.Visible = false;
			} 
			#endregion
		}

		private void button1_Click(object sender, System.EventArgs e) {
			double s1,s2,s3,s4;
			double RPDF,RCDF;
			int i1,i2,i3;
			RPDF = 0;
			RCDF = 0;
			#region radioBut
			if (radioButton1.Checked) { // BETA
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.BetaPDF(s3,s1,s2);
				RCDF = Probabilities.BetaCDF(s3,s1,s2);
				if (checkBox1.Checked) {
					xVec.Ramp(0.01,0.0099);
					Probabilities.BetaPDF(xVec,s1,s2,pdfVec);
					Probabilities.BetaCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton2.Checked) { // BINOMIAL
				i1 = Int32.Parse(textBox1.Text); // N
				s2 = Double.Parse(textBox2.Text); // p
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.BinomPDF(s3,i1,s2);
				RCDF = Probabilities.BinomCDF(s3,i1,s2);
				if (checkBox1.Checked) {
					xVec.Ramp(0,i1*0.01);
					Probabilities.BinomPDF(xVec,i1,s2,pdfVec);
					Probabilities.BinomCDF(xVec,i1,s2,cdfVec);
				}

			} else if (radioButton3.Checked) { // Cauchy
				s1 = Double.Parse(textBox1.Text); // b
				s2 = Double.Parse(textBox2.Text); // m
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.CauchyPDF(s3,s1,s2);
				RCDF = Probabilities.CauchyCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0,0.1);
					Probabilities.CauchyPDF(xVec,s1,s2,pdfVec);
					Probabilities.CauchyCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton4.Checked) { // CHI2
				i1 = Int32.Parse(textBox1.Text); // nu
				s1 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.ChiSquarePDF(s1,i1);
				RCDF = Probabilities.ChiSquareCDF(s1,i1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(1*0.02,s1*0.05);
					Probabilities.ChiSquarePDF(xVec,i1,pdfVec);
					Probabilities.ChiSquareCDF(xVec,i1,cdfVec);
				}

			} else if (radioButton5.Checked) { // Exponential
				s1 = Double.Parse(textBox1.Text); // Mu
				s2 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.ExpPDF(s2,s1);
				RCDF = Probabilities.ExpCDF(s2,s1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0,s1*0.05);
					Probabilities.ExpPDF(xVec,s1,pdfVec);
					Probabilities.ExpCDF(xVec,s1,cdfVec);
				}
			} else if (radioButton6.Checked) { // F - Fisher
				i1 = Int32.Parse(textBox1.Text); // Nu1
				i2 = Int32.Parse(textBox2.Text); // Nu2
				s1 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.FPDF(s1,i1,i2);
				RCDF = Probabilities.FCDF(s1,i1,i2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp();
					Probabilities.FPDF(xVec,i1,i2,pdfVec);
					Probabilities.FCDF(xVec,i1,i2,cdfVec);
				}
			} else if (radioButton7.Checked) { // GAMMA
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.GammaPDF(s3,s1,s2);
				RCDF =Probabilities.GammaCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0.02,0.2);
					Probabilities.GammaPDF(xVec,s1,s2,pdfVec);
					Probabilities.GammaCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton8.Checked) { // Geometric
				s1 = Double.Parse(textBox1.Text); // p
				s2 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.GeometricPDF(s2,s1);
				RCDF = Probabilities.GeometricCDF(s2,s1);
				if (checkBox1.Checked) {
					xVec.Ramp();
					Probabilities.GeometricPDF(xVec,s1,pdfVec);
					Probabilities.GeometricCDF(xVec,s1,cdfVec);
				}
			} else if (radioButton9.Checked) { // Hypergeometric
				i1 = Int32.Parse(textBox1.Text); //M
				i2 = Int32.Parse(textBox2.Text); //K
				i3 = Int32.Parse(textBox3.Text); //N
				s1 = Double.Parse(textBox4.Text); // x
				RPDF = Probabilities.HypGeometricPDF(s1,i1,i2,i3);
				RCDF = Probabilities.HypGeometricCDF(s1,i1,i2,i3);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0,Math387.Min(i2,i3)*0.01);
					Probabilities.HypGeometricPDF(xVec,i1,i2,i3,pdfVec);
					Probabilities.HypGeometricCDF(xVec,i1,i2,i3,cdfVec);
				}
			} else if (radioButton10.Checked) { // Laplace
				s1 = Double.Parse(textBox1.Text); // m
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.LaplacePDF(s3,s1,s2);
				RCDF = Probabilities.LaplaceCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(-s2,s2*0.1);
					Probabilities.LaplacePDF(xVec,s1,s2,pdfVec);
					Probabilities.LaplaceCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton11.Checked) { // Logistic
				s1 = Double.Parse(textBox1.Text); // m
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.LogisticPDF(s3,s1,s2);
				RCDF = Probabilities.LogisticCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0.01,s2*0.1);
					Probabilities.LogisticPDF(xVec,s1,s2,pdfVec);
					Probabilities.LogisticCDF(xVec,s1,s2,cdfVec);
				}

			} else if (radioButton12.Checked) { // Log-Normal
				s1 = Double.Parse(textBox1.Text); // mu
				s2 = Double.Parse(textBox2.Text); // sigma
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.LogNormalPDF(s3,s1,s2);
				RCDF = Probabilities.LogNormalCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0.01,s2*0.1);
					Probabilities.LogNormalPDF(xVec,s1,s2,pdfVec);
					Probabilities.LogNormalCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton13.Checked) { // Log-Weibull
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.LogWeibullPDF(s3,s1,s2);
				RCDF = Probabilities.LogWeibullCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(-5*s2+s1,s2*0.1);
					Probabilities.LogWeibullPDF(xVec,s1,s2,pdfVec);
					Probabilities.LogWeibullCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton14.Checked) { // Maxwell
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.MaxwellPDF(s2,s1);
				RCDF = Probabilities.MaxwellCDF(s2,s1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0,s2*0.05);
					Probabilities.MaxwellPDF(xVec,s1,pdfVec);
					Probabilities.MaxwellCDF(xVec,s1,cdfVec);
				}
			} else if (radioButton15.Checked) { // Negative binomial
				i1 = Int32.Parse(textBox1.Text); //R
				s1 = Double.Parse(textBox2.Text); // p
				s2 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.NegBinomPDF(s2,i1,s1);
				RCDF = Probabilities.NegBinomCDF(s2,i1,s1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0,0.02*i1);
					Probabilities.NegBinomPDF(xVec,i1,s1,pdfVec);
				}
			} else if (radioButton16.Checked) { // Normal
				s1 = Double.Parse(textBox1.Text); // mu
				s2 = Double.Parse(textBox2.Text); // sigma
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.NormalPDF(s3,s1,s2);
				RCDF = Probabilities.NormalCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(s1-10*s2,0.2*s2);
					Probabilities.NormalPDF(xVec,s1,s2,pdfVec);
					Probabilities.NormalCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton17.Checked) { //	Pareto
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.ParetoPDF(s3,s1,s2);
				RCDF = Probabilities.ParetoCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(s2+0.1,0.1);
					Probabilities.ParetoPDF(xVec,s1,s2,pdfVec);
					Probabilities.ParetoCDF(xVec,s1,s2,cdfVec);
				}
			} else if (radioButton18.Checked) { // Poisson
				s1 = Double.Parse(textBox1.Text); // lambda
				i1 = Int32.Parse(textBox2.Text); // x
				RPDF = Probabilities.PoissonPDF(i1,s1);
				RCDF = Probabilities.PoissonCDF(i1,s1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp();
					Probabilities.PoissonPDF(xVec,s1,pdfVec);
					Probabilities.PoissonCDF(xVec,s1,cdfVec);
				}
			} else if (radioButton19.Checked) { // Student
				i1 = Int32.Parse(textBox1.Text); // NU
				s1 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.StudentPDF(s1,i1);
				RCDF = Probabilities.StudentCDF(s1,i1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(-3*i1,0.06*i1);
					Probabilities.StudentPDF(xVec,i1,pdfVec);
					Probabilities.StudentCDF(xVec,i1,cdfVec);
				}
			} else if (radioButton20.Checked) { // Rayleigh
				s1 = Double.Parse(textBox1.Text); // b
				s2 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.RayleighPDF(s2,s1);
				RCDF = Probabilities.RayleighCDF(s2,s1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0.1,s2*0.05);
					Probabilities.RayleighPDF(xVec,s1,pdfVec);
					Probabilities.RayleighCDF(xVec,s1,cdfVec);
				}
			} else if (radioButton21.Checked) { // Trangular
				s1 = Double.Parse(textBox1.Text); //a
				s2 = Double.Parse(textBox2.Text); //b
				s3 = Double.Parse(textBox3.Text); //c
				s4 = Double.Parse(textBox4.Text); // x
				RPDF = Probabilities.TriangularPDF(s4,s1,s2,s3);
				RCDF = Probabilities.TriangularCDF(s4,s1,s2,s3);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(s1-1,(s2-s1+2)*0.01);
					Probabilities.TriangularPDF(xVec,s1,s2,s3,pdfVec);
					Probabilities.TriangularCDF(xVec,s1,s2,s3,cdfVec);
				}
			} else if (radioButton22.Checked) { // Uniform - continous
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.UniformPDF(s3,s1,s2);
				RCDF = Probabilities.UniformCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(s1,(s2-s1)*0.01);
					Probabilities.UniformPDF(xVec,s1,s2,pdfVec);
					Probabilities.UniformCDF(xVec,s1,s2,cdfVec);
				}

			} else if (radioButton23.Checked) { // Uniform - discrete
				i1 = Int32.Parse(textBox1.Text); // N
				s1 = Double.Parse(textBox2.Text); // x
				RPDF = Probabilities.UniformDPDF(s1,i1);
				RCDF = Probabilities.UniformDCDF(s1,i1);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(1,i1*0.01);
					Probabilities.UniformDPDF(xVec,i1,pdfVec);
					Probabilities.UniformDCDF(xVec,i1,cdfVec);
				}
			} else if (radioButton24.Checked) { // Weibull
				s1 = Double.Parse(textBox1.Text); // a
				s2 = Double.Parse(textBox2.Text); // b
				s3 = Double.Parse(textBox3.Text); // x
				RPDF = Probabilities.WeibullPDF(s3,s1,s2);
				RCDF = Probabilities.WeibullCDF(s3,s1,s2);
				if (checkBox1.Checked) {
															 
					xVec.Ramp(0.02,0.1);
					Probabilities.WeibullPDF(xVec,s1,s2,pdfVec);
					Probabilities.WeibullCDF(xVec,s1,s2,cdfVec);
				}
			}
			#endregion 
			textBox5.Text = RPDF.ToString("F",format);
			textBox6.Text = RCDF.ToString("F",format);
			if (checkBox1.Checked) {
				MtxVecTee.DrawValues(xVec, pdfVec,series1,false);
				MtxVecTee.DrawValues(xVec, cdfVec,series2,false);
			}
		}

		private void button2_Click(object sender, System.EventArgs e) {
			double s1,s2,s3;
			int i1,i2,i3;
			double x;
			double p = Double.Parse(textBox6.Text);
			if (radioButton1.Checked) { //BETA
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.BetaCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton2.Checked) { // Binomial
          i1 = Int32.Parse(textBox1.Text); // N
          s1 = Double.Parse(textBox2.Text); // p
          x = Probabilities.BinomCDFInv(p,i1,s1);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton3.Checked) { // Cauchy
          s1 = Double.Parse(textBox1.Text); // b
          s2 = Double.Parse(textBox2.Text); // m
          x = Probabilities.CauchyCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton4.Checked) { // CHI2
          s1 = Double.Parse(textBox1.Text); // Nu
          x = Probabilities.ChiSquareCDFInv(p,(int)s1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton5.Checked) { // Exponential
          s1 = Double.Parse(textBox1.Text); // Mu
          x = Probabilities.ExpCDFInv(p,s1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton6.Checked) { // F - Fisher
          i1 = Int32.Parse(textBox1.Text); // Nu1
          i2 = Int32.Parse(textBox2.Text); // Nu2
          x = Probabilities.FCDFInv(p,i1,i2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton7.Checked) { // GAMMA
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.GammaCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton8.Checked) { // Geometric
          s1 = Double.Parse(textBox1.Text); // p
          x = Probabilities.GeometricCDFInv(p,s1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton9.Checked) { // Hypergeometric
          i1 = Int32.Parse(textBox1.Text); //M
          i2 = Int32.Parse(textBox2.Text); //K
          i3 = Int32.Parse(textBox3.Text); //N
          x = Probabilities.HypGeometricCDFInv(p,i1,i2,i3);
          textBox4.Text = x.ToString("F",format);
			} else if (radioButton10.Checked) { // Laplace
          s1 = Double.Parse(textBox1.Text); // m
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.LaplaceCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton11.Checked) { // Logistic
          s1 = Double.Parse(textBox1.Text); // m
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.LogisticCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton12.Checked) { // log-normal
          s1 = Double.Parse(textBox1.Text); // mu
          s2 = Double.Parse(textBox2.Text); // sigma
          x = Probabilities.LogNormalCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton13.Checked) { // log-Weibull
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.LogWeibullCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton14.Checked) { // Maxwell
          s1 = Double.Parse(textBox1.Text); // a
          x = Probabilities.MaxwellCDFInv(p,s1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton15.Checked) { // Negative binomial
          i1 = Int32.Parse(textBox1.Text); //R
          s1 = Double.Parse(textBox2.Text); // p
          x = Probabilities.NegBinomCDFInv(p,i1,s1);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton16.Checked) { // Normal
          s1 = Double.Parse(textBox1.Text); // mu
          s2 = Double.Parse(textBox2.Text); // sigma
          x = Probabilities.NormalCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton17.Checked) { // Pareto
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.ParetoCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton18.Checked) { // Poisson
          s1 = Double.Parse(textBox1.Text); // lambda
          x = Probabilities.PoissonCDFInv(p,s1);
          textBox2.Text = ((int)x).ToString();
			} else if (radioButton19.Checked) { // Student
          i1 = Int32.Parse(textBox1.Text); // NU
          x = Probabilities.StudentCDFInv(p,i1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton20.Checked) { // Rayleigh
          s1 = Double.Parse(textBox1.Text); // lambda
          x = Probabilities.RayleighCDFInv(p,s1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton21.Checked) { // Hypergeometric
          s1 = Double.Parse(textBox1.Text); //a
          s2 = Double.Parse(textBox2.Text); //b
          s3 = Double.Parse(textBox3.Text); //c
          x = Probabilities.TriangularCDFInv(p,s1,s2,s3);
          textBox4.Text = x.ToString("F",format);
			} else if (radioButton22.Checked) { // Uniform - continous
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.UniformCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			} else if (radioButton23.Checked) { // Uniform - discrete
          i1 = Int32.Parse(textBox1.Text); // N
          x = Probabilities.UniformDCDFInv(p,i1);
          textBox2.Text = x.ToString("F",format);
			} else if (radioButton24.Checked) { // Weibull
          s1 = Double.Parse(textBox1.Text); // a
          s2 = Double.Parse(textBox2.Text); // b
          x = Probabilities.WeibullCDFInv(p,s1,s2);
          textBox3.Text = x.ToString("F",format);
			}
		}
	}
}

